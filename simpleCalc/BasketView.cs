using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace simpleCalc
{
    public class BasketView:Product
    {
        public int Count { get; set; }
        public decimal Total { get; set; }

        public BasketView()
        {
        }
    }
}
