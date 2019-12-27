using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComplexUIDemo.Ext;
using OpenQA.Selenium;

namespace ComplexUIDemo.UI.Controls.DynamicControls
{
    public class ExampleFormCheckBox : Control
    {
        public ExampleFormCheckBox(IWebElement element) : base(element)
        {
        }

        public static By DefaultLocator = By.Id("checkbox-example");

        private Button _button;
        private CheckBox _checkBox;

        public Button Button => _button ?? (_button = WrappedElement.Find<Button>(Button.DefaultLocator));
        public CheckBox CheckBox => _checkBox ?? (_checkBox = WrappedElement.Find<CheckBox>(CheckBox.DefaultLocator));
        //public CheckBox CheckBox
        //{
        //    get
        //    {
        //        if (_checkBox != null)
        //        {
        //            return _checkBox;
        //        }
        //        else
        //        {
        //            try
        //            {
        //                return WrappedElement.Find<CheckBox>(CheckBox.DefaultLocator);
        //            }
        //            catch
        //            {
        //                Console.WriteLine("CheckBox is NOT presented");
        //                return null;
        //            }
                    
        //        }
        //    }
        //}

        public bool IsCheckBoxPresented()
        {
            try
            {
                return CheckBox.State;
            }
            catch
            {
                Console.WriteLine("CheckBox is NOT presented");
                return false;
            }
        }
    }
}
