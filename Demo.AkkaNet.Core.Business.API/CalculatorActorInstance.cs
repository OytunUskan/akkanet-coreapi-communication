using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Akka.Actor;
using Demo.AkkaNet.Core.Common;

namespace Demo.AkkaNet.Core.Business.API
{
    public class CalculatorActorInstance : ICalculatorActorInstance
    {
        private IActorRef _actor;
        public CalculatorActorInstance(ActorSystem actorSystem)
        {
            _actor = actorSystem.ActorOf(Props.Create<CalculatorActor>(), "calculator");
        }
        public async Task<AnswerMessage> Sum(AddMessage message)
        {
            return await _actor.Ask<AnswerMessage>(message);
        }
    }
}
