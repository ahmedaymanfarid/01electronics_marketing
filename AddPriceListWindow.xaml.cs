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
using System.Windows.Shapes;
using _01electronics_library;

namespace _01electronics_marketing
{
    /// <summary>
    /// Interaction logic for AddPriceListWindow.xaml
    /// </summary>

    

    public partial class AddPriceListWindow : Window
    {
        CommonQueries commonQueries;
        List<PRODUCTS_STRUCTS.PRODUCT_CATEGORY_STRUCT> categoryList;
        List<PRODUCTS_STRUCTS.PRODUCT_TYPE_STRUCT> productList;
        List<PRODUCTS_STRUCTS.PRODUCT_BRAND_STRUCT> brandsList;
        List<PRODUCTS_STRUCTS.PRODUCT_MODEL_STRUCT> modelList;
        List<PRODUCTS_STRUCTS.PRODUCT_SPECS_STRUCT> specList;
        List<BASIC_STRUCTS.CURRENCY_STRUCT> currencyList;
        List<MARKETING_STRUCTS.PRICE_LIST_ITEMS> priceListItems;
        PriceList priceList;
        IntegrityChecks integrityChecks;
        int itemNumber;
        public AddPriceListWindow(ref Employee mLoggedInUser)
        {
            commonQueries = new CommonQueries();
            categoryList = new List<PRODUCTS_STRUCTS.PRODUCT_CATEGORY_STRUCT>();
            productList = new List<PRODUCTS_STRUCTS.PRODUCT_TYPE_STRUCT>();
            brandsList = new List<PRODUCTS_STRUCTS.PRODUCT_BRAND_STRUCT>();
            modelList = new List<PRODUCTS_STRUCTS.PRODUCT_MODEL_STRUCT>();
            specList = new List<PRODUCTS_STRUCTS.PRODUCT_SPECS_STRUCT>();
            currencyList = new List<BASIC_STRUCTS.CURRENCY_STRUCT>();
            priceListItems = new List<MARKETING_STRUCTS.PRICE_LIST_ITEMS>();
            priceList = new PriceList();
            itemNumber = 2;
            priceList.SetPriceListRequestor(mLoggedInUser);
            integrityChecks = new IntegrityChecks();
             InitializeComponent();
             DiasbleFunction();
            InitializeCategoryComboBox(categoryComboBox);
            InitializeCurrencyComboBox(priceCurrencyComboBox);
        }
        /////////////////////////////////////////// INITIALIZATION FUNCTION ////////////////
        public void DiasbleFunction()
        {
            typeComboBox.IsEnabled = false;
            brandComboBox.IsEnabled = false;
            modelComboBox.IsEnabled = false;
            specsComboBox.IsEnabled = false;
            priceTextBlock.IsEnabled = false;
            priceCurrencyComboBox.IsEnabled = false;
            discountTextBlock.IsEnabled = false;
            
        }
        public void InitializeCategoryComboBox(ComboBox categoryComboBox)
        {
            categoryList.Clear();
            if (!commonQueries.GetProductCategories(ref categoryList))
                return;
            for(int i = 0;i< categoryList.Count; i++)
            {
                categoryComboBox.Items.Add(categoryList[i].category_name);
                
            }


        }
        public void InitializeTypeComboBox( int categoryId , ComboBox typeComboBox )
        {
            
                if (!commonQueries.GetCompanyProducts(ref productList, categoryId))
                    return;
                for (int i = 0; i < productList.Count; i++)
                {
                    typeComboBox.Items.Add(productList[i].product_name);
                  
                }
            
           
        }
        public void InitializeBrandComboBox(int productId, ComboBox brandComboBox)
        {
            if (!commonQueries.GetProductBrands(productId, ref brandsList))
                return;
            for(int i=0; i< brandsList.Count;i++)
            {
                brandComboBox.Items.Add(brandsList[i].brand_name);
            
            }
        }
        public void InitializeModelComboBox(PRODUCTS_STRUCTS.PRODUCT_TYPE_STRUCT product , PRODUCTS_STRUCTS.PRODUCT_BRAND_STRUCT brand , ComboBox modelComboBox)
        {
            if(!commonQueries.GetCompanyModels(product,brand,ref modelList))
                return;
            for(int i=0; i< modelList.Count; i++)
            {
                modelComboBox.Items.Add(modelList[i].model_name);
           
            }
        }
        public void InitializeSpecsComboBox(int categoryId , int productId , int brandId , int modelId , ComboBox specsComboBox)
        {
            if (!commonQueries.GetModelSpecsNames(categoryId, productId, brandId, modelId, ref specList))
                return;
            for(int i= 0; i< specList.Count;i++)
            {
                specsComboBox.Items.Add(specList[i].spec_name);
              
            }

        }
        public void InitializeCurrencyComboBox(ComboBox currencyComboBox)
        {
            currencyList.Clear();
            if (!commonQueries.GetCurrencyTypes(ref currencyList))
                return;
            for(int i=0 ;i<currencyList.Count;i++)
            {
                currencyComboBox.Items.Add(currencyList[i].currencyName);
            }
        }
        /// <summary>
        /// //////////////////////////////// ON SELECTION CHANGED //////////////////////////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSelChangedCategoryComboBox(object sender, SelectionChangedEventArgs e)
        {
            ComboBox categoryComboBox  = sender as ComboBox;
          

            WrapPanel categoryWrapPanel = categoryComboBox.Parent as WrapPanel;
            StackPanel itemsStackPanel = categoryWrapPanel.Parent as StackPanel;

            WrapPanel typeWrapPanel = itemsStackPanel.Children[2] as WrapPanel;
            WrapPanel brandWrapPanel = itemsStackPanel.Children[3] as WrapPanel;
            WrapPanel modelWrapPanel = itemsStackPanel.Children[4] as WrapPanel;
            WrapPanel specsWrapPanel = itemsStackPanel.Children[5] as WrapPanel;
            WrapPanel priceWrapPanel = itemsStackPanel.Children[6] as WrapPanel;
            WrapPanel discountWrapPanel = itemsStackPanel.Children[7] as WrapPanel;

            ComboBox typeCombo  = typeWrapPanel.Children[1] as ComboBox;
            ComboBox brandCombo = brandWrapPanel.Children[1] as ComboBox;
            ComboBox modelCombo = modelWrapPanel.Children[1] as ComboBox;
            ComboBox specsCombo = specsWrapPanel.Children[1] as ComboBox;
            TextBox priceText = priceWrapPanel.Children[1] as TextBox;
            ComboBox currencyCombo = priceWrapPanel.Children[2] as ComboBox;
            TextBox discountText = discountWrapPanel.Children[1] as TextBox;

            if (categoryComboBox.SelectedIndex != -1)
            {
                categoryComboBox.Tag = categoryList[categoryComboBox.SelectedIndex].category_id;

                typeCombo.IsEnabled = true;
                typeCombo.Items.Clear();
                brandCombo.Items.Clear();
                modelCombo.Items.Clear();
                specsCombo.Items.Clear();
                priceText.Text = string.Empty;
                discountText.Text = string.Empty;
                productList.Clear();
                InitializeTypeComboBox(categoryList[categoryComboBox.SelectedIndex].category_id , typeCombo);
            }
        }

