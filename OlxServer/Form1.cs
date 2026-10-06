using System.Net;
using System.Net.Sockets;

namespace OlxServer
{
    public partial class Form1 : Form
    {
        TcpListener? server;
        private readonly bool isRunning = false;

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

                while (isRunning)
                {
                    Models.Message data = ReceiveMessage(ns);
                    if (data == null)
                        break;

                    switch (data.Name)
                    {
                        case "User":

                            Models.User user = new()
                            {
                                // Id =
                                // Name =
                                // Password =
                                // RegisteredAT =
                            };

                            break;

                        case "Product":

                            Models.Product product = new()
                            {
                                // Id =
                                // ProductName =
                                // Description =
                                // Price =
                                // SellerId =
                                // Unit =
                                // Status =
                            };

                            break;
                    }
                }
            }
            catch { }
        }

        private Models.Message ReceiveMessage(NetworkStream ns)
        {
            throw new NotImplementedException();
        }
    }
}