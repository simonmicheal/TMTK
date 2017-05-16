using System;
using System.Collections.Generic;

namespace TMTK.Models
{
	public class EventModel : BaseModel
	{
		public EventModel()
		{
			CommandModel.Area = "Event";
			CommandModel.ServiceName = "Event";
		}
	}

	public class Event
	{
		public string Id { get; set; }
		public string EventName { get; set; }
		public string StartDate { get; set; }
		public string EndDate { get; set; }
		public string DisplayStartDate { get; set; }
		public string DisplayEndDate { get; set; }
		public string EventStatus { get; set; }
		public string Status { get; set; }
		public string LastModified { get; set; }
		public string LastModifiedBy { get; set; }
		public string ServerLastModified { get; set; }
	}

	public class EventResults
	{
		public List<Event> Data { get; set; }
		public string Status { get; set; }
        public string ErrorMessage { get; set; }
    }
}