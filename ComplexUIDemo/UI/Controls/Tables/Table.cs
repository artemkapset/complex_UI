using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComplexUIDemo.Ext;
using OpenQA.Selenium;

namespace ComplexUIDemo.UI.Controls.Tables
{
    public class Table : Control
    {
        public Table(IWebElement element) : base(element)
        {
        }

        // строка с заголовками 
        public TitleRow TitleRow => WrappedElement.Find<TitleRow>(TitleRow.TitleRowLocator);

        // список строк с содержимым таблицы
        public List<Row> Rows => WrappedElement.FindAll<Row>(Row.DefaultLocator).ToList();
        

        private List<string> _columnNames;
        public List<string> ColumnNames => _columnNames ?? (_columnNames = TitleRow.TitleRowContent);
        
        public List<string> GetColumnContents(int columnNumber)
        {
            return WrappedElement.FindAll<Cell>(By.XPath($".//td[{columnNumber + 1}]")).Select(el => el.Text.Trim()).ToList();
        }

        public List<string> GetColumnContent(string columnName)
        {
            return GetColumnContents(GetColumnNumberByName(columnName));
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

        public void SotrByColumnName(string name)
        {
            TitleRow.Cells.First(el => el.Text.Equals(name)).Click();
        }
    }
}
