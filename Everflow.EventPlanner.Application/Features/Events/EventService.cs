using Azure.Core;
using Everflow.EventPlanner.Application.Common;
using Everflow.EventPlanner.Application.Common.Exceptions;
using Everflow.EventPlanner.Application.Features.Events.QueryList;
using Everflow.EventPlanner.Application.Features.Events.Upsert;
using Everflow.EventPlanner.Domain.Features.Events;
using Everflow.EventPlanner.Persistence.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Everflow.EventPlanner.Application.Features.Events
{
    public class EventService : IEventService
    {
        private readonly IMediator _mediator;
        private readonly EverflowContext _context;

        public EventService(IMediator mediator, EverflowContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        public async Task<UpsertEventDetailCommand> GetEventDetail(int eventDetailId)
        {
            var dbModel = await _context.EventDetails.Include(x => x.EventPersons).ThenInclude(x => x.Person).AsNoTracking().Where(x => x.EventDetailId == eventDetailId).FirstOrDefaultAsync();
            if (dbModel == null)
                throw new EntityNotFoundException(nameof(EventDetail), eventDetailId);


            return UpsertEventDetailCommandMapper.MapFromDB(dbModel);
        }

        public async Task<IList<EventDetailLookupModel>> GetListAllEvents(DateTime eventsAfter)
        {
            var result = await _mediator.Send(new GetEventDetailLookupQuery(eventsAfter));

            return result;
        }

        public async Task<UpdateResult> UpsertEvents(UpsertEventDetailCommand upsertEventDetail)
        {
            var result = await _mediator.Send(upsertEventDetail);

            return result;
        }
    }
}
