using Everflow.EventPlanner.Application.Features.People.QueryList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everflow.EventPlanner.Application.Features.Events.QueryList
{
    public class EventDetailLookupModel : EventDetailModel
    {
        public string PeopleAttending { get; set; }
    }
}
