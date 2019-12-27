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

        public static By DefaultLocator = By.XPath(".//button");
        public string Text => WrappedElement.Text;

        public void Click()
        {
            try
            {
                Driver.FindElement(By.XPath("//button[@disabled]"));

                WaitUntil(Driver => !WrappedElement.GetAttribute("disabled").Contains("disabled"));

                WrappedElement.Click();
            }
            catch
            {
                WrappedElement.Click();
            }
        }
    }
}
