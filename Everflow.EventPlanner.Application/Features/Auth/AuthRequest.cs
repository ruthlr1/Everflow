using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everflow.EventPlanner.Application.Features.Auth
{
    public class AuthRequest
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
    }
}
