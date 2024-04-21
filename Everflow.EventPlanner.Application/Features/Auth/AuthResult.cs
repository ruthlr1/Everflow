using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everflow.EventPlanner.Application.Features.Auth
{
    public class AuthResult
    {
        public AuthResult()
        {
            
        }
        public AuthResult(string errMsg)
        {
            ErrorMessage = errMsg;
        }
        public string? Token { get; set; }
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
