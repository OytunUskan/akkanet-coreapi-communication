using System;
using Akka.Actor;
using Demo.AkkaNet.Core.Common;

namespace Demo.AkkaNet.Server.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.Title = "Akka Server";
            var hocon = HoconLoader.FromFile("akka.net.hocon");
            ActorSystem system = ActorSystem.Create("akka-server-system", hocon);
            system.ActorOf<AkkaServerActor>("AkkaServer");
            System.Console.WriteLine("Akka.Net Server started..");
            System.Console.WriteLine();
            System.Console.WriteLine();
            System.Console.Read();
            system.Terminate().Wait();
        }
    }
}
