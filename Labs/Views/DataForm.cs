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

namespace Lab_1.Views {
    public partial class DataForm : Form {
        private readonly string PathToDocumentDirectory;
        private Word.Application application;
        private Word.Document document;

        public DataForm() {
            InitializeComponent();
            PathToDocumentDirectory = $@"{Directory.GetCurrentDirectory()}\docs";
        }

        private void Form1_Load(object sender, EventArgs e) {
            this.carOwnerTableAdapter.Fill(this.dB_OwnersCarsDataSet.CarOwner);
            this.ownerTableAdapter.Fill(this.dB_OwnersCarsDataSet.Owner);
            this.modelTableAdapter.Fill(this.dB_OwnersCarsDataSet.Model);
            this.markTableAdapter.Fill(this.dB_OwnersCarsDataSet.Mark);
            this.carTableAdapter.Fill(this.dB_OwnersCarsDataSet.Car);
        }

        #region Работа с файлами
        private bool ExecuteReplace(Word.Find find) => ExecuteReplace(find, Word.WdReplace.wdReplaceAll);

        private void OpenDocument(object path) {
            if (!File.Exists(path.ToString())) {
                throw new FileNotFoundException();
            }

            object newTemplate = false;
            object docType = Word.WdNewDocumentType.wdNewBlankDocument;
            object visible = true;

            application = new Word.Application();
            document = application.Documents.Add(ref path, ref newTemplate, ref docType, ref visible);
        }

        public void ReplaceText(string word, string repl) {
            object unit = Word.WdUnits.wdStory;
            object extend = Word.WdMovementType.wdMove;

            application.Selection.HomeKey(ref unit, ref extend);
            Word.Find fnd = application.Selection.Find;

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

        private void Button1_Click(object sender, EventArgs e) => this.Close();

        private void Button2_Click(object sender, EventArgs e) {
            try {
                AlertForm alertForm = new AlertForm();

                if (alertForm.ShowDialog() == DialogResult.OK) {
                    OpenDocument($@"{PathToDocumentDirectory}\продажа.docx");

                } else {
                    MessageBox.Show("Error!");
                }
            } catch (Exception) {
            }
        }
    }
}
