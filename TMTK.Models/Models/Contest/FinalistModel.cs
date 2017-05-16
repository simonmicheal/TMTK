using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TMTK.Models
{
    public class FinalistModel : BaseModel
    {
        public FinalistModel()
        {
            CommandModel.Area = "Event";
            CommandModel.ServiceName = "Finalist";
        }
    }

    public class Finalist
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Headline { get; set; }
        public string Headshot { get; set; }
        public string ShortDescription { get; set; }
        public Guid ContestId { get; set; }
        public int DisplayOrder { get; set; }
        public Guid EventId { get; set; }
        public string Status { get; set; }
        public string LastModified { get; set; }
        public string LastModifiedBy { get; set; }
        public string ServerLastModified { get; set; }

        private ContestVote _vote = null;
        public ContestVote Vote
        {
            get { return _vote; }
            set
            {
                if (_vote != value)
                {
                    _vote = value;
                }
            }
        }

        public bool CanVote
        {
            get { return _vote == null || _vote.FinalistId != Id; }
        }

        public string ButtonText
        {
            get { return CanVote ? "Vote" : "My Choice"; }
        }
    }

    public class FinalistResults
    {
        public List<Finalist> Data { get; set; }
        public string Status { get; set; }
        public string ErrorMessage { get; set; }
    }
}

