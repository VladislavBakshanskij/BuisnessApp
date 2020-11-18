using Lab_1.Extension_Methods;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
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

        private Word.Application _wordApplication;
        private Word.Document _wordDocument;

        private Excel.Application _excelApplication;
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
            _wordDocument = _wordApplication.Documents.Add(ref path, ref newTemplate, ref docType, ref visible);
        }

        public void ReplaceText(string word, string replace) {
            object unit = Word.WdUnits.wdStory;
            object extend = Word.WdMovementType.wdMove;

            _wordApplication.Selection.HomeKey(ref unit, ref extend);
            Word.Find fnd = _wordApplication.Selection.Find;

            fnd.ClearFormatting();
            fnd.Text = word;
            fnd.Replacement.ClearFormatting();
            fnd.Replacement.Text = replace;

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


        private void button4_Click(object sender, EventArgs e) {
            OpenDocument($@"{_pathToDocumentDirectory}\список авто.docx");
            ReplaceText("<Today>", DateTime.Today.ToShortDateString());

            object start = 0;
            object end = _wordDocument.Characters.Count;

            Word.Range rng = _wordDocument.Range(ref
                start, ref end);
            rng.TextRetrievalMode.IncludeHiddenText = false;
            rng.TextRetrievalMode.IncludeFieldCodes = false;
            string metka = "<Table>";

            int beginphrase = rng.Text.IndexOf(metka);
            start = beginphrase;

            end = beginphrase + metka.Length;

            if (beginphrase != -1) {
                rng = _wordDocument.Range(ref start, ref end);
                rng.Text = "";

                object defaultTableBehavior = Type.Missing;
                object autoFitBehavior = Type.Missing;

                Word.Table tbl = rng.Tables.Add(rng, 1, 4, ref defaultTableBehavior, ref autoFitBehavior);
                object style = "Сетка таблицы";

                tbl.Range.Font.Size = 14;
                tbl.set_Style(ref style);
                tbl.Cell(1, 1).Range.Text = "№";
                tbl.Cell(1, 2).Range.Text = "Имя марки";
                tbl.Cell(1, 3).Range.Text = "Номер машины";
                tbl.Cell(1, 4).Range.Text = "Дата регистрации в ГАИ";

                int i = 0;

                foreach (Mark mark in dB_OwnersCarsDataSet.Mark) {
                    Car[] cars = mark.GetChildRows(dB_OwnersCarsDataSet.Relations["MarkCar"]) as Car[];

                    if (cars != null && cars.Length < 1 || cars == null) {
                        continue;
                    }

                    string name = mark.MarkName;

                    foreach (Car car in cars) {
                        i++;

                        object beforeRow = Type.Missing;

                        tbl.Rows.Add(ref beforeRow);

                        tbl.Cell(i + 1, 1).Range.Text = i.ToString();
                        tbl.Cell(i + 1, 2).Range.Text = name;
                        tbl.Cell(i + 1, 3).Range.Text = car.Number;
                        tbl.Cell(i + 1, 4).Range.Text = car.DateRegGAI.ToString();
                    }
                }

                tbl.Rows[1].Range.Font.Italic = 1;
                tbl.Rows[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            } else {
                ReplaceText("Table", "");
            }

            _wordApplication.Visible = true;
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

                PutCell($"A{numCell}", owner.FIO());

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
                    PutCellBorder($"B{numCell + 1}", owner.FIO());
                    PutCellBorder($"C{numCell + 1}", car?.Number);
                    PutCellBorder($"D{numCell + 1}", mark?.MarkName);

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
        #endregion

        private void button5_Click(object sender, EventArgs e) {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog()) {
                saveFileDialog.FileName = "index.html";
                saveFileDialog.Filter = "html (*.html)|*.html";

                if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                    string path = saveFileDialog.FileName;

                    using (StreamWriter streamWriter = new StreamWriter(new FileStream(path, FileMode.OpenOrCreate))) {
                        streamWriter.WriteLine(@"
<!doctype html>
<html>
    <head>
        <title>Список владельцев и машин</title>
        <meta charset='UTF-8'/>
        <style>
            table {
                border-collapse: collapse;
                border: 4px double black;
            }

            th {
                text-align: left;
                background: #8BC34A;
                padding: 5px;
                border: 1px solid black;
            }

            td { 
                padding: 5px;
                border: 1px solid black;
            }
        </style>
    </head>
    <body>
        <h1>Список владельцев и машин</h1>
        <table>
            <tr>
                <th>Id владельцев</th>
                <th>ФИО</th>
                <th>Номер авто</th>
                <th>Марка</th>
            </tr>
");

                        foreach (Owner owner in dB_OwnersCarsDataSet.Owner) {
                            CarOwner[] carOwners = owner.GetChildRows("OwnerCarOwner") as CarOwner[];

                            foreach (CarOwner carOwner in carOwners) {
                                Car car = dB_OwnersCarsDataSet.Car.FirstOrDefault(x => x.Id == carOwner.CarId);
                                Mark mark = dB_OwnersCarsDataSet.Mark.FirstOrDefault(x => x.Id == car?.MarkId);

                                streamWriter.Write("<tr>");
                                streamWriter.WriteLine($"<td>{owner.Id}</td>");
                                streamWriter.WriteLine($"<td>{owner.FIO()}</td>");
                                streamWriter.WriteLine($"<td>{car?.Number}</td>");
                                streamWriter.WriteLine($"<td>{mark?.MarkName}</td>");
                                streamWriter.Write("</tr>");
                            }
                        }

                        streamWriter.WriteLine(@"
        </table>
    </body>
</html>
");
                    }
                }
            }
        }

        #endregion

        private void MarkDGV_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
            try {
                DataGridViewRow row = markDGV.Rows[e.RowIndex];
                _markId = Convert.ToInt32(row.Cells[0].Value);
            } catch (Exception) {
            }
        }

        private void Button1_Click(object sender, EventArgs e) => this.Close();
    }
}
