using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Everflow.EventPlanner.UI.Components.Pages.People
{
    public class PersonEditBase : ComponentBase
    {
        [Parameter] public int Id { get; set; }
    }
}