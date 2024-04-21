using Everflow.EventPlanner.Application.Common;
using Everflow.EventPlanner.Application.Features.Events.QueryList;
using Everflow.EventPlanner.Application.Features.Events.Upsert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everflow.EventPlanner.Application.Features.Events
{
    public interface IEventService
    {
        Task<IList<EventDetailLookupModel>> GetListAllEvents(DateTime eventsAfter);
        Task<UpsertEventDetailCommand> GetEventDetail(int eventDetailId);
        Task<UpdateResult> UpsertEvents(UpsertEventDetailCommand upsertEventDetail);
    }
}