        private void OnSelChangedTypeComboBox(object sender, SelectionChangedEventArgs e)
        {
            ComboBox typeComboBox = sender as ComboBox;
           
            WrapPanel typeWrapPanel = typeComboBox.Parent as WrapPanel;
            StackPanel itemsStackPanel = typeWrapPanel.Parent as StackPanel;

            WrapPanel categoryWrapPanel = itemsStackPanel.Children[1] as WrapPanel;
            WrapPanel brandWrapPanel = itemsStackPanel.Children[3] as WrapPanel;
            WrapPanel modelWrapPanel = itemsStackPanel.Children[4] as WrapPanel;
            WrapPanel specsWrapPanel = itemsStackPanel.Children[5] as WrapPanel;
            WrapPanel priceWrapPanel = itemsStackPanel.Children[6] as WrapPanel;
            WrapPanel discountWrapPanel = itemsStackPanel.Children[7] as WrapPanel;

            ComboBox categoryCombo = categoryWrapPanel.Children[1] as ComboBox;
            ComboBox brandCombo = brandWrapPanel.Children[1] as ComboBox;
            ComboBox modelCombo = modelWrapPanel.Children[1] as ComboBox;
            ComboBox specsCombo = specsWrapPanel.Children[1] as ComboBox;
            TextBox priceText = priceWrapPanel.Children[1] as TextBox;
            ComboBox currencyCombo = priceWrapPanel.Children[2] as ComboBox;
            TextBox discountText = discountWrapPanel.Children[1] as TextBox;
            if (typeComboBox.SelectedIndex != -1)
            {
                typeComboBox.Tag = productList[typeComboBox.SelectedIndex].type_id;

                brandCombo.IsEnabled = true;
                brandCombo.Items.Clear();
                modelCombo.Items.Clear();
                specsCombo.Items.Clear();
                priceText.Text = string.Empty;
                discountText.Text = string.Empty;
                brandsList.Clear();
                InitializeBrandComboBox(productList[typeComboBox.SelectedIndex].type_id , brandCombo);
            }
        }

