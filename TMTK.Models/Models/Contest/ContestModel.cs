using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMTK.Models
{
    public class ContestModel : BaseModel
    {
        public ContestModel()
        {
            CommandModel.Area = "Event";
            CommandModel.ServiceName = "Contest";
        }
    }

    public class Contest
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public DateTime DisplayStartDate { get; set; }
        public DateTime DisplayEndDate { get; set; }
        public string ContestStatus { get; set; }
        public Guid EventId { get; set; }
        public string Status { get; set; }
        public string LastModified { get; set; }
        public string LastModifiedBy { get; set; }
        public string ServerLastModified { get; set; }
    }

    public class ContestResults
    {
        public Contest Data { get; set; }
        public string Status { get; set; }
        public string ErrorMessage { get; set; }
    }
}
