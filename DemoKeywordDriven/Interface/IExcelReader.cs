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

        public abstract static int GetTotalRows(string xlPath, string sheetName);
        public abstract static object GetCellData(string xlPath, string sheetName, int row, int column);
        public abstract static object GetData(Type type, object data);



    }
}
