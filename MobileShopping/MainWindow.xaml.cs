using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MobileShopping.Repository;
using MobileShopping.Service;
using System.Collections.ObjectModel;
using MobileShopping.Model;
using MobileShopping.Utility;

namespace MobileShopping
{
    
    
    
    public partial class MainWindow : Window
    {
        private IShoppingService _shoppingService;
        
        private int currentPageIndex = 0;
        private int totalPage = -1;

        public ObservableCollection<Product> ProductList
        {
            get { return (ObservableCollection<Product>)GetValue(DataProperty); }
            set { SetValue(DataProperty, value); }
        }

        
        public static readonly DependencyProperty DataProperty =
        DependencyProperty.Register("ProductList", typeof(ObservableCollection<Product>), typeof(MainWindow), null);

        public MainWindow()
        {
            _shoppingService = new ShoppingService();
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(Window_Loaded);
        }

        private void ShowCurrentPageIndex()
        {
            this.tbCurrentPage.Text = (currentPageIndex + 1).ToString();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BindProductListView();
        }

        private void BindProductListView()
        {
            if (ProductList == null)
            {
                ProductList = new ObservableCollection<Product>();
            }
            else
            {
                ProductList.Clear();
            }
            ProductList = new ObservableCollection<Product>(_shoppingService.GetProductListByIndex(txtSearch.Text.Trim(), currentPageIndex + 1));
            if (totalPage == -1)
            {
                totalPage = _shoppingService.GetTotalProduct(txtSearch.Text.Trim());
            }
            ShowCurrentPageIndex();
            this.tbTotalPage.Text = totalPage.ToString();
        }

        private void btnFirst_Click(object sender, RoutedEventArgs e)
        {
            if (currentPageIndex != 0)
            {
                currentPageIndex = 0;
                
            }
            BindProductListView();
        }

        private void btnPrev_Click(object sender, RoutedEventArgs e)
        {
            if (currentPageIndex > 0)
            {
                currentPageIndex--;
                
            }
            BindProductListView();
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            
            if (currentPageIndex < totalPage - 1)
            {
                currentPageIndex++;
                
            }
            BindProductListView();
        }

        private void btnLast_Click(object sender, RoutedEventArgs e)
        {
            
            if (currentPageIndex != totalPage - 1)
            {
                currentPageIndex = totalPage - 1;
                
            }
            BindProductListView();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            currentPageIndex = 0;
            totalPage = -1;
            BindProductListView();
        }

        void lvProduct_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = ((FrameworkElement)e.OriginalSource).DataContext as Product;
            if (item != null)
            {
                var detailProductWindow = (Detail)DetailWindowSingleton.GetInstance();
                detailProductWindow.BindProductDetail(item.Link);
                detailProductWindow.Show();
            }
        }
    }
}
