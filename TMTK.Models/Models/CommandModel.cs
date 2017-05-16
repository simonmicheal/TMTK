using System;
using System.Collections.Generic;

namespace TMTK.Models
{
	public class CommandModel
	{
		public string SessionToken { get; set; }
		public string Area { get; set; }
		public string ServiceName { get; set; }
		public string Action { get; set; }
		public Dictionary<string, string> Parameters { get; set; }
	}
}
