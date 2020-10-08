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
        private readonly string PathToDocumentDirectory;
        private readonly string PathToExcelDirectory;

        private Word.Application wordApplication;
        private Word.Document document;

        private Excel.Application excelApplication;
        private Excel.Window ExcelWindow;
        private Excel.Workbook WorkBook;
        private Excel.Sheets ExcelSheets;
        private Excel.Worksheet WorkSheet;
        private Excel.Range range;

        private int markId = int.MinValue;

        public DataForm() {
            InitializeComponent();
            PathToDocumentDirectory = $@"{Application.StartupPath}\docs";
            PathToExcelDirectory = $@"{Application.StartupPath}\reports";
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

            wordApplication = new Word.Application();
            document = wordApplication.Documents.Add(ref path, ref newTemplate, ref docType, ref visible);
        }

        public void ReplaceText(string word, string repl) {
            object unit = Word.WdUnits.wdStory;
            object extend = Word.WdMovementType.wdMove;

            wordApplication.Selection.HomeKey(ref unit, ref extend);
            Word.Find fnd = wordApplication.Selection.Find;

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
            range = WorkSheet.Range[cell, Type.Missing];
            range.Value2 = val;
        }

        private void PutCellBorder(string cell, string val) {
            PutCell(cell, val);
            range.Interior.Color = ColorTranslator.ToOle(Color.FromArgb(33, 150, 243, 255 / 2));
            range.Columns.AutoFit();
            range.BorderAround(
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
                if (this.markId == int.MinValue) {
                    MessageBox.Show("Выбирите марку");
                    return;
                }

                AlertForm alertForm = new AlertForm();

                if (alertForm.ShowDialog() == DialogResult.OK) {
                    OpenDocument($@"{PathToDocumentDirectory}\продажа.docx");

                    Mark mark = dB_OwnersCarsDataSet.Mark.FindById(markId);
                    
                    ReplaceText("<FIO>", alertForm.FullName);
                    ReplaceText("<Description>", alertForm.Description);
                    ReplaceText("<DateCreation>", alertForm.DateCreation);
                    ReplaceText("<MarkName>", mark.MarkName);
                    ReplaceText("<StateAccurary>", alertForm.StateAccurary);

                    wordApplication.Visible = true;
                } else {
                    MessageBox.Show("Error!");
                }
            } catch (Exception) {
            }
        }

        private void MarkDGV_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
            try {
                DataGridViewRow row = markDGV.Rows[e.RowIndex];
                markId = Convert.ToInt32(row.Cells[0].Value);
            } catch (Exception) {
            }
        }

        private string FIO(Owner owner) => $"{owner.FirstName} {owner.SecondName} {owner.MiddleName}";

        private void Button3_Click(object sender, EventArgs e) {
            this.OpenExcelDocument(
                $@"{PathToExcelDirectory}\spisokCar.xlsx",
                out excelApplication,
                out WorkBook,
                out ExcelSheets,
                out WorkSheet
            );

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
            
            excelApplication.Visible = true;

            this.OpenExcelDocument(
                $@"{PathToExcelDirectory}\spisokCarOwner.xlsx",
                out excelApplication,
                out WorkBook,
                out ExcelSheets,
                out WorkSheet
            );

            PutCell("D1", DateTime.Now.ToShortDateString());
            int numCell = 6;

            foreach (Owner owner in dB_OwnersCarsDataSet.Owner) {
                CarOwner[] carOwners = owner.GetChildRows("OwnerCarOwner") as CarOwner[];

                PutCell($"A{numCell}", FIO(owner));

                range = WorkSheet.get_Range($"A{numCell}", $"D{numCell}");
                range.Merge(Type.Missing);
                range.Font.Bold = true;
                range.Font.Italic = true;
                range.Interior.ColorIndex = 34;

                range.BorderAround(
                    Excel.XlLineStyle.xlContinuous, 
                    Excel.XlBorderWeight.xlThin, 
                    Excel.XlColorIndex.xlColorIndexAutomatic, 
                    Type.Missing
                );
                
                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

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

                range = WorkSheet.get_Range($"A{numCell}", $"D{numCell}");
                range.Merge(Type.Missing);
                range.Font.Italic = true;
                range.Interior.ColorIndex = 40;

                range.BorderAround(
                    Excel.XlLineStyle.xlContinuous, 
                    Excel.XlBorderWeight.xlThin, 
                    Excel.XlColorIndex.xlColorIndexAutomatic, 
                    Type.Missing
                );

                numCell++;
            }

            excelApplication.Visible = true;
        }
    }
}
