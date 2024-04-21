using Everflow.EventPlanner.Application.Features.Auth.Token;
using Everflow.EventPlanner.Persistence.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everflow.EventPlanner.Application.Features.Auth
{
    public class AuthService : IAuthService
    {
        private readonly EverflowContext _context;
        private readonly JwtAuthenticationManager _jwtAuthenticationManager;

        public AuthService(EverflowContext context, JwtAuthenticationManager jwtAuthenticationManager)
        {
            _context = context;
            _jwtAuthenticationManager = jwtAuthenticationManager;
        }
        public async Task<AuthResult> AuthLogin(string email, string password)
        {
            var loggedInPerson = await _context.People.Where(x => x.EmailAddress == email && x.Password == password).AsNoTracking().FirstOrDefaultAsync();
            if(loggedInPerson == null)
            {
                return new AuthResult("Invalid Log in");
            }

            AuthResult result = new AuthResult();
            result.Success = true;
            result.Token = _jwtAuthenticationManager.Authenticate(email);
            return result;
        }
    }
}
