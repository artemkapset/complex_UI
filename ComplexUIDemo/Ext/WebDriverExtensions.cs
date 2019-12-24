using System;
using System.Collections.Generic;
using System.Linq;
using ComplexUIDemo.UI.Controls;
using OpenQA.Selenium;

namespace ComplexUIDemo.Ext
{
    public static class WebDriverExtensions
    {
        public static T Find<T>(this ISearchContext context, By by) where T : Control
        {
            return (T)Activator.CreateInstance(typeof(T), context.FindElement(by));
        }
        public static List<T> FindAll<T>(this ISearchContext context, By by) where T : Control
        {
            return context.FindElements(by).Select(item => (T)Activator.CreateInstance(typeof(T), item)).ToList();
        }
    }
}
