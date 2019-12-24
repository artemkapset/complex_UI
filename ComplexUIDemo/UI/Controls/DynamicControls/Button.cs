using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace ComplexUIDemo.UI.Controls
{
    public class Button : Control
    {
        public Button(IWebElement element) : base(element)
        {
        }

        public string Text => WrappedElement.Text;

        public void Click()
        {
            WrappedElement.Click();
        }
    }
}
