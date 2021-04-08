using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UDPClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string sendString = null;//要发送的字符串 
            byte[] sendData = null;//要发送的字节数组 
            UdpClient client = null;

            IPAddress remoteIP = IPAddress.Parse("127.0.0.1");
            int remotePort = 11000;
            IPEndPoint remotePoint = new IPEndPoint(remoteIP, remotePort);//实例化一个远程端点 

            while (true)
            {
                sendString = Console.ReadLine();
                sendData = Encoding.Default.GetBytes(sendString);

                client = new UdpClient();
                client.Send(sendData, sendData.Length, remotePoint);//将数据发送到远程端点 
                client.Close();//关闭连接 
            }
        }
    }
}
