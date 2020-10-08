using Lab_1.Extension_Methods;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*Tables*/
using ModelTable = Lab_1.DB_OwnersCarsDataSet.ModelDataTable;
using MarkTable = Lab_1.DB_OwnersCarsDataSet.MarkDataTable;

/*Models*/
using Model = Lab_1.DB_OwnersCarsDataSet.ModelRow;
using Mark = Lab_1.DB_OwnersCarsDataSet.MarkRow;

namespace Lab_1.Views {
    public partial class MarkModelForm : System.Windows.Forms.Form {
        private int modelId;
        private int markId;
        private MarkTable marks;
        private ModelTable models;
        private DataRelationCollection relations;

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
            this.FillHeaderCellDGV(this.dataGridView1, new string[] { this.label1.Text });
            this.FillHeaderCellDGV(this.dataGridView2, new string[] { this.label2.Text });

            modelId = 0;
            markId = 0;
            UpdateTables();
            relations = dB_OwnersCarsDataSet.Relations;
        }

        private void UpdateTables() {
            models = dB_OwnersCarsDataSet.Model;
            marks = dB_OwnersCarsDataSet.Mark;
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

                Mark mark = marks.NewMarkRow();
                mark.MarkName = name;

                marks.AddMarkRow(mark);
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

                Mark mark = marks.FirstOrDefault(x => x.Id == markId);
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
                        Mark mark = marks.FirstOrDefault(x => x.Id == markId);
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
                markId = Convert.ToInt32(row.Cells[0].Value);

                Mark mark = marks.FirstOrDefault(x => x.Id == markId);

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

                Model model = models.NewModelRow();
                model.NameModel = name;

                models.AddModelRow(model);
                
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

                Model model = models.FirstOrDefault(x => x.Id == modelId);
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
                        Model model = models.FirstOrDefault(x => x.Id == modelId);
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
                modelId = Convert.ToInt32(row.Cells[0].Value);

                Model model = models.FirstOrDefault(x => x.Id == modelId);

                this.modelTextBox.Text = model.NameModel;
            } catch (Exception) {
            }
        }
        #endregion

    }
}
