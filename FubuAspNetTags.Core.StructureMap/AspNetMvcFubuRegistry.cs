using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FubuCore;
using FubuMVC.Core.UI;
using FubuMVC.Core.UI.Configuration;
using FubuMVC.Core.UI.Tags;
using Microsoft.Practices.ServiceLocation;
using StructureMap.Configuration.DSL;

namespace FubuAspNetTags.Core.StructureMap
{
    public class AspNetMvcFubuRegistry : Registry
    {
        public AspNetMvcFubuRegistry(params HtmlConventionRegistry[] registries)
        {
            var tagpl = new TagProfileLibrary();
            registries.Each(tagpl.ImportRegistry);
            tagpl.ImportRegistry(new DefaultAspNetMvcHtmlConventions());
            

            For<ITypeResolver>().Use<TypeResolver>();
            For<ITypeResolverStrategy>().Use<TypeResolver.DefaultStrategy>();
            For<IElementNamingConvention>().Use<AspNetMvcElementNamingConvention>();
            For<TagProfileLibrary>().Use(tagpl);
            For(typeof(ITagGenerator<>)).Use(typeof(TagGenerator<>));
            For<IServiceLocator>().Use(() => ServiceLocator.Current);
        }
       
    }
}
