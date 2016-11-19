using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MobileShopping.Model;
using MobileShopping.Repository;

namespace MobileShopping.Service
{
    public class ShoppingService : IShoppingService
    {
        private IShopRepository _shopRepository;

        public ShoppingService()
        {
            _shopRepository = new HoangHaRepository();
        }

        public List<Product> GetProductListByIndex(string search, int index)
        {
            return _shopRepository.GetProductListByIndex(search, index);
        }

        public int GetTotalProduct(string search)
        {
            return _shopRepository.GetTotalProduct(search);
        }

        public ProductDetail GetProductDetail(string link)
        {
            return _shopRepository.GetProductDetail(link);
        }
    }
}
