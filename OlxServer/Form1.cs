using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OlxServer
{
    public partial class Form1 : Form
    {
        TcpListener? server;
        private readonly bool isRunning = false;
        private readonly ServerService serverService = new();

        public Form1()
        {
            InitializeComponent();
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            try
            {
                server = new TcpListener(
                    IPAddress.Parse(tbAddress.Text.Trim()),
                    Convert.ToInt32(tbPort.Text.Trim()));

                server.Start();

                Thread thread = new(Listen) { IsBackground = true };
                thread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to start the server: " + ex.Message);
            }
            finally
            {
                btStart.Enabled = false;
                tbAddress.Enabled = false;
                tbPort.Enabled = false;

                MessageBox.Show("Server started successfully!", "Success", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Listen()
        {
            try
            {
                while (isRunning && server != null)
                {
                    TcpClient client = server.AcceptTcpClient();
                    Thread thread = new(() => Dialog(client)) { IsBackground = true };
                    thread.Start();
                }
            }
            catch { }
        }

        private void Dialog(TcpClient client)
        {
            try
            {
                NetworkStream ns = client.GetStream();

                MessageBox.Show("Client connected"); // temp

                while (isRunning && client.Connected)
                {
                    Models.Message data = ReceiveMessage(ns);
                    if (data == null)
                        break;

                    switch (data.Name)
                    {
                        case "User":

                            Models.User user = JsonSerializer.Deserialize<Models.User>(data.Data);
                            if (user != null)
                            {
                                using (var db = new AppDbContext())
                                {
                                    db.Users.Add(user);
                                    db.SaveChanges();
                                }
                            }

                            break;

                        case "Product":

                            Models.Product product = JsonSerializer.Deserialize<Models.Product>(data.Data);
                            if (product != null)
                            {
                                using (var db = new AppDbContext())
                                {
                                    db.Products.Add(product);
                                    db.SaveChanges();
                                }
                            }

                            break;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Dialog: " + ex.Message);
            }
        }

        private Models.Message ReceiveMessage(NetworkStream ns)
        {
            try
            {
                byte[] lengthBytes = new byte[4];
                int bytesRead = ReadNecessaryBytes(ns, lengthBytes, 4);
                if (bytesRead == 0) return null;

                int jsonLength = BitConverter.ToInt32(lengthBytes, 0);
                byte[] bytes = new byte[jsonLength];
                bytesRead = ReadNecessaryBytes(ns, bytes, jsonLength);
                return JsonSerializer.Deserialize<Models.Message>(bytes);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Server ReceiveMessage: " + ex.Message);
                return null;
            }
        }

        private int ReadNecessaryBytes(NetworkStream ns, byte[] lengthBytes, int count)
        {
            int bytesRead = 0;
            while (bytesRead < count)
            {
                int read = ns.Read(lengthBytes, bytesRead, count - bytesRead);
                if (read == 0) break;
                bytesRead += read;
            }
            return bytesRead;
        }
    }
}