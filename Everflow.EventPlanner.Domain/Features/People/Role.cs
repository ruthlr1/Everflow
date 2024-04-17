using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everflow.EventPlanner.Domain.Features.People
{
    public class Role
    {
        public int RoleId { get; set; }
        public required string RoleName { get; set; }

        public enum RoleIndex
        {
            Admin = 1,
            Planner,
            Attendee,
        }
    }
}
