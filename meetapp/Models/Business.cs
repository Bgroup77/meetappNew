using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace meetapp.Models
{
    public class Business
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public int GoogleRating { get; set; }
        public int MeetappRating { get; set; }
        public string Facebook { get; set; }
        public string Menu { get; set; }
        public string Address { get; set; }
        public int OpeningHoursID { get; set; }

        public Business(string _name, string _phone, string _type, string _description, int _googleRating, int _meetappRating,string _facebook, string _menu, string _address, int _openingHoursID)
        {
            Name = _name;
            Phone = _phone;
            Type = _type;
            Description = _description;
            GoogleRating = _googleRating;
            MeetappRating = _meetappRating;
            Facebook = _facebook;
            Menu = _menu;
            Address = _address;
            OpeningHoursID = _openingHoursID;
        }

        public Business ()
        {
        }

        public List<Business> ReadBusinesses()
        {
            DBservices dbs = new DBservices();
            return dbs.ReadBusinesses("ConnectionStringMeetapp", "business");
        }
    }
}