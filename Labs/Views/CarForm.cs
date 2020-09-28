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
using CarTable = Lab_1.DB_OwnersCarsDataSet.CarDataTable;

/*Model*/
using Model = Lab_1.DB_OwnersCarsDataSet.ModelRow;
using Mark = Lab_1.DB_OwnersCarsDataSet.MarkRow;
using Car = Lab_1.DB_OwnersCarsDataSet.CarRow;

namespace Lab_1.Views {
    public partial class CarForm : System.Windows.Forms.Form {
        private int carId;
        private CarTable cars;
        private MarkTable marks;
        private ModelTable models;
        private DataRelationCollection relations;

        public CarForm() {
            InitializeComponent();
        }

        private void CarForm_Load(object sender, EventArgs e) => Init();
        private void Button1_Click(object sender, EventArgs e) => this.Close();
        private void CarFormClosing(object sender, FormClosingEventArgs e) => this.dB_OwnersCarsDataSet.AcceptChanges();
       
        private void Init() {
            this.FillHeaderCellDGV(this.dataGridView1, new string[] {
                this.label1.Text,
                this.label2.Text,
                this.label3.Text,
                this.label4.Text,
            });

            UpdateTables();
            FillCarDB();
            UpdateCarsDB();

            this.ModelComboBox.SelectedIndex = 0;
            this.MarkComboBox.SelectedIndex = 0;
        }

        private void UpdateTables() {
            this.cars = dB_OwnersCarsDataSet.Car;
            this.marks = dB_OwnersCarsDataSet.Mark;
            this.models = dB_OwnersCarsDataSet.Model;
            this.relations = dB_OwnersCarsDataSet.Relations;
        }

        private void FillCarDB() {
            this.modelTableAdapter.Fill(this.models);
            this.markTableAdapter.Fill(this.marks);
            this.carTableAdapter.Fill(this.cars);
        }
        
        private void UpdateAdapters() {
            this.carTableAdapter.Update(this.dB_OwnersCarsDataSet);
            this.modelTableAdapter.Update(this.dB_OwnersCarsDataSet);
            this.markTableAdapter.Update(this.dB_OwnersCarsDataSet);
        }

        private void UpdateCarsDB() {
            UpdateAdapters();

            this.dB_OwnersCarsDataSet.Clear();
            this.MarkComboBox.Items.Clear();
            this.ModelComboBox.Items.Clear();

            UpdateTables();
            FillCarDB();
            
            foreach (Mark mark in marks.Rows)
                MarkComboBox.Add(mark.MarkName);

            foreach (Model model in models.Rows)
                ModelComboBox.Add(model.NameModel);

            this.ModelComboBox.SelectedIndex = 0;
            this.MarkComboBox.SelectedIndex = 0;
        }

        #region Работа с данными
        private void AddBtn_Click(object sender, EventArgs e) {
            try {
                string number = this.numberTextBox.Text.Trim();
                string filterModel = $"NameModel='{this.ModelComboBox.With(x => x.SelectedItem)}'";
                string filterMark = $"MarkName='{this.MarkComboBox.With(x => x.SelectedItem)}'";

                if (string.IsNullOrEmpty(number)) {
                    MessageBox.Show("Номер машины не задан!");
                    return;
                }

                Model model = models.With(x => x.Select(filterModel)).With(x => x.First()) as Model;
                Mark mark = marks.With(x => x.Select(filterMark)).With(x => x.First()) as Mark;

                Car car = this.cars.NewCarRow();
                car.DateRegGAI = this.dateReg.Value;
                car.Number = number;
                car.ModelId = model.Id;
                car.MarkId = mark.Id;

                this.cars.AddCarRow(car);

                UpdateCarsDB();
            } catch (NullReferenceException) {
                MessageBox.Show("Один из параметров не задан либо не выбран");
            } catch (Exception) { }
        }

        private void ChangeBtn_Click(object sender, EventArgs e) {
            if (dataGridView1.SelectedRows.Count != 0) {
                try {
                    Car car = this.cars.Where(x => x.Id == carId).First();
                    
                    string filterModel = $"NameModel='{this.ModelComboBox.With(x => x.SelectedItem)}'";
                    string filterMark = $"MarkName='{this.MarkComboBox.With(x => x.SelectedItem)}'";

                    Mark mark = marks.With(x => x.Select(filterMark)).With(x => x.First()) as Mark;
                    Model model = models.With(x => x.Select(filterModel)).With(x => x.First()) as Model;

                    car.MarkId = mark.Id;
                    car.ModelId = model.Id;
                    car.Number = this.numberTextBox.Text;
                    car.DateRegGAI = this.dateReg.Value;
                } catch (NullReferenceException) {
                    MessageBox.Show("Один из параметров не задан либо не выбран");
                } catch (Exception) { }

                UpdateCarsDB();
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
                        Car car = cars.FirstOrDefault(x => x.Id == carId);
                        car.Delete();
                    } catch (Exception) {
                    }

                    UpdateCarsDB();
                }
            } else {
                MessageBox.Show("Выберите строку для удаления", "Ошибка");
            } 
        }
        #endregion

        private void DataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
            try {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                carId = Convert.ToInt32(row.Cells[0].Value);

                Car car = this.cars.Select($"Id='{carId}'").First() as Car;
                Model model = car.GetParentRows(relations["ModelCar"]).With(x => x.First()) as Model;
                Mark mark = car.GetParentRows(relations["MarkCar"]).With(x => x.First()) as Mark;

                this.numberTextBox.Text = car.Number;
                this.dateReg.Value = car.DateRegGAI;
                this.ModelComboBox.SelectedItem = model.NameModel;
                this.MarkComboBox.SelectedItem = mark.MarkName;
            } catch (Exception) {
                MessageBox.Show("Выберите строку для редактирования", "Ошибка");
            }
        }
    }
}
