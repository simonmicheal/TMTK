using System;
using System.Collections.Generic;

namespace TMTK.Models
{
	public class SpeakerModel : BaseModel
	{
		public SpeakerModel()
		{
			CommandModel.Area = "Event";
			CommandModel.ServiceName = "Speaker";
		}
	}

	public class Speakers
	{
		public string Id { get; set; }
		public string SpeakerPicture { get; set; }
		public string SpeakerName { get; set; }
		public object SpeakerCompany { get; set; }
		public string SpeakerBio { get; set; }
		public object SpeakerLink { get; set; }
		public string EventId { get; set; }
		public string Status { get; set; }
		public string LastModified { get; set; }
		public string LastModifiedBy { get; set; }
		public string ServerLastModified { get; set; }
	}

	public class SpeakersResults
	{
		public List<Speakers> Data { get; set; }
		public string Status { get; set; }
        public string ErrorMessage { get; set; }

    }

	public class SpeakerResults
	{
		public Speakers Data { get; set; }
		public string Status { get; set; }
        public string ErrorMessage { get; set; }
    }
}
