using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace ComplexUIDemo.UI.Controls.Forms
{
    public class UserNameForm : Control
    {
        public UserNameForm(IWebElement element) : base(element)
        {
        }

        public static By DefaultLocator = By.Id("username");

        public string Value
        {
            get
            {
                return WrappedElement.Text;
            }
            set
            {                
                WrappedElement.Clear();
                WrappedElement.SendKeys(value);
            }
        }

        public bool State
        {
            get
            {
                try
                {
                    var disp = WrappedElement.Displayed;
                    Console.WriteLine("UserNameForm is presented");
                    return disp;
                }
                catch
                {
                    Console.WriteLine("UserNameForm is NOT presented");
                    return false;
                }
            }
        }
    }
}
