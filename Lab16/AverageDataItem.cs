using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab16
{
    class AverageDataItem
    {
        public string MarketName { get; set; }
        public int CountProducts { get; set; }
        public float AveragePrice { get; set; }
        public float SumPrices { get; set; }
        public float CountUnicProducts { get; set; }

        public AverageDataItem(string MarketName, int CountProducts, float AveragePrice)
        {
            this.MarketName = MarketName;

            this.CountProducts = CountProducts;
            this.AveragePrice = AveragePrice;
        }
        public AverageDataItem(string MarketName)
        {
            this.MarketName = MarketName;

  
        }
        public void CalculateAverage()
        {
            AveragePrice = SumPrices / CountProducts;
        }
    }
}
