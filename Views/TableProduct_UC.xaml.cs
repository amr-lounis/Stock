﻿using Stock.C;
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
using Stock.Models;
using Stock.Interfaces;

namespace Stock.Views
{
    public partial class TableProduct_UC
    {
        ITableProduct ointerface = new CTableProducts();
        List<Product> lproducts { get; set; }
        public static int page = 0;
        public TableProduct_UC()
        {
            InitializeComponent();
            vPageNumber.Text = "" + page;
            lproducts = new List<Product>();
            myDataGrid.ItemsSource = lproducts;
        }
        private void event_backward(object sender, RoutedEventArgs e)
        {
            lproducts = ointerface.backward_page(0);

            page = Int32.Parse(vPageNumber.Text);
            vPageNumber.Text = "" + --page;
            myDataGrid.ItemsSource = null;
            myDataGrid.ItemsSource = lproducts;
        }
        private void event_forward(object sender, RoutedEventArgs e)
        {
            lproducts = ointerface.backward_page(0);

            page = Int32.Parse(vPageNumber.Text);
            vPageNumber.Text = "" + ++page;
            myDataGrid.ItemsSource = null;
            myDataGrid.ItemsSource = lproducts;
        }
        private void event_add(object sender, RoutedEventArgs e)
        {
            lproducts.Add(ointerface.add(new Product()));

            myDataGrid.ItemsSource = null;
            myDataGrid.ItemsSource = lproducts;
        }
        private void event_edit(object sender, RoutedEventArgs e)
        {
            if (myDataGrid.SelectedItem != null)
            {
                Product m = myDataGrid.SelectedItem as Product;
                lproducts[lproducts.FindIndex(o => o.ID == m.ID)] = ointerface.edit(m);

                myDataGrid.ItemsSource = null;
                myDataGrid.ItemsSource = lproducts;
            }
        }
        private void event_delete(object sender, RoutedEventArgs e)
        {
            if (myDataGrid.SelectedItem != null)
            {
                Product m = myDataGrid.SelectedItem as Product;
                if (ointerface.delete(m.ID) == 1)
                {
                    lproducts.RemoveAt(lproducts.FindIndex(o => o.ID == m.ID));
                    myDataGrid.ItemsSource = null;
                    myDataGrid.ItemsSource = lproducts;
                }
            }
            if (myDataGrid.SelectedItem != null)
            {
                Product m = myDataGrid.SelectedItem as Product;
                lproducts.RemoveAt(lproducts.FindIndex(o => o.ID == m.ID));

                myDataGrid.ItemsSource = null;
                myDataGrid.ItemsSource = lproducts;
            }
        }
        private void event_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (myDataGrid.SelectedItem != null)
            {
                Product dr = myDataGrid.SelectedItem as Product;
                Console.WriteLine(dr);
            }
        }

    }
}
