using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace ComplexUIDemo.UI.Controls.Forms
{
    public class LogButton : Control
    {
        public LogButton(IWebElement element) : base(element)
        {
        }

        public string Text => WrappedElement.Text;

        public bool State
        {
            get
            {
                try
                {
                    var disp = WrappedElement.Displayed;
                    Console.WriteLine("LogButton is presented");
                    return disp;
                }
                catch
                {
                    Console.WriteLine("LogButton is NOT presented");
                    return false;
                }
            }
        }

        public void Click()
        {
            WrappedElement.Click();            
        }
    }
}
