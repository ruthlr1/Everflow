using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everflow.EventPlanner.Application.Common
{
    public class UpdateResult
    {
        public int? Id { get; set; }
        public int NumberRecordsUpdated { get; set; }

        public bool IsSuccess
        {
            get
            {
                // should error if model not returned
                return NumberRecordsUpdated > 0 || (Id.HasValue && Id.Value > 0);
            }
        }
    }
}
