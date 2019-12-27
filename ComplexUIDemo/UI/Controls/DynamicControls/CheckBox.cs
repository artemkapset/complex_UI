using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace ComplexUIDemo.UI.Controls
{
    public class CheckBox : Control
    {
        public CheckBox(IWebElement element) : base(element)
        {
        }

        public static By DefaultLocator = By.XPath(".//input[@type='checkbox']");

        public bool State
        {
            get
            {
                var disp = WrappedElement.Displayed;
                if (disp)
                {
                    Console.WriteLine("CheckBox is presented");
                    return disp;
                }
                else
                {
                    Console.WriteLine("CheckBox is NOT Displayed");
                    return disp;
                }

                //try
                //{
                //    var disp = WrappedElement.Displayed;
                //    Console.WriteLine("CheckBox is presented");
                //    return disp;
                //}
                //catch
                //{
                //    Console.WriteLine("CheckBox is presented");
                //    return false;
                //}
            }
        }
    }
}
