using System;
using Akka.Actor;
using Demo.AkkaNet.Core.Common;

namespace Demo.AkkaNet.Core.Business.API
{
    public class AkkaClientActor : TypedActor,
        IHandle<ConnectRequest>,
        IHandle<ConnectResponse>,
        IHandle<SayRequest>,
        IHandle<SayResponse>,
        IHandle<Terminated>, ILogReceive
    {
        private string clientName = "Business API";

        private readonly ActorSelection _server = Context.ActorSelection("akka.tcp://akka-server-system@localhost:8081/user/AkkaServer");

        public void Handle(ConnectResponse message)
        {
            Console.WriteLine("Connected!");
            Console.WriteLine(message.Message);
        }       

        public void Handle(SayResponse message)
        {
            Console.WriteLine("Akka .NET server said => {0} : {1}", message.Username, message.Text);
        }

        public void Handle(ConnectRequest message)
        {
            Console.WriteLine("Connecting....");
            _server.Tell(message);
        }

        public void Handle(SayRequest message)
        {
            message.Username = this.clientName;
            _server.Tell(message);
        }

        public void Handle(Terminated message)
        {
            Console.Write("Server died");
        }
    }
}
