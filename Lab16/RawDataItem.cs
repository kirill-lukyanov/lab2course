using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab16
{
    class RawDataItem
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public int Count { get; set; }
        public string Market { get; set; }
        public float SumPrice { get; set; }

        public RawDataItem(string Name, float Price, int Count, string Market)
        {
            this.Name = Name;
            this.Price = Price;
            this.Count = Count;
            this.Market = Market;
            this.SumPrice = Price * (float)Count;
        }
        public RawDataItem()
        {
        }
    }
}
