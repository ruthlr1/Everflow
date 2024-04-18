using Everflow.EventPlanner.Application.Common;
using Everflow.EventPlanner.Application.Common.Exceptions;
using Everflow.EventPlanner.Application.Features.People.Upsert;
using Everflow.EventPlanner.Domain.Features.Events;
using Everflow.EventPlanner.Persistence.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everflow.EventPlanner.Application.Features.People
{
    public class PersonService : IPersonService
    {
        private readonly IMediator _mediator;
        private readonly EverflowContext _context;

        public PersonService(IMediator mediator, EverflowContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        public async Task<UpsertPersonCommand> GetUpsert(int personId)
        {
            var dbModel = await _context.People.AsNoTracking().Where(x => x.PersonId == personId).FirstOrDefaultAsync();
            if (dbModel == null)
                throw new EntityNotFoundException(nameof(EventDetail), personId);


            return UpsertPersonCommandMapper.MapFromDB(dbModel);
        }

        public async Task<UpdateResult> UpsertPerson(UpsertPersonCommand upsertPerson)
        {
            var result = await _mediator.Send(upsertPerson);

            return result;
        }
    }
}
