namespace OlxServer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            btStart = new Button();
            label4 = new Label();
            tbPort = new TextBox();
            label3 = new Label();
            tbAddress = new TextBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btStart);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(tbPort);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(tbAddress);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(200, 132);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Connection";
            // 
            // btStart
            // 
            btStart.Location = new Point(6, 84);
            btStart.Name = "btStart";
            btStart.Size = new Size(188, 34);
            btStart.TabIndex = 7;
            btStart.Text = "Start Server";
            btStart.UseVisualStyleBackColor = true;
            btStart.Click += btStart_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 58);
            label4.Name = "label4";
            label4.Size = new Size(32, 15);
            label4.TabIndex = 8;
            label4.Text = "Port:";
            // 
            // tbPort
            // 
            tbPort.Location = new Point(57, 55);
            tbPort.Name = "tbPort";
            tbPort.Size = new Size(137, 23);
            tbPort.TabIndex = 9;
            tbPort.Text = "12000";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 28);
            label3.Name = "label3";
            label3.Size = new Size(45, 15);
            label3.TabIndex = 7;
            label3.Text = "Adress:";
            // 
            // tbAddress
            // 
            tbAddress.Location = new Point(57, 25);
            tbAddress.Name = "tbAddress";
            tbAddress.Size = new Size(137, 23);
            tbAddress.TabIndex = 7;
            tbAddress.Text = "127.0.0.1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(520, 260);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btStart;
        private Label label4;
        private TextBox tbPort;
        private Label label3;
        private TextBox tbAddress;
    }
}
