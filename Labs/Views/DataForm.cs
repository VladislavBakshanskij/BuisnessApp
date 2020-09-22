using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_1.Views {
    public partial class DataForm : Form {
        public DataForm() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dB_OwnersCarsDataSet.CarOwner". При необходимости она может быть перемещена или удалена.
            this.carOwnerTableAdapter.Fill(this.dB_OwnersCarsDataSet.CarOwner);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dB_OwnersCarsDataSet.Owner". При необходимости она может быть перемещена или удалена.
            this.ownerTableAdapter.Fill(this.dB_OwnersCarsDataSet.Owner);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dB_OwnersCarsDataSet.Model". При необходимости она может быть перемещена или удалена.
            this.modelTableAdapter.Fill(this.dB_OwnersCarsDataSet.Model);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dB_OwnersCarsDataSet.Mark". При необходимости она может быть перемещена или удалена.
            this.markTableAdapter.Fill(this.dB_OwnersCarsDataSet.Mark);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dB_OwnersCarsDataSet.Car". При необходимости она может быть перемещена или удалена.
            this.carTableAdapter.Fill(this.dB_OwnersCarsDataSet.Car);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dB_OwnersCarsDataSet.Car". При необходимости она может быть перемещена или удалена.
            this.carTableAdapter.Fill(this.dB_OwnersCarsDataSet.Car);
        }

        private void button1_Click(object sender, EventArgs e) => this.Close();
    }
}
