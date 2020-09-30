using Lab_1.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_1 {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
        }

        private void ClosedBtn_Click(object sender, EventArgs e) => this.Close();

        #region Формы
        private void AllDataBtn_Click(object sender, EventArgs e) {
            DataForm df = new DataForm() {
                Text = this.AllDataBtn.Text
            };
            df.ShowDialog();
        }

        private void CarBtn_Click(object sender, EventArgs e) {
            CarForm cf = new CarForm() {
                Text = this.CarBtn.Text
            };
            cf.ShowDialog();
        }

        private void CarOwnerBtn_Click(object sender, EventArgs e) {
            CarOwnerForm cof = new CarOwnerForm() {
                Text = this.CarOwnerBtn.Text
            };
            cof.ShowDialog();
        }

        private void OwnerBtn_Click(object sender, EventArgs e) {
            OwnerForm of = new OwnerForm() {
                Text = this.OwnerBtn.Text
            };
            of.ShowDialog();
        }

        private void MarkModelBtn_Click(object sender, EventArgs e) {
            MarkModelForm mmf = new MarkModelForm() { 
                Text = this.MarkModelBtn.Text
            };
            mmf.ShowDialog();
        }
        #endregion

        private void Button1_Click(object sender, EventArgs e) {
            AlertForm alertForm = new AlertForm();
            alertForm.ShowDialog();
        }
    }
}
