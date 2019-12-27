using System.Collections.Generic;
using System.Linq;
using ComplexUIDemo.UI.Controls;
using OpenQA.Selenium;
using ComplexUIDemo.Ext;

namespace ComplexUIDemo.UI.Pages
{
    public class TinyMCEPage : BasePage
    {
        public TinyMCEPage(IWebDriver driver) : base(driver)
        {
        }

        public TinyMCETextWindow Editor => Driver.Find<TinyMCETextWindow>(TinyMCETextWindow.DefaultLocator);        
        //private string _mainWindow => Driver.CurrentWindowHandle;
        private IWebElement _frame => Driver.FindElement(By.Id("mce_0_ifr"));

        public void SetValue(string value)
        {
            Driver.SwitchTo().Frame(_frame);
            Editor.Value = value;
            Driver.SwitchTo().DefaultContent();
            //Driver.SwitchTo().Window(_mainWindow);
        }

        public string GetValue()
        {
            Driver.SwitchTo().Frame(_frame);
            var value = Editor.Value;
            Driver.SwitchTo().DefaultContent();
            //Driver.SwitchTo().Window(_mainWindow);

            return value;
        }
    }
}
