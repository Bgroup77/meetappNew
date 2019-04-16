using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using meetapp.Models;

namespace meetapp.Controllers
{
    
    public class PreferenceParticipantMeetingController : ApiController
    {
        // POST api/values
        //public void Post([FromBody]string value)
        public void Post([FromBody] PreferenceParticipantMeeting ppm)
        {
            ppm.insertPreferenceParticipantMeeting();
        }

        [HttpGet]
        [Route("api/PreferenceParticipantMeeting/get")]
        public IEnumerable<Preference> GetPreferenceParticipantMeeting(int meetingId)
        {
            PreferenceParticipantMeeting ppm = new PreferenceParticipantMeeting();
            return ppm.GetPreferenceParticipantMeeting(meetingId);
        }

    }

}