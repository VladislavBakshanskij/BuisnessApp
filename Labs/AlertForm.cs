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
    public partial class AlertForm : Form {
        public AlertForm() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) => this.Close();
    }
}
