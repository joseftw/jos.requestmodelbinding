using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace JOS.RequestModelBinding;

[AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property)]
public class FromRequestAttribute : Attribute, IBindingSourceMetadata
{
    public BindingSource BindingSource => new FromRequestModelBindingSource();
}
