using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComplexUIDemo.Ext;
using OpenQA.Selenium;

namespace ComplexUIDemo.UI.Controls.Tables
{
    public class Row : Control
    {
        public Row(IWebElement element) : base(element)
        {
        }
        
        public static By DefaultLocator = By.XPath(".//tbody/tr");

        private List<Cell> _cells;
        public List<Cell> Cells => _cells ?? (_cells = WrappedElement.FindAll<Cell>(Cell.DefaultLocator).ToList());

        public List<string> RowContent => Cells.Select(el => el.Text.Trim()).ToList();
    }
}
