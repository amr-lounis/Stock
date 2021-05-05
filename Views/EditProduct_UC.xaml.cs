using Stock.Classes;
using Stock.Controllers;
using Stock.Interfaces;
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
            initMessanger();
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
                if (ointerface.add(o) < 1)
                {
                    MessageBox.Show("can\'t add");
                }
            }
            else if (type.Equals("Edit"))
            {
                if (ointerface.edit(o) < 1)
                {
                    MessageBox.Show("can\'t edit");
                }
            }
            TableProduct_UC.Send("OverlayGridCancel", null);
        }

        //************************************************************************************* Messanger
        #region Messanger
        void initMessanger() { OnSendMessage += Receiver; }
        public delegate void delegateSend(string _mode, object _message);
        public static event delegateSend OnSendMessage;
        public static void Send(string _mode, object _message)
        {
            if (OnSendMessage != null) OnSendMessage(_mode, _message);
        }
        public void Receiver(string _mode, object _message)
        {
            if (_mode != null)
            {
                if (_mode.Equals("Add"))
                {
                    type = "Add";
                    var o = new Product_M();
                    o.ID = "0";
                    InitInput(o);
                }
                else if (_mode.Equals("Edit") && (_message != null))
                {
                    var o = (_message as Product_M);
                    type = "Edit";
                    InitInput(o);
                }
            }
        }
        #endregion
        //************************************************************************************* variable
        ITableProduct ointerface = new CTableProducts();
        string type = "";
        //*************************************************************************************  in/out
        #region in/out
        void InitInput(Product_M _Product)
        {
            v_text_ID.Content = _Product.ID;
            v_text_NAME.Text = _Product.NAME;
            v_text_CATEGORY.Text = _Product.CATEGORY;
            v_text_UNITY.Text = _Product.UNITE;
            v_text_DESCRIPTION.Text = _Product.DESCRIPTION;
            v_text_CODE.Text = _Product.CODE;

            v_Numeric_QUANTITY.Value = Helper.DoubleFromString(_Product.QUANTITY);
            v_Numeric_QUANTITY_MIN.Value = Helper.DoubleFromString(_Product.QUANTITY_MIN);
            v_Numeric_TAX_PERCE.Value = Helper.DoubleFromString(_Product.TAX_PERCE);
            v_Numeric_MONEY_PURCHASE.Value = Helper.DoubleFromString(_Product.MONEY_PURCHASE);
            v_Numeric_MONEY_SELLING.Value = Helper.DoubleFromString(_Product.MONEY_SELLING);
            v_Numeric_MONEY_SELLING_MIN.Value = Helper.DoubleFromString(_Product.MONEY_SELLING_MIN);
            v_dp_DATE_PRODUCTION.SelectedDate = Helper.DateTimeFromString(_Product.DATE_PRODUCTION);
            v_dp_DATE_PURCHASE.SelectedDate = Helper.DateTimeFromString(_Product.DATE_PURCHASE);
            v_dp_DATE_EXPIRATION.SelectedDate = Helper.DateTimeFromString(_Product.DATE_EXPIRATION);
        }
        //*************************************************************************************  
        Product_M getInput()
        {
            var o = new Product_M();
            o.ID = v_text_ID.Content.ToString();
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
            o.DATE_PRODUCTION = Helper.DateTimeToString(v_dp_DATE_PRODUCTION.SelectedDate.Value);
            o.DATE_PURCHASE = Helper.DateTimeToString(v_dp_DATE_PRODUCTION.SelectedDate.Value);
            o.DATE_EXPIRATION = Helper.DateTimeToString(v_dp_DATE_PRODUCTION.SelectedDate.Value);
            return o;
        }
        #endregion
    }
}