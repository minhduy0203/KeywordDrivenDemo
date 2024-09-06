using DemoKeywordDriven.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoKeywordDriven.ExcelReader
{
    public class ExcelReader : IExcelReader
    {
        public static object GetCellData(string xlPath, string sheetName, int row, int column)
        {
            throw new NotImplementedException();
        }

        public static object GetData(Type type, object data)
        {
            throw new NotImplementedException();
        }

        public static int GetTotalRows(string xlPath, string sheetName)
        {
            throw new NotImplementedException();
        }
    }
}
