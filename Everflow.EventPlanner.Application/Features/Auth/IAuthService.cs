using Everflow.EventPlanner.Application.Features.Events.QueryList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everflow.EventPlanner.Application.Features.Auth
{
    public interface IAuthService
    {
        Task<AuthResult> AuthLogin(string email, string password);
    }
}
