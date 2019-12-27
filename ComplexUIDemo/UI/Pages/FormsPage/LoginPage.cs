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
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public TitleElement TitleElement => Driver.Find<TitleElement>(TitleElement.DefaultLocator);
        public FlashForm FlashForm => Driver.Find<FlashForm>(FlashForm.DefaultLocator);
        public PasswordForm PasswordForm => Driver.Find<PasswordForm>(PasswordForm.DefaultLocator);
        public UserNameForm UserNameForm => Driver.Find<UserNameForm>(UserNameForm.DefaultLocator);
        public LogButton LoginButton => Driver.Find<LogButton>(By.XPath("//button[@class='radius']"));
    }
}
