using Everflow.EventPlanner.Application.Features.People.QueryList;
using Everflow.EventPlanner.Domain.Features.Events;
using Everflow.EventPlanner.Persistence.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everflow.EventPlanner.Application.Features.Events.QueryList
{
    public class GetMyEventsLookupQuery : IRequest<IList<EventDetailLookupModel>>
    {
        public int PersonId { get; set; }
        public GetMyEventsLookupQuery(int personId)
        {
            PersonId = personId;
        }
    }
    public class GetMyEventsLookupQueryHandler : IRequestHandler<GetMyEventsLookupQuery, IList<EventDetailLookupModel>>
    {
        private readonly EverflowContext _context;

        public GetMyEventsLookupQueryHandler(EverflowContext context)
        {
            _context = context;
        }


        public async Task<IList<EventDetailLookupModel>> Handle(GetMyEventsLookupQuery request, CancellationToken cancellationToken)
        {
            var query = _context.EventDetails.AsNoTracking().Where(x => x.EventPersons.Where(e => e.PersonId == request.PersonId).Any()).AsQueryable();


            return await query.Select(x => new EventDetailLookupModel()
            {
                EventDetailId = x.EventDetailId,
                EventDetailDescription = x.EventDetailDescription,
                EventDetailDate = x.EventDetailDate,
                EventDetailStartTime = x.EventDetailStartTime,
                EventDetailEndTime = x.EventDetailEndTime,
            }).ToListAsync(cancellationToken);
        }

    }
}
