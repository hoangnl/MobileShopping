using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace MobileShopping.Utility
{
    public class DetailWindowSingleton
    {
        private static Detail _instance;

        // Constructor is 'protected'
        protected DetailWindowSingleton()
        {
        }

        public static Detail GetInstance()
        {
            // Uses lazy initialization.
            // Note: this is not thread safe.
            if (_instance == null)
            {
                _instance = new Detail();
            }

            return _instance;
        }
    }

    public class HtmlWebSingleton
    {
        private static HtmlWeb _instance;

        // Constructor is 'protected'
        protected HtmlWebSingleton()
        {
        }

        public static HtmlWeb GetInstance()
        {
            // Uses lazy initialization.
            // Note: this is not thread safe.
            if (_instance == null)
            {
                _instance = new HtmlWeb();
            }

            return _instance;
        }
    }
}
