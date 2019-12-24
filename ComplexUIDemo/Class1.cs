using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComplexUIDemo.Ext;
using ComplexUIDemo.UI.Controls;
using ComplexUIDemo.UI.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ComplexUIDemo
{
    [TestFixture]
    public class Class1
    {
        private IWebDriver _driver;

        [OneTimeSetUp]
        public void BeforeSuite()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
        }
        [OneTimeTearDown]
        public void AfterSuite()
        {
            _driver.Quit();
        }

        [Test]
        public void SliderTest()
        {
            
            _driver.Url = "https://demos.telerik.com/kendo-ui/switch/index";
            new SwitchPage(_driver).SetAll(false);

        }

        [Test]
        public void GridTest()
        {
            _driver.Url = "https://demos.telerik.com/kendo-ui/grid/editing";
            var grid = new BatchEditPage(_driver).Grid;
            Console.WriteLine(string.Join(", ", grid.GetColumnContents(1)));
            Console.WriteLine(string.Join(", ", grid.GetColumnContents("Unit Price")));

            Console.WriteLine(string.Join(", ", grid.Rows.First().RowContents));

            grid.Rows.First(row => row.CellAtColumn("ProductName").Text == "Chang")
                .CellAtColumn("ProductName").As<InlineEditable>().Value = "Mang";
        }

        [Test]
        public void TreeTest()
        {
            _driver.Url = "https://demos.telerik.com/kendo-ui/treeview/odata-binding";
            var treeView = new TreeViewPage(_driver).TreeView;
            treeView.GetNode(new List<string> {"Dairy Products", "Mascarpone Fabioli", "10335"}).Select();

            _driver.Url = "https://demos.telerik.com/kendo-ui/treeview/index";

            treeView = new TreeViewPage(_driver).TreeView;
            treeView.GetNodeQuickly(new List<string> { "My Web Site", "resources", "pdf", "brochure.pdf" }).Select();

        }
    }
}
