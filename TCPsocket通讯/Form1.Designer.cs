namespace TCPsocket通讯
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_IP = new System.Windows.Forms.TextBox();
            this.txt_Port = new System.Windows.Forms.TextBox();
            this.txt_Online = new System.Windows.Forms.ListBox();
            this.txt_Rcv = new System.Windows.Forms.TextBox();
            this.btn_StartServer = new System.Windows.Forms.Button();
            this.btn_SendToSingle = new System.Windows.Forms.Button();
            this.txt_Send = new System.Windows.Forms.TextBox();
            this.OpenClient = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(245, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP地址：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(246, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "端口号：";
            // 
            // txt_IP
            // 
            this.txt_IP.Location = new System.Drawing.Point(328, 38);
            this.txt_IP.Name = "txt_IP";
            this.txt_IP.Size = new System.Drawing.Size(120, 21);
            this.txt_IP.TabIndex = 1;
            // 
            // txt_Port
            // 
            this.txt_Port.Location = new System.Drawing.Point(328, 78);
            this.txt_Port.Name = "txt_Port";
            this.txt_Port.Size = new System.Drawing.Size(120, 21);
            this.txt_Port.TabIndex = 1;
            // 
            // txt_Online
            // 
            this.txt_Online.FormattingEnabled = true;
            this.txt_Online.ItemHeight = 12;
            this.txt_Online.Location = new System.Drawing.Point(248, 117);
            this.txt_Online.Name = "txt_Online";
            this.txt_Online.Size = new System.Drawing.Size(208, 136);
            this.txt_Online.TabIndex = 2;
            // 
            // txt_Rcv
            // 
            this.txt_Rcv.Location = new System.Drawing.Point(31, 38);
            this.txt_Rcv.Multiline = true;
            this.txt_Rcv.Name = "txt_Rcv";
            this.txt_Rcv.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_Rcv.Size = new System.Drawing.Size(197, 254);
            this.txt_Rcv.TabIndex = 3;
            // 
            // btn_StartServer
            // 
            this.btn_StartServer.Location = new System.Drawing.Point(265, 268);
            this.btn_StartServer.Name = "btn_StartServer";
            this.btn_StartServer.Size = new System.Drawing.Size(173, 23);
            this.btn_StartServer.TabIndex = 4;
            this.btn_StartServer.Text = "开启服务";
            this.btn_StartServer.UseVisualStyleBackColor = true;
            this.btn_StartServer.Click += new System.EventHandler(this.btn_StartServer_Click);
            // 
            // btn_SendToSingle
            // 
            this.btn_SendToSingle.Location = new System.Drawing.Point(265, 310);
            this.btn_SendToSingle.Name = "btn_SendToSingle";
            this.btn_SendToSingle.Size = new System.Drawing.Size(173, 23);
            this.btn_SendToSingle.TabIndex = 5;
            this.btn_SendToSingle.Text = "发送消息";
            this.btn_SendToSingle.UseVisualStyleBackColor = true;
            this.btn_SendToSingle.Click += new System.EventHandler(this.btn_SendToSingle_Click);
            // 
            // txt_Send
            // 
            this.txt_Send.Location = new System.Drawing.Point(31, 310);
            this.txt_Send.Multiline = true;
            this.txt_Send.Name = "txt_Send";
            this.txt_Send.Size = new System.Drawing.Size(197, 81);
            this.txt_Send.TabIndex = 6;
            // 
            // OpenClient
            // 
            this.OpenClient.Location = new System.Drawing.Point(265, 351);
            this.OpenClient.Name = "OpenClient";
            this.OpenClient.Size = new System.Drawing.Size(173, 23);
            this.OpenClient.TabIndex = 7;
            this.OpenClient.Text = "打开客户端";
            this.OpenClient.UseVisualStyleBackColor = true;
            this.OpenClient.Click += new System.EventHandler(this.OpenClient_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 447);
            this.Controls.Add(this.OpenClient);
            this.Controls.Add(this.txt_Send);
            this.Controls.Add(this.btn_SendToSingle);
            this.Controls.Add(this.btn_StartServer);
            this.Controls.Add(this.txt_Rcv);
            this.Controls.Add(this.txt_Online);
            this.Controls.Add(this.txt_Port);
            this.Controls.Add(this.txt_IP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TCP通讯服务器";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_IP;
        private System.Windows.Forms.TextBox txt_Port;
        private System.Windows.Forms.ListBox txt_Online;
        private System.Windows.Forms.TextBox txt_Rcv;
        private System.Windows.Forms.Button btn_StartServer;
        private System.Windows.Forms.Button btn_SendToSingle;
        private System.Windows.Forms.TextBox txt_Send;
        private System.Windows.Forms.Button OpenClient;
    }
}

