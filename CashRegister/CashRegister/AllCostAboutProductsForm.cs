using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CashRegister
{
    public partial class AllCostAboutProductsForm : Form
    {
        //Блок инициализации и описания 

        #region Описание переменных 

        /// <summary>
        /// Данные для работы 
        /// </summary>
        DataSet Product_DataSet;
        /// <summary>
        /// Информация про товар для добавления в список 
        /// </summary>
        DataRow CurrentProductForFindToList;
        /// <summary>
        /// Таймер, который используеться для поиска соответствий
        /// </summary>
        System.Timers.Timer _timerForTextControl;
        /// <summary>
        /// таблица используеться для обмена информации при заполнении списка 
        /// </summary>
        DataTable TempForCheckCreate;

        #endregion

        #region Конструктор формы

        public AllCostAboutProductsForm(DataSet DataForShow)
        {
            InitializeComponent();

            _timerForTextControl = new System.Timers.Timer(1000);
            _timerForTextControl.Elapsed += new System.Timers.ElapsedEventHandler(_timerForTextControl_Elapsed);

            #region передача информации 
		 
            Product_DataSet = DataForShow;

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

                if (ProductComboBox.DroppedDown) { ProductComboBox.DroppedDown = false; }
                ProductComboBox.DroppedDown = true;
            }

            #endregion
        }

        #endregion

        #region Метод: Клонирует поле с информацией

        private void CloneDataRow(DataTable dtOld, int rowNumber)
        {
            CurrentProductForFindToList = dtOld.NewRow();
            CurrentProductForFindToList.ItemArray = dtOld.Rows[rowNumber].ItemArray;
        }

        #endregion

        #region Метод: Загрузка списка товаров 

        void ClearListProduct()
        {
            #region Перенос товара в список

            ProductCheckList.DataSource = null;
            DataTable ProductProductTable = new DataTable();
            ProductProductTable = Product_DataSet.Tables["Product_List_Of_Goods_Table"].Copy();

            #region Преобразование таблицы

            ProductProductTable.Columns.Add("AllCostOfProduct", System.Type.GetType("System.String"));
            if (ProductProductTable.Rows.Count>0)
            {
                double rezultDB = 0.0;
                for (int i = 0; i < ProductProductTable.Rows.Count; i++)
                {
                    double temp = double.Parse(ProductProductTable.Rows[i]["Product_CostOfOneOption"].ToString()) * double.Parse(ProductProductTable.Rows[i]["Product_Count"].ToString());
                    ProductProductTable.Rows[i]["AllCostOfProduct"] = temp;
                    rezultDB += temp;
                }
                ProductAllValueTextBox.Enabled = true;
                ProductAllValueTextBox.Text = rezultDB.ToString();
                ProductAllValueTextBox.Enabled = false;
            }

            #endregion

            ProductCheckList.AutoGenerateColumns = false;
            ProductCheckList.DataSource = ProductProductTable;

            ProductCheckList.Columns["UnicalCounterProduct"].DataPropertyName = "UnicalCounterProduct";

            ProductCheckList.Columns["Product_Name"].DataPropertyName = "Product_Name";
            ProductCheckList.Columns["Product_UnitValue"].DataPropertyName = "Product_UnitValue";
            ProductCheckList.Columns["Product_CostOfOneOption"].DataPropertyName = "Product_CostOfOneOption";
            ProductCheckList.Columns["Product_Count"].DataPropertyName = "Product_Count";
            ProductCheckList.Columns["Product_DateOfLastDelivery"].DataPropertyName = "Product_DateOfLastDelivery";
            ProductCheckList.Columns["AllCostOfProduct"].DataPropertyName = "AllCostOfProduct";

            ProductCheckList.RefreshEdit();
            ProductCheckList.ClearSelection();

            try { ProductCheckList.Rows[0].Selected = true; }
            catch (Exception) { }

            ProductCheckList.AutoResizeColumns();
            ProductCheckList.Refresh();

            #endregion

        }

        #endregion

        #region Метод:



        #endregion

        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        //События

        #region Событие: При выборе элемента для выбора товара 

        private void ProductComboBox_Enter(object sender, EventArgs e)
        {
            if (ProductComboBox.Text == "Начните вводить название товара")
            {
                ProductComboBox.Text = string.Empty;
                ProductComboBox.ForeColor = SystemColors.ControlText;
            }
        }
        private void ProductComboBox_Leave(object sender, EventArgs e)
        {
            if (ProductComboBox.Text == string.Empty)
            {
                ProductComboBox.ForeColor = SystemColors.GrayText;
                ProductComboBox.Text = "Начните вводить название товара";
                if (_timerForTextControl.Enabled) { _timerForTextControl.Stop(); }
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

                            

                            break;
                        }
                    }
                }

                #endregion
            }
        }
        private void ProductComboBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (ProductComboBox.Text == "Начните вводить название товара")
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
                case Keys.Escape: return; break;
            }

            if (_timerForTextControl.Enabled) { _timerForTextControl.Stop(); }
            _timerForTextControl.Start();
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


                        #endregion

                        break;
                    }
                }
            }

            #endregion
        }

        #endregion

        #region Событие: Фильтрация 

        private void FilterProductButton_Click(object sender, EventArgs e)
        {
            #region Проверка 

            if (string.IsNullOrEmpty( ProductComboBox.Text)||(ProductComboBox.Text=="Начните вводить название товара"))
            {
                MessageBox.Show("Введите товар для выполнения фильтрации", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }

            #endregion

            #region Перенос товара в список

            ProductCheckList.DataSource = null;
            DataTable ProductProductTable = new DataTable();
            ProductProductTable = Product_DataSet.Tables["Product_List_Of_Goods_Table"].Copy();

            DataView dView = new DataView(ProductProductTable);
            dView.RowFilter = "UnicalCounterProduct =" + CurrentProductForFindToList["UnicalCounterProduct"].ToString();

            if (dView.Count > 0)
            {
                ProductProductTable = dView.ToTable();

                #region Преобразование таблицы

                ProductProductTable.Columns.Add("AllCostOfProduct", System.Type.GetType("System.String"));
                ProductProductTable.Rows[0]["AllCostOfProduct"] = double.Parse(ProductProductTable.Rows[0]["Product_CostOfOneOption"].ToString()) * double.Parse(ProductProductTable.Rows[0]["Product_Count"].ToString());

                #endregion

                ProductCheckList.AutoGenerateColumns = false;
                ProductCheckList.DataSource = ProductProductTable;

                ProductCheckList.Columns["UnicalCounterProduct"].DataPropertyName = "UnicalCounterProduct";

                ProductCheckList.Columns["Product_Name"].DataPropertyName = "Product_Name";
                ProductCheckList.Columns["Product_UnitValue"].DataPropertyName = "Product_UnitValue";
                ProductCheckList.Columns["Product_CostOfOneOption"].DataPropertyName = "Product_CostOfOneOption";
                ProductCheckList.Columns["Product_Count"].DataPropertyName = "Product_Count";
                ProductCheckList.Columns["Product_DateOfLastDelivery"].DataPropertyName = "Product_DateOfLastDelivery";
                ProductCheckList.Columns["AllCostOfProduct"].DataPropertyName = "AllCostOfProduct";

                ProductCheckList.RefreshEdit();
                ProductCheckList.ClearSelection();

                try { ProductCheckList.Rows[0].Selected = true; }
                catch (Exception) { }

                ProductCheckList.AutoResizeColumns();
                ProductCheckList.Refresh();
            }

            #endregion
        }

        #endregion

        #region Событие: Очистить восстановить список товаров 

        private void ClearFilterProductButton_Click(object sender, EventArgs e)
        {
            ClearListProduct();
        }

        #endregion

        #region Событие: Активация таймера для контроля текста

        void _timerForTextControl_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {

            _timerForTextControl.Stop();
            this.Invoke(new EventHandler(delegate { LoadListOfProductInComboBoxProducts(ProductComboBox.Text); }));
        }

        #endregion

        #region Событие: При показе формы 

        private void AllCostAboutProductsForm_Shown(object sender, EventArgs e)
        {
            ClearListProduct();
            FilterProductButton.Focus();
        }

        #endregion

        #region Событие:

        #endregion

        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    }
}
