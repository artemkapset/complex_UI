using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    public class TestingClass
    {
        private IWebDriver _driver;
        private string _testString = "Test string";

        [OneTimeSetUp]
        public void BeforeSuite()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
        }
        [OneTimeTearDown]
        public void AfterSuite()
        {
            //_driver.Quit();
        }

        [Test]
        public void TinyMCETest()
        {
            _driver.Url = "http://the-internet.herokuapp.com/tinymce";
            var page = new TinyMCEPage(_driver);
            page.SetValue(_testString);
            Assert.That(page.GetValue(), Is.EqualTo(_testString));
        }

        [Test]
        public void DynamicControlTest()
        {
            _driver.Url = "http://the-internet.herokuapp.com/dynamic_controls";
            var page = new DynamicControlPage(_driver);
            page.Form.IsElementPresented();
            //Thread.Sleep(TimeSpan.FromSeconds(2));
            page.Form.Button.Click();
            //page.Form.Button.WaitUntil<bool>(_driver => !page.Form.Button.Text.Contains("Add"));
            Thread.Sleep(TimeSpan.FromSeconds(5));
            page.Form.IsElementPresented();
        }

        //[Test]
        //public void SliderTest()
        //{
            
        //    _driver.Url = "https://demos.telerik.com/kendo-ui/switch/index";
        //    new SwitchPage(_driver).SetAll(false);

        //}

        //[Test]
        //public void GridTest()
        //{
        //    _driver.Url = "https://demos.telerik.com/kendo-ui/grid/editing";
        //    var grid = new BatchEditPage(_driver).Grid;
        //    Console.WriteLine(string.Join(", ", grid.GetColumnContents(1)));
        //    Console.WriteLine(string.Join(", ", grid.GetColumnContents("Unit Price")));

        //    Console.WriteLine(string.Join(", ", grid.Rows.First().RowContents));

        //    grid.Rows.First(row => row.CellAtColumn("ProductName").Text == "Chang")
        //        .CellAtColumn("ProductName").As<InlineEditable>().Value = "Mang";
        //}

        //[Test]
        //public void TreeTest()
        //{
        //    _driver.Url = "https://demos.telerik.com/kendo-ui/treeview/odata-binding";
        //    var treeView = new TreeViewPage(_driver).TreeView;
        //    treeView.GetNode(new List<string> {"Dairy Products", "Mascarpone Fabioli", "10335"}).Select();

        //    _driver.Url = "https://demos.telerik.com/kendo-ui/treeview/index";

        //    treeView = new TreeViewPage(_driver).TreeView;
        //    treeView.GetNodeQuickly(new List<string> { "My Web Site", "resources", "pdf", "brochure.pdf" }).Select();

        //}
    }
}
