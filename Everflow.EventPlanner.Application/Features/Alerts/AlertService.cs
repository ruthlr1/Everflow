using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everflow.EventPlanner.Application.Features.Alerts
{
    public class AlertService
    {
        public event Action<AlertMessageModel> MessageEvent;
        public event Action MessageDisposed;


        public AlertMessageModel AlertMessageModel { get; private set; }

        public void ClearAlert()
        {
            if (AlertMessageModel == null)
                return; // no message to clear

            AlertMessageModel = null;
            MessageDisposed?.Invoke();
        }

        private void SetMessage(AlertType.AlertTypeIndex alertType, string description)
        {
            AlertMessageModel = new AlertMessageModel { AlertType = alertType, Message = description };
            NotifyAlertChanged(AlertMessageModel);
        }

        public void SetErrorMessage(string description)
        {
            SetMessage(AlertType.AlertTypeIndex.Failure, description);
        }

        public void SetErrorMessage(Exception ex)
        {
            string description = ex.Message;
            if (ex.InnerException != null)
                description = ex.InnerException.Message;

            SetMessage(AlertType.AlertTypeIndex.Failure, description);
        }
        public void SetSuccessMessage(string description)
        {
            SetMessage(AlertType.AlertTypeIndex.Success, description);
        }
        private void NotifyAlertChanged(AlertMessageModel message) => MessageEvent?.Invoke(message);

    }
}
