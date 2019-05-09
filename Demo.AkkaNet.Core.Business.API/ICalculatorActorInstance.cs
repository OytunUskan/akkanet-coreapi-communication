using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.AkkaNet.Core.Common;

namespace Demo.AkkaNet.Core.Business.API
{
   
    public interface ICalculatorActorInstance
    {
        Task<AnswerMessage> Sum(AddMessage message);
    }
}
