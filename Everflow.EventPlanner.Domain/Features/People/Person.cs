using Everflow.EventPlanner.Domain.Common;
using Everflow.EventPlanner.Domain.Features.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everflow.EventPlanner.Domain.Features.People
{
    public class Person : EntityBase
    {
        public int PersonId { get; set; }

        [MaxLength(150)]
        public string? FirstName { get; set; }

        [MaxLength(150)]
        public string? LastName { get; set; }

        [MaxLength(150)]
        public string? EmailAddress { get; set; }

        [MaxLength(150)]
        public string? Password { get; set; }


        public virtual ICollection<EventPerson>? EventPersons { get; set; }
    }
}
