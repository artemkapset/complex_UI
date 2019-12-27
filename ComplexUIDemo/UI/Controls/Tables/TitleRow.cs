using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComplexUIDemo.Ext;
using OpenQA.Selenium;

namespace ComplexUIDemo.UI.Controls.Tables
{
    public class TitleRow : Control
    {
        public TitleRow(IWebElement element) : base(element)
        {
        }

        public static By TitleRowLocator = By.XPath(".//thead/tr");

        private List<Cell> _cells;
        public List<Cell> Cells => _cells ?? (_cells = WrappedElement.FindAll<Cell>(Cell.TitleCellDefaultLocator).ToList());
        
        public List<string> TitleRowContent => Cells.Select(el => el.Text.Trim()).ToList();
    }
}
