using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using System.Web.Http.OData; //using System.Web.OData; This will cause EnableQuery() to act up, not sure why
using System.Web.Http.OData.Query;
using StatisticsHub.API.Models;

namespace StatisticsHub.API.Controllers
{
    //allow all types of clients to call into our API
    [EnableCorsAttribute("*", "*", "*")]
    public class TeamsController : ApiController
    {

        // returns a maximum of 100 rows and limits query options to select, top , filter, and orderby
        [EnableQuery(PageSize=100, AllowedQueryOptions=AllowedQueryOptions.Select | AllowedQueryOptions.Top | AllowedQueryOptions.Filter | AllowedQueryOptions.OrderBy)] 
        [ResponseType(typeof(Team))]
        public IHttpActionResult Get()
        {
            try
            {
                var teamRepository = new TeamRepository();
                return Ok(teamRepository.Retrieve().AsQueryable());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        [ResponseType(typeof(Team))]
        public IHttpActionResult Get(int id)
        {
            try
            {
                Team team = null;
                var teamRepository = new TeamRepository();

                if (id > 0)
                {
                    var teams = teamRepository.Retrieve();
                    team = teams.FirstOrDefault(t => t.ID == id);

                    if (team == null)
                    {
                        return NotFound();
                    }
                }

                return Ok(team);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }


        //GET api/teams?search=(searchword) or api/teams/(searchword)
        [ResponseType(typeof(Team))]
        public IHttpActionResult Get(string search)
        {
            try
            {
                var teamRepository = new TeamRepository();
                var teams = teamRepository.Retrieve();

                var  updatedTeam = teams.Where(t => t.Team_ID.Contains(search)) as Team;

                if (updatedTeam == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(updatedTeam);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        // POST api/teams
        [ResponseType(typeof(Team))]
        public IHttpActionResult Post([FromBody]Team team)
        {
            try
            {
                if (team == null) return BadRequest("Team can't be null");
                if (!ModelState.IsValid) return BadRequest(ModelState);

                var teamRepository = new TeamRepository();
                var updatedTeam = teamRepository.Save(team) as Team;

                if (updatedTeam == null) return Conflict();


                return Created<Team>(Request.RequestUri + updatedTeam.ID.ToString(), updatedTeam);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        // PUT api/teams/5
        [ResponseType(typeof(Team))]
        public IHttpActionResult Put(int id, [FromBody]Team team)
        {
            try
            {
                if (team == null) return BadRequest("Team can't be null");
                if (!ModelState.IsValid) return BadRequest(ModelState);

                var teamRepository = new TeamRepository();
                var updatedTeam = teamRepository.Save(id, team) as Team;

                if (updatedTeam == null) return NotFound();

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }
    }
}
