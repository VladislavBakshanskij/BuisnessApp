using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_1.Extension_Methods {
    public static class Form {
        public static void FillHeaderCellDGV(this System.Windows.Forms.Form self, DataGridView dgv, params string[] values) {
            if (dgv == null) 
                throw new ArgumentNullException(nameof(dgv), "Не задана таблица для вывода");
            else if (values == null)
                throw new ArgumentNullException(nameof(values), "Не заданы значения для таблицы");
            else if (dgv.Columns.Count - 1 != values.Length) 
                throw new Exception("Разная размерность в числе колонок и их значений");
           
            int count = values.Length;
            for (int i = 0; i < count; i++)
                dgv.Columns[i + 1].HeaderText = values[i];
        }
    }
}
