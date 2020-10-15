using Lab_1.Extension_Methods;
using System;
using System.Data;
using System.IO;
using System.Linq;
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
        private int _carId;
        private CarTable _cars;
        private MarkTable _marks;
        private ModelTable _models;
        private DataRelationCollection _relations;

        public CarForm() {
            InitializeComponent();
        }

        private void CarForm_Load(object sender, EventArgs e) => Init();
        private void Button1_Click(object sender, EventArgs e) => Close();
       
        private void Init() {
            this.FillHeaderCellDGV(dataGridView1, label1.Text, label2.Text, label3.Text, label4.Text);

            UpdateTables();
            FillCarDB();
            UpdateCarsDB();

            ModelComboBox.SelectedIndex = 0;
            MarkComboBox.SelectedIndex = 0;
        }

        private void UpdateTables() {
            _cars = dB_OwnersCarsDataSet.Car;
            _marks = dB_OwnersCarsDataSet.Mark;
            _models = dB_OwnersCarsDataSet.Model;
            _relations = dB_OwnersCarsDataSet.Relations;
        }

        private void FillCarDB() {
            modelTableAdapter.Fill(_models);
            markTableAdapter.Fill(_marks);
            carTableAdapter.Fill(_cars);
        }
        
        private void UpdateAdapters() {
            carTableAdapter.Update(dB_OwnersCarsDataSet);
            modelTableAdapter.Update(dB_OwnersCarsDataSet);
            markTableAdapter.Update(dB_OwnersCarsDataSet);
        }

        private void UpdateCarsDB() {
            UpdateAdapters();

            dB_OwnersCarsDataSet.Clear();
            MarkComboBox.Items.Clear();
            ModelComboBox.Items.Clear();

            UpdateTables();
            FillCarDB();
            
            foreach (Mark mark in _marks)
                MarkComboBox.Add(mark.MarkName);

            foreach (Model model in _models)
                ModelComboBox.Add(model.NameModel);

            ModelComboBox.SelectedIndex = 0;
            MarkComboBox.SelectedIndex = 0;
            numberTextBox.Text = "";
        }

        #region Работа с данными
        private void AddBtn_Click(object sender, EventArgs e) {
            try {
                string number = numberTextBox.Text.Trim();
                string filterModel = $"NameModel='{ModelComboBox.With(x => x.SelectedItem)}'";
                string filterMark = $"MarkName='{MarkComboBox.With(x => x.SelectedItem)}'";

                if (string.IsNullOrEmpty(number)) {
                    MessageBox.Show("Номер машины не задан!");
                    return;
                }

                Model model = _models.With(x => x.Select(filterModel)).With(x => x.First()) as Model;
                Mark mark = _marks.With(x => x.Select(filterMark)).With(x => x.First()) as Mark;

                Car car = _cars.NewCarRow();
                car.DateRegGAI = dateReg.Value;
                car.Number = number;
                car.ModelId = model.Id;
                car.MarkId = mark.Id;

                _cars.AddCarRow(car);

                UpdateCarsDB();
            } catch (NullReferenceException) {
                MessageBox.Show("Один из параметров не задан либо не выбран");
            } catch (Exception) { }
        }

        private void ChangeBtn_Click(object sender, EventArgs e) {
            if (dataGridView1.SelectedRows.Count != 0) {
                try {
                    Car car = _cars.Where(x => x.Id == _carId).First();
                    
                    string filterModel = $"NameModel='{ModelComboBox.With(x => x.SelectedItem)}'";
                    string filterMark = $"MarkName='{MarkComboBox.With(x => x.SelectedItem)}'";

                    Mark mark = _marks.With(x => x.Select(filterMark)).With(x => x.First()) as Mark;
                    Model model = _models.With(x => x.Select(filterModel)).With(x => x.First()) as Model;

                    car.MarkId = mark.Id;
                    car.ModelId = model.Id;
                    car.Number = numberTextBox.Text;
                    car.DateRegGAI = dateReg.Value;
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
                        Car car = _cars.FirstOrDefault(x => x.Id == _carId);
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
                _carId = Convert.ToInt32(row.Cells[0].Value);

                Car car = _cars.Select($"Id='{_carId}'").First() as Car;
                Model model = car.GetParentRows(_relations["ModelCar"]).With(x => x.First()) as Model;
                Mark mark = car.GetParentRows(_relations["MarkCar"]).With(x => x.First()) as Mark;

                numberTextBox.Text = car.Number;
                dateReg.Value = car.DateRegGAI;
                ModelComboBox.SelectedItem = model.NameModel;
                MarkComboBox.SelectedItem = mark.MarkName;
            } catch (Exception) {
                MessageBox.Show("Выберите строку для редактирования", "Ошибка");
            }
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e) {
            if (markCheckBox.Checked) {
                string filterMark = $"MarkName='{MarkComboBox.SelectedItem}'";
                Mark mark = _marks.Select(filterMark).With(x => x.First()) as Mark;
                string filterCar = $"MarkId='{mark.Id}'";
                carBindingSource.Filter = filterCar;
            } else {
                carBindingSource.Filter = "";
            }
        }

        private void ModelCheckBox_CheckedChanged(object sender, EventArgs e) {
            if (modelCheckBox.Checked) {
                string filterModel = $"NameModel='{ModelComboBox.SelectedItem}'";
                Model mark = _models.Select(filterModel).With(x => x.First()) as Model;
                string filterCar = $"ModelId='{mark.Id}'";
                carBindingSource.Filter = filterCar;
            } else {
                carBindingSource.Filter = "";
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            if (openFileDialog1.ShowDialog() != DialogResult.OK) {
                return;
            }

            string path = openFileDialog1.FileName;

            if (!File.Exists(path)) {
                MessageBox.Show("Файл не найден!!");
                return;
            }

            int i;

            for (i = 3;; i++) {
                string value = null;

                if (string.IsNullOrEmpty(value?.Trim())) {
                    break;
                }

                Car car = _cars.FirstOrDefault(x => x.Number == value);

                if (car != null) {
                    break;
                }

                car = _cars.NewCarRow();
                car.Number = value;
                _cars.AddCarRow(car);
            }

            UpdateCarsDB();
        }
    }
}
