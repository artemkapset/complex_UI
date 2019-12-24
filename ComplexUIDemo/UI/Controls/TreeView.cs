using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using ComplexUIDemo.Ext;

namespace ComplexUIDemo.UI.Controls
{
    public class TreeView : Control
    {
        public TreeView(IWebElement element) : base(element)
        {
        }

        protected TreeNode RootNode => this.As<TreeNode>();

        public TreeNode GetNode(List<string> path)
        {
            var currentNode = RootNode;            
            foreach (var nodeTitle in path)
            {
                currentNode = currentNode.GetChildByTitle(nodeTitle);
            }
            return currentNode;
        }

        public TreeNode GetNodeQuickly(List<string> path)
        {
            path = path.Select(folder => folder.Length > 5 ? folder.Substring(0, 5) : folder).ToList();
            var xpathParts = path.Select(node => $"/ul/li[./div//span[contains(., '{node}')]]");
            var resultXpath = "." + string.Join(string.Empty, xpathParts);
            return WrappedElement.Find<TreeNode>(By.XPath(resultXpath));
        }
    }
}
