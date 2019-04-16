using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using meetapp.Models;

namespace meetapp.Controllers
{

    public class ParticipantController : ApiController
    {
        // POST api/values
        //public void Post([FromBody]string value)
        public void Post([FromBody]Participant p)
        {
            p.insert();
        }

        [HttpGet]
        [Route("api/participant/ValidMail")]
        public bool ValidMail(string email)
        {
            Participant p = new Participant();
            return p.ValidMail(email);

        }


        //getting participants for meeting
        [HttpGet]
        [Route("api/participants")]
        public IEnumerable<Participant> Get()
        {
            Participant p = new Participant();
            return p.Read();
        }

        [HttpGet]
        [Route("api/participant/preferences")]
        public Participant GetPreferences(string email)
        {
            Participant p = new Participant();
            return p.GetPreferences(email);

        }

        [HttpGet]
        [Route("api/participant/meetings")]
        public List<Meeting> GetMeetingPerParticipant(string email)
        {
            Participant p = new Participant();
            return p.GetMeetingPerParticipant(email);

        }

        [HttpGet]
        [Route("api/participant/details")]
        public Participant GetDetails(string mail)
        {
            Participant p = new Participant();
            return p.GetDetails(mail);
        }

        [HttpGet]
        [Route("api/participants/login")]
        public bool login(string email, string password)
        {
            Participant p = new Participant();
            return p.GetParticipant(email, password);

        }

        [HttpPut]
        [Route("api/participants/update")]
        public void Put(Participant participant)
        {
            Participant p = new Participant();
            p.Update(participant);

        }

        //[HttpPost]
        //[Route("api/person/filter")]
        //public IEnumerable<Person> useFilter(Filter filter)
        //{
        //    Person p = new Person();
        //    return p.Filter(filter);
        //}

        //[HttpGet]
        //[Route("api/persons")]
        //public IEnumerable<Person> Get()
        //{
        //    Person p = new Person();
        //    return p.GetPersonList();
        //}

        //1-active 0-non active
        //[HttpPut]
        //[Route("api/persons")]
        //public void Put(int Active, int PersonId)
        //{
        //    Person p = new Person();
        //    p.UpdateActive(Active, PersonId);

        //}

        //[HttpGet]
        //[Route("api/persons/details")]
        //public Person GetDetails(string mail)
        //{
        //    Person p = new Person();
        //    return p.GetDetails(mail);

        //}

        //[HttpGet]
        //[Route("api/person/validMail")]
        //public bool ValidMail(string mail)
        //{
        //    Person p = new Person();
        //    return p.ValidMail(mail);

        //}


    }
}
