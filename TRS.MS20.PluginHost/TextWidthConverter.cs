using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace TRS.MS20.PluginHost
{
    public static class TextWidthConverter
    {
        public static string ToWide(this string source) => Strings.StrConv(source, VbStrConv.Wide);
        public static string ToNarrow(this string source) => Strings.StrConv(source, VbStrConv.Narrow);
    }
}
