using ComplexUIDemo.UI.Controls;
using ComplexUIDemo.Ext;
using OpenQA.Selenium;


namespace ComplexUIDemo.UI.Pages
{
    public class TreeViewPage : BasePage
    {
        public TreeViewPage(IWebDriver driver) : base(driver)
        {
        }

        public TreeView TreeView => Driver.Find<TreeView>(By.CssSelector("div.k-treeview"));
    }
}
