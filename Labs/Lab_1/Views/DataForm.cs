using Lab_1.Extension_Methods;
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
using Excel = Microsoft.Office.Interop.Excel;

/*Models*/
using Car = Lab_1.DB_OwnersCarsDataSet.CarRow;
using Mark = Lab_1.DB_OwnersCarsDataSet.MarkRow;
using Owner = Lab_1.DB_OwnersCarsDataSet.OwnerRow;
using Model = Lab_1.DB_OwnersCarsDataSet.ModelRow;
using CarOwner = Lab_1.DB_OwnersCarsDataSet.CarOwnerRow;

namespace Lab_1.Views {
    public partial class DataForm : System.Windows.Forms.Form {
        private readonly string _pathToDocumentDirectory;
        private readonly string _pathToExcelDirectory;
        private readonly Color _color;

        private Excel.Application _excelApplication;
        private Word.Application _wordApplication;
        private Excel.Worksheet _workSheet;
        private Excel.Range _range;

        private int _markId = int.MinValue;

        public DataForm() {
            InitializeComponent();
            _pathToDocumentDirectory = $@"{Application.StartupPath}\docs";
            _pathToExcelDirectory = $@"{Application.StartupPath}\reports";
            _color = Color.FromArgb(33, 150, 243, 255 / 2);
        }

        private void Form1_Load(object sender, EventArgs e) {
            this.carOwnerTableAdapter.Fill(this.dB_OwnersCarsDataSet.CarOwner);
            this.ownerTableAdapter.Fill(this.dB_OwnersCarsDataSet.Owner);
            this.modelTableAdapter.Fill(this.dB_OwnersCarsDataSet.Model);
            this.markTableAdapter.Fill(this.dB_OwnersCarsDataSet.Mark);
            this.carTableAdapter.Fill(this.dB_OwnersCarsDataSet.Car);
        }

        #region Работа с файлами

        #region Работа с word
        private bool ExecuteReplace(Word.Find find) => ExecuteReplace(find, Word.WdReplace.wdReplaceAll);

        private void OpenDocument(object path) {
            if (!File.Exists(path.ToString())) {
                throw new FileNotFoundException();
            }

            object newTemplate = false;
            object docType = Word.WdNewDocumentType.wdNewBlankDocument;
            object visible = true;

            _wordApplication = new Word.Application();
            _ = _wordApplication.Documents.Add(ref path, ref newTemplate, ref docType, ref visible);
        }

        public void ReplaceText(string word, string repl) {
            object unit = Word.WdUnits.wdStory;
            object extend = Word.WdMovementType.wdMove;

            _wordApplication.Selection.HomeKey(ref unit, ref extend);
            Word.Find fnd = _wordApplication.Selection.Find;

            fnd.ClearFormatting();
            fnd.Text = word;
            fnd.Replacement.ClearFormatting();
            fnd.Replacement.Text = repl;

            ExecuteReplace(fnd);
        }

        
        private bool ExecuteReplace(Word.Find find, object replaceOption) {
            object findText = Type.Missing;
            object matchCase = Type.Missing;
            object matchWholeWord = Type.Missing;
            object matchWildcards = Type.Missing;
            object matchSoundsLike = Type.Missing;
            object matchAllWordForms = Type.Missing;
            object forward = Type.Missing;
            object wrap = Type.Missing;
            object format = Type.Missing;
            object replaceWith = Type.Missing;
            object matchKashida = Type.Missing;
            object matchDiacritics = Type.Missing;
            object matchAlefHamza = Type.Missing;
            object matchControl = Type.Missing;

            return find.Execute(
                ref findText, ref matchCase,
                ref matchWholeWord, ref matchWildcards,
                ref matchSoundsLike, ref matchAllWordForms,
                ref forward, ref wrap,
                ref format, ref replaceWith,
                ref replaceOption, ref matchKashida,
                ref matchDiacritics, ref matchAlefHamza, ref matchControl
            );
        }
        #endregion

        #region Работа с excel
        private void PutCell(string cell, string val) {
            _range = _workSheet.Range[cell, Type.Missing];
            _range.Value2 = val;
        }

        private void PutCellBorder(string cell, string val) {
            PutCell(cell, val);
            _range.Interior.Color = ColorTranslator.ToOle(_color);
            _range.Columns.AutoFit();
            _range.BorderAround(
                Excel.XlLineStyle.xlContinuous, 
                Excel.XlBorderWeight.xlThin,
                Excel.XlColorIndex.xlColorIndexAutomatic, 
                Type.Missing
            );
        }
        #endregion

        #endregion

        private void Button1_Click(object sender, EventArgs e) => this.Close();

