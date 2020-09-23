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
using CarTable = Lab_1.DB_OwnersCarsDataSet.CarDataTable;
using OwnerTable = Lab_1.DB_OwnersCarsDataSet.OwnerDataTable;
using CarOwnerTable = Lab_1.DB_OwnersCarsDataSet.CarOwnerDataTable;

/*Model*/
using Car = Lab_1.DB_OwnersCarsDataSet.CarRow;
using Owner = Lab_1.DB_OwnersCarsDataSet.OwnerRow;
using CarOwner = Lab_1.DB_OwnersCarsDataSet.CarOwnerRow;

namespace Lab_1.Views {
    public partial class CarOwnerForm : System.Windows.Forms.Form {
        private int carOwnerId;
        private CarTable cars;
        private OwnerTable owners;
        private CarOwnerTable carOwners;
        private DataRelationCollection relations;

        public CarOwnerForm() {
            InitializeComponent();
        }

        private void CarOwnerForm_Load(object sender, EventArgs e) {
            Init();
        }

        private void Init() {
            this.FillHeaderCellDGV(this.dataGridView1, new string[] { 
                this.label1.Text,
                this.label2.Text
            });
            UpdateTables();
            UpdateDB();
        }

        private void UpdateAdapters() {
            this.carTableAdapter.Update(this.dB_OwnersCarsDataSet);
            this.ownerTableAdapter.Update(this.dB_OwnersCarsDataSet);
            this.carOwnerTableAdapter.Update(this.dB_OwnersCarsDataSet);
        }

        private void UpdateTables() {
            this.cars = dB_OwnersCarsDataSet.Car;
            this.owners = dB_OwnersCarsDataSet.Owner;
            this.carOwners = dB_OwnersCarsDataSet.CarOwner;
            this.relations = dB_OwnersCarsDataSet.Relations;
        }

        private void FillDB() {
            this.carTableAdapter.Fill(this.dB_OwnersCarsDataSet.Car);
            this.ownerTableAdapter.Fill(this.dB_OwnersCarsDataSet.Owner);
            this.carOwnerTableAdapter.Fill(this.dB_OwnersCarsDataSet.CarOwner);
        }

        private void UpdateDB() {
            UpdateAdapters();
            this.dB_OwnersCarsDataSet.Clear();
            FillDB();
            
            foreach (Car car in cars) 
                this.carComboBox.Items.Add(car.Number);

            foreach (Owner owner in owners)
                this.ownerComboBox.Add(owner.NumberLicense);

            this.carComboBox.SelectedIndex = this.ownerComboBox.SelectedIndex = 0;
            UpdateTables();
        }

        private void Button4_Click(object sender, EventArgs e) => this.Close();

        #region
        private void AddBtn_Click(object sender, EventArgs e) {
            try {
                string filterCar = $"Number='{this.carComboBox.With(x => x.SelectedItem)}'";
                string filterOwner = $"NumberLicense='{this.ownerComboBox.With(x => x.SelectedItem)}'";

                Owner owner = owners.With(x => x.Select(filterOwner)).With(x => x.First()) as Owner;
                Car car = cars.With(x => x.Select(filterCar)).With(x => x.First()) as Car;

                CarOwner carOwner = this.carOwners.NewCarOwnerRow();
                carOwner.CarId = car.Id;
                carOwner.OwnerId = owner.Id;

                this.carOwners.AddCarOwnerRow(carOwner);

                UpdateDB();
            } catch (NullReferenceException) {
                MessageBox.Show("Один из параметров не задан либо не выбран");
            } catch (Exception) { }
        }

        private void ChangeBtn_Click(object sender, EventArgs e) {
            if (dataGridView1.SelectedRows.Count != 0) {
                try {
                    string filterCar = $"Number='{this.carComboBox.With(x => x.SelectedItem)}'";
                    string filterOwner = $"NumberLicense='{this.ownerComboBox.With(x => x.SelectedItem)}'";

                    Owner owner = owners.With(x => x.Select(filterOwner)).With(x => x.First()) as Owner;
                    Car car = cars.With(x => x.Select(filterCar)).With(x => x.First()) as Car;

                    CarOwner carOwner = carOwners.FirstOrDefault(x => carOwnerId == x.Id);
                    carOwner.CarId = car.Id;
                    carOwner.OwnerId = owner.Id;
                } catch (NullReferenceException) {
                    MessageBox.Show("Один из параметров не задан либо не выбран");
                } catch (Exception) { }

                UpdateDB();
            } else {
                MessageBox.Show("Выберите строку для редактирования", "Ошибка");
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e) {
            if (dataGridView1.SelectedRows.Count != 0) {
                string message = "Вы действительно хотите удалить запись ? ";
                DialogResult response = MessageBox.Show(message, "Подтверждение", MessageBoxButtons.YesNo);

                if (response == DialogResult.Yes) {
                    try {
                        CarOwner carOwner = carOwners.FirstOrDefault(x => x.Id == carOwnerId);
                        carOwner.Delete();
                    } catch (Exception) {
                    }

                    UpdateDB();
                }
            } else {
                MessageBox.Show("Выберите строку для удаления", "Ошибка");
            }
        }
        #endregion

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) {
            try {
                carOwnerId = e.RowIndex + 1;
                CarOwner carOwner = carOwners.FirstOrDefault(x => x.Id == carOwnerId);
                Car car = carOwner.GetParentRows(relations["CarCarOwner"]).With(x => x.First()) as Car;
                Owner owner = carOwner.GetParentRows(relations["OwnerCarOwner"]).With(x => x.First()) as Owner;

                this.carComboBox.SelectedItem = car.Number;
                this.ownerComboBox.SelectedItem = owner.NumberLicense;
            } catch (Exception) {
            }
        }
    }
}
