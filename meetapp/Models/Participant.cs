using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace meetapp.Models
{
    public class Participant
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        //public DateTime BirthDate { get; set; }
        public int Gender { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public int[] Preferences { get; set; }
        

        public Participant(string _email, string _firstName, string _lastName, string _password, string _phone, /*DateTime _birthDate,*/ int _gender, string _image, string _address, int[] _preferences)
        {
            Email = _email;
            FirstName = _firstName;
            LastName = _lastName;
            Password = _password;
            Phone = _phone;
            //BirthDate = _birthDate;
            Gender = _gender;
            Image = _image;
            Address = _address;
            Preferences = _preferences;
        }

        public Participant()
        {
        }

        public int insert()
        {
            DBservices dbs = new DBservices();
            int numEffected = dbs.insert(this);
            return numEffected;
        }

        public List<Participant> Read()
        {
            DBservices dbs = new DBservices();
            return dbs.Read("ConnectionStringMeetapp", "participant");
        }

        public Participant GetPreferences(string email)
        {
            DBservices dbs = new DBservices();
            return dbs.GetPreferences("ConnectionStringMeetapp", "participant", email);
        }

        public List<Meeting> GetMeetingPerParticipant(string email)
        {
            DBservices dbs = new DBservices();
            return dbs.GetMeetingPerParticipant("ConnectionStringMeetapp", "meeting", email);
        }

        //public List<Person> Filter(Filter filter)
        //{
        //    DBservices dbs = new DBservices();
        //    return dbs.Filter("ConnectionStringTinder", "PersonTbl", filter);
        //}


        //public List<Person> GetPersonList()
        //{
        //    DBservices dbs = new DBservices();
        //    return dbs.GetPersonList("ConnectionStringTinder", "PersonTbl2");
        //}

        public void Update(Participant participant)
        {
            DBservices dbs = new DBservices();
            dbs.PutUpdate(participant);
        }

        public bool GetParticipant(string email, string password)
        {
            DBservices dbs = new DBservices();
            return dbs.GetParticipant("ConnectionStringMeetapp", "participant", email, password);
        }

        //public Person GetDetails(string mail)
        //{
        //    DBservices dbs = new DBservices();
        //    return dbs.GetDetails("ConnectionStringTinder", "PersonTbl2", mail);
        //}

        public bool ValidMail(string email)
        {
            DBservices dbs = new DBservices();
            return dbs.ValidMail("ConnectionStringMeetapp", "participant", email);
        }

        public Participant GetDetails(string email)
        {
            DBservices dbs = new DBservices();
            return dbs.GetParticipantDetails("ConnectionStringMeetapp", "participant", email);
        }

    }
}