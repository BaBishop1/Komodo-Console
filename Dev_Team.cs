using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// namespace Komodo
// {
    public class Dev_Team
    {
        public string TeamName { get; set; }
        public int TeamId { get; set; }
        public List<Developer> DevsOnTeam { get; set; } = new List<Developer>();

        public Dev_Team(){}
        public Dev_Team(string teamName, int teamId, List<Developer> devsOnTeam)
        {
            TeamName = teamName;
            TeamId = teamId;
            DevsOnTeam = devsOnTeam;
        }
        public Dev_Team(string teamName, int teamId)
        {
            TeamName = teamName;
            TeamId = teamId;
        }
        public void AddDevToTeam(Developer dev)
        {
            this.DevsOnTeam.Add(dev);
        }
        public void RemoveDevFromTeam(Developer dev)
        {
            this.DevsOnTeam.Remove(dev);
        }
    }
// }