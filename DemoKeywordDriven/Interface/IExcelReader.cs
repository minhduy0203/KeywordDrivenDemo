using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoKeywordDriven.Interface
{
    public interface IExcelReader
    {

        public abstract int GetTotalRows(string sheetName);
        public abstract object GetCellData(string sheetName, int row, int column);
        public abstract object GetData(Type type, object data);
        public abstract List<string> GetAllSheetName();
        public abstract int GetAllSheetCount();
        public abstract IDictionary<string, int> GetTestCaseRowNo(string sheet, int column = 1);

        public abstract void SaveSheet(string filePassword = "");

        public void SaveSheet();
       
        public abstract void WriteToCell(string sheetName, int row, int column, string value);

        public abstract bool IsWorkSheetFound(string sheetName);
      





    }
}
