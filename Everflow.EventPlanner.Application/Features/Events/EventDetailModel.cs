using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everflow.EventPlanner.Application.Features.Events
{
    public class EventDetailModel
    {
        public int EventDetailId { get; set; }
        public string? EventDetailDescription { get; set; }
        public DateTime EventDetailDate { get; set; }
        public TimeSpan EventDetailStartTime { get; set; }
        public TimeSpan EventDetailEndTime { get; set; }
        public string? EventDetailColour { get; set; }
    }
}
