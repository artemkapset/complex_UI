using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComplexUIDemo.Ext;
using ComplexUIDemo.UI.Controls.Forms;
using OpenQA.Selenium;

namespace ComplexUIDemo.UI.Pages.FormsPage
{
    public class SecureAreaPage : BasePage
    {
        public SecureAreaPage(IWebDriver driver) : base(driver)
        {
        }

        public TitleElement TitleElement => Driver.Find<TitleElement>(TitleElement.DefaultLocator);
        public FlashForm FlashForm => Driver.Find<FlashForm>(FlashForm.DefaultLocator);

        public LogButton LogoutButton => Driver.Find<LogButton>(By.XPath(".//a[@class='button secondary radius']"));
    }
}
