using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatisticsHub.API.Models;

namespace StatisticsHub.API.Interface
{
    public interface ITeamRepository
    {
        List<Team> Retrieve();
        Team Save(int id, Team team);
    }
}
