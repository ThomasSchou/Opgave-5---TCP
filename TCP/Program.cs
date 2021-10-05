using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using System.Threading.Tasks;
using TCP.Managers;
using TCP.Models;

namespace TCP
{
    class Program
    {
        
        static void Main(string[] args)
        {
            
            Console.WriteLine("Server ready");

            TcpListener listener = new TcpListener(IPAddress.Any, 2121);
            listener.Start();

            while (true)
            {
                TcpClient socket = listener.AcceptTcpClient();
                Console.WriteLine("New client");

                Task.Run(() =>
                {
                    HandleClient(socket);
                });
            }
        }

        private static void HandleClient(TcpClient socket)
        {
            FootBallPlayerManager _manager = new FootBallPlayerManager();
            NetworkStream ns = socket.GetStream();
            StreamReader reader = new StreamReader(ns);
            StreamWriter writer = new StreamWriter(ns);
            string message = reader.ReadLine();

            switch (message.Split(' ')[0].ToLower())
            {
                case "hent":
                    int number;

                    bool successParse = int.TryParse(message.Split(' ')[1], out number);
                    if (successParse)
                    {
                        writer.WriteLine(JsonSerializer.Serialize(_manager.GetPlayerByID(number)));
                    }
                    else
                    {
                        writer.WriteLine(JsonSerializer.Serialize(_manager.GetAllPlayers()));
                    }
                    writer.Flush();
                    break;

                case "gem":
                    string json = message.Substring(message.LastIndexOf('{'));
                    writer.WriteLine("json recieved: " + json);
                    _manager.AddPlayer(JsonSerializer.Deserialize<FootBallPlayer>(json));
                    writer.Flush();
                    break;

                default:
                    writer.WriteLine("Unknown command");
                    writer.Flush();
                    break;
            }

            socket.Close();
        }
    }
}
