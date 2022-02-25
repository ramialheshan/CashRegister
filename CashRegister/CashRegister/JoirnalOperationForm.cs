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
    public partial class JoirnalOperationForm : Form
    {
        //Блок инициализации и описания 
         
        #region Описание переменных 

        /// <summary>
        /// Инструмент для обработки данных 
        /// </summary>
        DataSet Product_DataSet;

        #endregion

        #region Конструктор формы 

        public JoirnalOperationForm(DataSet DataForWork)
        {
            InitializeComponent();

            #region получение информации 

            Product_DataSet = DataForWork;

            #endregion
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //Методы


        #region Метод: Фильтрации списка операций 

        string getDateTimeForFind(DateTime Value, string Time)
        {
            String TEMP = "#" + Value.Month.ToString() + "/" + Value.Day.ToString() + "/" + Value.Year.ToString() + " " + Time + ":00" + "#";
            return TEMP;
        }

        void FiltredListOfAction()
        {
            #region Заполнения списка операций 

            ProductCheckList.DataSource = null;
            DataTable ProductActionTable =  new DataTable();
            ProductActionTable = Product_DataSet.Tables["Product_Regisreted_Product_Table"].Copy();

            DataView dView = new DataView(ProductActionTable);
            dView.RowFilter = "DateTimeOfOperation >=" + getDateTimeForFind(DateInFilter.Value, StartTimeIntervalValueTextBox.Text.Trim()) + " AND " + "DateTimeOfOperation <=" + getDateTimeForFind(DateEndFilter.Value, EndTimeIntervalValueTextBox.Text.Trim()) ;
            dView.Sort = "UnicalCounterRegisretedOperation ASC";

            if (dView.Count > 0)
            {
                ProductActionTable = dView.ToTable();

                #region Преобразование таблицы 
	
                for (int i = 0; i < ProductActionTable.Rows.Count; i++)
                {
                    switch (ProductActionTable.Rows[i]["TypeOfOperation"].ToString())
                    {
                        case "AddNewProduct":

                            ProductActionTable.Rows[i]["TypeOfOperation"] = "Добавление нового товара";
                            break;
                        case "AddCountProduct":
                            ProductActionTable.Rows[i]["TypeOfOperation"] = "Добавление количества товара";
                            break;

                        case "RemoveCountProduct":
                            ProductActionTable.Rows[i]["TypeOfOperation"] = "Удаление количества товара";
                            break;
                        case "DeleteProduct":
                            ProductActionTable.Rows[i]["TypeOfOperation"] = "Удаление товара";
                            break;

                    }

                }    

	
                #endregion

                ProductCheckList.AutoGenerateColumns = false;
                ProductCheckList.DataSource = ProductActionTable;

                ProductCheckList.Columns["UnicalCounterRegisretedOperation"].DataPropertyName = "UnicalCounterRegisretedOperation";
                ProductCheckList.Columns["UnicalNumberProductForChange"].DataPropertyName = "UnicalNumberProductForChange";
                ProductCheckList.Columns["NameProductForChange"].DataPropertyName = "NameProductForChange";
                ProductCheckList.Columns["TypeOfOperation"].DataPropertyName = "TypeOfOperation";
                ProductCheckList.Columns["DateTimeOfOperation"].DataPropertyName = "DateTimeOfOperation";
                ProductCheckList.Columns["CountOfProductBeforeOperation"].DataPropertyName = "CountOfProductBeforeOperation";
                ProductCheckList.Columns["CountOfProductAfterOperation"].DataPropertyName = "CountOfProductAfterOperation";

                ProductCheckList.RefreshEdit();
                ProductCheckList.ClearSelection();

                try{ ProductCheckList.Rows[0].Selected = true; }
                catch (Exception) { }

                ProductCheckList.AutoResizeColumns();
                ProductCheckList.Refresh();
            }

            #endregion
        }

        #endregion

        #region Метод: Очистка списка операций 

        void ClearListOfOperation()
        {
            #region Заполнения списка операций

            ProductCheckList.DataSource = null;
            DataTable ProductActionTable = new DataTable();
            ProductActionTable = Product_DataSet.Tables["Product_Regisreted_Product_Table"].Copy();

            if (ProductActionTable.Rows.Count > 0)
            {
                #region Преобразование таблицы

                for (int i = 0; i < ProductActionTable.Rows.Count; i++)
                {
                    switch (ProductActionTable.Rows[i]["TypeOfOperation"].ToString())
                    {
                        case "AddNewProduct":

                            ProductActionTable.Rows[i]["TypeOfOperation"] = "Добавление нового товара";
                            break;
                        case "AddCountProduct":
                            ProductActionTable.Rows[i]["TypeOfOperation"] = "Добавление количества товара";
                            break;

                        case "RemoveCountProduct":
                            ProductActionTable.Rows[i]["TypeOfOperation"] = "Удаление количества товара";
                            break;
                        case "DeleteProduct":
                            ProductActionTable.Rows[i]["TypeOfOperation"] = "Удаление товара";
                            break;

                    }
                }

                #endregion

                ProductCheckList.AutoGenerateColumns = false;
                ProductCheckList.DataSource = ProductActionTable;

                ProductCheckList.Columns["UnicalCounterRegisretedOperation"].DataPropertyName = "UnicalCounterRegisretedOperation";
                ProductCheckList.Columns["UnicalNumberProductForChange"].DataPropertyName = "UnicalNumberProductForChange";
                ProductCheckList.Columns["NameProductForChange"].DataPropertyName = "NameProductForChange";
                ProductCheckList.Columns["TypeOfOperation"].DataPropertyName = "TypeOfOperation";
                ProductCheckList.Columns["DateTimeOfOperation"].DataPropertyName = "DateTimeOfOperation";
                ProductCheckList.Columns["CountOfProductBeforeOperation"].DataPropertyName = "CountOfProductBeforeOperation";
                ProductCheckList.Columns["CountOfProductAfterOperation"].DataPropertyName = "CountOfProductAfterOperation";

                ProductCheckList.RefreshEdit();
                ProductCheckList.ClearSelection();

                #endregion

                try { ProductCheckList.Rows[0].Selected = true; }
                catch (Exception) { }

                ProductCheckList.AutoResizeColumns();
                ProductCheckList.Refresh();
            }
        }

        #endregion

        #region Метод: Фильтрации списка операций 

        void FiltredListOfCheck()
        {
            #region Заполнения списка операций 

            CheckListGrid.DataSource = null;
            DataTable ProductCheckTable = new DataTable();
            ProductCheckTable = Product_DataSet.Tables["Product_Check_List_Table"].Copy();

            DataView dView = new DataView(ProductCheckTable);
            dView.RowFilter = "DateTimeOfCheck >=" + getDateTimeForFind(dateTimePickerInInterval.Value, "00:00") + " AND " + "DateTimeOfCheck <=" + getDateTimeForFind(dateTimePickerEndInterval.Value, "23:59");
            dView.Sort = "UnicalCheckID ASC";

            if (dView.Count > 0)
            {
                ProductCheckTable = dView.ToTable();

                CheckListGrid.AutoGenerateColumns = false;
                CheckListGrid.DataSource = ProductCheckTable;

                CheckListGrid.Columns["UnicalCheckID"].DataPropertyName = "UnicalCheckID";
                CheckListGrid.Columns["AllCountOfProduct"].DataPropertyName = "AllCountOfProduct";
                CheckListGrid.Columns["AllCostOfCheck"].DataPropertyName = "AllCostOfCheck";
                CheckListGrid.Columns["DateTimeOfCheck"].DataPropertyName = "DateTimeOfCheck";
                CheckListGrid.Columns["MoneyGive"].DataPropertyName = "MoneyGive";
                CheckListGrid.Columns["MoneyChange"].DataPropertyName = "MoneyChange";

                CheckListGrid.RefreshEdit();
                CheckListGrid.ClearSelection();

                try { CheckListGrid.Rows[0].Selected = true; }
                catch (Exception) { }

                CheckListGrid.AutoResizeColumns();
                CheckListGrid.Refresh();
            }

            #endregion
        }

        #endregion

        #region Метод: Очистка списка операций 

        void ClearListOfCheck()
        {
            #region Заполнения списка операций 

            CheckListGrid.DataSource = null;
            DataTable ProductCheckTable = new DataTable();
            ProductCheckTable = Product_DataSet.Tables["Product_Check_List_Table"].Copy();

            CheckListGrid.AutoGenerateColumns = false;
            CheckListGrid.DataSource = ProductCheckTable;

            CheckListGrid.Columns["UnicalCheckID"].DataPropertyName = "UnicalCheckID";
            CheckListGrid.Columns["AllCountOfProduct"].DataPropertyName = "AllCountOfProduct";
            CheckListGrid.Columns["AllCostOfCheck"].DataPropertyName = "AllCostOfCheck";
            CheckListGrid.Columns["DateTimeOfCheck"].DataPropertyName = "DateTimeOfCheck";
            CheckListGrid.Columns["MoneyGive"].DataPropertyName = "MoneyGive";
            CheckListGrid.Columns["MoneyChange"].DataPropertyName = "MoneyChange";

            CheckListGrid.RefreshEdit();
            CheckListGrid.ClearSelection();

            try { CheckListGrid.Rows[0].Selected = true; }
            catch (Exception) { }

            CheckListGrid.AutoResizeColumns();
            CheckListGrid.Refresh();

            #endregion
        }

        #endregion

        #region Метод:



        #endregion

        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        //События

        #region Событие: Фильтровать операции 

        private void FilterActionButton_Click(object sender, EventArgs e)
        {
            FiltredListOfAction();
        }

        #endregion

        #region Событие: Очистка фильтра списка операций 

        private void ClearListActionButton_Click(object sender, EventArgs e)
        {
            ClearListOfOperation();
        }

        #endregion

        #region Событие: Выбор вкладки 

        private void mainTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (mainTabControl.SelectedTab.Name)
            {
                case "WatchActionListTab":
                    #region Список операции просмотр 

                    ClearListOfOperation();

                    #endregion

                    break;
                case "ChechListWatchTab":

                    ClearListOfCheck();

                    break;
            }
        }


        #endregion

        #region Событие: При показе формы 

        private void JoirnalOperationForm_Shown(object sender, EventArgs e)
        {
            mainTabControl.SelectedTab = WatchActionListTab;
            ClearListOfOperation();
        }

        #endregion

        #region Событие: Закрытие формы 

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        #endregion

        #region Событие: Фильтровать чеков 

        private void FilterCheckButton_Click(object sender, EventArgs e)
        {
            FiltredListOfCheck();
        }

        #endregion

        #region Событие: Очистка списка чеков 

        private void ClearListOfCheckButton_Click(object sender, EventArgs e)
        {
            ClearListOfCheck();
        }

        #endregion

        #region Событие: Выбор чека из списка 

        private void CheckListGrid_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                #region Очистка опций

                PanelWithValues.Enabled = true;
                ProductAllValue_REMOVE_TextBox.Text = string.Empty;
                AllCostOfCheckTextBox.Text = string.Empty;
                MoneyGiveTextBox.Text = string.Empty;
                MoneyChangeTextBox.Text = string.Empty;

                #endregion

                if (CheckListGrid.Rows.Count > 0)
                {
                    PanelWithValues.Enabled = true;

                    #region Заполнение опций

                    ProductAllValue_REMOVE_TextBox.Text = CheckListGrid.SelectedRows[0].Cells["AllCountOfProduct"].Value.ToString();
                    AllCostOfCheckTextBox.Text = CheckListGrid.SelectedRows[0].Cells["AllCostOfCheck"].Value.ToString();
                    MoneyGiveTextBox.Text = CheckListGrid.SelectedRows[0].Cells["MoneyGive"].Value.ToString();
                    MoneyChangeTextBox.Text = CheckListGrid.SelectedRows[0].Cells["MoneyChange"].Value.ToString();

                    #region Загрузка проданных товаров 

                    ListOfSaleProductGrid.DataSource = null;
                    DataTable ProductSaleTable = new DataTable();
                    ProductSaleTable = Product_DataSet.Tables["Product_SALE_Items_Of_Check_Table"].Copy();
                    DataView dView = new DataView(ProductSaleTable);
                    dView.RowFilter = "IDParentCheck=" + CheckListGrid.SelectedRows[0].Cells["UnicalCheckID"].Value.ToString();

                    if (dView.Count > 0)
                    {
                        ProductSaleTable = dView.ToTable();

                        ListOfSaleProductGrid.AutoGenerateColumns = false;
                        ListOfSaleProductGrid.DataSource = ProductSaleTable;

                        ListOfSaleProductGrid.Columns["UnicalIDSaleItem"].DataPropertyName = "UnicalIDSaleItem";
                        ListOfSaleProductGrid.Columns["IDParentCheck"].DataPropertyName = "IDParentCheck";
                        ListOfSaleProductGrid.Columns["NameOfProduct"].DataPropertyName = "NameOfProduct";
                        ListOfSaleProductGrid.Columns["Product_CostOfOneOption"].DataPropertyName = "Product_CostOfOneOption";
                        ListOfSaleProductGrid.Columns["CountOfSaleProduct"].DataPropertyName = "CountOfSaleProduct";
                        ListOfSaleProductGrid.Columns["AllCostProductSaleOperation"].DataPropertyName = "AllCostProductSaleOperation";

                        ListOfSaleProductGrid.RefreshEdit();
                        ListOfSaleProductGrid.ClearSelection();

                        try { ListOfSaleProductGrid.Rows[0].Selected = true; }
                        catch (Exception) { }

                        ListOfSaleProductGrid.AutoResizeColumns();
                        ListOfSaleProductGrid.Refresh();
                    }

                    #endregion

                    #endregion
                }
                else
                {
                    PanelWithValues.Enabled = false;
                }
            }
            catch (Exception) { }
        }

        #endregion



        #region Событие:


        #endregion

        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    
    }
}
