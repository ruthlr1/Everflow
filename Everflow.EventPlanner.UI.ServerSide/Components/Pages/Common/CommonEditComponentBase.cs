using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everflow.EventPlanner.UI.ServerSide.Components.Pages.Common
{
    public abstract class CommonEditComponentBase : CommonComponentBase
    {

        public abstract Task SubmitValidForm();

        public virtual async Task SubmitForm(EditContext editContext)
        {
            if (editContext.Validate())
            {
                await SubmitValidForm();
            }
        }
    }
}
