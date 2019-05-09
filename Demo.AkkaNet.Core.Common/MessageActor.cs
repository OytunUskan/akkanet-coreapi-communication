using System;
using System.Collections.Generic;
using System.Text;
using Akka.Actor;

namespace Demo.AkkaNet.Core.Common
{
    public class MessageActor : ReceiveActor
    {

        public MessageActor()
        {
            Receive<RequestMessage>(add =>
            {
                Console.WriteLine($"{DateTime.Now}: {add.RequestSendMessage}");
                Sender.Tell(new ResponseMessage(add.RequestSendMessage));
            });
        }

    }
}