        private void Button2_Click(object sender, EventArgs e) {
            try {
                if (this._markId == int.MinValue) {
                    MessageBox.Show("Выбирите марку");
                    return;
                }

                AlertForm alertForm = new AlertForm();

                if (alertForm.ShowDialog() == DialogResult.OK) {
                    OpenDocument($@"{_pathToDocumentDirectory}\продажа.docx");

                    Mark mark = dB_OwnersCarsDataSet.Mark.FindById(_markId);
                    
                    ReplaceText("<FIO>", alertForm.FullName);
                    ReplaceText("<Description>", alertForm.Description);
                    ReplaceText("<DateCreation>", alertForm.DateCreation);
                    ReplaceText("<MarkName>", mark.MarkName);
                    ReplaceText("<StateAccurary>", alertForm.StateAccurary);

                    _wordApplication.Visible = true;
                } else {
                    MessageBox.Show("Error!");
                }
            } catch (Exception) {
            }
        }

        private void MarkDGV_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
            try {
                DataGridViewRow row = markDGV.Rows[e.RowIndex];
                _markId = Convert.ToInt32(row.Cells[0].Value);
            } catch (Exception) {
            }
        }

        private string FIO(Owner owner) => $"{owner.FirstName} {owner.SecondName} {owner.MiddleName}";

        private void Button3_Click(object sender, EventArgs e) {
            (_excelApplication, _workSheet) = this.OpenExcelDocument($@"{_pathToExcelDirectory}\spisokCar.xlsx");

            PutCell("F1", DateTime.Now.ToShortDateString());

            for (int i = 0; i < dB_OwnersCarsDataSet.Car.Count; i++) {
                string number = (i + 6).ToString();

                Car car = dB_OwnersCarsDataSet.Car[i];
                Model model = dB_OwnersCarsDataSet.Model.FirstOrDefault(x => x.Id == car.ModelId);
                Mark mark = dB_OwnersCarsDataSet.Mark.FirstOrDefault(x => x.Id == car.MarkId);

                PutCellBorder($"A{number}", car.Id.ToString());
                PutCellBorder($"B{number}", car.Number.ToString());
                PutCellBorder($"C{number}", car.DateRegGAI.ToString());
                PutCellBorder($"D{number}", model.NameModel);
                PutCellBorder($"E{number}", mark.MarkName);
            }
            
            _excelApplication.Visible = true;

            (_excelApplication, _workSheet) = this.OpenExcelDocument($@"{_pathToExcelDirectory}\spisokCarOwner.xlsx");

            PutCell("D1", DateTime.Now.ToShortDateString());
            int numCell = 6;

            foreach (Owner owner in dB_OwnersCarsDataSet.Owner) {
                CarOwner[] carOwners = owner.GetChildRows("OwnerCarOwner") as CarOwner[];

                PutCell($"A{numCell}", FIO(owner));

                _range = _workSheet.get_Range($"A{numCell}", $"D{numCell}");
                _range.Merge(Type.Missing);
                _range.Font.Bold = true;
                _range.Font.Italic = true;
                _range.Interior.ColorIndex = 34;

                _range.BorderAround(
                    Excel.XlLineStyle.xlContinuous, 
                    Excel.XlBorderWeight.xlThin, 
                    Excel.XlColorIndex.xlColorIndexAutomatic, 
                    Type.Missing
                );
                
                _range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                foreach (CarOwner carOwner in carOwners) {
                    Car car = dB_OwnersCarsDataSet.Car.FirstOrDefault(x => x.Id == carOwner.CarId);
                    Mark mark = dB_OwnersCarsDataSet.Mark.FirstOrDefault(x => x.Id == car.MarkId);

                    PutCellBorder($"A{numCell + 1}", car.Id.ToString());
                    PutCellBorder($"B{numCell + 1}", FIO(owner));
                    PutCellBorder($"C{numCell + 1}", car.Number);
                    PutCellBorder($"D{numCell + 1}", mark.MarkName);

                    numCell++;
                }
                numCell++;

                PutCell($"A{numCell}", $"Итого: {carOwners.Length}");

                _range = _workSheet.get_Range($"A{numCell}", $"D{numCell}");
                _range.Merge(Type.Missing);
                _range.Font.Italic = true;
                _range.Interior.ColorIndex = 40;

                _range.BorderAround(
                    Excel.XlLineStyle.xlContinuous, 
                    Excel.XlBorderWeight.xlThin, 
                    Excel.XlColorIndex.xlColorIndexAutomatic, 
                    Type.Missing
                );

                numCell++;
            }

            _excelApplication.Visible = true;
        }
    }
}
