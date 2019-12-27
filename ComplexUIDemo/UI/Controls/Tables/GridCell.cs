using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace ComplexUIDemo.UI.Controls
{
    public class GridCell : Control
    {
        public GridCell(IWebElement element) : base(element)
        {
        }


        public string Text => WrappedElement.Text;
    }
}
