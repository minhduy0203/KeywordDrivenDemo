using DemoKeywordDriven.Interface;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoKeywordDriven.ExcelReader
{
    public class ExcelReaderHelper : IExcelReader, IDisposable
    {


        #region Fields
        private static ExcelPackage _package { get; set; }

        #endregion


        #region Constructors
        public ExcelReaderHelper()
        {

        }
        public ExcelReaderHelper(string fileName) : this(new FileInfo(fileName))
        {
            
        }

        public ExcelReaderHelper(FileInfo fileInfo)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            _package = new ExcelPackage(fileInfo);
          


        }


        #endregion


        #region Public


        public int GetAllSheetCount()
        {
            return _package.Workbook.Worksheets.Count;
        }

        public List<string> GetAllSheetName()
        {
            return _package.Workbook.Worksheets.Select(sheet => sheet.Name).ToList();
        }

        public object GetCellData(string sheetName, int row, int column)
        {
            return _package.Workbook.Worksheets[sheetName].Cells[row, column].Text;
        }

        public object GetData(Type type, object data)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, int> GetTestCaseRowNo(string sheet, int column = 3)
        {
            var totalRows = GetTotalRows(sheet);
            var testCaseId = new Dictionary<string, int>();

            for (var i = 2; i <= totalRows; i++)
            {
                var celValue = GetCellData(sheet, i, column);
                if (!testCaseId.ContainsKey((string)celValue))
                {
                    testCaseId.Add((string)celValue, i);
                }
            }
            return testCaseId;
        }

        public int GetTotalRows(string sheetName)
        {
            var count = 1;

            while (!GetCellData(sheetName, count, 1).Equals(string.Empty))
            {
                count++;
            }

            return --count;
        }

        public void SaveSheet(string filePassword)
        {
            _package.Save(filePassword);
        }

        public void SaveSheet()
        {
            _package.Save();
        }

        public void WriteToCell(string sheetName, int row, int column, string value)
        {
            _package.Workbook.Worksheets[sheetName].Cells[row, column].Value = value;
            _package.Workbook.Worksheets[sheetName].Cells[row, column].Style.Font.Bold = true;
            _package.Workbook.Worksheets[sheetName].Cells[row, column].Style.Fill.PatternType = ExcelFillStyle.Solid;
            _package.Workbook.Worksheets[sheetName].Cells[row, column].Style.Fill.BackgroundColor.SetColor(value.Equals("Fail",
                StringComparison.OrdinalIgnoreCase)
                ? Color.Red
                : Color.Green);
            _package.Workbook.Worksheets[sheetName].Cells[row, column].AutoFitColumns();
        }



        #endregion

        #region Dispose
        public void Dispose()
        {
            _package.Dispose();
        }

        #endregion
    }
}
