using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCPsocket通讯
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        Socket socketClient = null;
        Thread threadClient = null;
        private bool IsRunning = true;
        private void btn_Connect_Click(object sender, EventArgs e)
        {
            socketClient = new Socket( AddressFamily.InterNetwork, SocketType.Stream,ProtocolType.Tcp);
            IPAddress iPAddress = IPAddress.Parse(txt_IP.Text.Trim());
            IPEndPoint iPEndPoint = new IPEndPoint(iPAddress,int.Parse(txt_Port.Text.Trim()));
            
            try
            {
                this.txt_Rev.AppendText("与服务器连接中。。。"+ Environment.NewLine);
                socketClient.Connect(iPEndPoint);
            }
            catch (Exception )
            {

                MessageBox.Show("连接失败");
                return;
            }
            this.txt_Rev.AppendText("连接成功");
            threadClient = new Thread(RecieveMsg);
            threadClient.IsBackground = true;
            threadClient.Start();
        }

        private void RecieveMsg()
        {
            while (IsRunning)
            {
                byte[] arrMsgRec = new byte [1024*1024*2];
                int length = -1;
                try
                {
                    length = socketClient.Receive(arrMsgRec);
                }
                catch (SocketException)
                {

                    break;
                }
                catch (Exception )
                {
                    Invoke(new Action (()=> this.txt_Rev.AppendText("断开连接"+Environment.NewLine)));
                }
              
                if (length == 0)
                {
                    Invoke(new Action(() => this.txt_Rev.AppendText("断开连接")));
                   
                    break;
                }
                else
                {
                    string strMsg = Encoding.UTF8.GetString(arrMsgRec,0,length);
                    string Msg = "[接收  ]" + strMsg + Environment.NewLine;
                    Invoke(new Action(()=>this.txt_Rev.AppendText(Msg)));
                }
            }
        }

        private void btn_Send_Click(object sender, EventArgs e)
        {
            string strMsg ="来自"+ this.txt_Name.Text.Trim()+ txt_Send.Text.Trim();
            byte[] arrMsg = Encoding.UTF8.GetBytes(strMsg);
            socketClient.Send(arrMsg);
            Invoke(new Action(()=>this.txt_Rev.AppendText("[发送]"+ this.txt_Send.Text.Trim()+Environment.NewLine)));
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            IsRunning = false;
            socketClient?.Close();
        }
    }
}
