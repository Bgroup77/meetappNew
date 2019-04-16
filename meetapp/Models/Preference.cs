using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace meetapp.Models
{
    public class Preference
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        public string Type { get; set; }

        public Preference (string _name,int _weight, string _type)
        {
            Name = _name;
            Weight = _weight;
            Type = _type;
        }

        public Preference ()
        {
        }

        public List<Preference> ReadPreferences()
        {
            DBservices dbs = new DBservices();
            return dbs.ReadPreferences("ConnectionStringMeetapp", "preference");
        }

        //public int insertPreferencesPerMeetingPerParticipant()
        //{
        //    DBservices dbs = new DBservices();
        //    int numEffected = dbs.insertPreferencesPerMeetingPerParticipant(this);
        //    return numEffected;
        //}
    }
}
    