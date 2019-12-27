using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ComplexUIDemo.Ext;
using ComplexUIDemo.UI.Controls;
using ComplexUIDemo.UI.Controls.Tables;
using ComplexUIDemo.UI.Pages;
using ComplexUIDemo.UI.Pages.FormsPage;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

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
            _driver.Quit();
        }

        // 1. TinyMCE
        [Test]
        public void TinyMCETest()
        {
            _driver.Url = "http://the-internet.herokuapp.com/tinymce";

            var page = new TinyMCEPage(_driver);

            page.SetValue(_testString);
            Assert.That(page.GetValue(), Is.EqualTo(_testString));
        }

        // 2. DynamicControl
        [Test]
        public void DynamicControlTest()
        {
            _driver.Url = "http://the-internet.herokuapp.com/dynamic_controls";

            var page = new DynamicControlPage(_driver);
            Assert.True(page.CheckBoxForm.IsCheckBoxPresented());
            Assert.False(page.TextForm.InputTextField.State);

            page.CheckBoxForm.Button.Click();
            page.TextForm.Button.Click();

            page.CheckBoxForm.Button.WaitUntil(_driver => page.CheckBoxForm.Button.Text.Contains("Add"));
            Assert.False(page.CheckBoxForm.IsCheckBoxPresented());

            page.TextForm.Button.WaitUntil(_driver => page.TextForm.Button.Text.Contains("Disable"));
            Assert.True(page.TextForm.InputTextField.State);

            page.CheckBoxForm.Button.Click();
            page.TextForm.Button.Click();

            page.CheckBoxForm.Button.WaitUntil(_driver => page.CheckBoxForm.Button.Text.Contains("Remove"));
            Assert.True(page.CheckBoxForm.IsCheckBoxPresented());

            page.TextForm.Button.WaitUntil(_driver => page.TextForm.Button.Text.Contains("Enable"));
            Assert.False(page.TextForm.InputTextField.State);

            var action = new Actions(_driver);            
        }

        // 3. Forms Pages
        [Test]
        public void FormsPageTest()
        {
            _driver.Url = "http://the-internet.herokuapp.com/login";
            var loginPage = new LoginPage(_driver);
            var securePage = new SecureAreaPage(_driver);

            Console.WriteLine(loginPage.TitleElement.Text);

            Assert.Multiple(() =>
            {
                Assert.True(loginPage.UserNameForm.State);
                Assert.True(loginPage.PasswordForm.State);
                Assert.True(loginPage.LoginButton.State);
            });

            loginPage.UserNameForm.Value = "tomsmith";
            loginPage.PasswordForm.Value = "SuperSecretPassword!";
            loginPage.LoginButton.Click();

            Console.WriteLine(securePage.TitleElement.Text);

            Assert.Multiple(() =>
            {                
                Assert.True(securePage.LogoutButton.State);
                StringAssert.StartsWith("You logged into a secure area!", securePage.FlashForm.Text);                
            });

            securePage.LogoutButton.Click();
            Console.WriteLine(loginPage.TitleElement.Text);

            Assert.Multiple(() =>
            {
                StringAssert.StartsWith("You logged out of the secure area!", loginPage.FlashForm.Text);                
                Assert.True(loginPage.UserNameForm.State);
                Assert.True(loginPage.PasswordForm.State);
                Assert.True(loginPage.LoginButton.State);
            });
        }

        // 4. sort by some column and verify the results
        [Test]
        public void TablesPageTest()
        {
            _driver.Url = "http://the-internet.herokuapp.com/tables";
            var page = new TablesPage(_driver);

            var columnForDefaultSorting = page.Table.GetColumnContent("First Name");
            columnForDefaultSorting.Sort();
      
            var contentListBefore = page.Table.Rows.Select(row => String.Join(" ", row.RowContent)).ToList();

            // выполение сортировки на странице
            page.Table.SotrByColumnName("First Name");

            var columnAfterSortingByClick = page.Table.GetColumnContent("First Name");
            CollectionAssert.AreEqual(columnForDefaultSorting, columnAfterSortingByClick);

            List<string> contentListAfter = page.Table.Rows.Select(row => String.Join(" ", row.RowContent)).ToList();

            CollectionAssert.AreEquivalent(contentListBefore, contentListAfter);
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
