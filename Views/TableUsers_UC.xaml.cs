using Stock.C;
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
        ITableUsers ointerface = new CUsers();
        List<User> lusers { get; set; }
        public static int page = 0;
        public TableUsers_UC()
        {
            InitializeComponent();
            vPageNumber.Text = "" + page;
            lusers = new List<User>();
            myDataGrid.ItemsSource = lusers;
        }
        private void event_backward(object sender, RoutedEventArgs e)
        {
            lusers = ointerface.backward_page(0);

            page = Int32.Parse(vPageNumber.Text);
            vPageNumber.Text = "" + --page;
            myDataGrid.ItemsSource = null;
            myDataGrid.ItemsSource = lusers;
        }
        private void event_forward(object sender, RoutedEventArgs e)
        {
            lusers = ointerface.backward_page(0);

            page = Int32.Parse(vPageNumber.Text);
            vPageNumber.Text = "" + ++page;
            myDataGrid.ItemsSource = null;
            myDataGrid.ItemsSource = lusers;
        }
        private void event_add(object sender, RoutedEventArgs e)
        {
            lusers.Add(ointerface.add(new User()));

            myDataGrid.ItemsSource = null;
            myDataGrid.ItemsSource = lusers;
        }
        private void event_edit(object sender, RoutedEventArgs e)
        {
            if (myDataGrid.SelectedItem != null)
            {
                User u = myDataGrid.SelectedItem as User;
                lusers[lusers.FindIndex(o => o.ID == u.ID)] = ointerface.edit(u);

                myDataGrid.ItemsSource = null;
                myDataGrid.ItemsSource = lusers;
            }
        }
        private void event_delete(object sender, RoutedEventArgs e)
        {
            if (myDataGrid.SelectedItem != null)
            {
                User m = myDataGrid.SelectedItem as User;
                int id = 0;
                if (Int32.TryParse(m.ID, out id))
                {
                    if (ointerface.delete(id) == 1)
                    {
                        lusers.RemoveAt(lusers.FindIndex(o => o.ID == m.ID));
                        myDataGrid.ItemsSource = null;
                        myDataGrid.ItemsSource = lusers;
                    }
                }
                
            }
        }
        private void event_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (myDataGrid.SelectedItem != null)
            {
                User dr = myDataGrid.SelectedItem as User;
                Console.WriteLine(dr);
            } 
        }

    }
}
