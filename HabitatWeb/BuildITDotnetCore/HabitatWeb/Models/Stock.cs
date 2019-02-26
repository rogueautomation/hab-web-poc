using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace HabitatWeb.Models
{
    public class Stock
    {
        [DisplayName("ID")]
        public int id { get; set; }

        [DisplayName("Market")]
        public string stockMarket { get; set; }

        [DisplayName("Stock Name")]
        public string stockName { get; set; }

        [DisplayName("Symbol")]
        public string stockSymbol { get; set; }

        [DisplayName("Price")]
        public string price { get; set; }
    }
}
