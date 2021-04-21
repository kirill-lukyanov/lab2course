using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab16
{
    class Utils
    {
        private static Dictionary<int, string> dict;
        static Utils()
        {
            if (dict == null)
            {
                dict = new Dictionary<int, string>(5);
                dict.Add(0, "Товар");
                dict.Add(1, "Цена");
                dict.Add(2, "Количество");
                dict.Add(3, "Магазин");
            }
        }

        public static string GetGroupByNumber(int number)
        {
            if (dict.ContainsKey(number))
                return dict[number];
            else
                return "???";
        }
    }
}
