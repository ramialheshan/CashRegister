namespace CashRegister
{
    partial class AllCostAboutProductsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AllCostAboutProductsForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ClearFilterProductButton = new System.Windows.Forms.Button();
            this.FilterProductButton = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.ProductComboBox = new System.Windows.Forms.ComboBox();
            this.ProductCheckList = new System.Windows.Forms.DataGridView();
            this.UnicalCounterProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product_UnitValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product_CostOfOneOption = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product_Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product_DateOfLastDelivery = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AllCostOfProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ProductAllValueTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProductCheckList)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ClearFilterProductButton);
            this.groupBox1.Controls.Add(this.FilterProductButton);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.ProductComboBox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(658, 69);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Выбор товара";
            // 
            // ClearFilterProductButton
            // 
            this.ClearFilterProductButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ClearFilterProductButton.Image = ((System.Drawing.Image)(resources.GetObject("ClearFilterProductButton.Image")));
            this.ClearFilterProductButton.Location = new System.Drawing.Point(533, 19);
            this.ClearFilterProductButton.Name = "ClearFilterProductButton";
            this.ClearFilterProductButton.Size = new System.Drawing.Size(119, 35);
            this.ClearFilterProductButton.TabIndex = 35;
            this.ClearFilterProductButton.Text = "Очистить";
            this.ClearFilterProductButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ClearFilterProductButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ClearFilterProductButton.UseVisualStyleBackColor = true;
            this.ClearFilterProductButton.Click += new System.EventHandler(this.ClearFilterProductButton_Click);
            // 
            // FilterProductButton
            // 
            this.FilterProductButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FilterProductButton.Image = ((System.Drawing.Image)(resources.GetObject("FilterProductButton.Image")));
            this.FilterProductButton.Location = new System.Drawing.Point(408, 19);
            this.FilterProductButton.Name = "FilterProductButton";
            this.FilterProductButton.Size = new System.Drawing.Size(119, 35);
            this.FilterProductButton.TabIndex = 35;
            this.FilterProductButton.Text = "Поиск товара";
            this.FilterProductButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.FilterProductButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.FilterProductButton.UseVisualStyleBackColor = true;
            this.FilterProductButton.Click += new System.EventHandler(this.FilterProductButton_Click);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(8, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 26);
            this.label10.TabIndex = 34;
            this.label10.Text = "Наименование товара";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProductComboBox
            // 
            this.ProductComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ProductComboBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ProductComboBox.FormattingEnabled = true;
            this.ProductComboBox.Location = new System.Drawing.Point(93, 27);
            this.ProductComboBox.Name = "ProductComboBox";
            this.ProductComboBox.Size = new System.Drawing.Size(309, 21);
            this.ProductComboBox.TabIndex = 33;
            this.ProductComboBox.Text = "Начните вводить название товара";
            this.ProductComboBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ProductComboBox_MouseClick);
            this.ProductComboBox.SelectedIndexChanged += new System.EventHandler(this.ProductComboBox_SelectedIndexChanged);
            this.ProductComboBox.Leave += new System.EventHandler(this.ProductComboBox_Leave);
            this.ProductComboBox.Enter += new System.EventHandler(this.ProductComboBox_Enter);
            this.ProductComboBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ProductComboBox_KeyUp);
            this.ProductComboBox.DropDownClosed += new System.EventHandler(this.ProductComboBox_SelectedIndexChanged);
            // 
            // ProductCheckList
            // 
            this.ProductCheckList.AllowUserToAddRows = false;
            this.ProductCheckList.AllowUserToDeleteRows = false;
            this.ProductCheckList.AllowUserToResizeColumns = false;
            this.ProductCheckList.AllowUserToResizeRows = false;
            this.ProductCheckList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ProductCheckList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.ProductCheckList.BackgroundColor = System.Drawing.Color.White;
            this.ProductCheckList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ProductCheckList.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.ProductCheckList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ProductCheckList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ProductCheckList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProductCheckList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UnicalCounterProduct,
            this.Product_Name,
            this.Product_UnitValue,
            this.Product_CostOfOneOption,
            this.Product_Count,
            this.Product_DateOfLastDelivery,
            this.AllCostOfProduct});
            this.ProductCheckList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProductCheckList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.ProductCheckList.Location = new System.Drawing.Point(4, 73);
            this.ProductCheckList.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.ProductCheckList.MultiSelect = false;
            this.ProductCheckList.Name = "ProductCheckList";
            this.ProductCheckList.ReadOnly = true;
            this.ProductCheckList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.ProductCheckList.RowHeadersVisible = false;
            this.ProductCheckList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.ProductCheckList.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ProductCheckList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ProductCheckList.ShowEditingIcon = false;
            this.ProductCheckList.Size = new System.Drawing.Size(658, 324);
            this.ProductCheckList.TabIndex = 20;
            this.ProductCheckList.TabStop = false;
            // 
            // UnicalCounterProduct
            // 
            this.UnicalCounterProduct.HeaderText = "UnicalIPCounter";
            this.UnicalCounterProduct.Name = "UnicalCounterProduct";
            this.UnicalCounterProduct.ReadOnly = true;
            this.UnicalCounterProduct.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UnicalCounterProduct.Visible = false;
            // 
            // Product_Name
            // 
            this.Product_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Product_Name.DefaultCellStyle = dataGridViewCellStyle2;
            this.Product_Name.HeaderText = "Наименование товара";
            this.Product_Name.MinimumWidth = 62;
            this.Product_Name.Name = "Product_Name";
            this.Product_Name.ReadOnly = true;
            this.Product_Name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Product_Name.ToolTipText = "Наименование товара";
            this.Product_Name.Width = 114;
            // 
            // Product_UnitValue
            // 
            this.Product_UnitValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Product_UnitValue.DefaultCellStyle = dataGridViewCellStyle3;
            this.Product_UnitValue.HeaderText = "Единица измерения";
            this.Product_UnitValue.MinimumWidth = 32;
            this.Product_UnitValue.Name = "Product_UnitValue";
            this.Product_UnitValue.ReadOnly = true;
            this.Product_UnitValue.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Product_UnitValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Product_UnitValue.ToolTipText = "Единица измерения";
            this.Product_UnitValue.Width = 104;
            // 
            // Product_CostOfOneOption
            // 
            this.Product_CostOfOneOption.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Product_CostOfOneOption.DefaultCellStyle = dataGridViewCellStyle4;
            this.Product_CostOfOneOption.HeaderText = "Стоимость единицы товара";
            this.Product_CostOfOneOption.MinimumWidth = 62;
            this.Product_CostOfOneOption.Name = "Product_CostOfOneOption";
            this.Product_CostOfOneOption.ReadOnly = true;
            this.Product_CostOfOneOption.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Product_CostOfOneOption.ToolTipText = "Стоимость единицы товара";
            this.Product_CostOfOneOption.Width = 86;
            // 
            // Product_Count
            // 
            this.Product_Count.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Product_Count.DefaultCellStyle = dataGridViewCellStyle5;
            this.Product_Count.HeaderText = "Количество товара";
            this.Product_Count.Name = "Product_Count";
            this.Product_Count.ReadOnly = true;
            this.Product_Count.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Product_Count.ToolTipText = "Количество товара";
            this.Product_Count.Width = 99;
            // 
            // Product_DateOfLastDelivery
            // 
            this.Product_DateOfLastDelivery.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Product_DateOfLastDelivery.DefaultCellStyle = dataGridViewCellStyle6;
            this.Product_DateOfLastDelivery.HeaderText = "Дата последнего пополнения товара";
            this.Product_DateOfLastDelivery.Name = "Product_DateOfLastDelivery";
            this.Product_DateOfLastDelivery.ReadOnly = true;
            this.Product_DateOfLastDelivery.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Product_DateOfLastDelivery.Width = 150;
            // 
            // AllCostOfProduct
            // 
            this.AllCostOfProduct.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.AllCostOfProduct.DefaultCellStyle = dataGridViewCellStyle7;
            this.AllCostOfProduct.HeaderText = "Остаточная стоимость";
            this.AllCostOfProduct.Name = "AllCostOfProduct";
            this.AllCostOfProduct.ReadOnly = true;
            this.AllCostOfProduct.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ProductAllValueTextBox);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(4, 357);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(658, 40);
            this.panel1.TabIndex = 21;
            // 
            // ProductAllValueTextBox
            // 
            this.ProductAllValueTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ProductAllValueTextBox.Location = new System.Drawing.Point(243, 10);
            this.ProductAllValueTextBox.Name = "ProductAllValueTextBox";
            this.ProductAllValueTextBox.ReadOnly = true;
            this.ProductAllValueTextBox.Size = new System.Drawing.Size(139, 20);
            this.ProductAllValueTextBox.TabIndex = 40;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(12, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(225, 15);
            this.label5.TabIndex = 39;
            this.label5.Text = "Общая стоимость всех товаров:";
            // 
            // AllCostAboutProductsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(666, 401);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ProductCheckList);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 439);
            this.MinimumSize = new System.Drawing.Size(682, 439);
            this.Name = "AllCostAboutProductsForm";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Инвентаризация остатков товара";
            this.Shown += new System.EventHandler(this.AllCostAboutProductsForm_Shown);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ProductCheckList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.DataGridView ProductCheckList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox ProductAllValueTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button ClearFilterProductButton;
        private System.Windows.Forms.Button FilterProductButton;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox ProductComboBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnicalCounterProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product_UnitValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product_CostOfOneOption;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product_Count;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product_DateOfLastDelivery;
        private System.Windows.Forms.DataGridViewTextBoxColumn AllCostOfProduct;
    }
}