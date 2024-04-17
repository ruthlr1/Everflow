using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everflow.EventPlanner.Domain.Common
{
    public abstract class EntityBase
    {
        public DateTime CreatedDateTime { get; set; }
    }
}
