using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace ComplexUIDemo.UI.Controls.Forms
{
    public class TitleElement : Control
    {
        public TitleElement(IWebElement element) : base(element)
        {
        }

        public static By DefaultLocator = By.XPath(".//h2");
        public string Text => WrappedElement.Text;
    }
}
