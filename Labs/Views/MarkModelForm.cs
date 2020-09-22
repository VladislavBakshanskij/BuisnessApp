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
            this.FillHeaderCellDGV(this.dataGridView1, new string[] { });
            this.FillHeaderCellDGV(this.dataGridView2, new string[] { });

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
    }
}
