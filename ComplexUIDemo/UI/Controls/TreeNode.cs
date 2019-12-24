using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComplexUIDemo.Ext;
using NUnit.Framework;
using OpenQA.Selenium;

namespace ComplexUIDemo.UI.Controls
{
    public class TreeNode : Control
    {
        public TreeNode(IWebElement element) : base(element)
        {
        }

        public List<TreeNode> Children => FindAll<TreeNode>(By.XPath("./ul/li"));
        public IWebElement Title => WrappedElement.FindElement(By.CssSelector("span.k-in"));

        public void TryExpand()
        {
            if (WrappedElement.FindElements(By.CssSelector(".k-i-collapse")).Any())
            {
                return;
            }
            try
            {
                WrappedElement.FindElement(By.CssSelector(".k-i-expand")).Click();
                WaitUntil(dr => WrappedElement.FindElements(By.CssSelector("li")).Any());
            }
            catch (Exception e)
            {
                Console.WriteLine($"Cannot expand tree node, exception caught: {e.Message}");
                throw;
            }
        }
        
        public TreeNode GetChildByTitle(string title)
        {
            TryExpand();
            var child = Children.FirstOrDefault(node => node.Title.Text.Trim().Equals(title));
            Assert.IsNotNull(child, $"Child '{title}' was not found");
            return child;
        }

        public TreeNode Select()
        {
            Title.Click();
            return this;
        }
    }
}
