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
            this.dataGridView1.Location = new System.Drawing.Point(56, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(250, 150);
            this.dataGridView1.TabIndex = 0;
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
            this.dataGridView2.Location = new System.Drawing.Point(312, 12);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(247, 150);
            this.dataGridView2.TabIndex = 1;
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
            this.button1.Location = new System.Drawing.Point(642, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Закрыть";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // MarkModelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 245);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "MarkModelForm";
            this.Text = "MarkModelForm";
            this.Load += new System.EventHandler(this.MarkModelForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.markBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dB_OwnersCarsDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelBindingSource)).EndInit();
            this.ResumeLayout(false);

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
    }
}