using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace ComplexUIDemo.UI.Controls.Tables
{
    public class Cell : Control
    {
        public Cell(IWebElement element) : base(element)
        {
        }

        public static By DefaultLocator = By.XPath(".//td");
        public static By TitleCellDefaultLocator = By.XPath(".//th");

        public string Text => WrappedElement.Text;

        public void Click()
        {
            try
            {
                WrappedElement.Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
