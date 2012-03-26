using System;
using FubuMVC.Core.UI.Configuration;

namespace FubuAspNetTags.Core
{
    public class AspNetMvcElementNamingConvention : IElementNamingConvention
    {
        public string GetName(Type modelType, FubuCore.Reflection.Accessor accessor)
        {
            var t = string.Join(".", accessor.PropertyNames).Replace(".[", "[");
            return t;
        }
    }
}