using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootstrapFormComponents.Helpers;

public abstract class BfBaseInput<T> : InputBase<T>
{
    [Parameter] public bool Required { get; set; }
}
