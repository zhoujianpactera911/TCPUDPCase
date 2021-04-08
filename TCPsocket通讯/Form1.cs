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
    public partial class Form1 : Form
    {
        delegate void AddOnlineDelegate(string  str ,bool bl);
        delegate void RecMegDelegate(string str);
        Dictionary<string, Socket> DicSocket = new Dictionary<string, Socket>();
        public Form1()
        {
            InitializeComponent();
            myAddOnlineDelegate = AddOnline;
            myRecMegDelegate = AddRecMsg;
        }
        Socket socket = null;
        Thread threadListen = null;
        AddOnlineDelegate myAddOnlineDelegate;
        RecMegDelegate myRecMegDelegate;
        private void btn_StartServer_Click(object sender, EventArgs e)
        {
            #region 第一步获取IP和端口进行相互通信
            //实例化Socket
            socket = new Socket( AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //获取IP
            IPAddress iPAddress = IPAddress.Parse(txt_IP.Text.Trim());
            //把IP和端口号放在IPEndPoint中
            IPEndPoint iPEndPoint = new IPEndPoint(iPAddress,int.Parse(txt_Port.Text.Trim()));
            try
            {
                //和socket进行关联
                socket.Bind(iPEndPoint);
                MessageBox.Show("服务开启成功" );
            }
            catch (Exception ex)
            {
                //失败了直接return出去
                MessageBox.Show("服务开启失败"+ex);
                return;
            }
            //socket可以对多少个客户端进行监视
            socket.Listen(10);
            #endregion
            #region 第二部开启多线程
            //开始进行多线程操作 开始执行此线程时要调用的方法的
            threadListen = new Thread(ListenConnecting1);
            //此线程则为后台线程
            threadListen.IsBackground=true;
            //启动线程
            threadListen.Start(); 
            //连接到服务器后把按钮禁用掉
            btn_StartServer.Enabled = false;
            #endregion
        }

        /// <summary>
        /// 正在进行的后台线程的方法
        /// </summary>
        private void ListenConnecting1()
        {
            //线程使用时进行循环
            while (true)
            {
                //创建一个新的Socket 列:如果有一个新的客户端来连接服务器给他一个Socket
                Socket socketClient = socket.Accept();
                //把谁连接的客户端给到skt中 字符串
                string skt = socketClient.RemoteEndPoint.ToString();
                DicSocket.Add(skt,socketClient);
                Invoke(myAddOnlineDelegate, skt,true);
                 
                //更新设备列表 需要接受来自不同客户端的消息 接着在开一个线程 
                Thread thr = new Thread(RecieveMsg); 
                thr.IsBackground = true;
                thr.Start(socketClient);
            }

        }

        /// <summary>
        /// 开的发送接受的线程 直接从上面传递过来参数 vs中没显示用什么类型的 视频中vs显示可以使用object类型 所有类型的基类来展示 带参的
        /// </summary>
        /// <param name="socketConnect"></param>
        private void RecieveMsg(object socketClient)
        {
            //as：转换强转 把object转换成Socket
            Socket scketClient = socketClient as Socket;
            while (true)
            {
                byte[] arrMsgRec = new byte[1024 * 1024 * 2];
                int length = -1;
                try
                {
                    length = scketClient.Receive(arrMsgRec);

                }
                catch (Exception)
                {

                    string str = scketClient.RemoteEndPoint.ToString();
                    Invoke(myRecMegDelegate, str + "下线了");
                    Invoke(myAddOnlineDelegate,str,false);
                    DicSocket.Remove(str);
                    break;
                }
               
                if (length == 0)
                {
                    //如果字节数没有的话把client移除掉
                    string str = scketClient.RemoteEndPoint.ToString();
                    //引用的委托
                    Invoke(myAddOnlineDelegate, str, false) ;
                    DicSocket.Remove(str);
                    break;
                }
                else
                {
                    //如果成功把接受的byte转换成string
                    string strMsg = Encoding.UTF8.GetString(arrMsgRec,0, length);
                    Invoke(myRecMegDelegate , strMsg+ Environment.NewLine);
                }
            }
        }
        #region 委托更新UI
        private void AddOnline(string str,bool bl)
        {
            if (bl)
            {
                //如果是true的话对listbox.Item进行一个添加
                txt_Online.Items.Add(str);
            }
            else
            {
                //反之删除
                txt_Online.Items.Remove(str);
            }
            
        }
        private void AddRecMsg(string str)
        {
            //将文字追加到文本中
            txt_Rcv.AppendText(str);
        }
        #endregion

        /// <summary>
        /// 发送消息  只能发送字节流
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SendToSingle_Click(object sender, EventArgs e)
        {
            string StrMsg = this.txt_Send.Text.Trim();
            byte[] arrMsg = Encoding.UTF8.GetBytes(StrMsg);
            if (this.txt_Online.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择要发送的对象");
                return;
            }
            else
            {
                foreach (String item in this.txt_Online.SelectedItems)
                {
                    //send发送到指定的socket中
                    DicSocket[item].Send(arrMsg);
                    string Msg = "[发送]  " + item + "   " + StrMsg;
                    //使用一个委托直接写入
                    Invoke(myRecMegDelegate,Msg+Environment.NewLine);
                }
            }
        }

        private void OpenClient_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }
    }
}
