namespace CashRegister
{
    partial class CloseCheckForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CloseCheckForm));
            this.label6 = new System.Windows.Forms.Label();
            this.AllProductsInCheckTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CloseCheckButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.COSTProductsInCheckTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.GetMoneyInCheckTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.GIveMoneyInChangeTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.CloseWindowsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(252, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 21);
            this.label6.TabIndex = 42;
            this.label6.Text = "шт.";
            // 
            // AllProductsInCheckTextBox
            // 
            this.AllProductsInCheckTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AllProductsInCheckTextBox.Enabled = false;
            this.AllProductsInCheckTextBox.Location = new System.Drawing.Point(147, 25);
            this.AllProductsInCheckTextBox.Name = "AllProductsInCheckTextBox";
            this.AllProductsInCheckTextBox.Size = new System.Drawing.Size(99, 23);
            this.AllProductsInCheckTextBox.TabIndex = 43;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(17, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 21);
            this.label5.TabIndex = 41;
            this.label5.Text = "Всего товаров:";
            // 
            // CloseCheckButton
            // 
            this.CloseCheckButton.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CloseCheckButton.Image = ((System.Drawing.Image)(resources.GetObject("CloseCheckButton.Image")));
            this.CloseCheckButton.Location = new System.Drawing.Point(25, 152);
            this.CloseCheckButton.Name = "CloseCheckButton";
            this.CloseCheckButton.Size = new System.Drawing.Size(186, 57);
            this.CloseCheckButton.TabIndex = 44;
            this.CloseCheckButton.Text = "Оплатить чек";
            this.CloseCheckButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CloseCheckButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CloseCheckButton.UseVisualStyleBackColor = true;
            this.CloseCheckButton.Click += new System.EventHandler(this.CloseCheckButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(39, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 21);
            this.label1.TabIndex = 41;
            this.label1.Text = "Сумма чека:";
            // 
            // COSTProductsInCheckTextBox
            // 
            this.COSTProductsInCheckTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.COSTProductsInCheckTextBox.Enabled = false;
            this.COSTProductsInCheckTextBox.Location = new System.Drawing.Point(147, 54);
            this.COSTProductsInCheckTextBox.Name = "COSTProductsInCheckTextBox";
            this.COSTProductsInCheckTextBox.Size = new System.Drawing.Size(99, 23);
            this.COSTProductsInCheckTextBox.TabIndex = 43;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(252, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 21);
            this.label2.TabIndex = 42;
            this.label2.Text = "грн.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(51, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 21);
            this.label3.TabIndex = 41;
            this.label3.Text = "Получено:";
            // 
            // GetMoneyInCheckTextBox
            // 
            this.GetMoneyInCheckTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GetMoneyInCheckTextBox.Location = new System.Drawing.Point(147, 83);
            this.GetMoneyInCheckTextBox.Name = "GetMoneyInCheckTextBox";
            this.GetMoneyInCheckTextBox.Size = new System.Drawing.Size(99, 23);
            this.GetMoneyInCheckTextBox.TabIndex = 43;
            this.GetMoneyInCheckTextBox.TextChanged += new System.EventHandler(this.GetMoneyInCheckTextBox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(252, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 21);
            this.label4.TabIndex = 42;
            this.label4.Text = "грн.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(83, 111);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 21);
            this.label7.TabIndex = 41;
            this.label7.Text = "Сдача:";
            // 
            // GIveMoneyInChangeTextBox
            // 
            this.GIveMoneyInChangeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GIveMoneyInChangeTextBox.Enabled = false;
            this.GIveMoneyInChangeTextBox.Location = new System.Drawing.Point(147, 112);
            this.GIveMoneyInChangeTextBox.Name = "GIveMoneyInChangeTextBox";
            this.GIveMoneyInChangeTextBox.Size = new System.Drawing.Size(99, 23);
            this.GIveMoneyInChangeTextBox.TabIndex = 43;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(252, 111);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 21);
            this.label8.TabIndex = 42;
            this.label8.Text = "грн.";
            // 
            // CloseWindowsButton
            // 
            this.CloseWindowsButton.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CloseWindowsButton.Image = ((System.Drawing.Image)(resources.GetObject("CloseWindowsButton.Image")));
            this.CloseWindowsButton.Location = new System.Drawing.Point(217, 152);
            this.CloseWindowsButton.Name = "CloseWindowsButton";
            this.CloseWindowsButton.Size = new System.Drawing.Size(67, 57);
            this.CloseWindowsButton.TabIndex = 44;
            this.CloseWindowsButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CloseWindowsButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CloseWindowsButton.UseVisualStyleBackColor = true;
            this.CloseWindowsButton.Click += new System.EventHandler(this.CloseWindowsButton_Click);
            // 
            // CloseCheckForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 228);
            this.ControlBox = false;
            this.Controls.Add(this.CloseWindowsButton);
            this.Controls.Add(this.CloseCheckButton);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.GIveMoneyInChangeTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.GetMoneyInCheckTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.COSTProductsInCheckTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AllProductsInCheckTextBox);
            this.Controls.Add(this.label5);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CloseCheckForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Закрытие чека";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox AllProductsInCheckTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button CloseCheckButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox COSTProductsInCheckTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox GetMoneyInCheckTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox GIveMoneyInChangeTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button CloseWindowsButton;
    }
}