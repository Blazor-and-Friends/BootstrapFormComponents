using BootstrapFormComponents.FormElements;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BootstrapFormComponents.Helpers;

public abstract class BfBaseInput<T> : InputBase<T>
{
    /// <summary>
    /// Optional. The input element's id attribute and the associated label's for attribute. If not supplied, a random id is generated.
    /// </summary>
    [Parameter] public string ElementId { get; set; }

    /// <summary>
    /// Optional. Sets input element as readonly or disabled. Default is enabled.
    /// </summary>
    [Parameter] public EnabledStatus EnabledStatus { get; set; }

    /// <summary>
    /// If supplied, adds a div.form-text to the form control.
    /// </summary>
    [Parameter] public string HelpText { get; set; }

    /// <summary>
    /// Optional. Default is "Enter {DisplayName.ToLower() here..."
    /// </summary>
    [Parameter] public string Placeholder { get; set; }

    /// <summary>
    /// If true, the associated label will have a red asterisk indicating this is a required field
    /// </summary>
    [Parameter] public bool Required { get; set; }

    /// <summary>
    /// If false, the associated label will not be displayed. Default is true.
    /// </summary>
    [Parameter] public bool ShowLabel { get; set; } = true;

    [Parameter] public Expression<Func<T>> ValidationFor { get; set; }

    protected bool disabled;
    protected bool readOnly;

    protected override void OnInitialized()
    {
        if(ElementId == null) ElementId = "".GenerateRandomString();

        if (Placeholder == null) Placeholder = $"Enter {DisplayName.ToLower()} here...";

        switch (EnabledStatus)
        {
            case EnabledStatus.Disabled:
                disabled = true;
                break;
            case EnabledStatus.ReadOnly:
                readOnly = true;
                break;
        }

        base.OnInitialized();
    }
}
