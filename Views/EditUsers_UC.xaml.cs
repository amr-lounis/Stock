using Stock.Classes;
using Stock.Controllers;
using Stock.Interfaces;
using Stock.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace Stock.Views
{
    public partial class EditUsers_UC : UserControl
    {
        public EditUsers_UC()
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
        ITableUsers ointerface = new TableUsers_CV();
        string type = "";
        #endregion

        //************************************************************************************* Messanger //dynamic data = new System.Dynamic.ExpandoObject();
        #region Messanger
        void initReceiver() { OnSendMessage = ReceiveMessage; }
        public static void Send(object _sender, dynamic _data) { if (OnSendMessage != null) OnSendMessage(_sender, _data); }
        public void ReturnMessage(object _sender, dynamic _data) { if (OnReturnMessage != null) OnReturnMessage(_sender, _data); }
        public void ReceiveMessage(object _sender, dynamic _data)
        {
            OnReturnMessage = (_sender as TableUsers_UC).ReturnAddEdit; //change
            if (_data.mode != null)
            {
                if (_data.mode.Equals("Add"))
                {
                    type = "Add";
                    var o = new User_M();//change
                    o.ID = "0";
                    InitInput(o);
                }
                else if (_data.mode.Equals("Edit") && (_data.message != null))
                {
                    var o = (_data.message as User_M);//change
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
        //*************************************************************************************  in/out
        #region in/out
        void InitInput(User_M _User)
        {
            v_text_ID.Content = _User.ID;
            v_text_NAME.Text = _User.NAME;
            v_text_GENDER.Text = _User.GENDER;
            v_password_1.Password = _User.PASSWORD;
            v_password_2.Password = _User.PASSWORD;
            v_text_ROLE.Text = _User.ROLE;
            v_text_ACTIVITY.Text = _User.ACTIVITY;
            v_text_DESCRIPTION.Text = _User.DESCRIPTION;
            v_text_NRC.Text = _User.NRC;
            v_text_NIF.Text = _User.NIF;
            v_text_ADDRESS.Text = _User.ADDRESS;
            v_text_CITY.Text = _User.CITY;
            v_text_COUNTRY.Text = _User.COUNTRY;
            v_text_PHONE.Text = _User.PHONE;
            v_text_FAX.Text = _User.FAX;
            v_text_WEBSITE.Text = _User.WEBSITE;
            v_text_EMAIL.Text = _User.EMAIL;

            v_Numeric_MONEY_ACCOUNT.Value = Helper.DoubleFromString(_User.MONEY_ACCOUNT);
        }
        User_M getInput()
        {
            var o = new User_M();
            o.ID = v_text_ID.Content.ToString();
            o.NAME = v_text_NAME.Text;
            o.GENDER = v_text_GENDER.Text;
            o.PASSWORD = v_password_1.Password;
            o.PASSWORD = v_password_2.Password;
            o.ROLE = v_text_ROLE.Text;
            o.ACTIVITY = v_text_ACTIVITY.Text;
            o.DESCRIPTION = v_text_DESCRIPTION.Text;
            o.NRC = v_text_NRC.Text;
            o.NIF = v_text_NIF.Text;
            o.ADDRESS = v_text_ADDRESS.Text;
            o.CITY = v_text_CITY.Text;
            o.COUNTRY = v_text_COUNTRY.Text;
            o.PHONE = v_text_PHONE.Text;
            o.FAX = v_text_FAX.Text;
            o.WEBSITE = v_text_WEBSITE.Text;
            o.EMAIL = v_text_EMAIL.Text;

            o.MONEY_ACCOUNT = string.Format("{0}", v_Numeric_MONEY_ACCOUNT.Value);
            return o;
        }
        #endregion
    }
}