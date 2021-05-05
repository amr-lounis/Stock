using Stock.Controllers;
using Stock.Interfaces;
using Stock.Models;
using System;
using System.Collections.Generic;
using System.Data;
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
    public partial class TableUsers_UC : UserControl
    {
        public TableUsers_UC()
        {
            InitializeComponent();
            initEventHandler();
            vPageNumber.Text = "" + page;
            GridRefresh();
        }
        //************************************************************************************* event
        #region event
        private void event_forward(object sender, RoutedEventArgs e)
        {
            page++;
            vPageNumber.Text = string.Format("{0}", page);
            GridRefresh();
        }
        private void event_backward(object sender, RoutedEventArgs e)
        {
            page--;
            vPageNumber.Text = string.Format("{0}", page);
            GridRefresh();
        }

        private void event_add(object sender, RoutedEventArgs e)
        {
            v_GridEdit.Visibility = Visibility.Visible;
            EditUsers_UC.Send(null);
        }
        private void event_edit(object sender, RoutedEventArgs e)
        {
            v_GridEdit.Visibility = Visibility.Visible;
            if (myDataGrid.SelectedItem != null)
            {
                var o = myDataGrid.SelectedItem as User;
                EditUsers_UC.Send(o);
            }
        }
        private void event_delete(object sender, RoutedEventArgs e)
        {
            if (myDataGrid.SelectedItem != null)
            {
                var o = myDataGrid.SelectedItem as User;
                if (ointerface.delete(o) >= 1)
                {
                    GridRefresh();
                }
                else
                {
                    MessageBox.Show("can\'t detete");
                }
            }
        }
        private void event_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (myDataGrid.SelectedItem != null)
            {
                if (myDataGrid.SelectedItem != null)
                {
                    var o = myDataGrid.SelectedItem;
                    System.Reflection.PropertyInfo pi = o.GetType().GetProperty("ID");
                    var v = (string)(pi.GetValue(o, null));
                    Console.WriteLine(v);
                }
            }
        }
        private void v_btn_OverlayGridCancel(object sender, EventArgs e)
        {
            GridRefresh();
        }
        #endregion
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
            v_GridEdit.Visibility = Visibility.Collapsed;
            if (p_message != null)
            {
                var o = (p_message as User);
                if (o.ID.Equals("0"))
                {
                    if (ointerface.add(o) >= 1)
                    {
                        GridRefresh();
                    }
                    else
                    {
                        MessageBox.Show("can\'t add");
                    }
                }
                else
                {
                    if (ointerface.edit(o) >= 1)
                    {
                        GridRefresh();
                    }
                    else
                    {
                        MessageBox.Show("can\'t edit");
                    }
                }
            }
        }
        public class EventHandlerClass
        {
            public event EventHandler mEventHandler;
            public void Send(object p_message) { mEventHandler?.Invoke(p_message, new EventArgs()); }
        }
        private static List<EventHandlerClass> mListEventHandlerClass;
        #endregion
        /**************************************************************/
        private void GridRefresh()
        {
            v_GridEdit.Visibility = Visibility.Collapsed;
            myDataGrid.ItemsSource = null;
            myDataGrid.ItemsSource = ointerface.getPage(ref page);
        }
        /**************************************************************/
        ITableUsers ointerface = new CTableUsers();
        public static int page = 0;
        /**************************************************************/

    }
}
