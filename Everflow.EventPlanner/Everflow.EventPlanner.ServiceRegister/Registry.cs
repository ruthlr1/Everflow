using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

namespace Everflow.EventPlanner.ServiceRegister
{
    public class Registry
    {
        private readonly IServiceCollection _services;
        private readonly ConfigurationManager Configuration;
        public Registry(IServiceCollection services, ConfigurationManager Configuration)
        {
            _services = services;
        }

        public void Register()
        {

        }
    }
}
