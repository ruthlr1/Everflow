using Everflow.EventPlanner.Domain.Common;
using Everflow.EventPlanner.Domain.Features.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everflow.EventPlanner.Domain.Features.People
{
    public class Person : EntityBase
    {
        public int PersonId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmailAddress { get; set; }
        public string? Password { get; set; }


        public virtual ICollection<EventPerson>? EventPersons { get; set; }
        public virtual ICollection<PersonRole>? PersonRoles { get; set; }
    }
}
