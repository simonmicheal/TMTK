using System;
using System.Collections.Generic;

namespace TMTK.Models
{
	public class SessionModel : BaseModel
	{
		public SessionModel()
		{
			CommandModel.Area = "Event";
			CommandModel.ServiceName = "Session";
		}
	}

	public class Session
	{
		public string Id { get; set; }
		public string StartTime { get; set; }
		public string EndTime { get; set; }
		public string Title { get; set; }
		public string ShortDescription { get; set; }
		public string SessionDescription { get; set; }
		public object PresenterName { get; set; }
		public object PresenterPicture { get; set; }
		public string Location { get; set; }
		public object SponsorName { get; set; }
		public object SponsorPicture { get; set; }
		public object SpeakerId { get; set; }
		public object SponsorId { get; set; }
		public string Status { get; set; }
		public string LastModified { get; set; }
		public string LastModifiedBy { get; set; }
		public string ServerLastModified { get; set; }
		public string ScheduleId { get; set; }

	}

	public class SessionResults
	{
		public List<Session> Data { get; set; }
		public string Status { get; set; }
        public string ErrorMessage { get; set; }
    }
}
