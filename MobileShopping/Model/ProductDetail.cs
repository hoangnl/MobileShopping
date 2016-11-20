using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobileShopping.Model
{
    public class ProductDetail : Product
    {
        public ProductDetail()
        {
            ImageLinkLst = new List<string>();
        }
        public List<string> ImageLinkLst { get; set; }
        public string Description { get; set; }
    }
}