        private void OnSelChangedBrandComboBox(object sender, SelectionChangedEventArgs e)
        {
            ComboBox brandComboBox = sender as ComboBox;
            

            WrapPanel brandWrapPanel = brandComboBox.Parent as WrapPanel;
            StackPanel itemsStackPanel = brandWrapPanel.Parent as StackPanel;

            WrapPanel categoryWrapPanel = itemsStackPanel.Children[1] as WrapPanel;
            WrapPanel typeWrapPanel = itemsStackPanel.Children[2] as WrapPanel;
            WrapPanel modelWrapPanel = itemsStackPanel.Children[4] as WrapPanel;
            WrapPanel specsWrapPanel = itemsStackPanel.Children[5] as WrapPanel;
            WrapPanel priceWrapPanel = itemsStackPanel.Children[6] as WrapPanel;
            WrapPanel discountWrapPanel = itemsStackPanel.Children[7] as WrapPanel;

            ComboBox categoryCombo = categoryWrapPanel.Children[1] as ComboBox;
            ComboBox typeCombo = typeWrapPanel.Children[1] as ComboBox;
            ComboBox modelCombo = modelWrapPanel.Children[1] as ComboBox;
            ComboBox specsCombo = specsWrapPanel.Children[1] as ComboBox;
            TextBox priceText = priceWrapPanel.Children[1] as TextBox;
            ComboBox currencyCombo = priceWrapPanel.Children[2] as ComboBox;
            TextBox discountText = discountWrapPanel.Children[1] as TextBox;
            if (brandComboBox.SelectedIndex != -1)
            {
                brandComboBox.Tag = brandsList[brandComboBox.SelectedIndex].brand_id;
                modelCombo.IsEnabled = true;
                modelCombo.Items.Clear();
                specsCombo.Items.Clear();
                priceText.Text = string.Empty;
                discountText.Text = string.Empty;
                modelList.Clear();
                InitializeModelComboBox(productList[typeCombo.SelectedIndex], brandsList[brandComboBox.SelectedIndex] , modelCombo);

            }
        }

