using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using ComplexUIDemo.Ext;

namespace ComplexUIDemo.UI.Controls
{
    public class GridRow  : Control
    {
        public GridRow(IWebElement element) : base(element)
        {
        }

        private List<GridCell> _cells;
        protected internal Grid Parent;
        
        public List<string> RowContents
        {
            get
            {
                // return Cells.Select(el => el.Text).ToList();
                var res = ((IJavaScriptExecutor)Driver)
                .ExecuteScript(
                    "var data = []; var elements=arguments[0].querySelectorAll('td'); for (var i=0; i<elements.length; i++) { data.push(elements[i].textContent); } return data;",
                    WrappedElement);
                return ((IList<object>) res).Select(el => el.ToString().Trim()).ToList();
            }
        }

        public List<GridCell> Cells => _cells ?? (_cells = WrappedElement.FindAll<GridCell>(By.CssSelector("td")).ToList());

        public GridCell CellAtColumn(string columnName)
        {
            return Cells.ElementAt(Parent.GetColumnNumberByName(columnName));
        }
    }
}
