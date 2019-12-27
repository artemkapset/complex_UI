using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComplexUIDemo.Ext;
using ComplexUIDemo.UI.Controls.Tables;
using OpenQA.Selenium;

namespace ComplexUIDemo.UI.Pages
{
    public class TablesPage : BasePage
    {
        public TablesPage(IWebDriver driver) : base(driver)
        {
        }

        public Table Table => Driver.Find<Table>(By.Id("table2"));
    }
}
