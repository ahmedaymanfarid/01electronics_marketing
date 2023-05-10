using _01electronics_library;
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

namespace _01electronics_marketing
{
    /// <summary>
    /// Interaction logic for PriceListPage.xaml
    /// </summary>
    public partial class PriceListPage : Page
    {
        Employee loggedInUser;
        public PriceListPage(ref Employee mLoggedInUser)
        {
            loggedInUser = mLoggedInUser;
            InitializeComponent();
        }


        private void OnButtonClickedProducts(object sender, MouseButtonEventArgs e)
        {
            CategoriesPage categoriesPage = new CategoriesPage(ref loggedInUser);
            this.NavigationService.Navigate(categoriesPage);
        }

        private void OnButtonClickAddNewPriceList(object sender, RoutedEventArgs e)
        {
            AddPriceListWindow addPriceListWindow = new AddPriceListWindow();
            addPriceListWindow.Show();
        }
    }
}
