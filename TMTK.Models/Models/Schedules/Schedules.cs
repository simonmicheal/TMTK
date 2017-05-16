using System;
using System.Collections.Generic;

namespace TMTK.Models
{
	public class ScheduleModel : BaseModel
	{
		public ScheduleModel()
		{
			CommandModel.Area = "Event";
			CommandModel.ServiceName = "Schedule";
		}
	}

	public class Schedule
	{
		public string Id { get; set; }
		public string ScheduleDate { get; set; }
		public string EventId { get; set; }
		public string Status { get; set; }
		public string LastModified { get; set; }
		public string LastModifiedBy { get; set; }
		public string ServerLastModified { get; set; }
	}

	public class ScheduleResults
	{
		public List<Schedule> Data { get; set; }
		public string Status { get; set; }
        public string ErrorMessage { get; set; }
    }
}