        private void OnSelChangedModelComboBox(object sender, SelectionChangedEventArgs e)
        {
            ComboBox modelComboBox = sender as ComboBox;
           

            WrapPanel modelWrapPanel = modelComboBox.Parent as WrapPanel;
            StackPanel itemsStackPanel = modelWrapPanel.Parent as StackPanel;

            WrapPanel categoryWrapPanel = itemsStackPanel.Children[1] as WrapPanel;
            WrapPanel typeWrapPanel = itemsStackPanel.Children[2] as WrapPanel;
            WrapPanel brandWrapPanel = itemsStackPanel.Children[3] as WrapPanel;
            WrapPanel specsWrapPanel = itemsStackPanel.Children[5] as WrapPanel;
            WrapPanel priceWrapPanel = itemsStackPanel.Children[6] as WrapPanel;
            WrapPanel discountWrapPanel = itemsStackPanel.Children[7] as WrapPanel;

            ComboBox categoryCombo = categoryWrapPanel.Children[1] as ComboBox;
            ComboBox typeCombo = typeWrapPanel.Children[1] as ComboBox;
            ComboBox brandCombo = brandWrapPanel.Children[1] as ComboBox;
            ComboBox specsCombo = specsWrapPanel.Children[1] as ComboBox;
            TextBox priceText = priceWrapPanel.Children[1] as TextBox;
            ComboBox currencyCombo = priceWrapPanel.Children[2] as ComboBox;
            TextBox discountText = discountWrapPanel.Children[1] as TextBox;
            if (modelComboBox.SelectedIndex != -1)
            {
                modelComboBox.Tag = modelList[modelComboBox.SelectedIndex].model_id;
                specsCombo.IsEnabled= true;
                specsCombo.Items.Clear();
                priceText.Text = string.Empty;
                discountText.Text = string.Empty;
                specList.Clear();
                InitializeSpecsComboBox(categoryList[categoryCombo.SelectedIndex].category_id,
                                        productList[typeCombo.SelectedIndex].type_id,
                                       brandsList[brandCombo.SelectedIndex].brand_id,
                                       modelList[modelComboBox.SelectedIndex].model_id , specsCombo);
            }
        }
        private void OnSelectionChangedSpecsComboBox(object sender, SelectionChangedEventArgs e)
        {
            ComboBox specsComboBox = sender as ComboBox;
            if(specsComboBox.SelectedIndex!=-1)
               specsComboBox.Tag = specList[specsComboBox.SelectedIndex].spec_id;

            WrapPanel specsWrapPanel = specsComboBox.Parent as WrapPanel;

            StackPanel itemsStackPanel = specsWrapPanel.Parent as StackPanel;

            WrapPanel categoryWrapPanel = itemsStackPanel.Children[1] as WrapPanel;
            WrapPanel typeWrapPanel = itemsStackPanel.Children[2] as WrapPanel;
            WrapPanel brandWrapPanel = itemsStackPanel.Children[3] as WrapPanel;
            WrapPanel modelWrapPanel = itemsStackPanel.Children[4] as WrapPanel;
            WrapPanel priceWrapPanel = itemsStackPanel.Children[6] as WrapPanel;
            WrapPanel discountWrapPanel = itemsStackPanel.Children[7] as WrapPanel;

            ComboBox categoryCombo = categoryWrapPanel.Children[1] as ComboBox;
            ComboBox typeCombo = typeWrapPanel.Children[1] as ComboBox;
            ComboBox brandCombo = brandWrapPanel.Children[1] as ComboBox;
            ComboBox modelCombo = modelWrapPanel.Children[1] as ComboBox;
            TextBox priceText = priceWrapPanel.Children[1] as TextBox;
            ComboBox currencyCombo = priceWrapPanel.Children[2] as ComboBox;
            TextBox discountText = discountWrapPanel.Children[1] as TextBox;

            priceText.IsEnabled= true;
            priceText.Text= string.Empty;
            currencyCombo.IsEnabled= true;
            discountText.IsEnabled=true;
            discountText.Text= string.Empty;

            

        }
        /// <summary>///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// //////////////////////////////////////////////// SAVE BUTTON //////////////////////////////////////////////////////////////
        /// </summary>////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void OnButtonClickSave(object sender, RoutedEventArgs e)
        {
            if (!CheckEmptyCard())
                return;
            for (int i = 0; i < mainWrapPanel.Children.Count; i++)
            {
                Border border = mainWrapPanel.Children[i] as Border;
                StackPanel itemsStackPanel = border.Child as StackPanel;
                WrapPanel categoryWrapPanel = itemsStackPanel.Children[1] as WrapPanel;
                WrapPanel typeWrapPanel = itemsStackPanel.Children[2] as WrapPanel;
                WrapPanel brandWrapPanel = itemsStackPanel.Children[3] as WrapPanel;
                WrapPanel modelWrapPanel = itemsStackPanel.Children[4] as WrapPanel;
                WrapPanel specsWrapPanel = itemsStackPanel.Children[5] as WrapPanel;
                WrapPanel priceWrapPanel = itemsStackPanel.Children[6] as WrapPanel;
                WrapPanel discountWrapPanel = itemsStackPanel.Children[7] as WrapPanel;

                ComboBox categoryCombo = categoryWrapPanel.Children[1] as ComboBox;
                ComboBox typeCombo = typeWrapPanel.Children[1] as ComboBox;
                ComboBox brandCombo = brandWrapPanel.Children[1] as ComboBox;
                ComboBox modelCombo = modelWrapPanel.Children[1] as ComboBox;
                ComboBox specsCombo = specsWrapPanel.Children[1] as ComboBox;
                TextBox priceText = priceWrapPanel.Children[1] as TextBox;
                ComboBox currencyCombo = priceWrapPanel.Children[2] as ComboBox;
                TextBox discountText = discountWrapPanel.Children[1] as TextBox;

                MARKETING_STRUCTS.PRICE_LIST_ITEMS items = new MARKETING_STRUCTS.PRICE_LIST_ITEMS();

                items.company_products.category_name.category_id =int.Parse(categoryCombo.Tag.ToString());
                items.company_products.category_name.category_name =categoryCombo.SelectedItem.ToString();

                items.company_products.product.type_id= int.Parse(typeCombo.Tag.ToString());
                items.company_products.product.product_name = typeCombo.SelectedItem.ToString();

                items.company_products.brand.brand_id = int.Parse(brandCombo.Tag.ToString());
                items.company_products.brand.brand_name = brandCombo.SelectedItem.ToString();

                items.company_products.model.model_id = int.Parse(modelCombo.Tag.ToString());
                items.company_products.model.model_name = modelCombo.SelectedItem.ToString();

                items.company_products.spec.spec_id = int.Parse(specsCombo.Tag.ToString());
                items.company_products.spec.spec_name = specsCombo.SelectedItem.ToString();

                items.price = decimal.Parse(priceText.Text);
                items.discount = decimal.Parse(discountText.Text);

                items.price_currency.currencyId = currencyList[currencyCombo.SelectedIndex].currencyId;
                items.price_currency.currencyName = currencyList[currencyCombo.SelectedIndex].currencyName;

                items.item_number = i + 1;
                priceListItems.Add(items);

            }
            priceList.SetPriceListItems(ref priceListItems);
            if (!priceList.IssuePriceList())
                return;

            this.Close();
        }

