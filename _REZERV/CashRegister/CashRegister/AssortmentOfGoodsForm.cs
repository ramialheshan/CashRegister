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
    public partial class AssortmentOfGoodsForm : Form
    {
        //Блок инициализации и описания 

        #region Описание переменных 

        /// <summary>
        /// Инструмент для обработки данных 
        /// </summary>
        DataSet Product_DataSet;
        /// <summary>
        /// Таймер, который используеться для поиска соответствий
        /// </summary>
        System.Timers.Timer _timerFortextControl;
        /// <summary>
        /// Таймер, который используеться для поиска соответствий в списке списания 
        /// </summary>
        System.Timers.Timer _timerFortextRemoveControl;
        /// <summary>
        /// таблица используеться для обмена информации при заполнении списка товаров
        /// </summary>
        DataTable TempForCheckCreate;
        /// <summary>
        /// Информация для добавления в таблицу 
        /// </summary>
        DataRow CurrentInfoForAddToCheck;
        /// <summary>
        /// Информация для списания в таблицу 
        /// </summary>
        DataRow CurrentInfoForRemoveToCheck;

        /// <summary>
        /// Ссылка на подключение 
        /// </summary>
        OleDbConnection _Connection;

        /// <summary>
        /// Адаптер для работы с данными 
        /// </summary>
        OleDbDataAdapter adapter;

        #endregion

        #region Конструктор формы 

        public AssortmentOfGoodsForm(ref DataSet DataForWork,OleDbConnection connect)
        {
            InitializeComponent();

            #region Инициализация инструментов 

            _timerFortextControl = new System.Timers.Timer(1000);
            _timerFortextControl.Elapsed += new System.Timers.ElapsedEventHandler(_timerFortextControl_Elapsed);

            _timerFortextRemoveControl = new System.Timers.Timer(1000);
            _timerFortextRemoveControl.Elapsed += new System.Timers.ElapsedEventHandler(_timerFortextRemoveControl_Elapsed);

            _Connection = connect;
            adapter = new OleDbDataAdapter();
            adapter.SelectCommand = new OleDbCommand("", _Connection);
            adapter.InsertCommand = new OleDbCommand("", _Connection);
            adapter.DeleteCommand = new OleDbCommand("", _Connection);
            adapter.UpdateCommand = new OleDbCommand("", _Connection);

            #endregion

            #region Получение инормации для работы 

            Product_DataSet = DataForWork;
            

            #endregion
            
        }


        #endregion

        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //Методы

        #region Метод: Загрузка товаров в список 

        private void LoadListOfProductInComboBoxProducts(string nameFingProduct,ref ComboBox TEMP_COMBO_BOX)
        {
            TEMP_COMBO_BOX.Items.Clear();

            #region Добавляем всех 

            if (nameFingProduct == string.Empty)
            {
                if (Product_DataSet.Tables["Product_List_Of_Goods_Table"].Rows.Count > 0)
                {
                    for (int i = 0; i < Product_DataSet.Tables["Product_List_Of_Goods_Table"].Rows.Count; i++)
                    {
                        TEMP_COMBO_BOX.Items.Add(Product_DataSet.Tables["Product_List_Of_Goods_Table"].Rows[i]["Product_Name"].ToString());
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
                    TEMP_COMBO_BOX.Items.Add(Rezult.Rows[i]["Product_Name"].ToString());
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
                    TEMP_COMBO_BOX.Items.Add(Rezult.Rows[i]["Product_Name"].ToString());
                }

                if (TEMP_COMBO_BOX.DroppedDown) { TEMP_COMBO_BOX.DroppedDown = false; }
                TEMP_COMBO_BOX.DroppedDown = true;
            }

            #endregion
        }

        #endregion

        #region Метод: Клонирует поле с информацией 

        private void CloneDataRow(ref DataRow RowForWork,DataTable dtOld, int rowNumber)
        {
            RowForWork = dtOld.NewRow();
            RowForWork.ItemArray = dtOld.Rows[rowNumber].ItemArray;
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

        #region Событие: Работа с элементом для выбора товара 

        private void ProductComboBox_Enter(object sender, EventArgs e)
        {
            switch ((sender as ComboBox).Name)
            {
                case "ProductComboBox":

                    #region Товары при добавлении 
                    
                    switch (ProductComboBox.DropDownStyle)
                    {
                        case ComboBoxStyle.DropDown:
                            if (ProductComboBox.Text == "Начните вводить название товара")
                            {
                                ProductComboBox.Text = string.Empty;
                                ProductComboBox.ForeColor = SystemColors.ControlText;
                            }
                            break;
                        case ComboBoxStyle.DropDownList:
                            break;
                        case ComboBoxStyle.Simple:
                            break;
                    }

                    #endregion

                    break;
                case "ProductForRemoveComboBox":

                    #region Товары при списании 

                    switch (ProductForRemoveComboBox.DropDownStyle)
                    {
                        case ComboBoxStyle.DropDown:
                            if (ProductForRemoveComboBox.Text == "Начните вводить название товара")
                            {
                                ProductForRemoveComboBox.Text = string.Empty;
                                ProductForRemoveComboBox.ForeColor = SystemColors.ControlText;
                            }
                            break;
                    }

                    #endregion

                    break;
            }

           
         
        }
        private void ProductComboBox_Leave(object sender, EventArgs e)
        {
            switch ((sender as ComboBox).Name)
            {
                case "ProductComboBox":
                    #region Товары при добавлении 

                    switch (ProductComboBox.DropDownStyle)
                    {
                        case ComboBoxStyle.DropDown:

                            if (ProductComboBox.Text == string.Empty)
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
                                            CloneDataRow(ref CurrentInfoForAddToCheck,TempForCheckCreate, i);
                                            break;
                                        }
                                    }
                                }

                                #endregion
                            }

                            break;
                        case ComboBoxStyle.DropDownList:


                            break;
                        case ComboBoxStyle.Simple:
                            break;
                        default:
                            break;
                    }

                    #endregion
                    break;
                case "ProductForRemoveComboBox":
                    #region Товары при списании 

                    switch (ProductForRemoveComboBox.DropDownStyle)
                    {
                        case ComboBoxStyle.DropDown:

                            if (ProductForRemoveComboBox.Text == string.Empty)
                            {
                                ProductForRemoveComboBox.ForeColor = SystemColors.GrayText;
                                ProductForRemoveComboBox.Text = "Начните вводить название товара";
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
                                            CloneDataRow(ref CurrentInfoForRemoveToCheck,TempForCheckCreate, i);
                                            break;
                                        }
                                    }
                                }

                                #endregion
                            }

                            break;
                    }

                    #endregion
                    break;
            }
        }
        private void ProductComboBox_MouseClick(object sender, MouseEventArgs e)
        {
            switch ((sender as ComboBox).Name)
            {
                case "ProductComboBox":
                    #region Добавление товара 
                    
                    switch (ProductComboBox.DropDownStyle)
                    {
                        case ComboBoxStyle.DropDown:

                            if (ProductComboBox.Text == "Начните вводить название товара")
                            {
                                ProductComboBox.Text = string.Empty;
                                ProductComboBox.ForeColor = SystemColors.ControlText;
                            }

                            break;
                        case ComboBoxStyle.DropDownList:

                            break;
                        case ComboBoxStyle.Simple:
                            break;
                    }

                    #endregion
                    break;
                case "ProductForRemoveComboBox":
                    #region Товары при списании 

                    switch (ProductForRemoveComboBox.DropDownStyle)
                    {
                        case ComboBoxStyle.DropDown:

                            if (ProductForRemoveComboBox.Text == "Начните вводить название товара")
                            {
                                ProductForRemoveComboBox.Text = string.Empty;
                                ProductForRemoveComboBox.ForeColor = SystemColors.ControlText;
                            }

                            break;
                    }

                    #endregion
                    break;
            }
        }

        #region Событие: Изменение текста для добавления товара 

        private void ProductComboBox_KeyUp(object sender, KeyEventArgs e)
        {
            switch ((sender as ComboBox).Name)
            {
                case "ProductComboBox":
                    #region Добавление товара 

                    switch (ProductComboBox.DropDownStyle)
                    {
                        case ComboBoxStyle.DropDown:
                            switch (e.KeyCode)
                            {
                                case Keys.Up:
                                case Keys.Left:
                                case Keys.Right:
                                case Keys.Down:
                                case Keys.Enter:
                                case Keys.Escape: return; break;
                            }

                            if (_timerFortextControl.Enabled) { _timerFortextControl.Stop(); }
                            _timerFortextControl.Start();
                            break;
                    }

                    #endregion
                    break;
                case "ProductForRemoveComboBox":
                    #region Товары при списании 

                    switch (ProductForRemoveComboBox.DropDownStyle)
                    {
                        case ComboBoxStyle.DropDown:
                            switch (e.KeyCode)
                            {
                                case Keys.Up:
                                case Keys.Left:
                                case Keys.Right:
                                case Keys.Down:
                                case Keys.Enter:
                                case Keys.Escape: return; break;
                            }

                            if (_timerFortextRemoveControl.Enabled) { _timerFortextRemoveControl.Stop(); }
                            _timerFortextRemoveControl.Start();
                            break;
                    }

                    #endregion
                    break;
            }
            
        }

        #endregion

        #endregion

        #region Событие: нажатие кнопки "ЗАКРЫТЬ" 
        
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        #endregion
 
        #region Событие: Выбор типа операции добавления 

        private void NewProductRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            switch ((sender as RadioButton).Checked)
            {
                case true:

                    switch ((sender as RadioButton).Name)
                    {
                        case "NewProductRadioButton":
                            #region Настройка для добавления нового товара 
                             
                            ProductComboBox.DropDownStyle = ComboBoxStyle.Simple;
                            ProductComboBox.Text = string.Empty;
                            ProductComboBox.ForeColor = SystemColors.ControlText;
                            NumberUnitProductComboBox.Enabled = true;
                            NumberUnitProductComboBox.SelectedIndex = 0;
                            CostPerOneOfProductTextBox.Enabled = true;
                            CostPerOneOfProductTextBox.Text = "0000,00";

                            #endregion
                            break;
                        case "ExistingProductRadioButton":
                            #region Настройка для добавления количества товара 

                            ProductComboBox.DropDownStyle = ComboBoxStyle.DropDown;
                            ProductComboBox.Text = string.Empty;
                            ProductComboBox.ForeColor = SystemColors.GrayText;
                            NumberUnitProductComboBox.Enabled = false;
                            CostPerOneOfProductTextBox.Enabled = false;
                            ProductComboBox.Text = "Начните вводить название товара";

                            #endregion

                            break;
                    }

                    break;
            }
        }

        #endregion

        #region Событие: Операция добавления 

        private void AddValueProductButton_Click(object sender, EventArgs e)
        {
            #region Добавляем новый товар 

            switch (NewProductRadioButton.Checked)
            {
                case true:

                    #region Переменные 

                    string _value_CostPerOneOfProductTextBox = string.Empty;
                    string _value_NumberForADDTextBox = string.Empty; 

                    #endregion

                    #region Наличия такого товара 

                    if (Product_DataSet.Tables["Product_List_Of_Goods_Table"].Rows.Count > 0 && !string.IsNullOrEmpty(ProductComboBox.Text.Trim()))
                    {
                        for (int i = 0; i < Product_DataSet.Tables["Product_List_Of_Goods_Table"].Rows.Count; i++)
                        {
                            if (Product_DataSet.Tables["Product_List_Of_Goods_Table"].Rows[i]["Product_Name"].ToString() == ProductComboBox.Text.Trim())
                            {
                                MessageBox.Show("Товар присутствует в списке товаров", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Stop); return;
                            }
                        }
                    }
                    else { MessageBox.Show("Введите название товара", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }

                    #endregion

                    #region Проверить стоимость товара 

                    try 
                    {
                        if (!string.IsNullOrEmpty(CostPerOneOfProductTextBox.Text))
                        {
                            double value = double.Parse(CostPerOneOfProductTextBox.Text.Replace('.', ',').ToString());
                            if (value <= 0)
                            {
                                throw new ArgumentException();
                            }
                            else
                            {
                                _value_CostPerOneOfProductTextBox = value.ToString();
                            }
                        }
                        else
                        {
                            throw new ArgumentException();
                        }
                     
                    }
                    catch (Exception) { MessageBox.Show("Стоимость товара должа быть больше нуля", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }


                    #endregion

                    #region Контроль добавляемого вещества 

                    switch (NumberUnitProductComboBox.SelectedIndex)
                    {
                        case 0:
                        case 1:
                            try { double value = double.Parse(NumberForADDTextBox.Text.Replace('.', ',').ToString()); _value_NumberForADDTextBox = value.ToString(); }
                            catch (Exception) { MessageBox.Show("Количество товара не соответствует типы единице измерения", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
                        break;

                        case 2:
                        case 3:
                        case 4:
                        try { int value = int.Parse(NumberForADDTextBox.Text); _value_NumberForADDTextBox = value.ToString(); }
                        catch (Exception) { MessageBox.Show("Количество товара не соответствует типы единице измерения", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
                        break;

                    }

                    #endregion

                    #region Добавление товара в список 

                    DataRow newROW_IN_TABLE = Product_DataSet.Tables["Product_List_Of_Goods_Table"].NewRow();
                    newROW_IN_TABLE["Product_Name"] = ProductComboBox.Text.Trim();
                    newROW_IN_TABLE["Product_UnitValue"] = NumberUnitProductComboBox.Text.Trim();
                    newROW_IN_TABLE["Product_CostOfOneOption"] = _value_CostPerOneOfProductTextBox;
                    newROW_IN_TABLE["Product_Count"] = _value_NumberForADDTextBox;
                    newROW_IN_TABLE["Product_DateOfLastDelivery"] = DateTime.Now;
                    Product_DataSet.Tables["Product_List_Of_Goods_Table"].Rows.Add(newROW_IN_TABLE);

                    ProductAllValueTextBox.Text = newROW_IN_TABLE["Product_Count"].ToString();

                    #endregion

                    #region Регистрируем событие в таблицы регистрации 

                    DataRow newROW_IN_TABLE_Regisreted = Product_DataSet.Tables["Product_Regisreted_Product_Table"].NewRow();

                    newROW_IN_TABLE_Regisreted["UnicalNumberProductForChange"] = int.Parse(newROW_IN_TABLE["UnicalCounterProduct"].ToString());
                    newROW_IN_TABLE_Regisreted["NameProductForChange"] = newROW_IN_TABLE["Product_Name"].ToString();
                    newROW_IN_TABLE_Regisreted["TypeOfOperation"] = mainForm.TypeOfOperationRegisreted.AddNewProduct.ToString();
                    newROW_IN_TABLE_Regisreted["DateTimeOfOperation"] = DateTime.Now.ToString();
                    newROW_IN_TABLE_Regisreted["CountOfProductBeforeOperation"] = "0";
                    newROW_IN_TABLE_Regisreted["CountOfProductAfterOperation"] = _value_NumberForADDTextBox;
                    Product_DataSet.Tables["Product_Regisreted_Product_Table"].Rows.Add(newROW_IN_TABLE_Regisreted);

                    #endregion

                    MessageBox.Show("Товар - " + newROW_IN_TABLE["Product_Name"].ToString() + "\n\n" + " Успешно добавлен", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                    break;

            }

            #endregion

            #region Добавляем количество товара 

            switch (ExistingProductRadioButton.Checked)
            {
                case true:

                    #region Переменные

                    var _value_CostPerOneOfProductTextBox = string.Empty;
                    var _value_NumberForADDTextBox = string.Empty;

                    #endregion

                    #region Контроль добавляемого вещества 

                    switch (NumberUnitProductComboBox.SelectedIndex)
                    {
                        case 0:
                        case 1:
                            try { double value = double.Parse(NumberForADDTextBox.Text.Replace('.', ',').ToString()); _value_NumberForADDTextBox = value.ToString(); }
                            catch (Exception) { MessageBox.Show("Количество товара не соответствует типы единице измерения", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
                            break;

                        case 2:
                        case 3:
                        case 4:
                            try { int value = int.Parse(NumberForADDTextBox.Text); _value_NumberForADDTextBox = value.ToString(); }
                            catch (Exception) { MessageBox.Show("Количество товара не соответствует типы единице измерения", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
                            break;

                    }

                    #endregion

                    #region Поиск товара и добавление 

                    if (Product_DataSet.Tables["Product_List_Of_Goods_Table"].Rows.Count>0)
                    {
                        for (int i = 0; i < Product_DataSet.Tables["Product_List_Of_Goods_Table"].Rows.Count; i++)
                        {
                            if (CurrentInfoForAddToCheck["Product_Name"].ToString()==Product_DataSet.Tables["Product_List_Of_Goods_Table"].Rows[i]["Product_Name"].ToString() )
                            {
                                #region Добавление 

                                switch (NumberUnitProductComboBox.SelectedIndex)
                                {
                                    case 0:
                                    case 1:
                                        try
                                        {
                                            double value = double.Parse(Product_DataSet.Tables["Product_List_Of_Goods_Table"].Rows[i]["Product_Count"].ToString().Replace('.', ',').ToString());
                                            double value_2 = double.Parse(NumberForADDTextBox.Text.Replace('.', ',').ToString());
                                            Product_DataSet.Tables["Product_List_Of_Goods_Table"].Rows[i]["Product_Count"] = (value + value_2).ToString();
                                            ProductAllValueTextBox.Text = Product_DataSet.Tables["Product_List_Of_Goods_Table"].Rows[i]["Product_Count"].ToString();
                                            i = Product_DataSet.Tables["Product_List_Of_Goods_Table"].Rows.Count;
                                            
                                            #region Регистрируем событие в таблицы регистрации 

                                            DataRow newROW_IN_TABLE_Regisreted = Product_DataSet.Tables["Product_Regisreted_Product_Table"].NewRow();

                                            newROW_IN_TABLE_Regisreted["UnicalNumberProductForChange"] = int.Parse(CurrentInfoForAddToCheck["UnicalCounterProduct"].ToString());
                                            newROW_IN_TABLE_Regisreted["NameProductForChange"] = CurrentInfoForAddToCheck["Product_Name"].ToString();
                                            newROW_IN_TABLE_Regisreted["TypeOfOperation"] = mainForm.TypeOfOperationRegisreted.AddCountProduct.ToString();
                                            newROW_IN_TABLE_Regisreted["DateTimeOfOperation"] = DateTime.Now.ToString();
                                            newROW_IN_TABLE_Regisreted["CountOfProductBeforeOperation"] = value.ToString();
                                            newROW_IN_TABLE_Regisreted["CountOfProductAfterOperation"] = _value_NumberForADDTextBox;
                                            Product_DataSet.Tables["Product_Regisreted_Product_Table"].Rows.Add(newROW_IN_TABLE_Regisreted);

                                            #endregion

                                        }
                                        catch (Exception) { MessageBox.Show("Количество товара не соответствует типу единицы измерения", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
                                        finally { NumberForADDTextBox.Text = string.Empty; }
                                        break;

                                    case 2:
                                    case 3:
                                    case 4:
                                        try 
                                        { 
                                            int value = int.Parse(NumberForADDTextBox.Text);
                                            int value_2 = int.Parse(Product_DataSet.Tables["Product_List_Of_Goods_Table"].Rows[i]["Product_Count"].ToString());
                                            Product_DataSet.Tables["Product_List_Of_Goods_Table"].Rows[i]["Product_Count"] = (value + value_2).ToString();
                                            ProductAllValueTextBox.Text = Product_DataSet.Tables["Product_List_Of_Goods_Table"].Rows[i]["Product_Count"].ToString();
                                            i = Product_DataSet.Tables["Product_List_Of_Goods_Table"].Rows.Count;

                                            #region Регистрируем событие в таблицы регистрации 

                                            DataRow newROW_IN_TABLE_Regisreted = Product_DataSet.Tables["Product_Regisreted_Product_Table"].NewRow();

                                            newROW_IN_TABLE_Regisreted["UnicalNumberProductForChange"] = int.Parse(CurrentInfoForAddToCheck["UnicalCounterProduct"].ToString());
                                            newROW_IN_TABLE_Regisreted["NameProductForChange"] = CurrentInfoForAddToCheck["Product_Name"].ToString();
                                            newROW_IN_TABLE_Regisreted["TypeOfOperation"] = mainForm.TypeOfOperationRegisreted.AddCountProduct.ToString();
                                            newROW_IN_TABLE_Regisreted["DateTimeOfOperation"] = DateTime.Now.ToString();
                                            newROW_IN_TABLE_Regisreted["CountOfProductBeforeOperation"] = value_2.ToString();
                                            newROW_IN_TABLE_Regisreted["CountOfProductAfterOperation"] = _value_NumberForADDTextBox;
                                            Product_DataSet.Tables["Product_Regisreted_Product_Table"].Rows.Add(newROW_IN_TABLE_Regisreted);

                                            #endregion
                                        }
                                        catch (Exception) { MessageBox.Show("Количество товара не соответствует типу единицы измерения", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
                                        finally { NumberForADDTextBox.Text = string.Empty; }
                                        break;
                                }
	
                                #endregion
                            }
                        }
                    }

                    #endregion

                    MessageBox.Show("Количество товара - " + CurrentInfoForAddToCheck["Product_Name"].ToString() + "\n\n" + "Успешно добавлено", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }

            #endregion
        }

        #endregion

        #region Событие: При первом показе формы 
        
        private void AssortmentOfGoodsForm_Shown(object sender, EventArgs e)
        {
            NewProductRadioButton.Checked = true;
            AddValueProductButton.Select();
        }

        #endregion

        #region Событие: Активация таймера для заполнения списка товаров 

        void _timerFortextControl_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _timerFortextControl.Stop();
            this.Invoke(new EventHandler(delegate { LoadListOfProductInComboBoxProducts(ProductComboBox.Text,ref ProductComboBox); }));
        
        }
        void _timerFortextRemoveControl_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _timerFortextRemoveControl.Stop();
            this.Invoke(new EventHandler(delegate { LoadListOfProductInComboBoxProducts(ProductForRemoveComboBox.Text, ref ProductForRemoveComboBox); }));
        }

        #endregion

        #region Событие: Открываем список выбираем и закрываем 

        private void ProductComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
           switch ((sender as ComboBox).Name)
            {
                case "ProductComboBox":
                   
                   #region Товары при добавлении

                    switch (ProductComboBox.DropDownStyle)
                    {
                        case ComboBoxStyle.DropDown:

                            #region Поиск в таблице опции 

                            TempForCheckCreate = Product_DataSet.Tables["Product_List_Of_Goods_Table"].Copy();

                            if (TempForCheckCreate.Rows.Count > 0)
                            {
                                for (int i = 0; i < TempForCheckCreate.Rows.Count; i++)
                                {
                                    if (TempForCheckCreate.Rows[i]["Product_Name"].ToString() == ProductComboBox.Text.Trim())
                                    {
                                        CloneDataRow(ref CurrentInfoForAddToCheck, TempForCheckCreate, i);

                                        #region Перенос свойств

                                        #region Поиск единицы измерения

                                        if (NumberUnitProductComboBox.Items.Count > 0)
                                        {
                                            for (int z = 0; z < NumberUnitProductComboBox.Items.Count; z++)
                                            {
                                                if (NumberUnitProductComboBox.Items[z].ToString() == CurrentInfoForAddToCheck["Product_UnitValue"].ToString())
                                                {
                                                    NumberUnitProductComboBox.Enabled = true;
                                                    NumberUnitProductComboBox.SelectedIndex = z;
                                                    NumberUnitProductComboBox.Enabled = false;
                                                    break;
                                                }
                                            }
                                        }

                                        #endregion

                                        #region Применение цены единицы

                                        string rezult = String.Format("{0:0000.00}", double.Parse(CurrentInfoForAddToCheck["Product_CostOfOneOption"].ToString()));

                                        CostPerOneOfProductTextBox.Enabled = true;
                                        CostPerOneOfProductTextBox.Text = rezult;
                                        CostPerOneOfProductTextBox.Enabled = false;

                                        #endregion

                                        ProductAllValueTextBox.Text = CurrentInfoForAddToCheck["Product_Count"].ToString();

                                        #endregion

                                        break;
                                    }
                                }
                            }

                            #endregion

                            break;
                        case ComboBoxStyle.Simple:
                            break;
                    }
                   
                   #endregion  
                   
                    break;

                case "ProductForRemoveComboBox":
                   
                   #region Товары при списании 

                    switch (ProductForRemoveComboBox.DropDownStyle)
                    {
                        case ComboBoxStyle.DropDown:
                            #region Поиск в таблице опции 

                            TempForCheckCreate = Product_DataSet.Tables["Product_List_Of_Goods_Table"].Copy();

                            if (TempForCheckCreate.Rows.Count > 0)
                            {
                                for (int i = 0; i < TempForCheckCreate.Rows.Count; i++)
                                {
                                    if (TempForCheckCreate.Rows[i]["Product_Name"].ToString() == ProductForRemoveComboBox.Text.Trim())
                                    {
                                        CloneDataRow(ref CurrentInfoForRemoveToCheck, TempForCheckCreate, i);

                                        #region Перенос свойств 

                                        #region Поиск единицы измерения 

                                        if (NumberUnitProduct_REMOVE_ComboBox.Items.Count > 0)
                                        {
                                            for (int z = 0; z < NumberUnitProduct_REMOVE_ComboBox.Items.Count; z++)
                                            {
                                                if (NumberUnitProduct_REMOVE_ComboBox.Items[z].ToString() == CurrentInfoForRemoveToCheck["Product_UnitValue"].ToString())
                                                {
                                                    NumberUnitProduct_REMOVE_ComboBox.Enabled = true;
                                                    NumberUnitProduct_REMOVE_ComboBox.SelectedIndex = z;
                                                    NumberUnitProduct_REMOVE_ComboBox.Enabled = false;
                                                    break;
                                                }
                                            }
                                        }

                                        #endregion

                                        #region Применение цены единицы 

                                        string rezult = String.Format("{0:0000.00}", double.Parse(CurrentInfoForRemoveToCheck["Product_CostOfOneOption"].ToString()));

                                        CostPerOneOfProduct_REMOVE_TextBox.Enabled = true;
                                        CostPerOneOfProduct_REMOVE_TextBox.Text = rezult;
                                        CostPerOneOfProduct_REMOVE_TextBox.Enabled = false;

                                        #endregion

                                        ProductAllValue_REMOVE_TextBox.Text = CurrentInfoForRemoveToCheck["Product_Count"].ToString();

                                        #endregion

                                        break;
                                    }
                                }
                            }

                            #endregion
                            break;
                    }
                    
                   #endregion
                    
                    break;
            }
        }

        #endregion


        #region Событие: Работа со списком товаров для списания и удаления товара 

        private void RemoveValueProductButton_Click(object sender, EventArgs e)
        {
            #region Переменные

            var _value_CostPerOneOfProductTextBox = string.Empty;
            var _value_NumberForRemoveTextBox = string.Empty;

            #endregion

            #region Контроль добавляемого вещества 

            switch (NumberUnitProduct_REMOVE_ComboBox.SelectedIndex)
            {
                case 0:
                case 1:
                    try { double value = double.Parse(NumberFor_REMOVE_TextBox.Text.Replace('.', ',').ToString()); _value_NumberForRemoveTextBox = value.ToString(); }
                    catch (Exception) { MessageBox.Show("Количество товара не соответствует типы единице измерения", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
                    break;

                case 2:
                case 3:
                case 4:
                    try { int value = int.Parse(NumberFor_REMOVE_TextBox.Text); _value_NumberForRemoveTextBox = value.ToString(); }
                    catch (Exception) { MessageBox.Show("Количество товара не соответствует типы единице измерения", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
                    break;

            }

            #endregion

            #region Поиск товара и добавление

            if (Product_DataSet.Tables["Product_List_Of_Goods_Table"].Rows.Count > 0)
            {
                for (int i = 0; i < Product_DataSet.Tables["Product_List_Of_Goods_Table"].Rows.Count; i++)
                {
                    if (CurrentInfoForRemoveToCheck["Product_Name"].ToString() == Product_DataSet.Tables["Product_List_Of_Goods_Table"].Rows[i]["Product_Name"].ToString())
                    {
                        #region Проверка спиания 

                        switch (NumberUnitProduct_REMOVE_ComboBox.SelectedIndex)
                        {
                            case 0:
                            case 1:
                                try
                                {
                                    double value = double.Parse(Product_DataSet.Tables["Product_List_Of_Goods_Table"].Rows[i]["Product_Count"].ToString().Replace('.', ',').ToString());
                                    double value_2 = double.Parse(NumberFor_REMOVE_TextBox.Text.Replace('.', ',').ToString());

                                    #region Проверка действий 
                                    
                                    if (value_2>=value)
                                    {
                                        switch (MessageBox.Show("Количество товара для списание привышает количество товара в наличии"+"\n"+"Списать и удалить товар из списка товаров?", "Списание товара", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                                        {
                                            case DialogResult.Yes:

                                                #region Регистрируем событие в таблицы регистрации 

                                                DataRow newROW_IN_TABLE_Regisreted = Product_DataSet.Tables["Product_Regisreted_Product_Table"].NewRow();

                                                newROW_IN_TABLE_Regisreted["UnicalNumberProductForChange"] = int.Parse(CurrentInfoForRemoveToCheck["UnicalCounterProduct"].ToString());
                                                newROW_IN_TABLE_Regisreted["NameProductForChange"] = CurrentInfoForRemoveToCheck["Product_Name"].ToString();
                                                newROW_IN_TABLE_Regisreted["TypeOfOperation"] = mainForm.TypeOfOperationRegisreted.DeleteProduct.ToString();
                                                newROW_IN_TABLE_Regisreted["DateTimeOfOperation"] = DateTime.Now.ToString();
                                                newROW_IN_TABLE_Regisreted["CountOfProductBeforeOperation"] = value.ToString();
                                                newROW_IN_TABLE_Regisreted["CountOfProductAfterOperation"] = "0";
                                                Product_DataSet.Tables["Product_Regisreted_Product_Table"].Rows.Add(newROW_IN_TABLE_Regisreted);

                                                #endregion

                                                Product_DataSet.Tables["Product_List_Of_Goods_Table"].Rows[i].Delete();
                                                Update_DB(Product_DataSet.Tables["Product_List_Of_Goods_Table"]);

                                                break;
                                            case DialogResult.No:

                                                #region Регистрируем событие в таблицы регистрации 

                                                DataRow newROW_IN_TABLE_Regisreted_NO = Product_DataSet.Tables["Product_Regisreted_Product_Table"].NewRow();

                                                newROW_IN_TABLE_Regisreted_NO["UnicalNumberProductForChange"] = int.Parse(CurrentInfoForRemoveToCheck["UnicalCounterProduct"].ToString());
                                                newROW_IN_TABLE_Regisreted_NO["NameProductForChange"] = CurrentInfoForRemoveToCheck["Product_Name"].ToString();
                                                newROW_IN_TABLE_Regisreted_NO["TypeOfOperation"] = mainForm.TypeOfOperationRegisreted.RemoveCountProduct.ToString();
                                                newROW_IN_TABLE_Regisreted_NO["DateTimeOfOperation"] = DateTime.Now.ToString();
                                                newROW_IN_TABLE_Regisreted_NO["CountOfProductBeforeOperation"] = value.ToString();
                                                newROW_IN_TABLE_Regisreted_NO["CountOfProductAfterOperation"] = "0";

                                                Product_DataSet.Tables["Product_Regisreted_Product_Table"].Rows.Add(newROW_IN_TABLE_Regisreted_NO);

                                                #endregion

                                                Product_DataSet.Tables["Product_List_Of_Goods_Table"].Rows[i]["Product_Count"] = "0";
                                                ProductAllValue_REMOVE_TextBox.Text = Product_DataSet.Tables["Product_List_Of_Goods_Table"].Rows[i]["Product_Count"].ToString();

                                                break;
                                        }
                                    }
                                    else
                                    {
                                        #region Списываем количество товара 

                                        #region Регистрируем событие в таблицы регистрации 

                                        DataRow newROW_IN_TABLE_Regisreted_NO = Product_DataSet.Tables["Product_Regisreted_Product_Table"].NewRow();

                                        newROW_IN_TABLE_Regisreted_NO["UnicalNumberProductForChange"] = int.Parse(CurrentInfoForRemoveToCheck["UnicalCounterProduct"].ToString());
                                        newROW_IN_TABLE_Regisreted_NO["NameProductForChange"] = CurrentInfoForRemoveToCheck["Product_Name"].ToString();
                                        newROW_IN_TABLE_Regisreted_NO["TypeOfOperation"] = mainForm.TypeOfOperationRegisreted.RemoveCountProduct.ToString();
                                        newROW_IN_TABLE_Regisreted_NO["DateTimeOfOperation"] = DateTime.Now.ToString();
                                        newROW_IN_TABLE_Regisreted_NO["CountOfProductBeforeOperation"] = value.ToString();
                                        newROW_IN_TABLE_Regisreted_NO["CountOfProductAfterOperation"] = (value - value_2).ToString();

                                        Product_DataSet.Tables["Product_Regisreted_Product_Table"].Rows.Add(newROW_IN_TABLE_Regisreted_NO);

                                        #endregion

                                        Product_DataSet.Tables["Product_List_Of_Goods_Table"].Rows[i]["Product_Count"] = (value - value_2).ToString();
                                        ProductAllValue_REMOVE_TextBox.Text = Product_DataSet.Tables["Product_List_Of_Goods_Table"].Rows[i]["Product_Count"].ToString();

                                        #endregion
                                    }

                                    #endregion

                                    i = Product_DataSet.Tables["Product_List_Of_Goods_Table"].Rows.Count;
                                }
                                catch (Exception) { MessageBox.Show("Количество товара не соответствует типу единицы измерения", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
                                finally { NumberFor_REMOVE_TextBox.Text = string.Empty; }
                                break;

                            case 2:
                            case 3:
                            case 4:
                                try
                                {
                                    int value = int.Parse(Product_DataSet.Tables["Product_List_Of_Goods_Table"].Rows[i]["Product_Count"].ToString()) ;
                                    int value_2 = int.Parse(NumberFor_REMOVE_TextBox.Text);

                                    #region Проверка действий

                                    if (value_2 >= value)
                                    {
                                        switch (MessageBox.Show("Количество товара для списание привышает количество товара в наличии" + "\n" + "Списать и удалить товар из списка товаров?", "Списание товара", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                                        {
                                            case DialogResult.Yes:

                                                #region Регистрируем событие в таблицы регистрации

                                                DataRow newROW_IN_TABLE_Regisreted = Product_DataSet.Tables["Product_Regisreted_Product_Table"].NewRow();

                                                newROW_IN_TABLE_Regisreted["UnicalNumberProductForChange"] = int.Parse(CurrentInfoForRemoveToCheck["UnicalCounterProduct"].ToString());
                                                newROW_IN_TABLE_Regisreted["NameProductForChange"] = CurrentInfoForRemoveToCheck["Product_Name"].ToString();
                                                newROW_IN_TABLE_Regisreted["TypeOfOperation"] = mainForm.TypeOfOperationRegisreted.DeleteProduct.ToString();
                                                newROW_IN_TABLE_Regisreted["DateTimeOfOperation"] = DateTime.Now.ToString();
                                                newROW_IN_TABLE_Regisreted["CountOfProductBeforeOperation"] = value.ToString();
                                                newROW_IN_TABLE_Regisreted["CountOfProductAfterOperation"] = "0";
                                                Product_DataSet.Tables["Product_Regisreted_Product_Table"].Rows.Add(newROW_IN_TABLE_Regisreted);

                                                #endregion

                                                Product_DataSet.Tables["Product_List_Of_Goods_Table"].Rows[i].Delete();
                                                Update_DB(Product_DataSet.Tables["Product_List_Of_Goods_Table"]);

                                                break;
                                            case DialogResult.No:

                                                #region Регистрируем событие в таблицы регистрации

                                                DataRow newROW_IN_TABLE_Regisreted_NO = Product_DataSet.Tables["Product_Regisreted_Product_Table"].NewRow();

                                                newROW_IN_TABLE_Regisreted_NO["UnicalNumberProductForChange"] = int.Parse(CurrentInfoForRemoveToCheck["UnicalCounterProduct"].ToString());
                                                newROW_IN_TABLE_Regisreted_NO["NameProductForChange"] = CurrentInfoForRemoveToCheck["Product_Name"].ToString();
                                                newROW_IN_TABLE_Regisreted_NO["TypeOfOperation"] = mainForm.TypeOfOperationRegisreted.RemoveCountProduct.ToString();
                                                newROW_IN_TABLE_Regisreted_NO["DateTimeOfOperation"] = DateTime.Now.ToString();
                                                newROW_IN_TABLE_Regisreted_NO["CountOfProductBeforeOperation"] = value.ToString();
                                                newROW_IN_TABLE_Regisreted_NO["CountOfProductAfterOperation"] = "0";

                                                Product_DataSet.Tables["Product_Regisreted_Product_Table"].Rows.Add(newROW_IN_TABLE_Regisreted_NO);

                                                #endregion

                                                Product_DataSet.Tables["Product_List_Of_Goods_Table"].Rows[i]["Product_Count"] = "0";
                                                ProductAllValue_REMOVE_TextBox.Text = Product_DataSet.Tables["Product_List_Of_Goods_Table"].Rows[i]["Product_Count"].ToString();

                                                break;
                                        }
                                    }
                                    else
                                    {
                                        #region Списываем количество товара 

                                        #region Регистрируем событие в таблицы регистрации 

                                        DataRow newROW_IN_TABLE_Regisreted_NO = Product_DataSet.Tables["Product_Regisreted_Product_Table"].NewRow();

                                        newROW_IN_TABLE_Regisreted_NO["UnicalNumberProductForChange"] = int.Parse(CurrentInfoForRemoveToCheck["UnicalCounterProduct"].ToString());
                                        newROW_IN_TABLE_Regisreted_NO["NameProductForChange"] = CurrentInfoForRemoveToCheck["Product_Name"].ToString();
                                        newROW_IN_TABLE_Regisreted_NO["TypeOfOperation"] = mainForm.TypeOfOperationRegisreted.RemoveCountProduct.ToString();
                                        newROW_IN_TABLE_Regisreted_NO["DateTimeOfOperation"] = DateTime.Now.ToString();
                                        newROW_IN_TABLE_Regisreted_NO["CountOfProductBeforeOperation"] = value.ToString();
                                        newROW_IN_TABLE_Regisreted_NO["CountOfProductAfterOperation"] = (value - value_2).ToString();

                                        Product_DataSet.Tables["Product_Regisreted_Product_Table"].Rows.Add(newROW_IN_TABLE_Regisreted_NO);

                                        #endregion

                                        Product_DataSet.Tables["Product_List_Of_Goods_Table"].Rows[i]["Product_Count"] = (value - value_2).ToString();
                                        ProductAllValue_REMOVE_TextBox.Text = Product_DataSet.Tables["Product_List_Of_Goods_Table"].Rows[i]["Product_Count"].ToString();

                                        #endregion
                                    }

                                    #endregion

                                    i = Product_DataSet.Tables["Product_List_Of_Goods_Table"].Rows.Count;
                                }
                                catch (Exception) { MessageBox.Show("Количество товара не соответствует типу единицы измерения", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
                                finally { NumberFor_REMOVE_TextBox.Text = string.Empty; }
                                break;
                        }

                        #endregion
                    }
                }
            }

            #endregion

            MessageBox.Show("Количество товара - " + CurrentInfoForRemoveToCheck["Product_Name"].ToString() + "\n\n" + "Успешно списано", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region Событие:

        #endregion

        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    }
}

