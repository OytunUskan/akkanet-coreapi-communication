using System;
using Akka.Actor;

namespace Demo.AkkaNet.Core.Common
{
    public class CalculatorActor : ReceiveActor
    {
        public CalculatorActor()
        {
            Receive<AddMessage>(add =>
            {
                Console.WriteLine($"{DateTime.Now}: Sum {add.Term1} + {add.Term2}");
                Sender.Tell(new AnswerMessage(add.Term1 + add.Term2));
            });
        }
    }
}