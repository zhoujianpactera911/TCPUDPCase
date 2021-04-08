using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCPSever
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient client = null;
            NetworkStream stream = null;
            byte[] buffer = null;
            string receiveString = null;

            IPAddress localIP = IPAddress.Parse("127.0.0.1");
            int localPort = 11000;
            TcpListener listener = new TcpListener(localIP, localPort);//用本地IP和端口实例化Listener 
            listener.Start();//开始监听 
            while (true)
            {
                client = listener.AcceptTcpClient();//接受一个Client 
                buffer = new byte[client.ReceiveBufferSize];
                stream = client.GetStream();//获取网络流 
                stream.Read(buffer, 0, buffer.Length);//读取网络流中的数据 
                stream.Close();//关闭流 
                client.Close();//关闭Client 

                receiveString = Encoding.Default.GetString(buffer).Trim('\0');//转换成字符串 
                Console.WriteLine(receiveString);
            }
        }
    }
}
