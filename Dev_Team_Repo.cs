using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// namespace Komodo
// {
public class Dev_Team_Repo
{
    public List<Dev_Team> _listOfDevTeams = new List<Dev_Team>();
    

    //Create
    public void AddTeamToList(Dev_Team dev_Team)
    {
        _listOfDevTeams.Add(dev_Team);
    }

    //Read
    public List<Dev_Team> GetDevTeamList()
    {
        return _listOfDevTeams;
    }
    //Update
    public bool UpdateDevTeamList(int original, Dev_Team newInfo)
    {
        Dev_Team oldInfo = GetDevTeamById(original);
        if (oldInfo != null)
        {
            oldInfo.TeamId = newInfo.TeamId;
            oldInfo.TeamName = newInfo.TeamName;
            return true;
        }
        else
        {
            return false;
        }
    }
    //Delete
    public bool RemoveDevTeamFromList(int teamId)
    {
        Dev_Team idNum = GetDevTeamById(teamId);
        if (idNum == null)
        {
            return false;
        }
        int initialCount = _listOfDevTeams.Count;
        _listOfDevTeams.Remove(idNum);
        if (initialCount > _listOfDevTeams.Count)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public Dev_Team GetDevTeamById(int teamId)
    {
        foreach (Dev_Team devTeam in _listOfDevTeams)
        {
            if (devTeam.TeamId == teamId)
            {
                return devTeam;
            }

        }
        return null;
    }
    public bool VerifyTeamExists(int teamId)
    {
        return (GetDevTeamById(teamId) != null);
    }
    
}
// }