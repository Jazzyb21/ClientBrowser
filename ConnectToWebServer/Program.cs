using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace ConnectToWebServer
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new TcpClient();

            const int MAXBUF = 4096;
            const string IP = "127.0.0.1";
            const int PORT = 8080;
            string command = "GET";
            string operand = "index.html";
            

            Console.WriteLine("Client Started");
            IPAddress addr = IPAddress.Parse(IP);
            client.Connect(addr, PORT);
            var stream = client.GetStream();
            string s = command + " " + operand + " HTTP/1.1\n";
            stream.Write(Encoding.ASCII.GetBytes(s, 0, s.Length), 0, s.Length);
            byte[] buffer = new byte[MAXBUF];
            NetworkStream clientstream = client.GetStream();
            int iLen = clientstream.Read(buffer, 0, MAXBUF);
            string request = Encoding.ASCII.GetString(buffer);
            request = request.Substring(0, iLen);
            request = request.Trim();

            Console.WriteLine($"{DateTime.Now} Received: {request}");

















        }
        }
    }
