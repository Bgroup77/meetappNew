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
    public class PreferenceController : ApiController
    {

        //public void insertPreferencesPerMeetingPerParticipant([FromBody]Meeting m)
        //{
        //    p.insertPreferencesPerMeetingPerParticipant();
        //}

        // POST api/values
        //public void Post([FromBody]string value)
        public void Post([FromBody]Participant p)
        {
            p.insert();
        }

        //getting participants for meeting
        [HttpGet]
        [Route("api/preferences")]
        public IEnumerable<Preference> Get()
        {
            Preference p = new Preference();
            return p.ReadPreferences();
        }

        //[HttpGet]
        //[Route("api/preferences/insertPreferencesPerMeetingPerParticipant")]
        //public IEnumerable<Preference> Get()
        //{
        //    Preference p = new Preference();
        //    return p.insertPreferencesPerMeetingPerParticipant();

        //}

        // POST api/values
        //public void Post([FromBody]string value)

    }
}