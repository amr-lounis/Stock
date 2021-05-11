using Stock.Controllers;
using Stock.Dataset.Model;
using Stock.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace Stock.Views
{
    public partial class EditProducts_UC : UserControl
    {
        public EditProducts_UC()
        {
            InitializeComponent();
            initReceiver();
        }

        //************************************************************************************* Button
        #region Button
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
            ReturnMessage(this, null);
        }
        #endregion

        //************************************************************************************* variable
        #region variable
        ITableProducts ointerface = new TableProducts_CV();
        string type = "";
        #endregion

        //************************************************************************************* Messanger //dynamic data = new System.Dynamic.ExpandoObject();
        #region Messanger
        void initReceiver() { OnSendMessage = ReceiveMessage; }
        public static void Send(object _sender, dynamic _data) { if (OnSendMessage != null) OnSendMessage(_sender, _data); }
        public void ReturnMessage(object _sender, dynamic _data) { if (OnReturnMessage != null) OnReturnMessage(_sender, _data); }
        public void ReceiveMessage(object _sender, dynamic _data)
        {
            OnReturnMessage = (_sender as TableProducts_UC).ReturnAddEdit; //change
            if (_data.mode != null)
            {
                if (_data.mode.Equals("Add"))
                {
                    type = "Add";
                    var o = new product();//change
                    o.ID = 0;
                    InitInput(o);
                }
                else if (_data.mode.Equals("Edit") && (_data.message != null))
                {
                    var o = (_data.message as product);//change
                    type = "Edit";
                    InitInput(o);
                }
            }
        }
        public delegate void delegateSend(object _sender, dynamic _data);
        public static event delegateSend OnSendMessage;

        public delegate void delegateReturn(object _sender, dynamic _data);
        public static event delegateReturn OnReturnMessage;
        #endregion

        //************************************************************************************* in/out
        #region in/out
        void InitInput(product _product)
        {
            v_text_ID.Content = _product.ID;
            v_text_NAME.Text = _product.NAME ?? "";
            v_text_DESCRIPTION.Text = _product.DESCRIPTION ?? "";
            v_text_CATEGORY.Text = _product.ID_CATEGORY +"";
            v_text_UNITY.Text = _product.ID_UNITE + "";
            v_text_CODE.Text = _product.CODE ?? "";

            v_Numeric_TAX_PERCE.Value = _product.TAX_PERCE ?? 0;
            v_Numeric_MONEY_PURCHASE.Value = _product.MONEY_PURCHASE ?? 0;
            v_Numeric_MONEY_SELLING.Value = _product.MONEY_SELLING_MIN ?? 0;
            v_Numeric_MONEY_SELLING_MIN.Value = _product.MONEY_SELLING_MIN ?? 0;
        }
        //*************************************************************************************  
        product getInput()
        {
            var o = new product();
            o.ID = Helper.LongFromString(v_text_ID.Content.ToString());
            o.NAME = v_text_NAME.Text;
            o.DESCRIPTION = v_text_DESCRIPTION.Text;
            o.ID_CATEGORY = Helper.LongFromString(v_text_CATEGORY.Text);
            o.ID_UNITE = Helper.LongFromString(v_text_UNITY.Text);
            o.CODE = v_text_CODE.Text;

            o.TAX_PERCE =  v_Numeric_TAX_PERCE.Value ;
            o.MONEY_PURCHASE = v_Numeric_MONEY_PURCHASE.Value ;
            o.MONEY_SELLING = v_Numeric_MONEY_SELLING.Value ;
            o.MONEY_SELLING_MIN = v_Numeric_MONEY_SELLING_MIN.Value;

            o.IMPORTANCE = 0;
            return o;
        }
        #endregion
    }
}