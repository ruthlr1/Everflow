using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everflow.EventPlanner.Application.Features.People
{
    public class PersonModel
    {
        public int PersonId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmailAddress { get; set; }
        public string? Password { get; set; }

        public string Name
        {
            get
            {
                return $"{FirstName} {LastName}"; 
            }
        }
    }
}
