using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootstrapFormComponents.Helpers
{
    public abstract class SelectTextOnFocusBaseInput<T> : BfBaseInput<T>
    {
        [Inject] public IJSRuntime Js { get; set; }

        /// <summary>
        /// If true, all the text in the input field gets selected on focus
        /// </summary>
        [Parameter] public virtual bool SelectAllTextOnFocus { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender && SelectAllTextOnFocus)
            {
                await Js.InvokeVoidAsync("bfc.setSelectAll", ElementId);
            }
            await base.OnAfterRenderAsync(firstRender);
        }
    }
}
