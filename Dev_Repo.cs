using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// namespace Komodo
// {
    public class Dev_Repo
    {
        private List<Developer> _listOfDevs = new List<Developer>();
        //Create
        public void AddDevToList(Developer developer)
        {
            _listOfDevs.Add(developer);
        }
        //Read
        public List<Developer> GetDevList()
        {
            return _listOfDevs;
        }
        //Update
        public bool UpdateDevList(int original, Developer newInfo)
        {
            Developer oldInfo = GetDevById(original);
            if (oldInfo != null)
            {
                oldInfo.FirstName = newInfo.FirstName;
                oldInfo.LastName = newInfo.LastName;
                oldInfo.IdNumber = newInfo.IdNumber;
                oldInfo.PluralAccess = newInfo.PluralAccess;
                return true;
            }
            else
            {
                return false;
            }
        }
        //Delete
        public bool RemoveDevFromList(int idNumber)
        {
            Developer idNum = GetDevById(idNumber);
            if (idNum == null)
            {
            return false;
            }
            int initialCount = _listOfDevs.Count;
            _listOfDevs.Remove(idNum);
            if (initialCount > _listOfDevs.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Developer GetDevById(int idNumber)
        {
            foreach (Developer developer in _listOfDevs)
            {
                if (developer.IdNumber == idNumber)
                {
                    return developer;
                }
                
            }
            return null;
        }
        public bool VerifyDevExists(int idNumber)
    {
        return (GetDevById(idNumber) != null);
    }
    }
// }