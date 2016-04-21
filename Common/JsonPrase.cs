using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFormMarkDown.Common
{
    public class JsonPrase
    {
        public static string PraseToJson(string str)
        {
            var tabIndex = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (i == 120)
                {
                    int sdfa = 0;
                }
                var cr = str[i];

                if (cr == '{' || cr == '[')
                {
                    var prestr = str.Substring(0, i);
                    var strsuff = str.Substring(i + 1, str.Length - i - 1);
                    var center = "\r\n" + getSpace(tabIndex + 1);
                    str = prestr + cr + center + strsuff;

                    i += (1 + center.Length);
                    tabIndex++;
                }
                else if (cr == '}' || cr == ']')
                {

                    var prestr = str.Substring(0, i);
                    var strsuff = str.Substring(i + 1, str.Length - i - 1);
                    var center = "\r\n" + getSpace(tabIndex + 1);
                    str = prestr + center + cr + strsuff;
                    i += (1 + center.Length);
                    tabIndex--;
                }
                else if (cr == ',')
                {
                    var prestr = str.Substring(0, i + 1);
                    var strsuff = str.Substring(i + 1, str.Length - i - 1);
                    var center = "\r\n" + getSpace(tabIndex);
                    str = prestr +  center + strsuff;
                    i += (1 + center.Length);
                }
            }

            return str.Trim();
        }

        private static string getSpace(int num)
        {
            string result = string.Empty;
            for (int i = 0; i < num; i++)
            {
                result += "    ";
            }
            return result;
        }
    }
}
