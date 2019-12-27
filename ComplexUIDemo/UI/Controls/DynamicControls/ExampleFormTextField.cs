using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComplexUIDemo.Ext;
using OpenQA.Selenium;

namespace ComplexUIDemo.UI.Controls.DynamicControls
{
    public class ExampleFormTextField : Control
    {
        public ExampleFormTextField(IWebElement element) : base(element)
        {
        }

        public static By DefaultLocator = By.Id("input-example");

        private Button _button;
        private InputTextField _input;
        public Button Button => _button ?? (_button = WrappedElement.Find<Button>(Button.DefaultLocator));
        public InputTextField InputTextField => _input ?? (_input = WrappedElement.Find<InputTextField>(InputTextField.DefaultLocator));

        public bool IsFieldAccessible()
        {
            return InputTextField.State;
        }
    }
}
