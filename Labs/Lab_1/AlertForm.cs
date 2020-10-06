using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Lab_1 {
    public partial class AlertForm : Form {
        public string Description => this.textBox1.Text;
        public string FullName => this.textBox2.Text;
        public string StateAccurary => this.comboBox1.Text;
        public string DateCreation => this.dateTimePicker1.Value.ToLongDateString();

        public AlertForm() => InitializeComponent();

        private void AlertForm_Load(object sender, EventArgs e) {
            this.textBox1.Text = string.Empty;
            this.textBox2.Text = string.Empty;
            this.comboBox1.SelectedIndex = 0;
        }

        private void Button1_Click(object sender, EventArgs e) => this.Close();

        private void Button2_Click(object sender, EventArgs e) {
            if (this.Description == string.Empty) {
                MessageBox.Show("Введите описание машины");
                return;
            } else if (DateTime.Now < this.dateTimePicker1.Value) {
                MessageBox.Show("Введите правильную дату");
                return;
            } else if (this.FullName == string.Empty) {
                MessageBox.Show("Введите ФИО");
                return;
            }

            this.DialogResult = DialogResult.OK;
        }
    }
}
