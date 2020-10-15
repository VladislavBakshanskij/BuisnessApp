using System;
using System.IO;
using System.Windows.Forms;

using Excel = Microsoft.Office.Interop.Excel;

namespace Lab_1.Extension_Methods {
    public static class Form {
        public static void FillHeaderCellDGV(this System.Windows.Forms.Form self, DataGridView dgv, params string[] values) {
            if (dgv == null) {
                throw new ArgumentNullException(nameof(dgv), "Не задана таблица для вывода");
            } else if (values == null) {
                throw new ArgumentNullException(nameof(values), "Не заданы значения для таблицы");
            } else if (dgv.Columns.Count - 1 != values.Length) {
                throw new Exception("Разная размерность в числе колонок и их значений");
            }

            int count = values.Length;
            for (int i = 0; i < count; i++)
                dgv.Columns[i + 1].HeaderText = values[i];
        }

        public static (Excel.Application, Excel.Worksheet) OpenExcelDocument(this System.Windows.Forms.Form self, string path) {
            if (!File.Exists(path)) {
                throw new FileNotFoundException();
            }

            Excel.Application application = new Excel.Application();
            application.Workbooks.Add(path);
            Excel.Workbook workBook = application.Workbooks[1];
            Excel.Sheets excelSheets = workBook.Worksheets;
            Excel.Worksheet workSheet = (Excel.Worksheet)excelSheets[1];

            return (application, workSheet);
        }
    }
}
