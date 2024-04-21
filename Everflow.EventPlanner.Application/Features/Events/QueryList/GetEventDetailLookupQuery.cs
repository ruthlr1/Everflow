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
    public class GetEventDetailLookupQuery : IRequest<IList<EventDetailLookupModel>>
    {
        public DateTime EventsAfter { get; set; }
        public GetEventDetailLookupQuery(DateTime eventsAfter)
        {
            EventsAfter = eventsAfter;
        }
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
            var query = _context.EventDetails.Include(x => x.EventPersons).ThenInclude(x => x.Person).AsNoTracking().Where(x => x.EventDetailDate.HasValue && x.EventDetailDate.Value.Date >= request.EventsAfter.Date).AsQueryable();


            return await query.Select(x => new EventDetailLookupModel() 
                                        {
                                            EventDetailId = x.EventDetailId,
                                            EventDetailDescription = x.EventDetailDescription,
                                            EventDetailDate = x.EventDetailDate,
                                            EventDetailStartTime = x.EventDetailStartTime,
                                            EventDetailEndTime = x.EventDetailEndTime,
                                            PeopleAttending = GetPeopleAttendingEvent(x),
            }).ToListAsync(cancellationToken);
        }

        private static string GetPeopleAttendingEvent(EventDetail detail)
        {
            if (detail.EventPersons == null || detail.EventPersons.Count == 0)
                return "";

            var lookupPeople = detail.EventPersons.Select(x => PersonLookupModel.GetName(x.Person.FirstName, x.Person.LastName)).Distinct().ToList();
            lookupPeople.Sort();

            return string.Join(", ", lookupPeople);
        }
    }
}
