namespace CashRegister
{
    partial class AssortmentOfGoodsForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AssortmentOfGoodsForm));
            this.cancelButton = new System.Windows.Forms.Button();
            this.GoodsActionTabControl = new System.Windows.Forms.TabControl();
            this.AddGoodsTabPage = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ProductComboBox = new System.Windows.Forms.ComboBox();
            this.NumberForADDTextBox = new System.Windows.Forms.TextBox();
            this.ProductAllValueTextBox = new System.Windows.Forms.TextBox();
            this.CostPerOneOfProductTextBox = new System.Windows.Forms.MaskedTextBox();
            this.AddValueProductButton = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.NumberUnitProductComboBox = new System.Windows.Forms.ComboBox();
            this.ExistingProductRadioButton = new System.Windows.Forms.RadioButton();
            this.NewProductRadioButton = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.WriteOffGoodsTabPage = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ProductForRemoveComboBox = new System.Windows.Forms.ComboBox();
            this.NumberFor_REMOVE_TextBox = new System.Windows.Forms.TextBox();
            this.ProductAllValue_REMOVE_TextBox = new System.Windows.Forms.TextBox();
            this.CostPerOneOfProduct_REMOVE_TextBox = new System.Windows.Forms.MaskedTextBox();
            this.RemoveValueProductButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.NumberUnitProduct_REMOVE_ComboBox = new System.Windows.Forms.ComboBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.ListLogoTools = new System.Windows.Forms.ImageList(this.components);
            this.GoodsActionTabControl.SuspendLayout();
            this.AddGoodsTabPage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.WriteOffGoodsTabPage.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(565, 244);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(101, 29);
            this.cancelButton.TabIndex = 24;
            this.cancelButton.Text = "Закрыть";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // GoodsActionTabControl
            // 
            this.GoodsActionTabControl.Controls.Add(this.AddGoodsTabPage);
            this.GoodsActionTabControl.Controls.Add(this.WriteOffGoodsTabPage);
            this.GoodsActionTabControl.ImageList = this.ListLogoTools;
            this.GoodsActionTabControl.Location = new System.Drawing.Point(6, 7);
            this.GoodsActionTabControl.Name = "GoodsActionTabControl";
            this.GoodsActionTabControl.SelectedIndex = 0;
            this.GoodsActionTabControl.Size = new System.Drawing.Size(660, 232);
            this.GoodsActionTabControl.TabIndex = 26;
            this.GoodsActionTabControl.SelectedIndexChanged += new System.EventHandler(this.GoodsActionTabControl_SelectedIndexChanged);
            // 
            // AddGoodsTabPage
            // 
            this.AddGoodsTabPage.BackColor = System.Drawing.SystemColors.Control;
            this.AddGoodsTabPage.Controls.Add(this.groupBox1);
            this.AddGoodsTabPage.ImageIndex = 0;
            this.AddGoodsTabPage.Location = new System.Drawing.Point(4, 31);
            this.AddGoodsTabPage.Name = "AddGoodsTabPage";
            this.AddGoodsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.AddGoodsTabPage.Size = new System.Drawing.Size(652, 197);
            this.AddGoodsTabPage.TabIndex = 0;
            this.AddGoodsTabPage.Text = "Пополнение товара";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.ProductComboBox);
            this.groupBox1.Controls.Add(this.NumberForADDTextBox);
            this.groupBox1.Controls.Add(this.ProductAllValueTextBox);
            this.groupBox1.Controls.Add(this.CostPerOneOfProductTextBox);
            this.groupBox1.Controls.Add(this.AddValueProductButton);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.NumberUnitProductComboBox);
            this.groupBox1.Controls.Add(this.ExistingProductRadioButton);
            this.groupBox1.Controls.Add(this.NewProductRadioButton);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Location = new System.Drawing.Point(8, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(636, 190);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Описание товара";
            // 
            // ProductComboBox
            // 
            this.ProductComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ProductComboBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.ProductComboBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ProductComboBox.Location = new System.Drawing.Point(152, 54);
            this.ProductComboBox.MaxDropDownItems = 100;
            this.ProductComboBox.Name = "ProductComboBox";
            this.ProductComboBox.Size = new System.Drawing.Size(313, 23);
            this.ProductComboBox.TabIndex = 27;
            this.ProductComboBox.Text = "Начните вводить название товара";
            this.ProductComboBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ProductComboBox_MouseClick);
            this.ProductComboBox.SelectedIndexChanged += new System.EventHandler(this.ProductComboBox_SelectedIndexChanged);
            this.ProductComboBox.Leave += new System.EventHandler(this.ProductComboBox_Leave);
            this.ProductComboBox.Enter += new System.EventHandler(this.ProductComboBox_Enter);
            this.ProductComboBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ProductComboBox_KeyUp);
            this.ProductComboBox.DropDownClosed += new System.EventHandler(this.ProductComboBox_SelectedIndexChanged);
            // 
            // NumberForADDTextBox
            // 
            this.NumberForADDTextBox.Location = new System.Drawing.Point(152, 129);
            this.NumberForADDTextBox.Name = "NumberForADDTextBox";
            this.NumberForADDTextBox.Size = new System.Drawing.Size(313, 23);
            this.NumberForADDTextBox.TabIndex = 26;
            // 
            // ProductAllValueTextBox
            // 
            this.ProductAllValueTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ProductAllValueTextBox.Enabled = false;
            this.ProductAllValueTextBox.Location = new System.Drawing.Point(152, 160);
            this.ProductAllValueTextBox.Name = "ProductAllValueTextBox";
            this.ProductAllValueTextBox.ReadOnly = true;
            this.ProductAllValueTextBox.Size = new System.Drawing.Size(313, 23);
            this.ProductAllValueTextBox.TabIndex = 26;
            // 
            // CostPerOneOfProductTextBox
            // 
            this.CostPerOneOfProductTextBox.Location = new System.Drawing.Point(152, 104);
            this.CostPerOneOfProductTextBox.Mask = "9999.99";
            this.CostPerOneOfProductTextBox.Name = "CostPerOneOfProductTextBox";
            this.CostPerOneOfProductTextBox.Size = new System.Drawing.Size(313, 23);
            this.CostPerOneOfProductTextBox.TabIndex = 4;
            // 
            // AddValueProductButton
            // 
            this.AddValueProductButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddValueProductButton.Image = ((System.Drawing.Image)(resources.GetObject("AddValueProductButton.Image")));
            this.AddValueProductButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AddValueProductButton.Location = new System.Drawing.Point(336, 16);
            this.AddValueProductButton.Name = "AddValueProductButton";
            this.AddValueProductButton.Size = new System.Drawing.Size(129, 32);
            this.AddValueProductButton.TabIndex = 25;
            this.AddValueProductButton.Text = "Добавить товар";
            this.AddValueProductButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.AddValueProductButton.UseVisualStyleBackColor = true;
            this.AddValueProductButton.Click += new System.EventHandler(this.AddValueProductButton_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(45, 162);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 15);
            this.label9.TabIndex = 3;
            this.label9.Text = "Всего товара:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Количество добавить:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Цена единицы товара:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Единица измерения:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Наименование товара:";
            // 
            // NumberUnitProductComboBox
            // 
            this.NumberUnitProductComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.NumberUnitProductComboBox.FormattingEnabled = true;
            this.NumberUnitProductComboBox.Items.AddRange(new object[] {
            "кг",
            "метр",
            "шт",
            "пачка",
            "бутылка"});
            this.NumberUnitProductComboBox.Location = new System.Drawing.Point(152, 79);
            this.NumberUnitProductComboBox.Name = "NumberUnitProductComboBox";
            this.NumberUnitProductComboBox.Size = new System.Drawing.Size(313, 23);
            this.NumberUnitProductComboBox.TabIndex = 2;
            // 
            // ExistingProductRadioButton
            // 
            this.ExistingProductRadioButton.AutoSize = true;
            this.ExistingProductRadioButton.Location = new System.Drawing.Point(152, 24);
            this.ExistingProductRadioButton.Name = "ExistingProductRadioButton";
            this.ExistingProductRadioButton.Size = new System.Drawing.Size(148, 19);
            this.ExistingProductRadioButton.TabIndex = 1;
            this.ExistingProductRadioButton.Text = "Существующий товар";
            this.ExistingProductRadioButton.UseVisualStyleBackColor = true;
            this.ExistingProductRadioButton.CheckedChanged += new System.EventHandler(this.NewProductRadioButton_CheckedChanged);
            // 
            // NewProductRadioButton
            // 
            this.NewProductRadioButton.AutoSize = true;
            this.NewProductRadioButton.Location = new System.Drawing.Point(36, 24);
            this.NewProductRadioButton.Name = "NewProductRadioButton";
            this.NewProductRadioButton.Size = new System.Drawing.Size(97, 19);
            this.NewProductRadioButton.TabIndex = 1;
            this.NewProductRadioButton.TabStop = true;
            this.NewProductRadioButton.Text = "Новый товар";
            this.NewProductRadioButton.UseVisualStyleBackColor = true;
            this.NewProductRadioButton.CheckedChanged += new System.EventHandler(this.NewProductRadioButton_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(471, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(159, 167);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // WriteOffGoodsTabPage
            // 
            this.WriteOffGoodsTabPage.BackColor = System.Drawing.SystemColors.Control;
            this.WriteOffGoodsTabPage.Controls.Add(this.groupBox2);
            this.WriteOffGoodsTabPage.ImageIndex = 1;
            this.WriteOffGoodsTabPage.Location = new System.Drawing.Point(4, 31);
            this.WriteOffGoodsTabPage.Name = "WriteOffGoodsTabPage";
            this.WriteOffGoodsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.WriteOffGoodsTabPage.Size = new System.Drawing.Size(652, 197);
            this.WriteOffGoodsTabPage.TabIndex = 1;
            this.WriteOffGoodsTabPage.Text = "Списание товара";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ProductForRemoveComboBox);
            this.groupBox2.Controls.Add(this.NumberFor_REMOVE_TextBox);
            this.groupBox2.Controls.Add(this.ProductAllValue_REMOVE_TextBox);
            this.groupBox2.Controls.Add(this.CostPerOneOfProduct_REMOVE_TextBox);
            this.groupBox2.Controls.Add(this.RemoveValueProductButton);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.NumberUnitProduct_REMOVE_ComboBox);
            this.groupBox2.Controls.Add(this.pictureBox2);
            this.groupBox2.Location = new System.Drawing.Point(8, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(636, 190);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Описание товара";
            // 
            // ProductForRemoveComboBox
            // 
            this.ProductForRemoveComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ProductForRemoveComboBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.ProductForRemoveComboBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ProductForRemoveComboBox.Location = new System.Drawing.Point(151, 52);
            this.ProductForRemoveComboBox.Name = "ProductForRemoveComboBox";
            this.ProductForRemoveComboBox.Size = new System.Drawing.Size(313, 23);
            this.ProductForRemoveComboBox.TabIndex = 39;
            this.ProductForRemoveComboBox.Text = "Начните вводить название товара";
            this.ProductForRemoveComboBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ProductComboBox_MouseClick);
            this.ProductForRemoveComboBox.SelectedIndexChanged += new System.EventHandler(this.ProductComboBox_SelectedIndexChanged);
            this.ProductForRemoveComboBox.Leave += new System.EventHandler(this.ProductComboBox_Leave);
            this.ProductForRemoveComboBox.Enter += new System.EventHandler(this.ProductComboBox_Enter);
            this.ProductForRemoveComboBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ProductComboBox_KeyUp);
            this.ProductForRemoveComboBox.DropDownClosed += new System.EventHandler(this.ProductComboBox_SelectedIndexChanged);
            // 
            // NumberFor_REMOVE_TextBox
            // 
            this.NumberFor_REMOVE_TextBox.Location = new System.Drawing.Point(151, 127);
            this.NumberFor_REMOVE_TextBox.Name = "NumberFor_REMOVE_TextBox";
            this.NumberFor_REMOVE_TextBox.Size = new System.Drawing.Size(313, 23);
            this.NumberFor_REMOVE_TextBox.TabIndex = 37;
            // 
            // ProductAllValue_REMOVE_TextBox
            // 
            this.ProductAllValue_REMOVE_TextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ProductAllValue_REMOVE_TextBox.Enabled = false;
            this.ProductAllValue_REMOVE_TextBox.Location = new System.Drawing.Point(151, 158);
            this.ProductAllValue_REMOVE_TextBox.Name = "ProductAllValue_REMOVE_TextBox";
            this.ProductAllValue_REMOVE_TextBox.ReadOnly = true;
            this.ProductAllValue_REMOVE_TextBox.Size = new System.Drawing.Size(313, 23);
            this.ProductAllValue_REMOVE_TextBox.TabIndex = 38;
            // 
            // CostPerOneOfProduct_REMOVE_TextBox
            // 
            this.CostPerOneOfProduct_REMOVE_TextBox.Location = new System.Drawing.Point(151, 102);
            this.CostPerOneOfProduct_REMOVE_TextBox.Mask = "9999-99";
            this.CostPerOneOfProduct_REMOVE_TextBox.Name = "CostPerOneOfProduct_REMOVE_TextBox";
            this.CostPerOneOfProduct_REMOVE_TextBox.ReadOnly = true;
            this.CostPerOneOfProduct_REMOVE_TextBox.Size = new System.Drawing.Size(313, 23);
            this.CostPerOneOfProduct_REMOVE_TextBox.TabIndex = 35;
            // 
            // RemoveValueProductButton
            // 
            this.RemoveValueProductButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RemoveValueProductButton.Image = ((System.Drawing.Image)(resources.GetObject("RemoveValueProductButton.Image")));
            this.RemoveValueProductButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RemoveValueProductButton.Location = new System.Drawing.Point(151, 14);
            this.RemoveValueProductButton.Name = "RemoveValueProductButton";
            this.RemoveValueProductButton.Size = new System.Drawing.Size(129, 32);
            this.RemoveValueProductButton.TabIndex = 36;
            this.RemoveValueProductButton.Text = "Списать товар";
            this.RemoveValueProductButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.RemoveValueProductButton.UseVisualStyleBackColor = true;
            this.RemoveValueProductButton.Click += new System.EventHandler(this.RemoveValueProductButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(44, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 15);
            this.label5.TabIndex = 33;
            this.label5.Text = "Всего товара:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 15);
            this.label6.TabIndex = 34;
            this.label6.Text = "Количество списать:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(130, 15);
            this.label7.TabIndex = 30;
            this.label7.Text = "Цена единицы товара:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(26, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(119, 15);
            this.label8.TabIndex = 31;
            this.label8.Text = "Единица измерения:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 55);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(133, 15);
            this.label10.TabIndex = 32;
            this.label10.Text = "Наименование товара:";
            // 
            // NumberUnitProduct_REMOVE_ComboBox
            // 
            this.NumberUnitProduct_REMOVE_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.NumberUnitProduct_REMOVE_ComboBox.Enabled = false;
            this.NumberUnitProduct_REMOVE_ComboBox.FormattingEnabled = true;
            this.NumberUnitProduct_REMOVE_ComboBox.Items.AddRange(new object[] {
            "кг",
            "метр",
            "шт",
            "пачка",
            "бутылка"});
            this.NumberUnitProduct_REMOVE_ComboBox.Location = new System.Drawing.Point(151, 77);
            this.NumberUnitProduct_REMOVE_ComboBox.Name = "NumberUnitProduct_REMOVE_ComboBox";
            this.NumberUnitProduct_REMOVE_ComboBox.Size = new System.Drawing.Size(313, 23);
            this.NumberUnitProduct_REMOVE_ComboBox.TabIndex = 28;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(470, 14);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(159, 167);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 27;
            this.pictureBox2.TabStop = false;
            // 
            // ListLogoTools
            // 
            this.ListLogoTools.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ListLogoTools.ImageStream")));
            this.ListLogoTools.TransparentColor = System.Drawing.Color.Transparent;
            this.ListLogoTools.Images.SetKeyName(0, "Plus_24.png");
            this.ListLogoTools.Images.SetKeyName(1, "remove_24.png");
            // 
            // AssortmentOfGoodsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(669, 280);
            this.Controls.Add(this.GoodsActionTabControl);
            this.Controls.Add(this.cancelButton);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(675, 308);
            this.MinimumSize = new System.Drawing.Size(675, 308);
            this.Name = "AssortmentOfGoodsForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактор ассотримента товаров";
            this.Shown += new System.EventHandler(this.AssortmentOfGoodsForm_Shown);
            this.GoodsActionTabControl.ResumeLayout(false);
            this.AddGoodsTabPage.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.WriteOffGoodsTabPage.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AddValueProductButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TabControl GoodsActionTabControl;
        private System.Windows.Forms.TabPage AddGoodsTabPage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MaskedTextBox CostPerOneOfProductTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox NumberUnitProductComboBox;
        private System.Windows.Forms.RadioButton ExistingProductRadioButton;
        private System.Windows.Forms.RadioButton NewProductRadioButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabPage WriteOffGoodsTabPage;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox NumberForADDTextBox;
        private System.Windows.Forms.TextBox ProductAllValueTextBox;
        private System.Windows.Forms.TextBox NumberFor_REMOVE_TextBox;
        private System.Windows.Forms.TextBox ProductAllValue_REMOVE_TextBox;
        private System.Windows.Forms.MaskedTextBox CostPerOneOfProduct_REMOVE_TextBox;
        private System.Windows.Forms.Button RemoveValueProductButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox NumberUnitProduct_REMOVE_ComboBox;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ImageList ListLogoTools;
        private System.Windows.Forms.ComboBox ProductComboBox;
        private System.Windows.Forms.ComboBox ProductForRemoveComboBox;
    }
}