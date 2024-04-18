using Everflow.EventPlanner.Application.Common;
using Everflow.EventPlanner.Application.Features.People.Upsert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everflow.EventPlanner.Application.Features.People
{
    public interface IPersonService
    {
        Task<UpdateResult> UpsertPerson(UpsertPersonCommand upsertPerson);
        Task<UpsertPersonCommand> GetUpsert(int personId);
    }
}
