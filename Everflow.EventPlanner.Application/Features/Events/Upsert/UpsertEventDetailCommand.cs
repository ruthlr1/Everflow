using Everflow.EventPlanner.Application.Common;
using Everflow.EventPlanner.Application.Common.Exceptions;
using Everflow.EventPlanner.Application.Features.Events.QueryList;
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

namespace Everflow.EventPlanner.Application.Features.Events.Upsert
{
    public class UpsertEventDetailCommand : EventDetailModel, IRequest<UpdateResult>
    {
        public IEnumerable<int> PersonIdsAttending { get; set; }
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
                cmd.PersonIdsAttending = eventDetail.EventPersons.Select(x => x.PersonId).ToList();
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
                dbModel = _context.EventDetails.Include(x => x.EventPersons).Where(x => x.EventDetailId == request.EventDetailId).FirstOrDefault();
                if (dbModel == null)
                    throw new EntityNotFoundException(nameof(EventDetail), request.EventDetailId);
            }

            dbModel.EventDetailDescription = request.EventDetailDescription;
            dbModel.EventDetailDate = request.EventDetailDate;
            dbModel.EventDetailStartTime = request.EventDetailStartTime;
            dbModel.EventDetailEndTime = request.EventDetailEndTime;

            if(request.PersonIdsAttending.Any())
            {
                if(dbModel.EventPersons != null)
                {
                    // some exist so
                    // lets delete the ones not used
                    foreach(var evntPerson in dbModel.EventPersons.Where(x => !request.PersonIdsAttending.Contains(x.PersonId)))
                    {
                        _context.EventPersons.Remove(evntPerson);
                    }

                    // lets add the ones that dont exist
                    foreach (var personId in request.PersonIdsAttending.Where(x => !dbModel.EventPersons.Any(p => p.PersonId == x)))
                    {
                        dbModel.EventPersons.Add(new EventPerson() { PersonId = personId });
                    }
                }
                else
                {
                    // none exists so add all
                    dbModel.EventPersons = request.PersonIdsAttending.Select(x => new EventPerson() { PersonId = x }).ToList();
                }
            }
            else
            {
                if(dbModel.EventPersons != null && dbModel.EventPersons.Any())
                {
                    // remove all
                    _context.EventPersons.RemoveRange(dbModel.EventPersons);
                }
            }

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
