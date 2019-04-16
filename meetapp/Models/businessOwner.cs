using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace meetapp.Models
{
    public class BusinessOwner
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public int BusinessId { get; set; }

        public BusinessOwner(string _email, string _firstName, string _lastName, string _password)
        {
            Email = _email;
            FirstName = _firstName;
            LastName = _lastName;
            Password = _password;
        }

        public BusinessOwner()
        {
        }

        public int insert()
        {
            DBservices dbs = new DBservices();
            int numEffected = dbs.insert(this);
            return numEffected;
        }

        public bool ValidMail(string email)
        {
            DBservices dbs = new DBservices();
            return dbs.ValidMail("ConnectionStringMeetapp", "businessOwner", email);
        }

        public bool GetBusinessOwner(string Mail, string Password)
        {
            DBservices dbs = new DBservices();
            return dbs.GetBusinessOwner("ConnectionStringMeetapp", "businessOwner", Mail, Password);
        }

        public BusinessOwner GetDetails(string email)
        {
            DBservices dbs = new DBservices();
            return dbs.GetBoDetails("ConnectionStringMeetapp", "businessOwner", email);
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

        //public void UpdateActive(int Active, int PersonId)
        //{
        //    DBservices dbs = new DBservices();
        //    dbs.UpdateActive(Active, PersonId);
        //}


        public int PutUpdate()
        {
            DBservices dbs = new DBservices();
            int numEffected = dbs.PutUpdate(this);
            return numEffected;
        }
    }
}




