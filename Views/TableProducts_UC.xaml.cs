﻿using Stock.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Stock.Interfaces;
using Stock.Dataset.Model;

namespace Stock.Views
{
    public partial class TableProducts_UC
    {
        public TableProducts_UC()
        {
            InitializeComponent();
            initReceiver();
            v_text_pageNumber.Text = "" + page;
            v_text_search.Text = "";
            GridRefresh();
        }

        //************************************************************************************* event
        #region event

        private void v_text_search_changed(object sender, RoutedEventArgs e)
        {
            page = 0;
            GridRefresh();
        }
        private void event_forward(object sender, RoutedEventArgs e)
        {
            page++;
            GridRefresh();
        }
        private void event_backward(object sender, RoutedEventArgs e)
        {
            page--;
            GridRefresh();
        }

        private void event_add(object sender, RoutedEventArgs e)
        {
            v_GridEdit.Visibility = Visibility.Visible;

            dynamic data = new System.Dynamic.ExpandoObject();
            data.mode = "Add";
            data.message = null;
            EditProducts_UC.Send(this, data); // changed
        }
        private void event_edit(object sender, RoutedEventArgs e)
        {
            v_GridEdit.Visibility = Visibility.Visible;

            if (myDataGrid.SelectedItem != null)
            {
                dynamic data = new System.Dynamic.ExpandoObject();
                data.mode = "Edit";
                data.message = myDataGrid.SelectedItem as product; // changed
                EditProducts_UC.Send(this, data); // changed
            }
        }
        private void event_delete(object sender, RoutedEventArgs e)
        {
            if (myDataGrid.SelectedItem != null)
            {
                var o = myDataGrid.SelectedItem as product; // changed
                MessageBox.Show(ointerface.delete(o.ID));
                GridRefresh();
            }
        }
        private void event_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (myDataGrid.SelectedItem != null)
            {
                var o = myDataGrid.SelectedItem as product;// changed
                dynamic data = new System.Dynamic.ExpandoObject();
                data.ID = o.ID;
                data.NAME = o.NAME;
                data.DESCRIPTION = o.DESCRIPTION;
                data.MONEY_SELLING = o.MONEY_SELLING;
                data.TAX_PERCE = o.TAX_PERCE;
                data.STAMP = o.STAMP;
                ReturnMessage(this, data);
            }
        }
        private void v_btn_OverlayGridCancel(object sender, EventArgs e)
        {
            GridRefresh();
        }
        private void GridRefresh()
        {
            v_GridEdit.Visibility = Visibility.Collapsed;
            myDataGrid.ItemsSource = null;
            string s;
            myDataGrid.ItemsSource = ointerface.search(v_text_search.Text, ref page, out s);
            v_text_pageNumber.Text = s;
        }
        #endregion
        //************************************************************************************* Messanger //dynamic data = new System.Dynamic.ExpandoObject();
        #region Messanger
        void initReceiver() { OnSendMessage = ReceiveMessage; }
        public static void Send(object _sender, dynamic _data) { if (OnSendMessage != null) OnSendMessage(_sender, _data); }
        public void ReturnMessage(object _sender, dynamic _data) { if (OnReturnMessage != null) OnReturnMessage(_sender, _data); }
        public void ReceiveMessage(object _sender, dynamic _data)
        {
            OnReturnMessage = (_sender as CashRegisters_UC).ReturnProduct; //change
            if(_data != null)
            {
                v_text_search.Text = _data;
            }
        }
        public delegate void delegateSend(object _sender, dynamic _data);
        public static event delegateSend OnSendMessage;

        public delegate void delegateReturn(object _sender, dynamic _data);
        public static event delegateReturn OnReturnMessage;
        //-----------------
        public void ReturnAddEdit(object _sender, dynamic _data)
        {
            GridRefresh();
        }
        #endregion
        //************************************************************************************* Variable
        #region Variable
        ITableProducts ointerface = new TableProducts_CV();// changed
        public static int page = 0;
        #endregion
    }
}

