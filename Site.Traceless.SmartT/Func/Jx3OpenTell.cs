using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Site.Traceless.SmartT.Func
{
    public class Jx3OpenTell
    {
        public static bool Ping(string ip)
        {
            Ping ping = new Ping();
            PingOptions pingOptions = new PingOptions()
            {
                DontFragment = true
            };
            string s = "Test Data!";
            byte[] bytes = Encoding.ASCII.GetBytes(s);
            int timeout = 1000;
            PingReply pingReply = ping.Send(ip, timeout, bytes, pingOptions);
            return pingReply.Status == IPStatus.Success;
        }

        public static bool IsOpen(string ip, int port)
        {
            bool flag = !string.IsNullOrEmpty(ip);
            bool result;
            if (flag)
            {
                IPAddress address = IPAddress.Parse(ip);
                IPEndPoint remoteEP = new IPEndPoint(address, port);
                try
                {
                    TcpClient tcpClient = new TcpClient();
                    tcpClient.Connect(remoteEP);
                    result = true;
                    return result;
                }
                catch
                {
                    result = false;
                    return result;
                }
            }
            result = false;
            return result;
        }

        public static string[] GetSerIni()
        {
            Encoding encoding = Encoding.GetEncoding("GB2312");
            return File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "serverlist.ini"), encoding);
        }

        public static string[,] GetSerList()
        {
            string[] serIni = Jx3OpenTell.GetSerIni();
            string[,] array = new string[serIni.Length, 5];
            string[] array2 = new string[5];
            int num = 0;
            string[] array3 = serIni;
            for (int i = 0; i < array3.Length; i++)
            {
                string text = array3[i];
                array2 = text.Split(new char[]
                {
                    '\t'
                });
                array[num, 0] = array2[0];
                array[num, 1] = array2[1];
                array[num, 2] = array2[3];
                array[num, 3] = "0";
                array[num, 4] = "List";
                num++;
            }
            return array;
        }
    }
}
