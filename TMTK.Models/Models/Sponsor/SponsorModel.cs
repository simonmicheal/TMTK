using System;
using System.Collections.Generic;

namespace TMTK.Models
{
	public class SponsorModel : BaseModel
	{
		public SponsorModel()
		{
			CommandModel.Area = "Event";
			CommandModel.ServiceName = "Sponsor";
		}
	}

	public class Sponsor
	{
		public string Id { get; set; }
		public string SponsorLogo { get; set; }
		public string SponsorCompanyName { get; set; }
		public string SponsorLink { get; set; }
		public object SpeakerDescription { get; set; }
		public string Location { get; set; }
		public string SponsorLevel { get; set; }
		public int DisplayOrder { get; set; }
		public string EventId { get; set; }
		public string Status { get; set; }
		public string LastModified { get; set; }
		public string LastModifiedBy { get; set; }
		public string ServerLastModified { get; set; }
	}

	public class SponsorsResults
	{
		public List<Sponsor> Data { get; set; }
		public string Status { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class SponsorResults
	{
		public Sponsor Data { get; set; }
		public string Status { get; set; }
        public string ErrorMessage { get; set; }
    }
}


