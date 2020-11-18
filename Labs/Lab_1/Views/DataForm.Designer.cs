namespace Lab_1.Views {
    partial class DataForm {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.carDGV = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.markIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.markBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dB_OwnersCarsDataSet = new Lab_1.DB_OwnersCarsDataSet();
            this.dateRegGAIDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modelIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.modelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.carBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.carTableAdapter = new Lab_1.DB_OwnersCarsDataSetTableAdapters.CarTableAdapter();
            this.markDGV = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.markNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.markTableAdapter = new Lab_1.DB_OwnersCarsDataSetTableAdapters.MarkTableAdapter();
            this.modelDGV = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameModelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modelTableAdapter = new Lab_1.DB_OwnersCarsDataSetTableAdapters.ModelTableAdapter();
            this.ownerDGV = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.secondNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.middleNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numberLicenseDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ownerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ownerTableAdapter = new Lab_1.DB_OwnersCarsDataSetTableAdapters.OwnerTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            this.carOwnerDGV = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ownerIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.carIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.carOwnerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.carOwnerTableAdapter = new Lab_1.DB_OwnersCarsDataSetTableAdapters.CarOwnerTableAdapter();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.carDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.markBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dB_OwnersCarsDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.carBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.markDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ownerDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ownerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.carOwnerDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.carOwnerBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // carDGV
            // 
            this.carDGV.AutoGenerateColumns = false;
            this.carDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.carDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.numberDataGridViewTextBoxColumn,
            this.markIdDataGridViewTextBoxColumn,
            this.dateRegGAIDataGridViewTextBoxColumn,
            this.modelIdDataGridViewTextBoxColumn});
            this.carDGV.DataSource = this.carBindingSource;
            this.carDGV.Location = new System.Drawing.Point(12, 12);
            this.carDGV.Name = "carDGV";
            this.carDGV.Size = new System.Drawing.Size(545, 150);
            this.carDGV.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // numberDataGridViewTextBoxColumn
            // 
            this.numberDataGridViewTextBoxColumn.DataPropertyName = "Number";
            this.numberDataGridViewTextBoxColumn.HeaderText = "Number";
            this.numberDataGridViewTextBoxColumn.Name = "numberDataGridViewTextBoxColumn";
            // 
            // markIdDataGridViewTextBoxColumn
            // 
            this.markIdDataGridViewTextBoxColumn.DataPropertyName = "MarkId";
            this.markIdDataGridViewTextBoxColumn.DataSource = this.markBindingSource;
            this.markIdDataGridViewTextBoxColumn.DisplayMember = "MarkName";
            this.markIdDataGridViewTextBoxColumn.HeaderText = "MarkId";
            this.markIdDataGridViewTextBoxColumn.Name = "markIdDataGridViewTextBoxColumn";
            this.markIdDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.markIdDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.markIdDataGridViewTextBoxColumn.ValueMember = "Id";
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
            // dateRegGAIDataGridViewTextBoxColumn
            // 
            this.dateRegGAIDataGridViewTextBoxColumn.DataPropertyName = "DateRegGAI";
            this.dateRegGAIDataGridViewTextBoxColumn.HeaderText = "DateRegGAI";
            this.dateRegGAIDataGridViewTextBoxColumn.Name = "dateRegGAIDataGridViewTextBoxColumn";
            // 
            // modelIdDataGridViewTextBoxColumn
            // 
            this.modelIdDataGridViewTextBoxColumn.DataPropertyName = "ModelId";
            this.modelIdDataGridViewTextBoxColumn.DataSource = this.modelBindingSource;
            this.modelIdDataGridViewTextBoxColumn.DisplayMember = "NameModel";
            this.modelIdDataGridViewTextBoxColumn.HeaderText = "ModelId";
            this.modelIdDataGridViewTextBoxColumn.Name = "modelIdDataGridViewTextBoxColumn";
            this.modelIdDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.modelIdDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.modelIdDataGridViewTextBoxColumn.ValueMember = "Id";
            // 
            // modelBindingSource
            // 
            this.modelBindingSource.DataMember = "Model";
            this.modelBindingSource.DataSource = this.dB_OwnersCarsDataSet;
            // 
            // carBindingSource
            // 
            this.carBindingSource.DataMember = "Car";
            this.carBindingSource.DataSource = this.dB_OwnersCarsDataSet;
            // 
            // carTableAdapter
            // 
            this.carTableAdapter.ClearBeforeFill = true;
            // 
            // markDGV
            // 
            this.markDGV.AutoGenerateColumns = false;
            this.markDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.markDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn1,
            this.markNameDataGridViewTextBoxColumn});
            this.markDGV.DataSource = this.markBindingSource;
            this.markDGV.Location = new System.Drawing.Point(563, 168);
            this.markDGV.Name = "markDGV";
            this.markDGV.Size = new System.Drawing.Size(244, 150);
            this.markDGV.TabIndex = 1;
            this.markDGV.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.MarkDGV_RowHeaderMouseClick);
            // 
            // idDataGridViewTextBoxColumn1
            // 
            this.idDataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn1.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn1.Name = "idDataGridViewTextBoxColumn1";
            // 
            // markNameDataGridViewTextBoxColumn
            // 
            this.markNameDataGridViewTextBoxColumn.DataPropertyName = "MarkName";
            this.markNameDataGridViewTextBoxColumn.HeaderText = "MarkName";
            this.markNameDataGridViewTextBoxColumn.Name = "markNameDataGridViewTextBoxColumn";
            // 
            // markTableAdapter
            // 
            this.markTableAdapter.ClearBeforeFill = true;
            // 
            // modelDGV
            // 
            this.modelDGV.AutoGenerateColumns = false;
            this.modelDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.modelDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn2,
            this.nameModelDataGridViewTextBoxColumn});
            this.modelDGV.DataSource = this.modelBindingSource;
            this.modelDGV.Location = new System.Drawing.Point(563, 12);
            this.modelDGV.Name = "modelDGV";
            this.modelDGV.Size = new System.Drawing.Size(244, 150);
            this.modelDGV.TabIndex = 2;
            // 
            // idDataGridViewTextBoxColumn2
            // 
            this.idDataGridViewTextBoxColumn2.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn2.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn2.Name = "idDataGridViewTextBoxColumn2";
            // 
            // nameModelDataGridViewTextBoxColumn
            // 
            this.nameModelDataGridViewTextBoxColumn.DataPropertyName = "NameModel";
            this.nameModelDataGridViewTextBoxColumn.HeaderText = "NameModel";
            this.nameModelDataGridViewTextBoxColumn.Name = "nameModelDataGridViewTextBoxColumn";
            // 
            // modelTableAdapter
            // 
            this.modelTableAdapter.ClearBeforeFill = true;
            // 
            // ownerDGV
            // 
            this.ownerDGV.AutoGenerateColumns = false;
            this.ownerDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ownerDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn3,
            this.firstNameDataGridViewTextBoxColumn,
            this.secondNameDataGridViewTextBoxColumn,
            this.middleNameDataGridViewTextBoxColumn,
            this.numberLicenseDataGridViewTextBoxColumn});
            this.ownerDGV.DataSource = this.ownerBindingSource;
            this.ownerDGV.Location = new System.Drawing.Point(12, 168);
            this.ownerDGV.Name = "ownerDGV";
            this.ownerDGV.Size = new System.Drawing.Size(545, 150);
            this.ownerDGV.TabIndex = 3;
            // 
            // idDataGridViewTextBoxColumn3
            // 
            this.idDataGridViewTextBoxColumn3.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn3.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn3.Name = "idDataGridViewTextBoxColumn3";
            // 
            // firstNameDataGridViewTextBoxColumn
            // 
            this.firstNameDataGridViewTextBoxColumn.DataPropertyName = "FirstName";
            this.firstNameDataGridViewTextBoxColumn.HeaderText = "FirstName";
            this.firstNameDataGridViewTextBoxColumn.Name = "firstNameDataGridViewTextBoxColumn";
            // 
            // secondNameDataGridViewTextBoxColumn
            // 
            this.secondNameDataGridViewTextBoxColumn.DataPropertyName = "SecondName";
            this.secondNameDataGridViewTextBoxColumn.HeaderText = "SecondName";
            this.secondNameDataGridViewTextBoxColumn.Name = "secondNameDataGridViewTextBoxColumn";
            // 
            // middleNameDataGridViewTextBoxColumn
            // 
            this.middleNameDataGridViewTextBoxColumn.DataPropertyName = "MiddleName";
            this.middleNameDataGridViewTextBoxColumn.HeaderText = "MiddleName";
            this.middleNameDataGridViewTextBoxColumn.Name = "middleNameDataGridViewTextBoxColumn";
            // 
            // numberLicenseDataGridViewTextBoxColumn
            // 
            this.numberLicenseDataGridViewTextBoxColumn.DataPropertyName = "NumberLicense";
            this.numberLicenseDataGridViewTextBoxColumn.HeaderText = "NumberLicense";
            this.numberLicenseDataGridViewTextBoxColumn.Name = "numberLicenseDataGridViewTextBoxColumn";
            // 
            // ownerBindingSource
            // 
            this.ownerBindingSource.DataMember = "Owner";
            this.ownerBindingSource.DataSource = this.dB_OwnersCarsDataSet;
            // 
            // ownerTableAdapter
            // 
            this.ownerTableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(12, 324);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 72);
            this.button1.TabIndex = 4;
            this.button1.Text = "Закрыть";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // carOwnerDGV
            // 
            this.carOwnerDGV.AutoGenerateColumns = false;
            this.carOwnerDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.carOwnerDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn4,
            this.ownerIdDataGridViewTextBoxColumn,
            this.carIdDataGridViewTextBoxColumn});
            this.carOwnerDGV.DataSource = this.carOwnerBindingSource;
            this.carOwnerDGV.Location = new System.Drawing.Point(459, 322);
            this.carOwnerDGV.Name = "carOwnerDGV";
            this.carOwnerDGV.Size = new System.Drawing.Size(348, 74);
            this.carOwnerDGV.TabIndex = 5;
            // 
            // idDataGridViewTextBoxColumn4
            // 
            this.idDataGridViewTextBoxColumn4.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn4.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn4.Name = "idDataGridViewTextBoxColumn4";
            // 
            // ownerIdDataGridViewTextBoxColumn
            // 
            this.ownerIdDataGridViewTextBoxColumn.DataPropertyName = "OwnerId";
            this.ownerIdDataGridViewTextBoxColumn.DataSource = this.ownerBindingSource;
            this.ownerIdDataGridViewTextBoxColumn.DisplayMember = "SecondName";
            this.ownerIdDataGridViewTextBoxColumn.HeaderText = "OwnerId";
            this.ownerIdDataGridViewTextBoxColumn.Name = "ownerIdDataGridViewTextBoxColumn";
            this.ownerIdDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ownerIdDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ownerIdDataGridViewTextBoxColumn.ValueMember = "Id";
            // 
            // carIdDataGridViewTextBoxColumn
            // 
            this.carIdDataGridViewTextBoxColumn.DataPropertyName = "CarId";
            this.carIdDataGridViewTextBoxColumn.DataSource = this.carBindingSource;
            this.carIdDataGridViewTextBoxColumn.DisplayMember = "Number";
            this.carIdDataGridViewTextBoxColumn.HeaderText = "CarId";
            this.carIdDataGridViewTextBoxColumn.Name = "carIdDataGridViewTextBoxColumn";
            this.carIdDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.carIdDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.carIdDataGridViewTextBoxColumn.ValueMember = "Id";
            // 
            // carOwnerBindingSource
            // 
            this.carOwnerBindingSource.DataMember = "CarOwner";
            this.carOwnerBindingSource.DataSource = this.dB_OwnersCarsDataSet;
            // 
            // carOwnerTableAdapter
            // 
            this.carOwnerTableAdapter.ClearBeforeFill = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(90, 324);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(85, 72);
            this.button2.TabIndex = 6;
            this.button2.Text = "Продажа";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(181, 325);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(85, 72);
            this.button3.TabIndex = 7;
            this.button3.Text = "В excel";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Excel Sheet(*.xlsx)|*.xlsx";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(272, 326);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(77, 71);
            this.button4.TabIndex = 8;
            this.button4.Text = "Список авто";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(355, 326);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(74, 70);
            this.button5.TabIndex = 9;
            this.button5.Text = " В HTML";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // DataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 404);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.carOwnerDGV);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ownerDGV);
            this.Controls.Add(this.modelDGV);
            this.Controls.Add(this.markDGV);
            this.Controls.Add(this.carDGV);
            this.Name = "DataForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.carDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.markBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dB_OwnersCarsDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.carBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.markDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ownerDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ownerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.carOwnerDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.carOwnerBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView carDGV;
        private DB_OwnersCarsDataSet dB_OwnersCarsDataSet;
        private System.Windows.Forms.BindingSource carBindingSource;
        private DB_OwnersCarsDataSetTableAdapters.CarTableAdapter carTableAdapter;
        private System.Windows.Forms.DataGridView markDGV;
        private System.Windows.Forms.BindingSource markBindingSource;
        private DB_OwnersCarsDataSetTableAdapters.MarkTableAdapter markTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn markNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridView modelDGV;
        private System.Windows.Forms.BindingSource modelBindingSource;
        private DB_OwnersCarsDataSetTableAdapters.ModelTableAdapter modelTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameModelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridView ownerDGV;
        private System.Windows.Forms.BindingSource ownerBindingSource;
        private DB_OwnersCarsDataSetTableAdapters.OwnerTableAdapter ownerTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn secondNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn middleNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberLicenseDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn markIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateRegGAIDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn modelIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridView carOwnerDGV;
        private System.Windows.Forms.BindingSource carOwnerBindingSource;
        private DB_OwnersCarsDataSetTableAdapters.CarOwnerTableAdapter carOwnerTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewComboBoxColumn ownerIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn carIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}

