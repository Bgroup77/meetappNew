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
    public class MeetingController : ApiController
    {
        // POST api/values
        //public void Post([FromBody]string value)
        public void Post([FromBody] Meeting m)
        {
            m.insertMeeting();
        }

        [HttpGet]
        [Route("api/meeting/getDetailsById")]
        public Meeting GetMeetingById(int meetingId)
        {
            Meeting m = new Meeting();
            return m.GetMeetingById(meetingId);

        }

    }
}