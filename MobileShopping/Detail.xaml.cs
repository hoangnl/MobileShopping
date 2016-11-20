using MobileShopping.Model;
using MobileShopping.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MobileShopping
{
    /// <summary>
    /// Interaction logic for Detail.xaml
    /// </summary>
    public partial class Detail : Window
    {
        private IShoppingService _shoppingService;
        public Detail()
        {
            InitializeComponent();
            this.Closing += new CancelEventHandler(Window_Closing);
            _shoppingService = new ShoppingService();
        }

        public void BindProductDetail(string link)
        {
            ProductDetail item = _shoppingService.GetProductDetail(link);
            rtbDescription.Selection.Text = item.Description;
            txtPrice.Text = item.Price;
            txtProductName.Text = item.ProductName;
            lvSlides.ItemsSource = item.ImageLinkLst;

        }

        public void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
        }


    }
}
