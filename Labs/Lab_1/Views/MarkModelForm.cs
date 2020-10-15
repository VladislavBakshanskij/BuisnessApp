using Lab_1.Extension_Methods;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

using Excel = Microsoft.Office.Interop.Excel;

/*Tables*/
using ModelTable = Lab_1.DB_OwnersCarsDataSet.ModelDataTable;
using MarkTable = Lab_1.DB_OwnersCarsDataSet.MarkDataTable;

/*Models*/
using Model = Lab_1.DB_OwnersCarsDataSet.ModelRow;
using Mark = Lab_1.DB_OwnersCarsDataSet.MarkRow;

namespace Lab_1.Views {
    public partial class MarkModelForm : System.Windows.Forms.Form {
        private int _modelId;
        private int _markId;
        private MarkTable _marks;
        private ModelTable _models;

        private Excel.Application _excelApplication;
        private Excel.Worksheet _workSheet;
        private Excel.Range _range;

        public MarkModelForm() {
            InitializeComponent();
        }

        private void MarkModelForm_Load(object sender, EventArgs e) {
            FillDB();
            Init();
        }

        private void FillDB() {
            this.modelTableAdapter.Fill(this.dB_OwnersCarsDataSet.Model);
            this.markTableAdapter.Fill(this.dB_OwnersCarsDataSet.Mark);
        }

        private void UpdateTableAdapters() {
            this.modelTableAdapter.Update(this.dB_OwnersCarsDataSet);
            this.markTableAdapter.Update(this.dB_OwnersCarsDataSet);
        }

        private void UpdateDB() {
            UpdateTableAdapters();
            this.dB_OwnersCarsDataSet.Clear();
            UpdateTables();
            FillDB();
        }

        private void Init() {
            this.FillHeaderCellDGV(this.dataGridView1, this.label1.Text);
            this.FillHeaderCellDGV(this.dataGridView2, this.label2.Text);

            _modelId = 0;
            _markId = 0;
            UpdateTables();
        }

        private void UpdateTables() {
            _models = dB_OwnersCarsDataSet.Model;
            _marks = dB_OwnersCarsDataSet.Mark;
        }

        private void Button1_Click(object sender, EventArgs e) => this.Close();

        #region Mark
        private void MarkBtnAdded_Click(object sender, EventArgs e) {
            try {
                string name = this.markTextBox.Text?.Trim();

                if (string.IsNullOrEmpty(name)) {
                    MessageBox.Show("Не введено название марки");
                    return;
                }

                Mark mark = _marks.NewMarkRow();
                mark.MarkName = name;

                _marks.AddMarkRow(mark);
                UpdateDB();
            } catch(Exception) {  
            }
        }

        private void MarkBtnChanged_Click(object sender, EventArgs e) {
            try {
                string name = this.markTextBox.Text?.Trim();

                if (string.IsNullOrEmpty(name)) {
                    MessageBox.Show("Не введено название марки");
                    return;
                }

                Mark mark = _marks.FirstOrDefault(x => x.Id == _markId);
                mark.MarkName = name;

                UpdateDB();
            } catch (Exception) {
            }
        }

        private void MarkBtnDeleted_Click(object sender, EventArgs e) {
            if (dataGridView1.SelectedRows.Count != 0) {
                string message = "Вы действительно хотите удалить запись ? ";
                DialogResult response = MessageBox.Show(message, "Подтверждение", MessageBoxButtons.YesNo);

                if (response == DialogResult.Yes) {
                    try {
                        Mark mark = _marks.FirstOrDefault(x => x.Id == _markId);
                        mark.Delete();
                    } catch (Exception) {
                    }

                    UpdateDB();
                }
            } else {
                MessageBox.Show("Выберите строку для удаления", "Ошибка");
            }
        }

        private void DataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
            try {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                _markId = Convert.ToInt32(row.Cells[0].Value);

                Mark mark = _marks.FirstOrDefault(x => x.Id == _markId);

                this.markTextBox.Text = mark.MarkName;
            } catch (Exception) {
            }
        }
        #endregion

