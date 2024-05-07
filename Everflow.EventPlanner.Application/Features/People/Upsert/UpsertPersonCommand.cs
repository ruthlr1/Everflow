using Everflow.EventPlanner.Application.Common.Exceptions;
using Everflow.EventPlanner.Application.Common;
using Everflow.EventPlanner.Application.Features.Events.Upsert;
using Everflow.EventPlanner.Application.Features.People.QueryList;
using Everflow.EventPlanner.Domain.Features.Events;
using Everflow.EventPlanner.Persistence.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Everflow.EventPlanner.Domain.Features.People;

namespace Everflow.EventPlanner.Application.Features.People.Upsert
{
    public class UpsertPersonCommand : PersonModel, IRequest<UpdateResult>
    {
        public string ConfirmedPassword { get; set; }
    }

    public class UpsertPersonCommandMapper
    {
        public static UpsertPersonCommand MapFromDB(Person Person)
        {
            var cmd = new UpsertPersonCommand();
            cmd.PersonId = Person.PersonId;
            cmd.FirstName = Person.FirstName;
            cmd.LastName = Person.LastName;
            cmd.EmailAddress = Person.EmailAddress;
            cmd.Password = Person.Password;

            return cmd;
        }
    }

    public class UpsertPersonCommandHandler : IRequestHandler<UpsertPersonCommand, UpdateResult>
    {
        private readonly EverflowContext _context;

        public UpsertPersonCommandHandler(EverflowContext context)
        {
            _context = context;
        }


        public async Task<UpdateResult> Handle(UpsertPersonCommand request, CancellationToken cancellationToken)
        {
            var addNew = request.PersonId == 0;

            Person? dbModel = new Person();

            if (!addNew)
            {
                dbModel = _context.People.Where(x => x.PersonId == request.PersonId).FirstOrDefault();
                if (dbModel == null)
                    throw new EntityNotFoundException(nameof(Person), request.PersonId);
            }

            dbModel.FirstName = request.FirstName;
            dbModel.LastName = request.LastName;
            dbModel.EmailAddress = request.EmailAddress;
            dbModel.Password = request.Password;

            if (addNew)
            {
                _context.People.Add(dbModel);
            }

            UpdateResult updateResult = new UpdateResult();
            updateResult.NumberRecordsUpdated = await _context.SaveChangesAsync(cancellationToken);
            updateResult.Id = dbModel?.PersonId;

            return updateResult;

        }
    }
}
