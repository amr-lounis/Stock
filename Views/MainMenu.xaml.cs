using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Stock.Views
{
    public partial class MainMenu : RibbonWindow
    {
        public MainMenu()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            try
            {
                InitializeComponent();
                tabDynamic.DataContext = _tabItems;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //-------------------------------------------------------------------------------
        private void RibbonWin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RibbonWin.SelectedIndex == 0)
            {

            }
        }
        //-------------------------------------------------------------------------------
        public void v_btn_Customer_Click(object sender, RoutedEventArgs e)
        {
            TableUsers_UC o = new TableUsers_UC();
            AddTabItem(o, "Customer:"+cpt);
        }
        //-------------------------------------------------------------------------------
        public void v_btn_Stock_Click(object sender, RoutedEventArgs e)
        {
            TableProduct_UC o = new TableProduct_UC();
            AddTabItem(o, "Stock:" + cpt);
        }
        //-------------------------------------------------------------------------------
        private void tabDynamic_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TabItem tab = tabDynamic.SelectedItem as TabItem;
            if (tab == null) return;

            Console.WriteLine(tab.Name);
        }
        //-------------------------------------------------------------------------------
        private void AddTabItem(object _content, string _name)
        {
            TabItem tab = new TabItem();
            tab.Header = _name;
            string tab_name = string.Format("tab_" + cpt++);
            Console.WriteLine("add new tab : " + tab_name);
            tab.Name = tab_name;
            tab.HeaderTemplate = tabDynamic.FindResource("TabHeader") as DataTemplate;
            tab.Content = _content;

            _tabItems.Add(tab);
            tabDynamic.DataContext = null;
            tabDynamic.DataContext = _tabItems;
            tabDynamic.SelectedItem = tab;
        }
        //-------------------------------------------------------------------------------
        private void v_btn_delete_Click(object sender, RoutedEventArgs e)
        {
            string tabName = (sender as Button).CommandParameter.ToString();
            Console.WriteLine(tabName);
            var item = tabDynamic.Items.Cast<TabItem>().Where(i => i.Name.Equals(tabName)).SingleOrDefault();
            TabItem tab = item as TabItem;

            if (tab != null)
            {
                if (MessageBox.Show(string.Format("Are you sure you want to close the tab '{0}'?", tab.Header.ToString()),
                    "Close Tab", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    TabItem selectedTab = tabDynamic.SelectedItem as TabItem;
                    tabDynamic.DataContext = null;
                    _tabItems.Remove(tab);
                    tabDynamic.DataContext = _tabItems;
                }
            }
            if (_tabItems.Count >= 1)
            {
                tabDynamic.SelectedItem = _tabItems[0];
            }
        }
        //-------------------------------------------------------------------------------
        private static List<TabItem> _tabItems = new List<TabItem>();
        static int cpt = 0;
        //-------------------------------------------------------------------------------
    }
}
