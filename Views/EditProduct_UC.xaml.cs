using Stock.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace Stock.Views
{
    public partial class EditProduct_UC : UserControl
    {
        public EditProduct_UC()
        {
            InitializeComponent();
            initEventHandler();
        }
        private void v_btn_EditImage(object sender, RoutedEventArgs e)
        {

        }
        private void v_btn_DeleteImage(object sender, RoutedEventArgs e)
        {

        }
        private void v_btn_Save(object sender, RoutedEventArgs e)
        {
            var o = getInput();
            if (type.Equals("Add"))
            {
                o.ID = "0";
            }
            TableProduct_UC.Send(o);
        }

        //************************************************************************************* Messanger
        #region Messanger
        public void initEventHandler()
        {
            mListEventHandlerClass = new List<EventHandlerClass>();
            mListEventHandlerClass.Insert(0, new EventHandlerClass());
            mListEventHandlerClass[0].mEventHandler += delegate (object p_message, EventArgs e) { Receiver(p_message); };
        }
        public static void Send(object p_message)
        {
            foreach (var v in mListEventHandlerClass) v.Send(p_message);
        }
        public void Receiver(object p_message)
        {
            if (p_message != null)
            {
                type = "Edit";
                var p = (p_message as Product);
                InitInput(p);
            }
            else
            {
                type = "Add";
                var p = new Product();
                InitInput(p);
            }
        }
        public class EventHandlerClass
        {
            public event EventHandler mEventHandler;
            public void Send(object p_message) { mEventHandler?.Invoke(p_message, new EventArgs()); }
        }
        private static List<EventHandlerClass> mListEventHandlerClass;
        #endregion
        //*************************************************************************************  in/out
        #region in/out
        void InitInput(Product _Product)
        {
            v_text_NAME.Text = _Product.NAME;
            v_text_CATEGORY.Text = _Product.CATEGORY;
            v_text_UNITY.Text = _Product.UNITE;
            v_text_DESCRIPTION.Text = _Product.DESCRIPTION;
            v_text_CODE.Text = _Product.CODE;

            v_Numeric_QUANTITY.Value = DoubleFromString(_Product.QUANTITY);
            v_Numeric_QUANTITY_MIN.Value = DoubleFromString(_Product.QUANTITY_MIN);
            v_Numeric_TAX_PERCE.Value = DoubleFromString(_Product.TAX_PERCE);
            v_Numeric_MONEY_PURCHASE.Value = DoubleFromString(_Product.MONEY_PURCHASE);
            v_Numeric_MONEY_SELLING.Value = DoubleFromString(_Product.MONEY_SELLING);
            v_Numeric_MONEY_SELLING_MIN.Value = DoubleFromString(_Product.MONEY_SELLING_MIN);
            v_dp_DATE_PRODUCTION.SelectedDate = DateTimeFromString(_Product.DATE_PRODUCTION);
            v_dp_DATE_PURCHASE.SelectedDate = DateTimeFromString(_Product.DATE_PURCHASE);
            v_dp_DATE_EXPIRATION.SelectedDate = DateTimeFromString(_Product.DATE_EXPIRATION);
        }
        //*************************************************************************************  
        Product getInput()
        {
            var o = new Product();
            o.NAME = v_text_NAME.Text;
            o.CATEGORY = v_text_CATEGORY.Text;
            o.UNITE = v_text_UNITY.Text;
            o.DESCRIPTION = v_text_DESCRIPTION.Text;
            o.CODE = v_text_CODE.Text;
            o.QUANTITY = string.Format("{0}", v_Numeric_QUANTITY.Value);
            o.QUANTITY_MIN = string.Format("{0}", v_Numeric_QUANTITY_MIN.Value);
            o.TAX_PERCE = string.Format("{0}", v_Numeric_TAX_PERCE.Value);
            o.MONEY_PURCHASE = string.Format("{0}", v_Numeric_MONEY_PURCHASE.Value);
            o.MONEY_SELLING = string.Format("{0}", v_Numeric_MONEY_SELLING.Value);
            o.MONEY_SELLING_MIN = string.Format("{0}", v_Numeric_MONEY_SELLING_MIN.Value);
            o.DATE_PRODUCTION = DateTimeToString(v_dp_DATE_PRODUCTION.SelectedDate.Value);
            o.DATE_PURCHASE = DateTimeToString(v_dp_DATE_PRODUCTION.SelectedDate.Value);
            o.DATE_EXPIRATION = DateTimeToString(v_dp_DATE_PRODUCTION.SelectedDate.Value);
            return o;
        }
        private DateTime DateTimeFromString(string _DateTime)
        {
            try
            {
                return DateTime.ParseExact(_DateTime, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
            }
            catch (Exception e)
            {
                return DateTime.Now;
            }
        }
        private string DateTimeToString(DateTime _DateTime)
        {
            return _DateTime.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
        }
        private double DoubleFromString(string _Double)
        {
            try
            {
                return double.Parse(_Double);
            }
            catch (Exception e)
            {
                return 0f;
            }
        }
        #endregion
        string type = "";
    }
}