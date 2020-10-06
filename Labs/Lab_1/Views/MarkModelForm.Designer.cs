namespace Lab_1.Views {
    partial class MarkModelForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.markNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.markBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dB_OwnersCarsDataSet = new Lab_1.DB_OwnersCarsDataSet();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameModelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.markTableAdapter = new Lab_1.DB_OwnersCarsDataSetTableAdapters.MarkTableAdapter();
            this.modelTableAdapter = new Lab_1.DB_OwnersCarsDataSetTableAdapters.ModelTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            this.markTextBox = new System.Windows.Forms.TextBox();
            this.modelTextBox = new System.Windows.Forms.TextBox();
            this.modelBtnAdded = new System.Windows.Forms.Button();
            this.modelBtnChanged = new System.Windows.Forms.Button();
            this.modelBtnDeleted = new System.Windows.Forms.Button();
            this.markBtnDeleted = new System.Windows.Forms.Button();
            this.markBtnChanged = new System.Windows.Forms.Button();
            this.markBtnAdded = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.markBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dB_OwnersCarsDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.markNameDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.markBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 66);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(285, 150);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridView1_RowHeaderMouseClick);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // markNameDataGridViewTextBoxColumn
            // 
            this.markNameDataGridViewTextBoxColumn.DataPropertyName = "MarkName";
            this.markNameDataGridViewTextBoxColumn.HeaderText = "MarkName";
            this.markNameDataGridViewTextBoxColumn.Name = "markNameDataGridViewTextBoxColumn";
            // 
            // markBindingSource
            // 
            this.markBindingSource.DataMember = "Mark";
            this.markBindingSource.DataSource = this.dB_OwnersCarsDataSet;
            // 
            // dB_OwnersCarsDataSet
            // 
            this.dB_OwnersCarsDataSet.DataSetName = "DB_OwnersCarsDataSet";
            this.dB_OwnersCarsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn1,
            this.nameModelDataGridViewTextBoxColumn});
            this.dataGridView2.DataSource = this.modelBindingSource;
            this.dataGridView2.Location = new System.Drawing.Point(333, 66);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(318, 150);
            this.dataGridView2.TabIndex = 1;
            this.dataGridView2.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridView2_RowHeaderMouseClick);
            // 
            // idDataGridViewTextBoxColumn1
            // 
            this.idDataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn1.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn1.Name = "idDataGridViewTextBoxColumn1";
            // 
            // nameModelDataGridViewTextBoxColumn
            // 
            this.nameModelDataGridViewTextBoxColumn.DataPropertyName = "NameModel";
            this.nameModelDataGridViewTextBoxColumn.HeaderText = "NameModel";
            this.nameModelDataGridViewTextBoxColumn.Name = "nameModelDataGridViewTextBoxColumn";
            // 
            // modelBindingSource
            // 
            this.modelBindingSource.DataMember = "Model";
            this.modelBindingSource.DataSource = this.dB_OwnersCarsDataSet;
            // 
            // markTableAdapter
            // 
            this.markTableAdapter.ClearBeforeFill = true;
            // 
            // modelTableAdapter
            // 
            this.modelTableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(544, 280);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 38);
            this.button1.TabIndex = 2;
            this.button1.Text = "Закрыть";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // markTextBox
            // 
            this.markTextBox.Location = new System.Drawing.Point(12, 40);
            this.markTextBox.Name = "markTextBox";
            this.markTextBox.Size = new System.Drawing.Size(100, 20);
            this.markTextBox.TabIndex = 3;
            // 
            // modelTextBox
            // 
            this.modelTextBox.Location = new System.Drawing.Point(333, 40);
            this.modelTextBox.Name = "modelTextBox";
            this.modelTextBox.Size = new System.Drawing.Size(100, 20);
            this.modelTextBox.TabIndex = 4;
            // 
            // modelBtnAdded
            // 
            this.modelBtnAdded.Location = new System.Drawing.Point(333, 222);
            this.modelBtnAdded.Name = "modelBtnAdded";
            this.modelBtnAdded.Size = new System.Drawing.Size(75, 23);
            this.modelBtnAdded.TabIndex = 5;
            this.modelBtnAdded.Text = "Добавить";
            this.modelBtnAdded.UseVisualStyleBackColor = true;
            this.modelBtnAdded.Click += new System.EventHandler(this.ModelBtnAdded_Click);
            // 
            // modelBtnChanged
            // 
            this.modelBtnChanged.Location = new System.Drawing.Point(414, 222);
            this.modelBtnChanged.Name = "modelBtnChanged";
            this.modelBtnChanged.Size = new System.Drawing.Size(75, 23);
            this.modelBtnChanged.TabIndex = 6;
            this.modelBtnChanged.Text = "Изменить";
            this.modelBtnChanged.UseVisualStyleBackColor = true;
            this.modelBtnChanged.Click += new System.EventHandler(this.ModelBtnChanged_Click);
            // 
            // modelBtnDeleted
            // 
            this.modelBtnDeleted.Location = new System.Drawing.Point(495, 222);
            this.modelBtnDeleted.Name = "modelBtnDeleted";
            this.modelBtnDeleted.Size = new System.Drawing.Size(75, 23);
            this.modelBtnDeleted.TabIndex = 7;
            this.modelBtnDeleted.Text = "Удалить";
            this.modelBtnDeleted.UseVisualStyleBackColor = true;
            this.modelBtnDeleted.Click += new System.EventHandler(this.ModelBtnDeleted_Click);
            // 
            // markBtnDeleted
            // 
            this.markBtnDeleted.Location = new System.Drawing.Point(174, 222);
            this.markBtnDeleted.Name = "markBtnDeleted";
            this.markBtnDeleted.Size = new System.Drawing.Size(75, 23);
            this.markBtnDeleted.TabIndex = 10;
            this.markBtnDeleted.Text = "Удалить";
            this.markBtnDeleted.UseVisualStyleBackColor = true;
            this.markBtnDeleted.Click += new System.EventHandler(this.MarkBtnDeleted_Click);
            // 
            // markBtnChanged
            // 
            this.markBtnChanged.Location = new System.Drawing.Point(93, 222);
            this.markBtnChanged.Name = "markBtnChanged";
            this.markBtnChanged.Size = new System.Drawing.Size(75, 23);
            this.markBtnChanged.TabIndex = 9;
            this.markBtnChanged.Text = "Изменить";
            this.markBtnChanged.UseVisualStyleBackColor = true;
            this.markBtnChanged.Click += new System.EventHandler(this.MarkBtnChanged_Click);
            // 
            // markBtnAdded
            // 
            this.markBtnAdded.Location = new System.Drawing.Point(12, 222);
            this.markBtnAdded.Name = "markBtnAdded";
            this.markBtnAdded.Size = new System.Drawing.Size(75, 23);
            this.markBtnAdded.TabIndex = 8;
            this.markBtnAdded.Text = "Добавить";
            this.markBtnAdded.UseVisualStyleBackColor = true;
            this.markBtnAdded.Click += new System.EventHandler(this.MarkBtnAdded_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Название Марки";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(330, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Название модели";
            // 
            // MarkModelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 330);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.markBtnDeleted);
            this.Controls.Add(this.markBtnChanged);
            this.Controls.Add(this.markBtnAdded);
            this.Controls.Add(this.modelBtnDeleted);
            this.Controls.Add(this.modelBtnChanged);
            this.Controls.Add(this.modelBtnAdded);
            this.Controls.Add(this.modelTextBox);
            this.Controls.Add(this.markTextBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "MarkModelForm";
            this.Text = "MarkModelForm";
            this.Load += new System.EventHandler(this.MarkModelForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.markBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dB_OwnersCarsDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private DB_OwnersCarsDataSet dB_OwnersCarsDataSet;
        private System.Windows.Forms.BindingSource markBindingSource;
        private DB_OwnersCarsDataSetTableAdapters.MarkTableAdapter markTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn markNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.BindingSource modelBindingSource;
        private DB_OwnersCarsDataSetTableAdapters.ModelTableAdapter modelTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameModelDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox markTextBox;
        private System.Windows.Forms.TextBox modelTextBox;
        private System.Windows.Forms.Button modelBtnAdded;
        private System.Windows.Forms.Button modelBtnChanged;
        private System.Windows.Forms.Button modelBtnDeleted;
        private System.Windows.Forms.Button markBtnDeleted;
        private System.Windows.Forms.Button markBtnChanged;
        private System.Windows.Forms.Button markBtnAdded;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}