using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace meetapp.Models
{
    public class Meeting
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        //public DateTime StartTime { get; set; }
        public string StartTime { get; set; }
        //public TimeSpan StartHour { get; set; }
        public string StartHour { get; set; }
        //public DateTime CreationDate { get; set; }
        //public string CreationDate { get; set; }
         public int TimeTillRunningHours { get; set; }
        public string SpecificLocation { get; set; }
        public string Notes { get; set; }
        public int [] Participants { get; set; }
        public int BusinessID { get; set; }
        public int StatusID { get; set; }
        public int CreatorID { get; set; }


        public Meeting(string _subject, string _startTime, string _startHour, int _timeTillRunningHours, string _specificLocation, string _notes, int[] _participants,int _businessID, int _statusID, int _creatorID)
        {
            Subject = _subject;
            StartTime = _startTime;
            StartHour = _startHour;
            //CreationDate = _creationDate;
            TimeTillRunningHours = TimeTillRunningHours;
            SpecificLocation = _specificLocation;
            Notes = _notes;
            Participants = _participants;
            BusinessID = _businessID; 
             StatusID = _statusID; 
             CreatorID =_creatorID ; 
        }

        public Meeting()
        {
            StatusID = 1;
            CreatorID = 1;
            BusinessID = 5;
        }

        public int insertMeeting()
        {
            DBservices dbs = new DBservices();
            int numEffected = dbs.insertMeeting(this);
            return numEffected;
        }

        public Meeting GetMeetingById(int meetingId)
        {
            DBservices dbs = new DBservices();
            return dbs.GetMeetingById("ConnectionStringMeetapp", "meeting", meetingId);
        }

        //public List<Meeting> GetMeetingPerParticipant(string email)
        //{
        //    DBservices dbs = new DBservices();
        //    return dbs.GetMeetingPerParticipant("ConnectionStringMeetapp", "participant", email);
        //}

    }
}