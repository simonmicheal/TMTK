using System;
namespace TMTK.Models
{
	public class BaseModel
	{
		public string LastModified { get; set; }
		public string LastModifiedBy { get; set; }
		public string ServerLastModified { get; set; }

		private CommandModel _commandModel;
		public CommandModel CommandModel
		{
			get
			{
				if (_commandModel == null)
				{
					_commandModel = new CommandModel();
				}

				return _commandModel;
			}
		}

		public class Data
		{
			public string Status { get; set; }
			public string ErrorMessage { get; set; }
		}
	}
}
