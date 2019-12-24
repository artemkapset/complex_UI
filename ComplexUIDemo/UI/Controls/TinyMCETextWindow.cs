using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace ComplexUIDemo.UI.Controls
{
    public class TinyMCETextWindow : Control
    {
        public TinyMCETextWindow(IWebElement element) : base(element)
        {
        }

        public static By DefaultLocator = By.Id("tinymce");

        public string Value
        {
            get
            {
                //Driver.SwitchTo().Frame(Driver.FindElement(By.Id("mce_0_ifr")));
                //var value = WrappedElement.Text;
                //Driver.SwitchTo().Window(_mainWindow);
                //return value;

                return WrappedElement.Text;
            }
            set
            {                
                //Driver.SwitchTo().Frame(Driver.FindElement(By.Id("mce_0_ifr")));
                //WrappedElement.Clear();
                //WrappedElement.SendKeys(value);
                //Driver.SwitchTo().Window(_mainWindow);

                WrappedElement.Clear();
                WrappedElement.SendKeys(value);
            }
        }
    }
}
