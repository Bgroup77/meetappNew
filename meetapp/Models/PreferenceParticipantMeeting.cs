using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace meetapp.Models
{
    public class PreferenceParticipantMeeting
    {
        public int[] PreferenceId { get; set; }
        public int ParticipantId { get; set; }
        public int MeetingId { get; set; }

        public PreferenceParticipantMeeting(int []  _preferenceId, int _participantId, int _meetingId)
        {
            PreferenceId = _preferenceId;
            ParticipantId = _participantId;
            MeetingId = _meetingId;
        }

        public PreferenceParticipantMeeting()
        {
        }

        public int insertPreferenceParticipantMeeting()
        {
            DBservices dbs = new DBservices();
            int numEffected = dbs.insertPreferenceParticipantMeeting(this);
            return numEffected;
        }

        public List<Preference> GetPreferenceParticipantMeeting(int meetingId)
        {
            DBservices dbs = new DBservices();
            return dbs.GetPreferenceParticipantMeeting("ConnectionStringMeetapp", "participant_preference_meeting", meetingId);
        }
    }
}