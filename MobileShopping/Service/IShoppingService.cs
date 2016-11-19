using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MobileShopping.Model;

namespace MobileShopping.Service
{
    public interface IShoppingService
    {
        List<Product> GetProductListByIndex(string search, int index);
        int GetTotalProduct(string search);
        ProductDetail GetProductDetail(string link);
    }
}
