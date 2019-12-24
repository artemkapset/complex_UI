using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComplexUIDemo.Ext;
using ComplexUIDemo.UI.Controls;
using OpenQA.Selenium;

namespace ComplexUIDemo.UI.Pages
{
    public class BatchEditPage : BasePage
    {
        public BatchEditPage(IWebDriver driver) : base(driver)
        {
        }

        public Grid Grid => Driver.Find<Grid>(By.CssSelector("#grid"));
        // public IWebElement SomeButton => Driver.FindElement(By.CssSelector())
    }
}
