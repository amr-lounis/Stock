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

namespace Stock.Views
{
    public partial class TabDynamic_UC : UserControl
    {
        private List<TabItem> _tabItems;

        public TabDynamic_UC()
        {
            try
            {
                InitializeComponent();
                _tabItems = new List<TabItem>();
                tabDynamic.DataContext = _tabItems;
                tabDynamic.SelectedIndex = 0;

                this.AddTabItem(new TextBox(),"hello");
                this.AddTabItem(new TextBox(), "helxcaadalo");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddTabItem(object _content, string _name)
        {
            int count = _tabItems.Count;
            TabItem tab = new TabItem();
            tab.Header = _name;
            tab.Name = _name;
            tab.HeaderTemplate = tabDynamic.FindResource("TabHeader") as DataTemplate;
            tab.Content = _content;

            _tabItems.Add(tab);
        }


        private void tabDynamic_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TabItem tab = tabDynamic.SelectedItem as TabItem;
            if (tab == null) return;

            Console.WriteLine(tab.Name);
        }

        private void v_btn_delete_Click(object sender, RoutedEventArgs e)
        {
            string tabName = (sender as Button).CommandParameter.ToString();
            Console.WriteLine(tabName);
            var item = tabDynamic.Items.Cast<TabItem>().Where(i => i.Name.Equals(tabName)).SingleOrDefault();
            TabItem tab = item as TabItem;

            if (tab != null)
            {
                if (MessageBox.Show(string.Format("Are you sure you want to close the tab '{0}'?", tab.Header.ToString()),
                    "close Tab", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    TabItem selectedTab = tabDynamic.SelectedItem as TabItem;
                    tabDynamic.DataContext = null;
                    _tabItems.Remove(tab);
                    tabDynamic.DataContext = _tabItems;
                }
            }
        }
    }
}