        #region Model
        private void ModelBtnAdded_Click(object sender, EventArgs e) {
            try {
                string name = this.modelTextBox.Text.With(x => x.Trim());

                if (string.IsNullOrEmpty(name)) {
                    MessageBox.Show("Не введено название марки");
                    return;
                }

                Model model = _models.NewModelRow();
                model.NameModel = name;

                _models.AddModelRow(model);
                
                UpdateDB();
            } catch (Exception) { 
            }
        }

        private void ModelBtnChanged_Click(object sender, EventArgs e) {
            try {
                string name = this.modelTextBox.Text.With(x => x.Trim());

                if (string.IsNullOrEmpty(name)) {
                    MessageBox.Show("Не введено название марки");
                    return;
                }

                Model model = _models.FirstOrDefault(x => x.Id == _modelId);
                model.NameModel = name;

                UpdateDB();
            } catch (Exception) { 
            }
        }

        private void ModelBtnDeleted_Click(object sender, EventArgs e) {
            if (dataGridView2.SelectedRows.Count != 0) {
                string message = "Вы действительно хотите удалить запись ? ";
                DialogResult response = MessageBox.Show(message, "Подтверждение", MessageBoxButtons.YesNo);

                if (response == DialogResult.Yes) {
                    try {
                        Model model = _models.FirstOrDefault(x => x.Id == _modelId);
                        model.Delete();
                    } catch (Exception) {
                    }

                    UpdateDB();
                }
            } else {
                MessageBox.Show("Выберите строку для удаления", "Ошибка");
            }
        }

        private void DataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
            try {
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];
                _modelId = Convert.ToInt32(row.Cells[0].Value);

                Model model = _models.FirstOrDefault(x => x.Id == _modelId);

                this.modelTextBox.Text = model.NameModel;
            } catch (Exception) {
            }
        }
        #endregion

        #region Import data from excel

        private void Open(string path) => (_excelApplication, _workSheet) = this.OpenExcelDocument(path);

        private void button2_Click(object sender, EventArgs e) {
            if (openFileDialog1.ShowDialog() != DialogResult.OK) {
                return;
            }

            string path = openFileDialog1.FileName;

            if (!File.Exists(path)) {
                MessageBox.Show("Файл не найден");
                return;
            }

            Open(path);
            
            /*Super logic working with Excel file!! :)*/
            Excel.Workbook workbook = _excelApplication.Workbooks.Open(path);
            _workSheet = workbook.Sheets[1];
            Excel.Range cells = _workSheet.UsedRange;
            int i; // count rows

            for (i = 3; i <= cells.Count; i++) {
                string value = cells[i, 2].Text.ToString();

                if (string.IsNullOrEmpty(value?.Trim())) {
                    continue;
                } 

                Mark mark = _marks.FirstOrDefault(x => x.MarkName == value);

                if (mark != null) {
                    continue;
                }

                mark = _marks.NewMarkRow();
                mark.MarkName = value;
                mark.Id = Convert.ToInt32(cells[i, 1].Text);
                _marks.AddMarkRow(mark);
            }
        }

        private void button3_Click(object sender, EventArgs e) {
            if (openFileDialog1.ShowDialog() != DialogResult.OK) {
                return;
            }

            string path = openFileDialog1.FileName;

            if (!File.Exists(path)) {
                MessageBox.Show("Файл не был найден!");
                return;
            }

            Open(path);

            Excel.Workbook workbook = _excelApplication.Workbooks.Open(path);
            _workSheet = workbook.Sheets[1];
            Excel.Range cells = _workSheet.UsedRange;
            int i; // count rows

            for (i = 3; i <= cells.Count; i++) {
                string value = cells[i, 2].Text.ToString();

                if (string.IsNullOrEmpty(value?.Trim())) {
                    continue;
                }

                Model model = _models.FirstOrDefault(x => x.NameModel == value);

                if (model != null) {
                    continue;
                }

                model = _models.NewModelRow();
                model.NameModel = value;
                model.Id = Convert.ToInt32(cells[i, 1].Text);
                _models.AddModelRow(model);
            }
        }
        #endregion
    }
}
