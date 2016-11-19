using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MobileShopping.Model;
using HtmlAgilityPack;
using Fizzler.Systems.HtmlAgilityPack;
using MobileShopping.Utility;

namespace MobileShopping.Repository
{
    public class HoangHaRepository : IShopRepository
    {
        private string baseLink = "https://hoanghamobile.com";
        private HtmlWeb _web;

        public HoangHaRepository()
        {
            _web = new HtmlWeb();
        }

        public ProductDetail GetProductDetail(string link)
        {
            HtmlDocument document = _web.Load(baseLink + link);
            var detail = document.DocumentNode.QuerySelector(".product-details");
            var product = new ProductDetail();
            product.Description = HtmlEntity.DeEntitize(detail.QuerySelector(".info .simple-prop").InnerHtml.RemoveHtmlTag());
            product.ProductName = detail.QuerySelector("h1").InnerText;
            product.Price = detail.QuerySelector(".product-price span").InnerText;
            product.Thumbnail = detail.QuerySelectorAll("#slider1_container > div > div > div:nth-child(3) img:first-child")!= null ? detail.QuerySelectorAll("#slider1_container > div > div > div:nth-child(3) img:first-child").ToList().FirstOrDefault().Attributes["src"].Value : string.Empty; 
            return product;
        }

        public List<Product> GetProductListByIndex(string search = "", int index = 1)
        {
            List<Product> items = new List<Product>();
            HtmlDocument document = null;
            if (String.IsNullOrEmpty(search))
            {
                document = _web.Load(baseLink + "/dien-thoai-di-dong-c14.html" + "?p=" + index);
            }
            else
            {
                document = _web.Load(baseLink + "/tim-kiem.html?p=" + index + "&kwd=" + search);
            }
            var threadItems = document.DocumentNode.QuerySelectorAll(".list-item").ToList();

            foreach (var item in threadItems)
            {
                var productName = HtmlEntity.DeEntitize(item.QuerySelector(".product-name a").InnerText);
                var price = item.QuerySelector(".product-price").InnerText;
                var image = item.QuerySelector(".mosaic-block .mosaic-backdrop img").Attributes["src"].Value;
                var path = item.QuerySelector(".mosaic-block > a").Attributes["href"].Value;
                items.Add(new Product()
                {
                    ProductName = productName,
                    Price = price,
                    Thumbnail = image,
                    Link = path
                });
            }
            return items;
        }

        public int GetTotalProduct(string search)
        {
            HtmlDocument document = null;
            if (String.IsNullOrEmpty(search))
            {
                document = _web.Load(baseLink + "/dien-thoai-di-dong-c14.html");
            }
            else
            {
                document = _web.Load(baseLink + "/tim-kiem.html?kwd=" + search);
            }
            if (document.DocumentNode.QuerySelectorAll(".pageing-container .paging a").Count() != 0)
            {
                var link = document.DocumentNode.QuerySelectorAll(".pageing-container .paging a").Last().Attributes["href"].Value;
                var total = link.Substring(link.LastIndexOf("=") + 1);
                return Convert.ToInt32(total);
            }
            return 1;
        }
    }
}
