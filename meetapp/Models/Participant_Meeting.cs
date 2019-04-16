using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace meetapp.Models
{
    public class Participant_Meeting
    {
        public int ParticipantId { get; set; }
        public int MeetingId { get; set; }
        public int IsPaidParking { get; set; }
        public int DidReject { get; set; }
        public int HasCar { get; set; }
        public int IsVegan { get; set; }
        public int IsVegeterian { get; set; }
        public int WantsKosher { get; set; }
        public int Effort { get; set; }

        public Participant_Meeting(int _participantId, int _meetingId, int _isPaidParking, int _didReject, int _hasCar, int _isVegan, int _isVegeterian, int _wantsKosher, int _effort)
        {
            ParticipantId = ParticipantId;
            MeetingId = MeetingId;
            IsPaidParking = _isPaidParking;
            DidReject = _didReject;
            HasCar = _hasCar;
            IsVegan = _isVegan;
            IsVegeterian = _isVegeterian;
            WantsKosher = _wantsKosher;
            Effort = _effort;
        }

        public Participant_Meeting()
        {
        }
    }


}