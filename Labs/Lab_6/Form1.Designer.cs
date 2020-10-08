namespace Lab_6 {
    partial class Form1 {
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
            this.countPointNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.elasticNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.fondBtn = new System.Windows.Forms.Button();
            this.drawBtn = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.countPointNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.elasticNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // countPointNumericUpDown
            // 
            this.countPointNumericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.countPointNumericUpDown.Location = new System.Drawing.Point(137, 12);
            this.countPointNumericUpDown.Name = "countPointNumericUpDown";
            this.countPointNumericUpDown.Size = new System.Drawing.Size(69, 22);
            this.countPointNumericUpDown.TabIndex = 0;
            this.countPointNumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // elasticNumericUpDown
            // 
            this.elasticNumericUpDown.DecimalPlaces = 1;
            this.elasticNumericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.elasticNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.elasticNumericUpDown.Location = new System.Drawing.Point(137, 38);
            this.elasticNumericUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.elasticNumericUpDown.Name = "elasticNumericUpDown";
            this.elasticNumericUpDown.Size = new System.Drawing.Size(69, 22);
            this.elasticNumericUpDown.TabIndex = 1;
            this.elasticNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(26, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Число точек";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(26, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Упругость";
            // 
            // fondBtn
            // 
            this.fondBtn.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fondBtn.Location = new System.Drawing.Point(29, 116);
            this.fondBtn.Name = "fondBtn";
            this.fondBtn.Size = new System.Drawing.Size(153, 59);
            this.fondBtn.TabIndex = 4;
            this.fondBtn.Text = "Выбрать шрифт";
            this.fondBtn.UseVisualStyleBackColor = true;
            this.fondBtn.Click += new System.EventHandler(this.FondBtn_Click);
            // 
            // drawBtn
            // 
            this.drawBtn.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.drawBtn.Location = new System.Drawing.Point(29, 181);
            this.drawBtn.Name = "drawBtn";
            this.drawBtn.Size = new System.Drawing.Size(153, 59);
            this.drawBtn.TabIndex = 5;
            this.drawBtn.Text = "Нарисовать график";
            this.drawBtn.UseVisualStyleBackColor = true;
            this.drawBtn.Click += new System.EventHandler(this.DrawBtn_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(29, 246);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(153, 59);
            this.button3.TabIndex = 6;
            this.button3.Text = "Закрыть";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(212, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(618, 295);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 317);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.drawBtn);
            this.Controls.Add(this.fondBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.elasticNumericUpDown);
            this.Controls.Add(this.countPointNumericUpDown);
            this.Font = new System.Drawing.Font("Symbol", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.countPointNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.elasticNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown countPointNumericUpDown;
        private System.Windows.Forms.NumericUpDown elasticNumericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button fondBtn;
        private System.Windows.Forms.Button drawBtn;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

