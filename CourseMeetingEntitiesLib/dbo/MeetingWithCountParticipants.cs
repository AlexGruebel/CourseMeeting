using System;

namespace CourseMeetingEntitiesLib.dbo
{
    public class MeetingWithCountParticpants
    {
        public int MID {get;set;}
        public int CID {get;set;}

        public DateTime DateOfTheMeeting{get;set;}

        public int MaxParticipants {get;set;}
        public int CountParticpants{get;set;}

        public int FreeSeats {get => this.MaxParticipants - this.CountParticpants;}
    }
}