using Everflow.EventPlanner.Application.Common;
using Everflow.EventPlanner.Application.Common.Exceptions;
using Everflow.EventPlanner.Application.Features.Events.QueryList;
using Everflow.EventPlanner.Application.Features.People.QueryList;
using Everflow.EventPlanner.Domain.Features.Events;
using Everflow.EventPlanner.Persistence.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everflow.EventPlanner.Application.Features.Events.Upsert
{
    public class UpsertEventDetailCommand : EventDetailModel, IRequest<UpdateResult>
    {
        public IList<PersonLookupModel> PeopleAttending { get; set; }
    }

    public class UpsertEventDetailCommandMapper
    {
        public static UpsertEventDetailCommand MapFromDB(EventDetail eventDetail)
        {
            var cmd = new UpsertEventDetailCommand();
            cmd.EventDetailId = eventDetail.EventDetailId;
            cmd.EventDetailDescription = eventDetail.EventDetailDescription;
            cmd.EventDetailDate = eventDetail.EventDetailDate;
            cmd.EventDetailStartTime = eventDetail.EventDetailStartTime;
            cmd.EventDetailEndTime = eventDetail.EventDetailEndTime;

            if (eventDetail.EventPersons != null && eventDetail.EventPersons.Any())
            {
                cmd.PeopleAttending = eventDetail.EventPersons.Select(x => new PersonLookupModel() { FirstName = x.Person.FirstName, LastName = x.Person.LastName }).ToList();
            }

            return cmd;
        }
    }

    public class UpsertEventDetailCommandHandler : IRequestHandler<UpsertEventDetailCommand, UpdateResult>
    {
        private readonly EverflowContext _context;

        public UpsertEventDetailCommandHandler(EverflowContext context)
        {
            _context = context;
        }


        public async Task<UpdateResult> Handle(UpsertEventDetailCommand request, CancellationToken cancellationToken)
        {
            var addNew = request.EventDetailId == 0;

            EventDetail? dbModel = new EventDetail();

            if (!addNew)
            {
                dbModel = _context.EventDetails.Where(x => x.EventDetailId == request.EventDetailId).FirstOrDefault();
                if (dbModel == null)
                    throw new EntityNotFoundException(nameof(EventDetail), request.EventDetailId);
            }

            dbModel.EventDetailDescription = request.EventDetailDescription;
            dbModel.EventDetailDate = request.EventDetailDate;
            dbModel.EventDetailStartTime = request.EventDetailStartTime;
            dbModel.EventDetailEndTime = request.EventDetailEndTime;

            if (addNew)
            {
                _context.EventDetails.Add(dbModel);
            }

            UpdateResult updateResult = new UpdateResult();
            updateResult.NumberRecordsUpdated = await _context.SaveChangesAsync(cancellationToken);

            return updateResult;

        }
    }
}
