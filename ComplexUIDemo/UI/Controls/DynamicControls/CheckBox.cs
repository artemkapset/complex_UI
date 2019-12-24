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

        public static By DefaultLocator = By.Id("checkbox");

        public bool State
        {
            get
            {                
                return WrappedElement.Displayed;
            }
        }
    }
}
