using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace CashRegister
{
    public partial class mainForm : Form
    {
        //Блок инициализации и описания 

        #region Описание переменных 

        /// <summary>
        /// Подключение к базе данных товаров 
        /// </summary>
        OleDbConnection Product_Connect;
        /// <summary>
        /// Инструмент лдя работы с базой данных базы данных 
        /// </summary>
        OleDbDataAdapter adapter;

        #region ЧЕК 

        /// <summary>
        /// Номер товара для добавления в чек
        /// </summary>
        int CurrentProductForAddToList;
        /// <summary>
        /// Таймер, который используеться для поиска соответствий
        /// </summary>
        System.Timers.Timer _timerFortextControl;
        /// <summary>
        /// таблица используеться для обмена информации при заполнении списка чека
        /// </summary>
        DataTable TempForCheckCreate;
        /// <summary>
        /// Информация для добавления в чек 
        /// </summary>
        DataRow CurrentInfoForAddToCheck;
        /// <summary>
        /// Таблица, которой хранится список товаров для оформления чека
        /// </summary>
        DataTable ProductListOfCheck;
        /// <summary>
        /// Таблица, которой хранится список товаров Для контроля количества 
        /// </summary>
        DataTable ProductListForControlValueProduct;

        #endregion

        #region Перечисления 

        /// <summary>
        /// Типы операций с продуктами
        /// </summary>
        public enum TypeOfOperationRegisreted
        {
            /// <summary>
            /// Добавили новый продукт 
            /// </summary>
            AddNewProduct,
            /// <summary>
            /// Добавили значение к продукту
            /// </summary>
            AddCountProduct,
            /// <summary>
            /// Списали значение с продукта
            /// </summary>
            RemoveCountProduct,
            /// <summary>
            /// Удалили продукт из списка 
            /// </summary>
            DeleteProduct
        }

        #endregion

        #endregion

        #region Конструктор формы

        public mainForm()
        {
            InitializeComponent();

            #region Создаем инструменты 

            Product_Connect = new OleDbConnection();
            adapter = new OleDbDataAdapter();
            adapter.SelectCommand = new OleDbCommand("", Product_Connect);
            adapter.InsertCommand = new OleDbCommand("", Product_Connect);
            adapter.DeleteCommand = new OleDbCommand("", Product_Connect);
            adapter.UpdateCommand = new OleDbCommand("", Product_Connect);

            _timerFortextControl = new System.Timers.Timer(1000);
            _timerFortextControl.Elapsed += new System.Timers.ElapsedEventHandler(_timerFortextControl_Elapsed);

            #region Таблица чека 
            
            ProductListOfCheck = new DataTable();

            #region Картинка 

            //DataColumn column = new DataColumn("ImageStateOfProduct");
            //column.DataType = System.Type.GetType("System.Byte[]");
            //column.AllowDBNull = true;
            //ProductListOfCheck.Columns.Add(column);

            //ProductListOfCheck.Columns.Add("FlagCurrent", System.Type.GetType("System.Boolean"));

            #endregion 

            ProductListOfCheck.Columns.Add("Product_Name", System.Type.GetType("System.String"));
            ProductListOfCheck.Columns.Add("Product_UnitValue", System.Type.GetType("System.String"));
            ProductListOfCheck.Columns.Add("Product_Count", System.Type.GetType("System.String"));
            ProductListOfCheck.Columns.Add("Product_CostOfOneOption", System.Type.GetType("System.String"));
            ProductListOfCheck.Columns.Add("AllCostProductSaleOperation", System.Type.GetType("System.String"));

            #endregion

            #endregion

            #region Загрузка информации о товарах 

            #region Подключение к базе данных 

            Product_Connect.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "/" + "CashRegister_DB.mdb;" + "Jet OLEDB:Database Password=cashregister_admin";

            try { Product_Connect.Open();}
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message + "\n" + "Приложение будет закрыто", "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Close();
            }

            #endregion

            #region Загрузка данных с базы данных 

            adapter.SelectCommand.CommandText = "SELECT * FROM Product_Check_List_Table";
            adapter.Fill(Product_DataSet.Tables["Product_Check_List_Table"]);

            adapter.SelectCommand.CommandText = "SELECT * FROM Product_List_Of_Goods_Table";
            adapter.Fill(Product_DataSet.Tables["Product_List_Of_Goods_Table"]);

            adapter.SelectCommand.CommandText = "SELECT * FROM Product_Regisreted_Product_Table";
            adapter.Fill(Product_DataSet.Tables["Product_Regisreted_Product_Table"]);

            adapter.SelectCommand.CommandText = "SELECT * FROM Product_SALE_Items_Of_Check_Table";
            adapter.Fill(Product_DataSet.Tables["Product_SALE_Items_Of_Check_Table"]);

            #endregion

            #endregion

            #region Настройка формы 


            #endregion
        }

        #endregion
      
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //Методы

        #region Метод: Загрузка товаров в список 

        private void LoadListOfProductInComboBoxProducts(string nameFingProduct)
        {
            ProductComboBox.Items.Clear();

            #region Добавляем всех 

            if (nameFingProduct == string.Empty)
            {
                if (Product_DataSet.Tables["Product_List_Of_Goods_Table"].Rows.Count > 0)
                {
                    for (int i = 0; i < Product_DataSet.Tables["Product_List_Of_Goods_Table"].Rows.Count; i++)
                    {
                        ProductComboBox.Items.Add(Product_DataSet.Tables["Product_List_Of_Goods_Table"].Rows[i]["Product_Name"].ToString());
                    }
                }
                return;
            }

            #endregion

            DataView dView = new DataView(Product_DataSet.Tables["Product_List_Of_Goods_Table"].Copy());
            try { dView.RowFilter = "Product_Name=" + nameFingProduct; }
            catch (Exception) { }
            DataTable Temp = Product_DataSet.Tables["Product_List_Of_Goods_Table"].Copy();
            DataTable Rezult = Product_DataSet.Tables["Product_List_Of_Goods_Table"].Copy();

            if (dView.Count == 1)
            {
                #region Нашли четкое соответствие 

                Rezult = dView.ToTable();
                for (int i = 0; i < Rezult.Rows.Count; i++)
                {
                    ProductComboBox.Items.Add(Rezult.Rows[i]["Product_Name"].ToString());
                }

                #endregion
            }
            else
            {
                #region Поиск совпадений 

                if (Temp.Rows.Count > 0)
                {
                    for (int z = 0; z < Temp.Rows.Count; )
                    {
                        int IndexENTER = Temp.Rows[z]["Product_Name"].ToString().IndexOf(nameFingProduct);
                        if (IndexENTER != 0)
                        {
                            Temp.Rows.RemoveAt(z);
                            z = 0;
                        }
                        else { z++; }
                    }
                }

                #endregion

                if (Temp.Rows.Count > 0)
                {
                    Rezult = Temp.Copy();
                }
            }

            #region Вывод списка товаров в COMBOBOX

            if (Rezult.Rows.Count > 0)
            {
                for (int i = 0; i < Rezult.Rows.Count; i++)
                {
                    ProductComboBox.Items.Add(Rezult.Rows[i]["Product_Name"].ToString());
                }

                if (ProductComboBox.DroppedDown) { ProductComboBox.DroppedDown = false;}
                ProductComboBox.DroppedDown = true;
            }

            #endregion
        }

        #endregion

        #region Метод: Клонирует поле с информацией 

        private void CloneDataRow(DataTable dtOld, int rowNumber)
        {
            CurrentInfoForAddToCheck = dtOld.NewRow();
            CurrentInfoForAddToCheck.ItemArray = dtOld.Rows[rowNumber].ItemArray;
        }

        #endregion

        #region Метод: Перевод BITMAP в массив байт 

        protected byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }

        #endregion

        #region Метод: Обновление таблицы 

        private void refreshDataGridView_ProductCheckList(DataTable ProductCheck)
        {
            bool goodIs = false;
            while (!goodIs)
            {
                try
                {
                    ProductCheckList.DataSource = ProductListOfCheck;
                    ProductCheckList.AutoResizeColumns();
                    ProductCheckList.Refresh();
                    goodIs = true;
                }
                catch (Exception) { System.Threading.Thread.Sleep(200); }
            }
        }

        #endregion

        #region Метод: Обновление таблицы с данными о товарах 

        private void Update_DB(DataTable Table_For_Update)
        {
            #region Обновить в базе данных информацию по передачам

            adapter.SelectCommand.CommandText = "SELECT * FROM " + Table_For_Update.TableName;
            OleDbCommandBuilder bilderObjectsCommands = new OleDbCommandBuilder(adapter);
            adapter.DeleteCommand = bilderObjectsCommands.GetDeleteCommand();
            adapter.UpdateCommand = bilderObjectsCommands.GetUpdateCommand();
            adapter.InsertCommand = bilderObjectsCommands.GetInsertCommand();
            try { adapter.Update(Table_For_Update); }
            catch (Exception) { }
            Table_For_Update.AcceptChanges();

            #endregion
        }

        #endregion

        #region Метод:

        #endregion

        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        //События

        #region Событие: Вызов окна настройки ассортимента товаров 
       
        private void AssortmentOfGoodsToolItem_Click(object sender, EventArgs e)
        {
            AssortmentOfGoodsForm form = new AssortmentOfGoodsForm(ref Product_DataSet, Product_Connect);
            form.Owner = this;
            switch (form.ShowDialog())
            {
                case DialogResult.OK:

                    #region Положительное закрытие формы 

                    Update_DB(Product_DataSet.Tables["Product_List_Of_Goods_Table"]);
                    Update_DB(Product_DataSet.Tables["Product_Regisreted_Product_Table"]);

                    #endregion

                    #region Очистка поля с товаром 

                    ProductListOfCheck.Rows.Clear();
                    CloseCheckToolItem.Enabled = false;

                    ProductComboBox.ForeColor = SystemColors.GrayText;
                    ProductComboBox.Text = "Начните вводить название товара";
                    ProductComboBox.Items.Clear();

                    QuantityDomainUpDown.Text = string.Empty;
                    TypeOfUnitValueLabel.Text = string.Empty;

                    AddProductToCheckButton.Focus();

                    #endregion

                    break;
            }
        }

        #endregion

        #region Событие: Вызов окна инвентаризации 
        
        private void InventoryToolItem_Click(object sender, EventArgs e)
        {
            AllCostAboutProductsForm form = new AllCostAboutProductsForm(Product_DataSet);
            form.Owner = this;
            switch (form.ShowDialog())
            {
                case DialogResult.OK:




                    break;
            }
        }

        #endregion

        #region Событие: Вызов окна просмотра операций 

        private void JoirnalOfActionTool_Item_Click(object sender, EventArgs e)
        {
            JoirnalOperationForm form = new JoirnalOperationForm(Product_DataSet);
            form.Owner = this;
            switch (form.ShowDialog())
            {
                case DialogResult.OK:
                    break;
            }
        }

        #endregion

        //Оформление чека

        #region Событие: Добавление товара в список товаров чека 

        private void AddProductToCheckButton_Click(object sender, EventArgs e)
        {
            #region Проверка 
            
            if (QuantityDomainUpDown.Text==string.Empty)
            {
                MessageBox.Show("Введите количество товара для добавления его в чек", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                QuantityDomainUpDown.Text = string.Empty;
                return;
            }

            switch (TypeOfUnitValueLabel.Text.Trim())
            {
                case "кг":
                case "метр":
                    try { double value = double.Parse(QuantityDomainUpDown.Text.Replace('.', ',').ToString()); }
                    catch (Exception) { MessageBox.Show("Количество товара не соответствует типы единице измерения", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
                    break;
                case "шт":
                case "пачка":
                case "бутылка":
                    try { int value = int.Parse(QuantityDomainUpDown.Text); }
                    catch (Exception) { MessageBox.Show("Количество товара не соответствует типы единице измерения", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
                    break;
            }

            #endregion

            #region Обработка добавления в чек 

            #region Проверка допустимости

            if (double.Parse(QuantityDomainUpDown.Text) <= double.Parse(CurrentInfoForAddToCheck["Product_Count"].ToString()))
            {
                #region Добавляем элемент 

                DataRow dRow = ProductListOfCheck.NewRow();
                //dRow["ImageStateOfProduct"] = imageToByteArray(ImagesForFlagItemInCheck.Images[0]);
                //dRow["FlagCurrent"] = true;
                dRow["Product_Name"] = CurrentInfoForAddToCheck["Product_Name"].ToString();
                dRow["Product_UnitValue"] = CurrentInfoForAddToCheck["Product_UnitValue"].ToString();
                dRow["Product_Count"] = double.Parse(QuantityDomainUpDown.Text).ToString();

                #region Отнимаем в таблице с товарами 

                for (int z = 0; z < Product_DataSet.Tables["Product_List_Of_Goods_Table"].Rows.Count; z++)
                {
                    if (dRow["Product_Name"].ToString() == Product_DataSet.Tables["Product_List_Of_Goods_Table"].Rows[z]["Product_Name"].ToString())
                    {
                        Product_DataSet.Tables["Product_List_Of_Goods_Table"].Rows[z]["Product_Count"] = (double.Parse(Product_DataSet.Tables["Product_List_Of_Goods_Table"].Rows[z]["Product_Count"].ToString()) - double.Parse(dRow["Product_Count"].ToString())).ToString();
                        CurrentInfoForAddToCheck["Product_Count"] = (double.Parse(CurrentInfoForAddToCheck["Product_Count"].ToString()) - double.Parse(dRow["Product_Count"].ToString())).ToString();
                        break;
                    }
                }

                #endregion

                dRow["Product_CostOfOneOption"] = CurrentInfoForAddToCheck["Product_CostOfOneOption"].ToString();
                dRow["AllCostProductSaleOperation"] = String.Format("{0:0.00}", (double.Parse(CurrentInfoForAddToCheck["Product_CostOfOneOption"].ToString()) * double.Parse(QuantityDomainUpDown.Text)));
                ProductListOfCheck.Rows.Add(dRow);

                #endregion

                #region Связываем таблицы 

                ProductCheckList.AutoGenerateColumns = false;
                ProductCheckList.DataSource = ProductListOfCheck;

                //ProductCheckList.Columns["FlagOfItem"].DataPropertyName = "ImageStateOfProduct";
                //ProductCheckList.Columns["FlagCurrent"].DataPropertyName = "FlagCurrent";
                ProductCheckList.Columns["NameOfProduct"].DataPropertyName = "Product_Name";
                ProductCheckList.Columns["TypeOfUnitProduct"].DataPropertyName = "Product_UnitValue";
                ProductCheckList.Columns["CountOfSaleProduct"].DataPropertyName = "Product_Count";
                ProductCheckList.Columns["Product_CostOfOneOption"].DataPropertyName = "Product_CostOfOneOption";
                ProductCheckList.Columns["AllCostProductSaleOperation"].DataPropertyName = "AllCostProductSaleOperation";

                #endregion

                #region Настройка списка 

                refreshDataGridView_ProductCheckList(ProductListOfCheck);
                CloseCheckToolItem.Enabled = true;
                this.Refresh();

                #endregion
            }
            else
            {
                MessageBox.Show("Нет возможности продать данное количество товара так как оно привышает остаток товара","Предупреждение",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                QuantityDomainUpDown.Text = string.Empty;
                return;
            }

            #endregion

            #endregion
        }

        #endregion

        #region Событие: При выборе элемента для выбора товара 

        private void ProductComboBox_Enter(object sender, EventArgs e)
        {
            if (ProductComboBox.Text == "Начните вводить название товара")
            {
                ProductComboBox.Text = string.Empty;
                ProductComboBox.ForeColor =  SystemColors.ControlText;
            }
        }
        private void ProductComboBox_Leave(object sender, EventArgs e)
        {
            if (ProductComboBox.Text==string.Empty )
            {
                ProductComboBox.ForeColor = SystemColors.GrayText;
                ProductComboBox.Text = "Начните вводить название товара";
                if (_timerFortextControl.Enabled) { _timerFortextControl.Stop(); }
                ProductComboBox.Items.Clear();
            }
            else
            {
                #region Поиск в таблице опции 

                TempForCheckCreate = Product_DataSet.Tables["Product_List_Of_Goods_Table"].Copy();

                if (TempForCheckCreate.Rows.Count > 0)
                {
                    for (int i = 0; i < TempForCheckCreate.Rows.Count; i++)
                    {
                        if (TempForCheckCreate.Rows[i]["Product_Name"].ToString() == ProductComboBox.Text.Trim())
                        {
                            CloneDataRow(TempForCheckCreate, i);

                            #region Перенос свойств

                            TypeOfUnitValueLabel.Text = CurrentInfoForAddToCheck["Product_UnitValue"].ToString();

                            #endregion

                            break;
                        }
                    }
                }

                #endregion
            }
        }
        private void ProductComboBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (ProductComboBox.Text=="Начните вводить название товара")
            {
                ProductComboBox.Text = string.Empty;
                ProductComboBox.ForeColor = SystemColors.ControlText;
            }
        }

        #endregion

        #region Событие: Изменение текста для добавления в чек 

        private void ProductComboBox_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                case Keys.Left:
                case Keys.Right:
                case Keys.Down:
                case Keys.Enter:
                case Keys.Escape:  return; break;
            }

            if (_timerFortextControl.Enabled) { _timerFortextControl.Stop(); }
            _timerFortextControl.Start();
        }

        #endregion

        #region Событие: Активация таймера для заполнения списка товаров 

        void _timerFortextControl_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _timerFortextControl.Stop();
            this.Invoke(new EventHandler(delegate { LoadListOfProductInComboBoxProducts(ProductComboBox.Text); }));
        }

        #endregion

        #region Событие: Открываем список выбираем и закрываем 

        private void ProductComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region Поиск в таблице опции 

            TempForCheckCreate = Product_DataSet.Tables["Product_List_Of_Goods_Table"].Copy();

            if (TempForCheckCreate.Rows.Count > 0)
            {
                for (int i = 0; i < TempForCheckCreate.Rows.Count; i++)
                {
                    if (TempForCheckCreate.Rows[i]["Product_Name"].ToString() == ProductComboBox.Text.Trim())
                    {
                        CloneDataRow(TempForCheckCreate, i);

                        #region Перенос свойств 

                        TypeOfUnitValueLabel.Text = CurrentInfoForAddToCheck["Product_UnitValue"].ToString();

                        #endregion

                        break;
                    }
                }
            }

            #endregion
        }

        #endregion


        //Форма

        #region Событие: При первом показе формы 

        private void mainForm_Shown(object sender, EventArgs e)
        {
            AddProductToCheckButton.Focus();
        }

        #endregion

        #region Событие: Вызов меню над элементом 

        private void ProductCheckList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Right:
                    contextMenuDeleteItems.Update();
                    contextMenuDeleteItems.Show(new Point(Cursor.Position.X, Cursor.Position.Y)); break;
            }
        }

        #endregion

        #region Событие: Снять_Включить позицию в списке 

        //private void FlagOFF_ON_ToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    switch (FlagOFF_ON_ToolStripMenuItem.Text)
        //    {
        //        case "Снять позицию": 
        //            ProductCheckList.SelectedRows[0].Cells["FlagCurrent"].Value = false;
        //            ProductCheckList.SelectedRows[0].Cells["FlagOfItem"].Value = imageToByteArray(ImagesForFlagItemInCheck.Images[1]);
        //            break;
        //        case "Активировать позицию": 
        //            ProductCheckList.SelectedRows[0].Cells["FlagCurrent"].Value = true;
        //            ProductCheckList.SelectedRows[0].Cells["FlagOfItem"].Value = imageToByteArray(ImagesForFlagItemInCheck.Images[0]);
        //            break;
        //    }

        //    refreshDataGridView_ProductCheckList(ProductListOfCheck);
        //}

        #endregion

        #region Событие: Удалить из списка чека 

        private void ToolStripMenuItemForDelete_Click(object sender, EventArgs e)
        {
            if (ProductListOfCheck.Rows.Count>0)
            {
                for (int i = 0; i < ProductListOfCheck.Rows.Count; i++)
                {
                    if (ProductListOfCheck.Rows[i]["Product_Name"].ToString() == ProductCheckList.SelectedRows[0].Cells["NameOfProduct"].Value.ToString())
                    {
                        #region Добавить товар в список обратно

                        for (int z = 0; z < Product_DataSet.Tables["Product_List_Of_Goods_Table"].Rows.Count; z++)
                        {
                            if (ProductListOfCheck.Rows[i]["Product_Name"].ToString() == Product_DataSet.Tables["Product_List_Of_Goods_Table"].Rows[z]["Product_Name"].ToString())
                            {
                                Product_DataSet.Tables["Product_List_Of_Goods_Table"].Rows[z]["Product_Count"] = (double.Parse(Product_DataSet.Tables["Product_List_Of_Goods_Table"].Rows[z]["Product_Count"].ToString()) + double.Parse(ProductListOfCheck.Rows[i]["Product_Count"].ToString())).ToString();
                                CurrentInfoForAddToCheck["Product_Count"] = (double.Parse(CurrentInfoForAddToCheck["Product_Count"].ToString()) + double.Parse(ProductListOfCheck.Rows[i]["Product_Count"].ToString())).ToString();
                                break;
                            }
                        }

                        #endregion

                        ProductListOfCheck.Rows.RemoveAt(i);

                        refreshDataGridView_ProductCheckList(ProductListOfCheck);
                        break;
                    }
                }
            }
            if (ProductListOfCheck.Rows.Count==0) { CloseCheckToolItem.Enabled = false; }
        }

        #endregion

        #region Событие: Активация кнопки "Закрыть чек" 

        private void CloseCheckToolItem_EnabledChanged(object sender, EventArgs e)
        {
            switch (CloseCheckToolItem.Enabled)
            {
                case true:
                    AssortmentOfGoodsToolItem.Enabled = false;
                    InventoryToolItem.Enabled = false;
                    JoirnalOfActionTool_Item.Enabled = false;
                    break;
                case false:
                    AssortmentOfGoodsToolItem.Enabled = true;
                    InventoryToolItem.Enabled = true;
                    JoirnalOfActionTool_Item.Enabled = true;
                    break;
            }
       } 

        #endregion

        #region Событие: Вызов окна закрытия операции по чеку 

        private void CloseCheckToolItem_Click(object sender, EventArgs e)
        {
            #region Подсчет чека 

            #region Вся стоимость 

            string AllCostOfCheck = string.Empty;

            double rezultDB = 0.0;
            for (int i = 0; i < ProductListOfCheck.Rows.Count; i++)
            {
                double Temp = double.Parse(ProductListOfCheck.Rows[i]["AllCostProductSaleOperation"].ToString());
                rezultDB += Temp;
            }

            AllCostOfCheck += rezultDB.ToString();

            #endregion

            #endregion

            #region Окно подтверждения заказа и закрытие чека 

            CloseCheckForm form = new CloseCheckForm(AllCostOfCheck, ProductListOfCheck.Rows.Count, Product_DataSet.Tables["Product_Check_List_Table"]);
            form.Owner = this;
            switch (form.ShowDialog())
            {
                case DialogResult.OK:

                    #region Добавляем чек 

                    Product_DataSet.Tables["Product_Check_List_Table"].Rows.Add(form.CheckInfo);

                    #endregion

                    #region Переносим все проданные товары в таблицу 

                    for (int i = 0; i < ProductListOfCheck.Rows.Count; i++)
                    {
                        #region Добавляем поле в таблицу 

                        DataRow dRow = Product_DataSet.Tables["Product_SALE_Items_Of_Check_Table"].NewRow();
                        dRow["IDParentCheck"]= form.CheckInfo["UnicalCheckID"];
                        dRow["NameOfProduct"]= ProductListOfCheck.Rows[i]["Product_Name"].ToString();
                        dRow["Product_CostOfOneOption"] = ProductListOfCheck.Rows[i]["Product_CostOfOneOption"].ToString();
                        dRow["CountOfSaleProduct"]= ProductListOfCheck.Rows[i]["Product_Count"].ToString();
                        dRow["AllCostProductSaleOperation"] = ProductListOfCheck.Rows[i]["AllCostProductSaleOperation"].ToString(); ;

                        Product_DataSet.Tables["Product_SALE_Items_Of_Check_Table"].Rows.Add(dRow);

                        #endregion
                    }
                    
                    #region Очистка поля с товаром 
                    
                    ProductListOfCheck.Rows.Clear();
                    CloseCheckToolItem.Enabled = false;

                    ProductComboBox.ForeColor = SystemColors.GrayText;
                    ProductComboBox.Text = "Начните вводить название товара";
                    ProductComboBox.Items.Clear();

                    QuantityDomainUpDown.Text = string.Empty;
                    TypeOfUnitValueLabel.Text = string.Empty;

                    AddProductToCheckButton.Focus();

                    #endregion

                    #endregion

                    #region Сохраняем результаты

                    Update_DB(Product_DataSet.Tables["Product_List_Of_Goods_Table"]);
                    Update_DB(Product_DataSet.Tables["Product_Check_List_Table"]);
                    Update_DB(Product_DataSet.Tables["Product_SALE_Items_Of_Check_Table"]);

                    #endregion

                    break;
                case DialogResult.Cancel:

                    break;
            }

            form.Dispose();
            GC.Collect();

            #endregion
        }

        #endregion

        #region Событие:

        #endregion

        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------


  
    }
}
