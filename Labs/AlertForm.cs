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

using Word = Microsoft.Office.Interop.Word;

namespace Lab_1 {
    public partial class AlertForm : Form {
        public string Description => this.textBox1.Text;

        public AlertForm() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) => this.Close();

        private void AlertForm_Load(object sender, EventArgs e) {
            this.textBox1.Text = string.Empty;
        }

        private void button2_Click(object sender, EventArgs e) {
            if (this.Description == string.Empty) {
                MessageBox.Show("Введите описание машины");
                return;
            } else if (DateTime.Now < this.dateTimePicker1.Value) {
                MessageBox.Show("Введите правильную дату");
                return;
            }
        }
    }
}
