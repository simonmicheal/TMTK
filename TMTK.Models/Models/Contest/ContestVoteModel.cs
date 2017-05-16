using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMTK.Models
{
    public class ContestVoteModel : BaseModel
    {
        public ContestVoteModel()
        {
            CommandModel.Area = "Event";
            CommandModel.ServiceName = "ContestVote";
        }
    }

    public class ContestVote
    {
        public Guid ContestId { get; set; }
        public int ContactId { get; set; }
        public string FinalistId { get; set; }
        public string Status { get; set; }
        public string LastModified { get; set; }
        public string LastModifiedBy { get; set; }
        public string ServerLastModified { get; set; }
    }

    public class ContestVoteResults
    {
        public ContestVote Data { get; set; }
        public string Status { get; set; }
    }
}
