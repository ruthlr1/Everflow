using Everflow.EventPlanner.Application.Features.People.QueryList;
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
    public class GetEventDetailLookupQuery : IRequest<IList<EventDetailLookupModel>>
    {

    }
    public class GetEventDetailLookupQueryHandler : IRequestHandler<GetEventDetailLookupQuery, IList<EventDetailLookupModel>>
    {
        private readonly EverflowContext _context;

        public GetEventDetailLookupQueryHandler(EverflowContext context)
        {
            _context = context;
        }


        public async Task<IList<EventDetailLookupModel>> Handle(GetEventDetailLookupQuery request, CancellationToken cancellationToken)
        {
            var query = _context.EventDetails.Include(x => x.EventPersons).ThenInclude(x => x.Person).AsNoTracking().AsQueryable();


            return await query.Select(x => new EventDetailLookupModel() 
                                        {
                                            EventDetailId = x.EventDetailId,
                                            EventDetailDescription = x.EventDetailDescription,
                                            EventDetailDate = x.EventDetailDate,
                                            EventDetailColour = x.EventDetailColour,
                                        }).ToListAsync(cancellationToken);
        }
    }
}
