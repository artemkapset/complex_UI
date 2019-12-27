using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace ComplexUIDemo.UI.Controls.DynamicControls
{
    public class InputTextField : Control
    {
        public InputTextField(IWebElement element) : base(element)
        {
        }
        
        public static By DefaultLocator = By.XPath(".//input[@type='text']");
        public static By DefaultUnaccessibleLocator = By.XPath(".//input[@disabled]");

        public bool State
        {
            get
            {
                try
                {
                    Driver.FindElement(By.XPath("//input[@disabled]"));
                    Console.WriteLine("Text field is NOT accessible");
                    return false;
                }
                catch
                {
                    Console.WriteLine("Text field is accessible");
                    return true;
                }                
            }
        }
    }
}
