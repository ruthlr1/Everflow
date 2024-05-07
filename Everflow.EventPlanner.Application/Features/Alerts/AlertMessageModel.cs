using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everflow.EventPlanner.Application.Features.Alerts
{
    public class AlertMessageModel
    {
        public string Message { get; set; }
        public AlertType.AlertTypeIndex AlertType { get; set; }
    }
}
