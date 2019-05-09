using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Akka.Actor;
using Demo.AkkaNet.Core.Common;
using Microsoft.AspNetCore.Mvc;

namespace Demo.AkkaNet.Core.AVS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        //private readonly IMessageActorInstance messageActorInstance;

        //public ValuesController(IMessageActorInstance _messageActorInstance)
        //{
        //    messageActorInstance = _messageActorInstance;
        //}

        private readonly ActorSystem akkaActorSystem;

        public ValuesController(ActorSystem _akkaActorSystem)
        {
            this.akkaActorSystem = _akkaActorSystem;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            //var retVal = messageActorInstance.SaySometing(new RequestMessage("Hello World"));
            var avsClient = akkaActorSystem.ActorOf(Props.Create<AkkaClientActor>());
            avsClient.Tell(new SayRequest()
            {
                Username = "Avs API",
                Text = "api/values calls"
            });
            
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
