using Everflow.EventPlanner.Domain.Common;
using Everflow.EventPlanner.Domain.Features.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everflow.EventPlanner.Domain.Features.Events
{
    public class EventPerson : EntityBase
    {
        public int EventPersonId { get; set; }
        public int EventDetailId { get; set; }
        public EventDetail EventDetail { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
