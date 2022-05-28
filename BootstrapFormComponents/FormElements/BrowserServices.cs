using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootstrapFormComponents.FormElements;

public class BrowserServices : ComponentBase
{
    public IJSRuntime Js { get; set; }

    public BrowserServices(IJSRuntime js)
    {
        Js = js;
    }

    public async Task ScrollToFormTop()
    {
        await Js.InvokeVoidAsync("bfc.scrollToFormTop");
    }
}