        private void OnButtonClickAddNewItem(object sender, RoutedEventArgs e)
        {
            if (!CheckEmptyCard())
                return;
            CreateCard();

        }
        ///////////////////////////////// CREATE CARD //////////////////////////////////////
        public void CreateCard()
        {
            /////// create border/////////
            Border cardBorder = new Border();
            cardBorder.Margin = new Thickness(10);
            cardBorder.BorderBrush = (Brush)(new BrushConverter().ConvertFrom("#105A97"));
            cardBorder.BorderThickness = new Thickness(1);

            DropShadowEffect shadow = new DropShadowEffect();
            shadow.BlurRadius = 20;
            shadow.Color = Color.FromRgb(211, 211, 211);
            cardBorder.Effect = shadow;

            ///////////// create StackPanel /////////////
            StackPanel itemStackPanel = new StackPanel();

            /////// create header wrappanel ///////////
            
            WrapPanel headerWrapPanel = new WrapPanel();
            headerWrapPanel.Margin = new Thickness(10);
            headerWrapPanel.Background = (Brush)(new BrushConverter().ConvertFrom("#105A97"));

            Label header = new Label();
            header.Content = "Item " + itemNumber;
            header.Style = (Style)FindResource("tableHeaderItem");
            header.Margin = new Thickness(160,0,0,0);
            header.Foreground = Brushes.White;
            header.FontSize = 20;

            headerWrapPanel.Children.Add(header);

            /////////// create category wrapPanel ///////////////
            WrapPanel categorywrapPanel = new WrapPanel();
            categorywrapPanel.Margin = new Thickness(10);
            categorywrapPanel.Background = Brushes.White;
            
            Label categoryLabel = new Label();
            categoryLabel.Content = "Category *";
            categoryLabel.Style = (Style)FindResource("labelStyleCard");
            ComboBox categoryComboBox = new ComboBox();
            categoryComboBox.Style = (Style)FindResource("comboBoxStyleCard");
            categoryComboBox.SelectionChanged += OnSelChangedCategoryComboBox;

            categorywrapPanel.Children.Add(categoryLabel);
            categorywrapPanel.Children.Add(categoryComboBox);

            /////////// create type wrapPanel ///////////////
            WrapPanel typewrapPanel = new WrapPanel();
            typewrapPanel.Margin = new Thickness(10);
            typewrapPanel.Background = Brushes.White;

            Label typeLabel = new Label();
            typeLabel.Content = "Type *";
            typeLabel.Style = (Style)FindResource("labelStyleCard");
            ComboBox typeComboBox = new ComboBox();
            typeComboBox.Style = (Style)FindResource("comboBoxStyleCard");
            typeComboBox.SelectionChanged += OnSelChangedTypeComboBox;
            typeComboBox.IsEnabled = false;

            typewrapPanel.Children.Add(typeLabel);
            typewrapPanel.Children.Add(typeComboBox);

            /////////// create brand wrapPanel ///////////////
            WrapPanel brandWrapPanel = new WrapPanel();
            brandWrapPanel.Margin = new Thickness(10);
            brandWrapPanel.Background = Brushes.White;

            Label brandLabel = new Label();
            brandLabel.Content = "Brand *";
            brandLabel.Style = (Style)FindResource("labelStyleCard");
            ComboBox brandComboBox = new ComboBox();
            brandComboBox.Style = (Style)FindResource("comboBoxStyleCard");
            brandComboBox.SelectionChanged += OnSelChangedBrandComboBox;
            brandComboBox.IsEnabled = false;
            
            brandWrapPanel.Children.Add(brandLabel);
            brandWrapPanel.Children.Add(brandComboBox);

            ////////////// create model wrapPanel //////////////
            WrapPanel modelWrapPanel = new WrapPanel();
            modelWrapPanel.Margin = new Thickness(10);
            modelWrapPanel.Background = Brushes.White;

            Label modelLabel = new Label();
            modelLabel.Content = "Model *";
            modelLabel.Style = (Style)FindResource("labelStyleCard");
            ComboBox modelComboBox = new ComboBox();
            modelComboBox.Style = (Style)FindResource("comboBoxStyleCard");
            modelComboBox.SelectionChanged += OnSelChangedModelComboBox;
            modelComboBox.IsEnabled = false;

            modelWrapPanel.Children.Add(modelLabel);
            modelWrapPanel.Children.Add(modelComboBox);

            ////////////// create specs wrapPanel //////////////
            WrapPanel specsWrapPanel = new WrapPanel();
            specsWrapPanel.Margin = new Thickness(10);
            specsWrapPanel.Background = Brushes.White;

            Label specsLabel = new Label();
            specsLabel.Content = "Specs *";
            specsLabel.Style = (Style)FindResource("labelStyleCard");
            ComboBox specsComboBox = new ComboBox();
            specsComboBox.Style = (Style)FindResource("comboBoxStyleCard");
            specsComboBox.SelectionChanged += OnSelectionChangedSpecsComboBox;
            specsComboBox.IsEnabled = false;

            specsWrapPanel.Children.Add(specsLabel);
            specsWrapPanel.Children.Add(specsComboBox);

            ////////////// create price wrapPanel //////////////
            WrapPanel priceWrapPanel = new WrapPanel();
            priceWrapPanel.Margin = new Thickness(10);
            priceWrapPanel.Background = Brushes.White;

            Label priceLabel = new Label();
            priceLabel.Content = "Price *";
            priceLabel.Style = (Style)FindResource("labelStyleCard");
            TextBox priceTextBox = new TextBox();
            priceTextBox.Style = (Style)FindResource("TextBlockStyleCard");
            priceTextBox.Width = 100;
            ComboBox currencyComboBox = new ComboBox();
            currencyComboBox.Style = (Style)FindResource("comboBoxStyleCard");
            currencyComboBox.Width = 100;
            priceTextBox.IsEnabled = false;
            currencyComboBox.IsEnabled = false;


            priceWrapPanel.Children.Add(priceLabel);
            priceWrapPanel.Children.Add(priceTextBox);
            priceWrapPanel.Children.Add(currencyComboBox);


            ////////////// create discount wrapPanel //////////////
            WrapPanel discountWrapPanel = new WrapPanel();
            discountWrapPanel.Margin = new Thickness(10);
            discountWrapPanel.Background = Brushes.White;

            Label discountLabel = new Label();
            discountLabel.Content = "Discount *";
            discountLabel.Style = (Style)FindResource("labelStyleCard");
            TextBox discountTextBox = new TextBox();
            discountTextBox.Style = (Style)FindResource("TextBlockStyleCard");
            discountTextBox.Width = 100;
            discountTextBox.IsEnabled = false;
         
            discountWrapPanel.Children.Add(discountLabel);
            discountWrapPanel.Children.Add(discountTextBox);

            itemStackPanel.Children.Add(headerWrapPanel);
            itemStackPanel.Children.Add(categorywrapPanel);
            itemStackPanel.Children.Add(typewrapPanel);
            itemStackPanel.Children.Add(brandWrapPanel);
            itemStackPanel.Children.Add(modelWrapPanel);
            itemStackPanel.Children.Add(specsWrapPanel);
            itemStackPanel.Children.Add(priceWrapPanel);
            itemStackPanel.Children.Add(discountWrapPanel);

            cardBorder.Child= itemStackPanel;

            mainWrapPanel.Children.Add(cardBorder);
            InitializeCategoryComboBox(categoryComboBox);
            InitializeCurrencyComboBox(currencyComboBox);
            itemNumber++;





        }
        /////////////////////////////////////////// CHECK FOR EMPTY CARD //////////////////////////////////
        public bool CheckEmptyCard()
        {
            for (int i = 0; i < mainWrapPanel.Children.Count; i++)
            {
                Border border = mainWrapPanel.Children[i] as Border;
                StackPanel itemsStackPanel = border.Child as StackPanel;
                WrapPanel categoryWrapPanel = itemsStackPanel.Children[1] as WrapPanel;
                WrapPanel typeWrapPanel = itemsStackPanel.Children[2] as WrapPanel;
                WrapPanel brandWrapPanel = itemsStackPanel.Children[3] as WrapPanel;
                WrapPanel modelWrapPanel = itemsStackPanel.Children[4] as WrapPanel;
                WrapPanel specsWrapPanel = itemsStackPanel.Children[5] as WrapPanel;
                WrapPanel priceWrapPanel = itemsStackPanel.Children[6] as WrapPanel;
                WrapPanel discountWrapPanel = itemsStackPanel.Children[7] as WrapPanel;

                ComboBox categoryCombo = categoryWrapPanel.Children[1] as ComboBox;
                ComboBox typeCombo = typeWrapPanel.Children[1] as ComboBox;
                ComboBox brandCombo = brandWrapPanel.Children[1] as ComboBox;
                ComboBox modelCombo = modelWrapPanel.Children[1] as ComboBox;
                ComboBox specsCombo = specsWrapPanel.Children[1] as ComboBox;
                TextBox priceText = priceWrapPanel.Children[1] as TextBox;
                ComboBox currencyCombo = priceWrapPanel.Children[2] as ComboBox;
                TextBox discountText = discountWrapPanel.Children[1] as TextBox;

                if (categoryCombo.SelectedIndex == -1)
                {
                    System.Windows.Forms.MessageBox.Show($@"Please select category item {i + 1}", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    return false;
                }
                if (typeCombo.SelectedIndex == -1)
                {
                    System.Windows.Forms.MessageBox.Show($@"Please select type item {i + 1}", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    return false;
                }
                if (brandCombo.SelectedIndex == -1)
                {
                    System.Windows.Forms.MessageBox.Show($@"Please select brand item {i + 1}", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    return false;
                }
                if (modelCombo.SelectedIndex == -1)
                {
                    System.Windows.Forms.MessageBox.Show($@"Please select model item {i + 1}", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    return false;
                }
                if (specsCombo.SelectedIndex == -1)
                {
                    System.Windows.Forms.MessageBox.Show($@"Please select specs item {i + 1}", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    return false;
                }
                if (currencyCombo.SelectedIndex == -1)
                {
                    System.Windows.Forms.MessageBox.Show($@"Please select currency item {i + 1}", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    return false;
                }

                
            }
            return true;
        }
        /// <summary>
        /// ///////////////////////////////////////// ON TEXT CHANGED //////////////////////////////////////////////////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTextChangedPriceTextBox(object sender, TextChangedEventArgs e)
        {
            TextBox priceInput = sender as TextBox;
            if (!decimal.TryParse(priceInput.Text, out decimal value))
            {
                System.Windows.Forms.MessageBox.Show($@"Please enter numeric values", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                priceInput.Text = string.Empty;
                return;
            }
           
        }

        private void OnTextChangedDiscountTextBox(object sender, TextChangedEventArgs e)
        {
            TextBox discountInput = sender as TextBox;
            if (!decimal.TryParse(discountInput.Text, out decimal value))
            {
                System.Windows.Forms.MessageBox.Show($@"Please enter numeric values", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                discountInput.Text = string.Empty;
                return;
            }
        }
    }
}
