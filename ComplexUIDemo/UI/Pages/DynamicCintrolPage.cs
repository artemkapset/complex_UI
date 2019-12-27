using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComplexUIDemo.Ext;
using ComplexUIDemo.UI.Controls.DynamicControls;
using OpenQA.Selenium;

namespace ComplexUIDemo.UI.Pages
{
    public class DynamicControlPage : BasePage
    {
        public DynamicControlPage(IWebDriver driver) : base(driver)
        {
        }

        public ExampleFormCheckBox CheckBoxForm => Driver.Find<ExampleFormCheckBox>(ExampleFormCheckBox.DefaultLocator);
        public ExampleFormTextField TextForm => Driver.Find<ExampleFormTextField>(ExampleFormTextField.DefaultLocator);
    }
}
