using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using StatisticsHub.API.Models;

namespace StatisticsHub.API.Controllers
{
    //allows all clients to call into our API
    [EnableCorsAttribute("*", "*", "*")]
    public class TeamsController : ApiController
    {
        // GET api/teams
        public IEnumerable<Team> Get()
        {
            var teamRepository = new TeamRepository();
            return teamRepository.Retrieve();
        }

        // GET api/teams/5
        public IEnumerable<Team> Get(string search)
        {
            var teamRepository = new TeamRepository();
            var teams = teamRepository.Retrieve();
            return teams.Where(t => t.Team_ID.Contains(search));
        }

        // POST api/teams
        public void Post([FromBody]string value)
        {
        }

        // PUT api/teams/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/teams/5
        public void Delete(int id)
        {
        }
    }
}
