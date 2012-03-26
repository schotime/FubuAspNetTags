using System;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using FubuMVC.Core.UI.Tags;
using HtmlTags;
using Microsoft.Practices.ServiceLocation;

namespace FubuAspNetTags.Core
{
    public static class FubuAspNetTagExtensions
    {
        public static HtmlTag Input<T>(this HtmlHelper<T> helper, Expression<Func<T, object>> expression) where T : class
        {
            var generator = GetGenerator(helper);
            return generator.InputFor(expression);
        }

        public static HtmlTag Label<T>(this HtmlHelper<T> helper, Expression<Func<T, object>> expression) where T : class
        {
            var generator = GetGenerator(helper);
            return generator.LabelFor(expression);
        }

        public static HtmlTag Display<T>(this HtmlHelper<T> helper, Expression<Func<T, object>> expression) where T : class
        {
            var generator = GetGenerator(helper);
            return generator.DisplayFor(expression);
        }

        private static ITagGenerator<T> GetGenerator<T>(HtmlHelper<T> helper) where T : class
        {
            var generator = ServiceLocator.Current.GetInstance<ITagGenerator<T>>() as TagGenerator<T>;
            generator.SetModel(helper.ViewData.Model);
            return generator;
        }
    }
}
