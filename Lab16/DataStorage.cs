using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Lab16
{
    class DataStorage
    {
        public bool isReady
        {
            get
            {
                if (rawData == null) return false;
                else return true;
            }
        }
        public List<RawDataItem> rawData;
        public List<AverageDataItem> averageData;
        private char devider = '/';
        private DataStorage() { }
        private void BuildAverage()
        {
            //Dictionary<int, float> Shops = new Dictionary<int, float>();
            List<AverageDataItem> markets = new List<AverageDataItem>();
            foreach (RawDataItem rawDataItem in rawData)
            {
                if (!markets.Exists(m => m.MarketName == rawDataItem.Market))
                    markets.Add(new AverageDataItem(rawDataItem.Market));
            }
            foreach (RawDataItem rawDataItem in rawData)
            {
                foreach(AverageDataItem market in markets)
                {
                    if (rawDataItem.Market == market.MarketName)
                    {
                        market.CountProducts += rawDataItem.Count;
                        market.CountUnicProducts++;
                        market.SumPrices += rawDataItem.Price;
                    }
                }
            }
            foreach (AverageDataItem market in markets)
            {
                market.AveragePrice = market.SumPrices / market.CountUnicProducts;
            }
            averageData = markets;
            /*foreach (var item in rawData)
            {
                if (tmp.ContainsKey(item.Market))
                    tmp[item.Market] += item.Price;
                else
                    tmp[item.Market] = item.Price;
            }

            averageData = new List<AverageDataItem>();
            foreach (var item in averageData)
            {
                if (averageData.Exists(i => i.MarketName == item.MarketName))
                    item.CountProducts += rawData

                averageData.Add(new AverageDataItem() {
                    MarketName = Utils.GetGroupByNumber(item.Key),
                    CountProducts +=
                    AveragePrice = item.Value,
                });
            }*/
        }

        private bool InitData(string datapath)
        {
            rawData = new List<RawDataItem>();

            try
            {
                StreamReader sr = new StreamReader(datapath, Encoding.Default);
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] items = line.Split(devider);

                    RawDataItem item = new RawDataItem();
                    item.Name = items[0];
                    item.Price = Convert.ToSingle(items[1]);
                    item.Count = Convert.ToInt32(items[2]);
                    item.Market = items[3];
                    item.SumPrice = item.Price * item.Count;
                    rawData.Add(item);
                }

                sr.Close();
                BuildAverage();
            } catch (IOException ex) { return false; }

            return true;
        }

        public static DataStorage DataCreator(string path)
        {
            DataStorage d = new DataStorage();
            if (d.InitData(path))
                return d;
            else return null;
        }

        public List<RawDataItem> GetRawData()
        {
            if (this.isReady)
                return rawData;
            else
                return null;
        }

        public List<AverageDataItem> GetSummaryData()
        {
            if (this.isReady)
                return averageData;
            else return null;
        }
    }
}
