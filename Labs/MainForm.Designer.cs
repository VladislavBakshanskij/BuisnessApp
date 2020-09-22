namespace Lab_1 {
    partial class MainForm {
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
            this.AllDataBtn = new System.Windows.Forms.Button();
            this.CarBtn = new System.Windows.Forms.Button();
            this.CarOwnerBtn = new System.Windows.Forms.Button();
            this.MarkModelBtn = new System.Windows.Forms.Button();
            this.OwnerBtn = new System.Windows.Forms.Button();
            this.ClosedBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AllDataBtn
            // 
            this.AllDataBtn.Location = new System.Drawing.Point(12, 12);
            this.AllDataBtn.Name = "AllDataBtn";
            this.AllDataBtn.Size = new System.Drawing.Size(244, 56);
            this.AllDataBtn.TabIndex = 0;
            this.AllDataBtn.Text = "Все таблицы";
            this.AllDataBtn.UseVisualStyleBackColor = true;
            this.AllDataBtn.Click += new System.EventHandler(this.AllDataBtn_Click);
            // 
            // CarBtn
            // 
            this.CarBtn.Location = new System.Drawing.Point(12, 74);
            this.CarBtn.Name = "CarBtn";
            this.CarBtn.Size = new System.Drawing.Size(244, 56);
            this.CarBtn.TabIndex = 1;
            this.CarBtn.Text = "Автомобили";
            this.CarBtn.UseVisualStyleBackColor = true;
            this.CarBtn.Click += new System.EventHandler(this.CarBtn_Click);
            // 
            // CarOwnerBtn
            // 
            this.CarOwnerBtn.Location = new System.Drawing.Point(12, 136);
            this.CarOwnerBtn.Name = "CarOwnerBtn";
            this.CarOwnerBtn.Size = new System.Drawing.Size(244, 56);
            this.CarOwnerBtn.TabIndex = 2;
            this.CarOwnerBtn.Text = "Владельцы с авто";
            this.CarOwnerBtn.UseVisualStyleBackColor = true;
            this.CarOwnerBtn.Click += new System.EventHandler(this.CarOwnerBtn_Click);
            // 
            // MarkModelBtn
            // 
            this.MarkModelBtn.Location = new System.Drawing.Point(12, 198);
            this.MarkModelBtn.Name = "MarkModelBtn";
            this.MarkModelBtn.Size = new System.Drawing.Size(244, 56);
            this.MarkModelBtn.TabIndex = 3;
            this.MarkModelBtn.Text = "Марка и модель авто";
            this.MarkModelBtn.UseVisualStyleBackColor = true;
            this.MarkModelBtn.Click += new System.EventHandler(this.MarkModelBtn_Click);
            // 
            // OwnerBtn
            // 
            this.OwnerBtn.Location = new System.Drawing.Point(12, 260);
            this.OwnerBtn.Name = "OwnerBtn";
            this.OwnerBtn.Size = new System.Drawing.Size(244, 56);
            this.OwnerBtn.TabIndex = 5;
            this.OwnerBtn.Text = "Владельцы";
            this.OwnerBtn.UseVisualStyleBackColor = true;
            this.OwnerBtn.Click += new System.EventHandler(this.OwnerBtn_Click);
            // 
            // ClosedBtn
            // 
            this.ClosedBtn.Location = new System.Drawing.Point(12, 322);
            this.ClosedBtn.Name = "ClosedBtn";
            this.ClosedBtn.Size = new System.Drawing.Size(244, 56);
            this.ClosedBtn.TabIndex = 4;
            this.ClosedBtn.Text = "Закрыть";
            this.ClosedBtn.UseVisualStyleBackColor = true;
            this.ClosedBtn.Click += new System.EventHandler(this.ClosedBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 384);
            this.Controls.Add(this.OwnerBtn);
            this.Controls.Add(this.ClosedBtn);
            this.Controls.Add(this.MarkModelBtn);
            this.Controls.Add(this.CarOwnerBtn);
            this.Controls.Add(this.CarBtn);
            this.Controls.Add(this.AllDataBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AllDataBtn;
        private System.Windows.Forms.Button CarBtn;
        private System.Windows.Forms.Button CarOwnerBtn;
        private System.Windows.Forms.Button MarkModelBtn;
        private System.Windows.Forms.Button OwnerBtn;
        private System.Windows.Forms.Button ClosedBtn;
    }
}