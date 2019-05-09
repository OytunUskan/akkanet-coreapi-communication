using System;
using System.Collections.Generic;
using System.Text;
using Akka.Actor;
using Demo.AkkaNet.Core.Common;

namespace Demo.AkkaNet.Server.Console
{
    public class AkkaServerActor : TypedActor,
        IHandle<SayRequest>,
        IHandle<ConnectRequest>,
        IHandle<Disconnect>,
        ILogReceive
    {

        private readonly HashSet<IActorRef> _clients = new HashSet<IActorRef>();

        public void Handle(ConnectRequest message)
        {
            System.Console.WriteLine("Client {0} has connected", message.Username);
            _clients.Add(this.Sender);
            Sender.Tell(new ConnectResponse
            {
                Message = "Hello and welcome to Akka .NET remote messaging example",
            }, Self);
        }

        public void Handle(Disconnect message)
        {
            System.Console.WriteLine("Client Disconnect happen!");
        }

        public void Handle(SayRequest message)
        {
            System.Console.WriteLine("Client {0} said : {1}", message.Username, message.Text);
            var response = new SayResponse
            {
                Username = message.Username,
                Text = message.Text,
            };
            foreach (var client in _clients)
            {
                client.Tell(response, Self);
            }
        }
    }
}
