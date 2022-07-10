using Microsoft.AspNetCore.Components;

namespace BootstrapFormComponents.Helpers;

public abstract class MinLengthMaxLengthBaseInput : SelectTextOnFocusBaseInput<string>
{
    [Parameter] public int MaxLength { get; set; } = int.MaxValue;

    [Parameter] public int MinLength { get; set; }
}
