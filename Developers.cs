using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// namespace Komodo
// {
    public class Developer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int IdNumber { get; set; }
        public bool PluralAccess { get; set; }

        public Developer() {}
        public Developer (string firstName, string lastName, int idNumber, bool pluralAccess)
        {
            FirstName = firstName;
            LastName = lastName;
            IdNumber = idNumber;
            PluralAccess = pluralAccess;
        }
    }
// }