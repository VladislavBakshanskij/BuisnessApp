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
using OwnerTable = Lab_1.DB_OwnersCarsDataSet.OwnerDataTable;

/*Models*/
using Owner = Lab_1.DB_OwnersCarsDataSet.OwnerRow;

namespace Lab_1.Views {
    public partial class OwnerForm : System.Windows.Forms.Form {
        private int ownerId;
        private OwnerTable owners;

        public OwnerForm() {
            InitializeComponent();
        }

        private void OwnerForm_Load(object sender, EventArgs e) {
            Init();
        }

        private void UpdateDB() {
            this.ownerTableAdapter.Update(this.dB_OwnersCarsDataSet);
            this.dB_OwnersCarsDataSet.Clear();
            this.ownerTableAdapter.Fill(this.dB_OwnersCarsDataSet.Owner);
        }

        private void Init() {
            this.ownerTableAdapter.Fill(this.dB_OwnersCarsDataSet.Owner);
            this.FillHeaderCellDGV(this.dataGridView1, new string[] {
                this.label1.Text,
                this.label2.Text,
                this.label3.Text,
                this.label4.Text,
            });
            owners = this.dB_OwnersCarsDataSet.Owner;
        }

        private void Button1_Click(object sender, EventArgs e) => this.Close();

        #region
        private void AddBtn_Click(object sender, EventArgs e) {
            try {
                Owner owner = owners.NewOwnerRow();
                owner.FirstName = this.firstNameTextBox.Text.With(x => x.Trim());
                owner.SecondName = this.lastNameTextBox.Text.With(x => x.Trim());
                owner.MiddleName = this.middleNameTextBox.Text.With(x => x.Trim());
                owner.NumberLicense = this.numberLicenseTextBox.Text.With(x => x.Trim());

                if (!ValidOwner(owner)) 
                    return;

                this.owners.AddOwnerRow(owner);
                UpdateDB();
            } catch (NullReferenceException) {
            } catch (Exception) {
            }
        }

        private bool ValidOwner(Owner owner) {
            if (
                string.IsNullOrEmpty(owner.FirstName) ||
                string.IsNullOrEmpty(owner.SecondName) ||
                string.IsNullOrEmpty(owner.MiddleName) ||
                string.IsNullOrEmpty(owner.NumberLicense)
            ) {
                MessageBox.Show("Не задано либо имя, либо фаимилия, либо отчество, либо права");
                return false;
            } else if (owner.NumberLicense.Length != 10) {
                MessageBox.Show("Права введены не полностью");
                return false;
            }

            return true;
        }

        private void ChangeBtn_Click(object sender, EventArgs e) {
            try {
                Owner owner = owners.FirstOrDefault(x => x.Id == ownerId);
                if (!ValidOwner(owner))
                    return;

                owner.FirstName = firstNameTextBox.Text;
                owner.SecondName = lastNameTextBox.Text;
                owner.MiddleName = middleNameTextBox.Text;
                owner.NumberLicense = numberLicenseTextBox.Text;

                owners.AcceptChanges();
                UpdateDB();
            } catch (Exception) { 
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e) {
            if (dataGridView1.SelectedRows.Count != 0) {
                string message = "Вы действительно хотите удалить запись ? ";
                DialogResult response = MessageBox.Show(message, "Подтверждение", MessageBoxButtons.YesNo);

                if (response == DialogResult.Yes) {
                    try {
                        Owner owner = owners.FirstOrDefault(x => x.Id == ownerId);
                        owner.Delete();
                    } catch (Exception) {
                    }

                    UpdateDB();
                }
            } else {
                MessageBox.Show("Выберите строку для удаления", "Ошибка");
            }
        }
        #endregion

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) {
            try {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                ownerId = Convert.ToInt32(row.Cells[0].Value);
                
                Owner owner = owners.FirstOrDefault(x => x.Id == ownerId);

                this.firstNameTextBox.Text = owner.FirstName;
                this.lastNameTextBox.Text = owner.SecondName;
                this.middleNameTextBox.Text = owner.MiddleName;
                this.numberLicenseTextBox.Text = owner.NumberLicense;
            } catch (Exception) { 
            }
        }
    }
}
