using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComplexUIDemo.Ext;
using OpenQA.Selenium;

namespace ComplexUIDemo.UI.Controls.DynamicControls
{
    public class ExampleForm : Control
    {
        public ExampleForm(IWebElement element) : base(element)
        {
        }

        public static By DefaultLocator = By.Id("checkbox-example");

        private Button _button;

        public Button Button => _button ?? (_button = WrappedElement.Find<Button>(By.XPath(".//button")));

        public bool IsElementPresented()
        {

            //TODO - исправить (checkbox displayed????)
            Console.WriteLine(WrappedElement.GetAttribute(".............").Equals("checkbox"));
            return WrappedElement.GetAttribute(".............").Equals("checkbox");
        }
    }
}
