using System.Collections.Generic;
using System.Text;

namespace Wulveagfin.NKeys
{
    public static class Extension
    {
        public static void Add<T>(this List<string> addToMe, T sb)
        {
            addToMe.Add(sb.ToString());
        }

        public static void Add<T>(this List<string> addToMe, T sb, int tabs)
        {
            StringBuilder tabs2 = new StringBuilder(tabs);
            for (int t = 0; t < tabs; t++)
                tabs2.Append('\t');
            addToMe.Add($"{tabs2.ToString()}{sb.ToString()}");
        }

        public static string ReverseString(this string content)
        {
            char[] ary = content.ToCharArray();
            StringBuilder sb = new StringBuilder(content.Length);
            for (int c = ary.Length - 1; c >= 0; c--)
            {
                sb.Append(ary[c]);
            }
            return sb.ToString();
        }

    }

}
