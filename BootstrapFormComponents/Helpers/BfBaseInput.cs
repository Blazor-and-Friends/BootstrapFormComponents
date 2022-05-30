using BootstrapFormComponents.FormElements;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Linq.Expressions;

namespace BootstrapFormComponents.Helpers;

public abstract class BfBaseInput<T> : InputBase<T>
{
    /// <summary>
    /// Optional. The values for the input element's id attribute and the associated label's for attribute. If omitted, a random id is generated.
    /// </summary>
    [Parameter] public string ElementId { get; set; }

    /// <summary>
    /// Optional. Adds either a "readonly" atrribute for EnabledStatus.Readonly or a "disabled" attribute for EnabledStatus.Disabled. Default is enabled.
    /// </summary>
    [Parameter] public EnabledStatus EnabledStatus { get; set; }

    /// <summary>
    /// Optional. If supplied, adds a "div class='form-text'" underneath the input element.
    /// </summary>
    [Parameter] public string HelpText { get; set; }

    /// <summary>
    /// Optional. Default is "Enter {DisplayName.ToLower()} here..."
    /// </summary>
    [Parameter] public string Placeholder { get; set; }

    /// <summary>
    /// If true, a "required" attribute is placed on the input element and the associated label will have a red asterisk indicating this is a required field
    /// </summary>
    [Parameter] public bool Required { get; set; }

    /// <summary>
    /// Optional. If true, the input's associated label is visually hidden.
    /// </summary>
    [Parameter] public bool HideLabel { get; set; }

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
