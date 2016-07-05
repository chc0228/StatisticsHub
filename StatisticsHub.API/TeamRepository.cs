using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using Newtonsoft.Json;
using StatisticsHub.API.Interface;
using StatisticsHub.API.Models;

namespace StatisticsHub.API
{
    public class TeamRepository : ITeamRepository
    {
        public List<Team> Retrieve()
        {
            var filePath = HostingEnvironment.MapPath(@"~/App_Data/teams.json");
            var json = File.ReadAllText(filePath);
            var teams = JsonConvert.DeserializeObject<List<Team>>(json);

            return teams;
        }

        public Team Save(int id, Team team)
        {
            var teams = this.Retrieve();

            var itemIndex = teams.FindIndex(t => t.ID == team.ID);

            if (itemIndex > 0)
            {
                teams[itemIndex] = team;
            }
            else
            {
                return null;
            }

            WriteData(teams);
            return team;
        }

        public Team Save(Team team)
        {
            var teams = this.Retrieve();

            var maxID = teams.Max(t => t.ID);
            team.ID = maxID + 1;
            teams.Add(team);

            WriteData(teams);
            return team;
        }

        private void WriteData(List<Team> teams)
        {
            var filePath = HostingEnvironment.MapPath(@"~/App_Data/teams.json");

            var json = JsonConvert.SerializeObject(teams, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

    }
}