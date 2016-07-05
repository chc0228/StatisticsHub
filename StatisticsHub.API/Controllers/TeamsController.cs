using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.OData; //using System.Web.OData; This will cause EnableQuery() to act up, not sure why
using System.Web.Http.OData.Query;
using StatisticsHub.API.Models;

namespace StatisticsHub.API.Controllers
{
    //allows all clients to call into our API
    [EnableCorsAttribute("*", "*", "*")]
    public class TeamsController : ApiController
    {

        // returns a maximum of 100 rows and limits query options to select, top , filter, and orderby
        [EnableQuery(PageSize=100, AllowedQueryOptions=AllowedQueryOptions.Select | AllowedQueryOptions.Top | AllowedQueryOptions.Filter | AllowedQueryOptions.OrderBy)] 
        public IQueryable<Team> Get()
        {
            var teamRepository = new TeamRepository();
            return teamRepository.Retrieve().AsQueryable();
        }

        public Team Get(int id)
        {
            Team team = null;
            var teamRepository = new TeamRepository();

            if (id > 0)
            {
                var teams = teamRepository.Retrieve();
                team = teams.FirstOrDefault(t => t.ID == id);
            }
            
            return team;
        }


        //GET api/teams?search=(searchword) or api/teams/(searchword)
        public IEnumerable<Team> Get(string search)
        {
            var teamRepository = new TeamRepository();
            var teams = teamRepository.Retrieve();
            return teams.Where(t => t.Team_ID.Contains(search));
        }

        // POST api/teams
        public Team Post([FromBody]Team team)
        {
            var teamRepository = new TeamRepository();
            var newTeam = teamRepository.Save(team);
            return newTeam;
        }

        // PUT api/teams/5
        public void Put(int id, [FromBody]Team team)
        {
            var teamRepository = new TeamRepository();
            teamRepository.Save(id, team);
        }

        // DELETE api/teams/5
        public void Delete(int id)
        {
        }
    }
}
