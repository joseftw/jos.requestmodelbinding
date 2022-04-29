using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace JOS.RequestModelBinding;

public class FromRequestModelBindingSource : BindingSource
{
    public FromRequestModelBindingSource() : base(
        "FromModelBinding",
        "FromModelBinding",
        true,
        true
    )
    {
    }

    public override bool CanAcceptDataFrom(BindingSource bindingSource)
    {
        return bindingSource == ModelBinding;
    }
}