using Everflow.EventPlanner.Domain.Common;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everflow.EventPlanner.Domain.Features.Events
{
    public class EventDetail : EntityBase
    {
        public int EventDetailId { get; set; }
        public string? EventDetailDescription { get; set; }
        public DateTime EventDetailDate { get; set; }
        public TimeSpan EventDetailStartTime { get; set; }
        public TimeSpan EventDetailEndTime { get; set; }

        public virtual ICollection<EventPerson> EventPersons { get; set;}
    }
}
