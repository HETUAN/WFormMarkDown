using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFormMarkDown.Common
{
    public class MarkDownHelper
    {
        public static string ConvertToHtml(string mdStr)
        {
            try
            {
                MarkdownSharp.Markdown mds = new MarkdownSharp.Markdown();
                return mds.Transform(mdStr);
            }
            catch (Exception ex)
            {
                return "Convert MarkDown To HTML Faile!";
            }
        }
    }
}
