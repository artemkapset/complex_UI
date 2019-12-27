using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace ComplexUIDemo.UI.Controls.Forms
{
    public class FlashForm : Control
    {
        public FlashForm(IWebElement element) : base(element)
        {
        }

        public static By DefaultLocator = By.Id("flash");
        public string Text => WrappedElement.Text;
    }
}
