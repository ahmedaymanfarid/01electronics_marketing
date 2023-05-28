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
using System.Windows.Media.Effects;
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
        List<MARKETING_STRUCTS.PRICE_LIST_ITEMS> priceListItems;
        CommonQueries commonQueries;
        private CommonFunctions commonFunctions;
        private IntegrityChecks integrityChecks;
        public PriceListPage(ref CommonQueries mCommonQueries, ref CommonFunctions mCommonFunctions, ref IntegrityChecks mIntegrityChecks, ref Employee mLoggedInUser)
        {
            loggedInUser = mLoggedInUser;
            priceListItems = new List<MARKETING_STRUCTS.PRICE_LIST_ITEMS>();
            commonQueries = mCommonQueries;
            InitializeComponent();
            TableView();
        }


        private void OnButtonClickedProducts(object sender, MouseButtonEventArgs e)
        {
            CategoriesPage categoriesPage = new CategoriesPage(ref commonQueries, ref commonFunctions, ref integrityChecks, ref loggedInUser);
            this.NavigationService.Navigate(categoriesPage);
        }

        private void OnButtonClickAddNewPriceList(object sender, RoutedEventArgs e)
        {
            AddPriceListWindow addPriceListWindow = new AddPriceListWindow(ref loggedInUser);
            addPriceListWindow.Show();
           
        }
        private void TableView()
        {
            ColumnDefinition priceListIdColumn = new ColumnDefinition();
            ColumnDefinition categoryColumn = new ColumnDefinition();
            ColumnDefinition typeColumn = new ColumnDefinition();
            ColumnDefinition brandColumn = new ColumnDefinition();
            ColumnDefinition modelColumn = new ColumnDefinition();
            ColumnDefinition specsColumn = new ColumnDefinition();
            ColumnDefinition priceColumn = new ColumnDefinition();
            ColumnDefinition currencyColumn = new ColumnDefinition();
            ColumnDefinition discountColumn = new ColumnDefinition();

            priceListGrid.ColumnDefinitions.Add(priceListIdColumn);
            priceListGrid.ColumnDefinitions.Add(categoryColumn);
            priceListGrid.ColumnDefinitions.Add(typeColumn);
            priceListGrid.ColumnDefinitions.Add(brandColumn);
            priceListGrid.ColumnDefinitions.Add(modelColumn);
            priceListGrid.ColumnDefinitions.Add(specsColumn);
            priceListGrid.ColumnDefinitions.Add(priceColumn);
            priceListGrid.ColumnDefinitions.Add(currencyColumn);
            priceListGrid.ColumnDefinitions.Add(discountColumn);

            RowDefinition header = new RowDefinition();

            priceListGrid.RowDefinitions.Add(header);

            ////////////////////////////////////////////// price list id header //////////////////////////////////////
            Border priceListBorder = new Border();
            //priceListBorder.Margin = new Thickness(10);
            priceListBorder.BorderBrush = (Brush)(new BrushConverter().ConvertFrom("#105A97"));
            priceListBorder.Background = (Brush)(new BrushConverter().ConvertFrom("#105A97"));
            priceListBorder.BorderThickness = new Thickness(1);
            priceListBorder.CornerRadius = new CornerRadius(10);

            DropShadowEffect shadow = new DropShadowEffect();
            shadow.BlurRadius = 20;
            shadow.Color = Color.FromRgb(211, 211, 211);
            priceListBorder.Effect = shadow;

            Label priceListIdLabel = new Label();
            priceListIdLabel.Style = (Style)FindResource("sideNavigationItemStyle");
            priceListIdLabel.HorizontalAlignment = HorizontalAlignment.Center;
            priceListIdLabel.Content = "Price List Id";

            priceListBorder.Child = priceListIdLabel;

            Grid.SetColumn(priceListBorder, 0);
            Grid.SetRow(priceListBorder, 0);
            priceListGrid.Children.Add(priceListBorder);

            ///////////////////////////////// category header ////////////////////////////////////////////////
            Border categoryBorder = new Border();
           // categoryBorder.Margin = new Thickness(10);
            categoryBorder.BorderBrush = (Brush)(new BrushConverter().ConvertFrom("#105A97"));
            categoryBorder.Background = (Brush)(new BrushConverter().ConvertFrom("#105A97"));
            categoryBorder.BorderThickness = new Thickness(1);
            categoryBorder.CornerRadius = new CornerRadius(10);
            categoryBorder.Effect = shadow;

            Label CategoryLabel = new Label();
            CategoryLabel.Style = (Style)FindResource("sideNavigationItemStyle");
            CategoryLabel.HorizontalAlignment = HorizontalAlignment.Center;
            CategoryLabel.Content = "Category";

            categoryBorder.Child = CategoryLabel;

            Grid.SetColumn(categoryBorder, 1);
            Grid.SetRow(categoryBorder, 0);
            priceListGrid.Children.Add(categoryBorder);

            ///////////////////////////////// type header ////////////////////////////////////////////////
            Border typeBorder = new Border();
            //typeBorder.Margin = new Thickness(10);
            typeBorder.BorderBrush = (Brush)(new BrushConverter().ConvertFrom("#105A97"));
            typeBorder.Background = (Brush)(new BrushConverter().ConvertFrom("#105A97"));
            typeBorder.BorderThickness = new Thickness(1);
            typeBorder.CornerRadius = new CornerRadius(10);
            typeBorder.Effect = shadow;

            Label typeLabel = new Label();
            typeLabel.Style = (Style)FindResource("sideNavigationItemStyle");
            typeLabel.HorizontalAlignment = HorizontalAlignment.Center;
            typeLabel.Content = "Type";

            typeBorder.Child = typeLabel;

            Grid.SetColumn(typeBorder, 2);
            Grid.SetRow(typeBorder, 0);
            priceListGrid.Children.Add(typeBorder);

            ///////////////////////////////// brand header ////////////////////////////////////////////////
            Border brandBorder = new Border();
           // brandBorder.Margin = new Thickness(10);
            brandBorder.BorderBrush = (Brush)(new BrushConverter().ConvertFrom("#105A97"));
            brandBorder.Background = (Brush)(new BrushConverter().ConvertFrom("#105A97"));
            brandBorder.BorderThickness = new Thickness(1);
            brandBorder.CornerRadius = new CornerRadius(10);
            brandBorder.Effect = shadow;

            Label brandLabel = new Label();
            brandLabel.Style = (Style)FindResource("sideNavigationItemStyle");
            brandLabel.HorizontalAlignment = HorizontalAlignment.Center;
            brandLabel.Content = "Brand";

            brandBorder.Child = brandLabel;

            Grid.SetColumn(brandBorder,3);
            Grid.SetRow(brandBorder, 0);
            priceListGrid.Children.Add(brandBorder);

            ///////////////////////////////// model header ////////////////////////////////////////////////
            Border modelBorder = new Border();
           // modelBorder.Margin = new Thickness(10);
            modelBorder.BorderBrush = (Brush)(new BrushConverter().ConvertFrom("#105A97"));
            modelBorder.Background = (Brush)(new BrushConverter().ConvertFrom("#105A97"));
            modelBorder.BorderThickness = new Thickness(1);
            modelBorder.CornerRadius = new CornerRadius(10);
            modelBorder.Effect = shadow;

            Label modelLabel = new Label();
            modelLabel.Style = (Style)FindResource("sideNavigationItemStyle");
            modelLabel.HorizontalAlignment = HorizontalAlignment.Center;
            modelLabel.Content = "Model";

            modelBorder.Child = modelLabel;

            Grid.SetColumn(modelBorder, 4);
            Grid.SetRow(modelBorder, 0);
            priceListGrid.Children.Add(modelBorder);

            ///////////////////////////////// specs header ////////////////////////////////////////////////
            Border specsBorder = new Border();
           // specsBorder.Margin = new Thickness(10);
            specsBorder.BorderBrush = (Brush)(new BrushConverter().ConvertFrom("#105A97"));
            specsBorder.Background = (Brush)(new BrushConverter().ConvertFrom("#105A97"));
            specsBorder.BorderThickness = new Thickness(1);
            specsBorder.CornerRadius = new CornerRadius(10);
            specsBorder.Effect = shadow;

            Label specsLabel = new Label();
            specsLabel.Style = (Style)FindResource("sideNavigationItemStyle");
            specsLabel.HorizontalAlignment= HorizontalAlignment.Center; 
            specsLabel.Content = "Specs";

            specsBorder.Child = specsLabel;

            Grid.SetColumn(specsBorder, 5);
            Grid.SetRow(specsBorder, 0);
            priceListGrid.Children.Add(specsBorder);

            ///////////////////////////////// Price header ////////////////////////////////////////////////
            Border priceBorder = new Border();
           // priceBorder.Margin = new Thickness(10);
            priceBorder.BorderBrush = (Brush)(new BrushConverter().ConvertFrom("#105A97"));
            priceBorder.Background = (Brush)(new BrushConverter().ConvertFrom("#105A97"));
            priceBorder.BorderThickness = new Thickness(1);
            priceBorder.CornerRadius = new CornerRadius(10);
            priceBorder.Effect = shadow;

            Label priceLabel = new Label();
            priceLabel.Style = (Style)FindResource("sideNavigationItemStyle");
            priceLabel.HorizontalAlignment = HorizontalAlignment.Center;
            priceLabel.Content = "Price";

            priceBorder.Child = priceLabel;

            Grid.SetColumn(priceBorder, 6);
            Grid.SetRow(priceBorder, 0);
            priceListGrid.Children.Add(priceBorder);

            ///////////////////////////////// Currency header ////////////////////////////////////////////////
            Border currencyBorder = new Border();
           // currencyBorder.Margin = new Thickness(10);
            currencyBorder.BorderBrush = (Brush)(new BrushConverter().ConvertFrom("#105A97"));
            currencyBorder.Background = (Brush)(new BrushConverter().ConvertFrom("#105A97"));
            currencyBorder.BorderThickness = new Thickness(1);
            currencyBorder.CornerRadius = new CornerRadius(10);
            currencyBorder.Effect = shadow;

            Label currencyLabel = new Label();
            currencyLabel.Style = (Style)FindResource("sideNavigationItemStyle");
            currencyLabel.HorizontalAlignment = HorizontalAlignment.Center;
            currencyLabel.Content = "Currency";

            currencyBorder.Child = currencyLabel;

            Grid.SetColumn(currencyBorder, 7);
            Grid.SetRow(currencyBorder, 0);
            priceListGrid.Children.Add(currencyBorder);

            ///////////////////////////////// Currency header ////////////////////////////////////////////////
            Border discountBorder = new Border();
          //  discountBorder.Margin = new Thickness(10);
            discountBorder.BorderBrush = (Brush)(new BrushConverter().ConvertFrom("#105A97"));
            discountBorder.Background = (Brush)(new BrushConverter().ConvertFrom("#105A97"));
            discountBorder.BorderThickness = new Thickness(1);
            discountBorder.CornerRadius = new CornerRadius(10);
            discountBorder.Effect = shadow;

            Label dicountLabel = new Label();
            dicountLabel.Style = (Style)FindResource("sideNavigationItemStyle");
            dicountLabel.HorizontalAlignment = HorizontalAlignment.Center;
            dicountLabel.Content = "Discount";

            discountBorder.Child = dicountLabel;

            Grid.SetColumn(discountBorder, 8);
            Grid.SetRow(discountBorder, 0);
            priceListGrid.Children.Add(discountBorder);

            if (!commonQueries.GetAllPriceListItems(ref priceListItems))
                return;



            for (int i = 0; i<priceListItems.Count; i++) 
            {
                RowDefinition newRow = new RowDefinition();
                priceListGrid.RowDefinitions.Add(newRow);
                if (i%2==0)
                {
                    ///////////////////////////////// list id (style even )////////////////////////////
                    Label priceListIdItem = new Label();
                    priceListIdItem.Style = (Style)FindResource("labelStyle");
                    priceListIdItem.Margin = new Thickness(0);
                    priceListIdItem.Content = priceListItems[i].price_list.list_id;

                    Border priceListItemBorder = new Border();
                    priceListItemBorder.BorderBrush = (Brush)(new BrushConverter().ConvertFrom("#EDEDED"));
                    priceListItemBorder.Background = (Brush)(new BrushConverter().ConvertFrom("#EDEDED"));
                    priceListItemBorder.BorderThickness = new Thickness(1);
                   // priceListItemBorder.CornerRadius = new CornerRadius(10);
                    priceListItemBorder.Effect = shadow;

                    priceListItemBorder.Child = priceListIdItem;

                    Grid.SetColumn(priceListItemBorder, 0);
                    Grid.SetRow(priceListItemBorder, i + 1);

                    priceListGrid.Children.Add(priceListItemBorder);

                    ///////////////////////////////// category (style even )////////////////////////////
                    Label categoryListIdItem = new Label();
                    categoryListIdItem.Style = (Style)FindResource("labelStyle");
                    categoryListIdItem.Margin = new Thickness(0);
                    categoryListIdItem.Content = priceListItems[i].company_products.category_name.category_name;

                    Border categoryItemBorder = new Border();
                    categoryItemBorder.BorderBrush = (Brush)(new BrushConverter().ConvertFrom("#EDEDED"));
                    categoryItemBorder.Background = (Brush)(new BrushConverter().ConvertFrom("#EDEDED"));
                    categoryItemBorder.BorderThickness = new Thickness(1);
                   // categoryItemBorder.CornerRadius = new CornerRadius(10);
                    categoryItemBorder.Effect = shadow;

                    categoryItemBorder.Child = categoryListIdItem;

                    Grid.SetColumn(categoryItemBorder, 1);
                    Grid.SetRow(categoryItemBorder, i + 1);

                    priceListGrid.Children.Add(categoryItemBorder);

                    ///////////////////////////////// type (style even )////////////////////////////
                    Label typeListIdItem = new Label();
                    typeListIdItem.Style = (Style)FindResource("labelStyle");
                    typeListIdItem.Margin = new Thickness(0);
                    typeListIdItem.Content = priceListItems[i].company_products.product.product_name;

                    Border typeItemBorder = new Border();
                    typeItemBorder.BorderBrush = (Brush)(new BrushConverter().ConvertFrom("#EDEDED"));
                    typeItemBorder.Background = (Brush)(new BrushConverter().ConvertFrom("#EDEDED"));
                    typeItemBorder.BorderThickness = new Thickness(1);
                    //typeItemBorder.CornerRadius = new CornerRadius(10);
                    typeItemBorder.Effect = shadow;

                    typeItemBorder.Child = typeListIdItem;

                    Grid.SetColumn(typeItemBorder, 2);
                    Grid.SetRow(typeItemBorder, i + 1);

                    priceListGrid.Children.Add(typeItemBorder);

                    ///////////////////////////////// brand (style even )////////////////////////////
                    Label brandListIdItem = new Label();
                    brandListIdItem.Style = (Style)FindResource("labelStyle");
                    brandListIdItem.Margin = new Thickness(0);
                    brandListIdItem.Content = priceListItems[i].company_products.brand.brand_name;

                    Border brandItemBorder = new Border();
                    brandItemBorder.BorderBrush = (Brush)(new BrushConverter().ConvertFrom("#EDEDED"));
                    brandItemBorder.Background = (Brush)(new BrushConverter().ConvertFrom("#EDEDED"));
                    brandItemBorder.BorderThickness = new Thickness(1);
                    //brandItemBorder.CornerRadius = new CornerRadius(10);
                    brandItemBorder.Effect = shadow;

                    brandItemBorder.Child = brandListIdItem;

                    Grid.SetColumn(brandItemBorder, 3);
                    Grid.SetRow(brandItemBorder, i + 1);

                    priceListGrid.Children.Add(brandItemBorder);

                    ///////////////////////////////// model (style even )////////////////////////////
                    Label modelListIdItem = new Label();
                    modelListIdItem.Style = (Style)FindResource("labelStyle");
                    modelListIdItem.Margin = new Thickness(0);
                    modelListIdItem.Content = priceListItems[i].company_products.model.model_name;

                    Border modelItemBorder = new Border();
                    modelItemBorder.BorderBrush = (Brush)(new BrushConverter().ConvertFrom("#EDEDED"));
                    modelItemBorder.Background = (Brush)(new BrushConverter().ConvertFrom("#EDEDED"));
                    modelItemBorder.BorderThickness = new Thickness(1);
                   // modelItemBorder.CornerRadius = new CornerRadius(10);
                    modelItemBorder.Effect = shadow;

                    modelItemBorder.Child = modelListIdItem;

                    Grid.SetColumn(modelItemBorder, 4);
                    Grid.SetRow(modelItemBorder, i + 1);

                    priceListGrid.Children.Add(modelItemBorder);

                    ///////////////////////////////// specs (style even )////////////////////////////
                    Label specsListIdItem = new Label();
                    specsListIdItem.Style = (Style)FindResource("labelStyle");
                    specsListIdItem.Margin = new Thickness(0);
                    specsListIdItem.Content = priceListItems[i].company_products.spec.spec_name;

                    Border specsItemBorder = new Border();
                    specsItemBorder.BorderBrush = (Brush)(new BrushConverter().ConvertFrom("#EDEDED"));
                    specsItemBorder.Background = (Brush)(new BrushConverter().ConvertFrom("#EDEDED"));
                    specsItemBorder.BorderThickness = new Thickness(1);
                   // specsItemBorder.CornerRadius = new CornerRadius(10);
                    specsItemBorder.Effect = shadow;

                    specsItemBorder.Child = specsListIdItem;

                    Grid.SetColumn(specsItemBorder, 5);
                    Grid.SetRow(specsItemBorder, i + 1);

                    priceListGrid.Children.Add(specsItemBorder);

                    ///////////////////////////////// price (style even )////////////////////////////
                    Label priceIdItem = new Label();
                    priceIdItem.Style = (Style)FindResource("labelStyle");
                    priceIdItem.Margin = new Thickness(0);
                    priceIdItem.Content = priceListItems[i].price;

                    Border priceItemBorder = new Border();
                    priceItemBorder.BorderBrush = (Brush)(new BrushConverter().ConvertFrom("#EDEDED"));
                    priceItemBorder.Background = (Brush)(new BrushConverter().ConvertFrom("#EDEDED"));
                    priceItemBorder.BorderThickness = new Thickness(1);
                  //  priceItemBorder.CornerRadius = new CornerRadius(10);
                    priceItemBorder.Effect = shadow;

                    priceItemBorder.Child = priceIdItem;

                    Grid.SetColumn(priceItemBorder, 6);
                    Grid.SetRow(priceItemBorder, i + 1);

                    priceListGrid.Children.Add(priceItemBorder);

                    ///////////////////////////////// currency (style even )////////////////////////////
                    Label currencyItem = new Label();
                    currencyItem.Style = (Style)FindResource("labelStyle");
                    currencyItem.Margin = new Thickness(0);
                    currencyItem.Content = priceListItems[i].price_currency.currencyName;

                    Border currencyItemBorder = new Border();
                    currencyItemBorder.BorderBrush = (Brush)(new BrushConverter().ConvertFrom("#EDEDED"));
                    currencyItemBorder.Background = (Brush)(new BrushConverter().ConvertFrom("#EDEDED"));
                    currencyItemBorder.BorderThickness = new Thickness(1);
                   // currencyItemBorder.CornerRadius = new CornerRadius(10);
                    currencyItemBorder.Effect = shadow;

                    currencyItemBorder.Child = currencyItem;

                    Grid.SetColumn(currencyItemBorder, 7);
                    Grid.SetRow(currencyItemBorder, i + 1);

                    priceListGrid.Children.Add(currencyItemBorder);

                    ///////////////////////////////// discount (style even )////////////////////////////
                    Label discountItem = new Label();
                    discountItem.Style = (Style)FindResource("labelStyle");
                    discountItem.Margin = new Thickness(0);
                    discountItem.Content = priceListItems[i].discount;

                    Border discountItemBorder = new Border();
                    discountItemBorder.BorderBrush = (Brush)(new BrushConverter().ConvertFrom("#EDEDED"));
                    discountItemBorder.Background = (Brush)(new BrushConverter().ConvertFrom("#EDEDED"));
                    discountItemBorder.BorderThickness = new Thickness(1);
                   // discountItemBorder.CornerRadius = new CornerRadius(10);
                    discountItemBorder.Effect = shadow;

                    discountItemBorder.Child = discountItem;

                    Grid.SetColumn(discountItemBorder, 8);
                    Grid.SetRow(discountItemBorder, i + 1);

                    priceListGrid.Children.Add(discountItemBorder);
                }
                else
                {
                    ///////////////////////////////// list id (style odd )////////////////////////////
                    Label priceListIdItem = new Label();
                    priceListIdItem.Style = (Style)FindResource("labelStyle");
                    priceListIdItem.Margin = new Thickness(0);
                    priceListIdItem.Content = priceListItems[i].price_list.list_id;

                    Border priceListItemBorder = new Border();
                    priceListItemBorder.BorderBrush = (Brush)(new BrushConverter().ConvertFrom("#E0E0E0"));
                    priceListItemBorder.Background = (Brush)(new BrushConverter().ConvertFrom("#E0E0E0"));
                    priceListItemBorder.BorderThickness = new Thickness(1);
                  //  priceListItemBorder.CornerRadius = new CornerRadius(10);
                    priceListItemBorder.Effect = shadow;

                    priceListItemBorder.Child = priceListIdItem;

                    Grid.SetColumn(priceListItemBorder, 0);
                    Grid.SetRow(priceListItemBorder, i + 1);

                    priceListGrid.Children.Add(priceListItemBorder);

                    ///////////////////////////////// category (style odd )////////////////////////////
                    Label categoryListIdItem = new Label();
                    categoryListIdItem.Style = (Style)FindResource("labelStyle");
                    categoryListIdItem.Margin = new Thickness(0);
                    categoryListIdItem.Content = priceListItems[i].company_products.category_name.category_name;

                    Border categoryItemBorder = new Border();
                    categoryItemBorder.BorderBrush = (Brush)(new BrushConverter().ConvertFrom("#E0E0E0"));
                    categoryItemBorder.Background = (Brush)(new BrushConverter().ConvertFrom("#E0E0E0"));
                    categoryItemBorder.BorderThickness = new Thickness(1);
                   // categoryItemBorder.CornerRadius = new CornerRadius(10);
                    categoryItemBorder.Effect = shadow;

                    categoryItemBorder.Child = categoryListIdItem;

                    Grid.SetColumn(categoryItemBorder, 1);
                    Grid.SetRow(categoryItemBorder, i + 1);

                    priceListGrid.Children.Add(categoryItemBorder);

                    ///////////////////////////////// type (style even )////////////////////////////
                    Label typeListIdItem = new Label();
                    typeListIdItem.Style = (Style)FindResource("labelStyle");
                    typeListIdItem.Margin = new Thickness(0);
                    typeListIdItem.Content = priceListItems[i].company_products.product.product_name;

                    Border typeItemBorder = new Border();
                    typeItemBorder.BorderBrush = (Brush)(new BrushConverter().ConvertFrom("#E0E0E0"));
                    typeItemBorder.Background = (Brush)(new BrushConverter().ConvertFrom("#E0E0E0"));
                    typeItemBorder.BorderThickness = new Thickness(1);
                   // typeItemBorder.CornerRadius = new CornerRadius(10);
                    typeItemBorder.Effect = shadow;

                    typeItemBorder.Child = typeListIdItem;

                    Grid.SetColumn(typeItemBorder, 2);
                    Grid.SetRow(typeItemBorder, i + 1);

                    priceListGrid.Children.Add(typeItemBorder);

                    ///////////////////////////////// brand (style even )////////////////////////////
                    Label brandListIdItem = new Label();
                    brandListIdItem.Style = (Style)FindResource("labelStyle");
                    brandListIdItem.Margin = new Thickness(0);
                    brandListIdItem.Content = priceListItems[i].company_products.brand.brand_name;

                    Border brandItemBorder = new Border();
                    brandItemBorder.BorderBrush = (Brush)(new BrushConverter().ConvertFrom("#E0E0E0"));
                    brandItemBorder.Background = (Brush)(new BrushConverter().ConvertFrom("#E0E0E0"));
                    brandItemBorder.BorderThickness = new Thickness(1);
                   // brandItemBorder.CornerRadius = new CornerRadius(10);
                    brandItemBorder.Effect = shadow;

                    brandItemBorder.Child = brandListIdItem;

                    Grid.SetColumn(brandItemBorder, 3);
                    Grid.SetRow(brandItemBorder, i + 1);

                    priceListGrid.Children.Add(brandItemBorder);

                    ///////////////////////////////// model (style even )////////////////////////////
                    Label modelListIdItem = new Label();
                    modelListIdItem.Style = (Style)FindResource("labelStyle");
                    modelListIdItem.Margin = new Thickness(0);
                    modelListIdItem.Content = priceListItems[i].company_products.model.model_name;

                    Border modelItemBorder = new Border();
                    modelItemBorder.BorderBrush = (Brush)(new BrushConverter().ConvertFrom("#E0E0E0"));
                    modelItemBorder.Background = (Brush)(new BrushConverter().ConvertFrom("#E0E0E0"));
                    modelItemBorder.BorderThickness = new Thickness(1);
                   // modelItemBorder.CornerRadius = new CornerRadius(10);
                    modelItemBorder.Effect = shadow;

                    modelItemBorder.Child = modelListIdItem;

                    Grid.SetColumn(modelItemBorder, 4);
                    Grid.SetRow(modelItemBorder, i + 1);

                    priceListGrid.Children.Add(modelItemBorder);

                    ///////////////////////////////// specs (style even )////////////////////////////
                    Label specsListIdItem = new Label();
                    specsListIdItem.Style = (Style)FindResource("labelStyle");
                    specsListIdItem.Margin = new Thickness(0);
                    specsListIdItem.Content = priceListItems[i].company_products.spec.spec_name;

                    Border specsItemBorder = new Border();
                    specsItemBorder.BorderBrush = (Brush)(new BrushConverter().ConvertFrom("#E0E0E0"));
                    specsItemBorder.Background = (Brush)(new BrushConverter().ConvertFrom("#E0E0E0"));
                    specsItemBorder.BorderThickness = new Thickness(1);
                   // specsItemBorder.CornerRadius = new CornerRadius(10);
                    specsItemBorder.Effect = shadow;

                    specsItemBorder.Child = specsListIdItem;

                    Grid.SetColumn(specsItemBorder, 5);
                    Grid.SetRow(specsItemBorder, i + 1);

                    priceListGrid.Children.Add(specsItemBorder);

                    ///////////////////////////////// price (style even )////////////////////////////
                    Label priceIdItem = new Label();
                    priceIdItem.Style = (Style)FindResource("labelStyle");
                    priceIdItem.Margin = new Thickness(0);
                    priceIdItem.Content = priceListItems[i].price;

                    Border priceItemBorder = new Border();
                    priceItemBorder.BorderBrush = (Brush)(new BrushConverter().ConvertFrom("#E0E0E0"));
                    priceItemBorder.Background = (Brush)(new BrushConverter().ConvertFrom("#E0E0E0"));
                    priceItemBorder.BorderThickness = new Thickness(1);
                   // priceItemBorder.CornerRadius = new CornerRadius(10);
                    priceItemBorder.Effect = shadow;

                    priceItemBorder.Child = priceIdItem;

                    Grid.SetColumn(priceItemBorder, 6);
                    Grid.SetRow(priceItemBorder, i + 1);

                    priceListGrid.Children.Add(priceItemBorder);

                    ///////////////////////////////// currency (style even )////////////////////////////
                    Label currencyItem = new Label();
                    currencyItem.Style = (Style)FindResource("labelStyle");
                    currencyItem.Margin = new Thickness(0);
                    currencyItem.Content = priceListItems[i].price_currency.currencyName;

                    Border currencyItemBorder = new Border();
                    currencyItemBorder.BorderBrush = (Brush)(new BrushConverter().ConvertFrom("#E0E0E0"));
                    currencyItemBorder.Background = (Brush)(new BrushConverter().ConvertFrom("#E0E0E0"));
                    currencyItemBorder.BorderThickness = new Thickness(1);
                   // currencyItemBorder.CornerRadius = new CornerRadius(10);
                    currencyItemBorder.Effect = shadow;

                    currencyItemBorder.Child = currencyItem;

                    Grid.SetColumn(currencyItemBorder, 7);
                    Grid.SetRow(currencyItemBorder, i + 1);

                    priceListGrid.Children.Add(currencyItemBorder);

                    ///////////////////////////////// discount (style even )////////////////////////////
                    Label discountItem = new Label();
                    discountItem.Style = (Style)FindResource("labelStyle");
                    discountItem.Margin = new Thickness(0);
                    discountItem.Content = priceListItems[i].discount;

                    Border discountItemBorder = new Border();
                    discountItemBorder.BorderBrush = (Brush)(new BrushConverter().ConvertFrom("#E0E0E0"));
                    discountItemBorder.Background = (Brush)(new BrushConverter().ConvertFrom("#E0E0E0"));
                    discountItemBorder.BorderThickness = new Thickness(1);
                   // discountItemBorder.CornerRadius = new CornerRadius(10);
                    discountItemBorder.Effect = shadow;

                    discountItemBorder.Child = discountItem;

                    Grid.SetColumn(discountItemBorder, 8);
                    Grid.SetRow(discountItemBorder, i + 1);

                    priceListGrid.Children.Add(discountItemBorder);
                }


            }


        }
    }
}
