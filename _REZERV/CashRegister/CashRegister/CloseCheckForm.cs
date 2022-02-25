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
    public partial class CloseCheckForm : Form
    {
        //Блок инициализации и описания 

        #region Описание переменных 

        /// <summary>
        /// Вся сумма чека 
        /// </summary>
        string _AllCostOfProductsList;
        /// <summary>
        /// Количество товаров в списке
        /// </summary>
        int _AllListProduct;
        /// <summary>
        /// Количество полученых денег 
        /// </summary>
        public double MoneyGive;
        /// <summary>
        /// Количество сдачи 
        /// </summary>
        public double MoneyChange;
        /// <summary>
        /// Хранит информацию о чеке 
        /// </summary>
        public DataRow CheckInfo;
        /// <summary>
        /// Таблица с чеками
        /// </summary>
        DataTable TableWithChecks;

        /// <summary>
        /// Таймер для получение числа здачи 
        /// </summary>
        System.Timers.Timer timerForChangeGet;

        #endregion

        #region Конструктор формы 

        public CloseCheckForm(string AllCostOfProductsList,int CountOFProducts,DataTable CheckTableTemplate)
        {
            InitializeComponent();

            _AllCostOfProductsList = AllCostOfProductsList;
            _AllListProduct = CountOFProducts;
            TableWithChecks = CheckTableTemplate;
            timerForChangeGet = new System.Timers.Timer(1000);
            timerForChangeGet.Elapsed += new System.Timers.ElapsedEventHandler(timerForChangeGet_Elapsed); 

            #region Ввод значение 

            EnterValueOnForm();


            #endregion

        }

    

        #endregion

        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //Методы

        #region Метод: Ввод значений на форму 

        private void EnterValueOnForm()
        {
            AllProductsInCheckTextBox.Enabled = true;
            AllProductsInCheckTextBox.Text = _AllListProduct.ToString();
            AllProductsInCheckTextBox.Enabled = false;

            COSTProductsInCheckTextBox.Enabled = true;
            COSTProductsInCheckTextBox.Text = _AllCostOfProductsList.ToString();
            COSTProductsInCheckTextBox.Enabled = false;
        }

        #endregion

        #region Метод: Создание строки с информацией 

        protected DataRow CreateRecordInfo()
        {
            DataRow infoRow = TableWithChecks.NewRow();

            infoRow["AllCountOfProduct"] = (object)int.Parse(AllProductsInCheckTextBox.Text.Trim());
            infoRow["AllCostOfCheck"] = (object)COSTProductsInCheckTextBox.Text.Trim();
            infoRow["DateTimeOfCheck"] = (object)DateTime.Now;
            infoRow["MoneyGive"] = (object)GetMoneyInCheckTextBox.Text.Trim();
            infoRow["MoneyChange"] = (object)GIveMoneyInChangeTextBox.Text.Trim();

            return infoRow;
        }

        #endregion

        #region Метод:



        #endregion

        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        //События

        #region Событие: Закрытие чека 

        private void CloseCheckButton_Click(object sender, EventArgs e)
        {
            #region Проверка 

            try
            {
                if (string.IsNullOrEmpty(GetMoneyInCheckTextBox.Text)) { throw new ArgumentNullException(); }

                double TryTemp = double.Parse(GetMoneyInCheckTextBox.Text.Trim());
                double TryTemp_2 = double.Parse(COSTProductsInCheckTextBox.Text.Trim());
                if (TryTemp < TryTemp_2)
                {
                    throw new  ArgumentOutOfRangeException(); 
                }
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Проверте корректность ввода", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Сумма не достаточна для расчета", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }

            #endregion

            CheckInfo = CreateRecordInfo();
            this.DialogResult = DialogResult.OK;
        }

        #endregion

        #region Событие: Закрыть чек 

        private void CloseWindowsButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        #endregion

        #region Событие: Ввод суммы для расчета 

        private void GetMoneyInCheckTextBox_TextChanged(object sender, EventArgs e)
        {
            if (timerForChangeGet.Enabled) { timerForChangeGet.Stop(); }
            timerForChangeGet.Start();
        }

        void timerForChangeGet_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            timerForChangeGet.Stop();
            double TryTemp = double.Parse(GetMoneyInCheckTextBox.Text.Trim());
            double TryTemp_2 = double.Parse(COSTProductsInCheckTextBox.Text.Trim());
            if (TryTemp < TryTemp_2) { this.Invoke(new EventHandler(delegate { GIveMoneyInChangeTextBox.Text = "Недопустимо"; })); }
            else { this.Invoke(new EventHandler(delegate {GIveMoneyInChangeTextBox.Text = (TryTemp-TryTemp_2).ToString();})); }
        }

        #endregion

        #region Событие:



        #endregion

        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------


     
    }
}
