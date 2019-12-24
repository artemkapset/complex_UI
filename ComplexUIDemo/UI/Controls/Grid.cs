using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using ComplexUIDemo.Ext;

namespace ComplexUIDemo.UI.Controls
{
    public class Grid : Control
    {
        public Grid(IWebElement element) : base(element)
        {
        }

        private List<string> _columnNames;
        

        // We have to use last() because in some cases we can have only one table (without table for grid columns).
        // + we select only visible rows  

        public List<GridRow> Rows => WrappedElement.FindAll<GridRow>(By.XPath(".//table[last()]/tbody/tr[not(contains(@style, 'none'))]")).Select(
            el =>
            {
                el.Parent = this;
                return el;
            }).ToList();

        
        protected List<string> ColumnNames
        {
            get
            {
                return _columnNames ?? (_columnNames = WrappedElement.FindElements(By.CssSelector(".k-grid-header table tr th"))
                    .Where(el => el.Displayed)
                    .Select(header => header.Text.Replace("Filter", String.Empty).Trim())
                    .ToList());
            }
        }

        public List<string> GetColumnContents(string columnName)
        {
            return GetColumnContents(GetColumnNumberByName(columnName));
        }

        public List<string> GetColumnContents(int columnNumber)
        {
           // return WrappedElement.FindElements(By.XPath($"(.//table[last()]/tbody//tr)/td[{columnNumber + 1}]")).Select(el => el.Text.Trim()).ToList();
           var table = WrappedElement.FindElement(By.XPath(".//table[last()]/tbody"));
           var res = ((IJavaScriptExecutor)Driver)
                .ExecuteScript(
                    "var data = []; var elements=arguments[0].querySelectorAll('tr'); for (var i=0; i<elements.length; i++) { data.push(elements[i].querySelectorAll('td')[arguments[1]].textContent); } return data;",
                    table,
                    columnNumber);
            return ((IList<object>) res).Select(el => el.ToString().Trim()).ToList();
        }

        protected internal int GetColumnNumberByName(string columnName)
        {
            int index = ColumnNames.IndexOf(columnName);

            if (index == -1)
            {
                throw new Exception($"Column with name '{columnName}' is not found");
            }

            return index;
        }
        
    }
}
