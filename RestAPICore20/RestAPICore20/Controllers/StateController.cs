using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;
using RestAPICore20.Models;
using RestAPICore20.Models.Interfaces;

namespace RestAPICore20.Controllers
{
    [Route("api/[controller]")]
    public class StateController : Controller
    {

        private readonly IStatable Statable;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stateble"></param>
        public StateController(IStatable statable)
        {
            this.Statable = statable;
        }

        // GET api/state/5
        [HttpGet("{id}")]
        [Produces("application/json")]
        public StateModel Get(Guid id)
        {
            return this.Statable.ReadState(id);
        }

        // POST api/state
        [HttpPost]
        [Produces("application/json")]
        public bool Post([FromBody]StateModel stateValue)
        {
            if (stateValue == null) return false;
            return this.Statable.SaveState(stateValue);
        }

        // GET api/state
        [HttpGet()]
        [Produces("application/json")]
        public IReadOnlyCollection<StateModel> Get()
        {
            return this.Statable.ReadAll();
        }

    }
}
