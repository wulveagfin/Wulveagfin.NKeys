using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Wulveagfin.NKeys
{
    public partial class Generator
    {
        public void Start()
        {
            int maxNode = 26 * 2 + 1;

            StoreGenericCharLowerPlural[0] = "as1";

            for (int n = 0; n <= maxNode + 1; n++)
            {
                this.GenericCharLowerPlural(n);
            }

            for (int node = 2; node < maxNode; node++)
            {
                this.GenerateCubes(node);
            }

            this.GenerateUnitTests(15);
        }

        private void GenerateCubes(int maxNode)
        {
            List<string> lines = new List<string>();

            this.MultiKeyValueHeaders(maxNode, ref lines);
            this.MultiKeyValueDeclaration(maxNode, ref lines);
            this.MultiKeyValueToString(maxNode, ref lines);
            this.MultiKeyValueCloser(ref lines);

            this.CubeHeaders(maxNode, ref lines);
            this.CubeAny(maxNode, ref lines);
            this.CubeCounts(maxNode, ref lines);
            this.DexedProperty(maxNode, ref lines);
            this.CubeGet(maxNode, ref lines);
            this.CubeTryGetValue(maxNode, ref lines);
            this.CubeClear(maxNode, ref lines);
            this.CubeAdd(maxNode, ref lines);
            this.CubeDelete(maxNode, ref lines);
            this.CubeRemove(maxNode, ref lines);
            this.CubeContainsKey(maxNode, ref lines);
            this.CubeUpsert(maxNode, ref lines);
            this.CubeFaces(maxNode, ref lines);

            lines.Add("}", 1);
            lines.Add("}", 0);

            string file = $@"C:\Code\Wulveagfin.NKeys\Wulveagfin.NKeyHash\NKeyHash{maxNode}.cs";
            //string file = $@"e:\Wulveagfin.NKeys\Wulveagfin.NKeyHash\NKeyHash{maxNode}.cs";
            using (StreamWriter sw = new StreamWriter(file))
            {
                foreach (string ln in lines)
                {
                    sw.WriteLine(ln);
                }
            }

            // System.IO.File.Copy(
        }

        private string GenericCharLower(int forN)
        {
            string s = GenericCharUpper(forN).ToLower();
            switch (s)
            {
                case "as": s = "o1"; break;
                case "is": s = "o3"; break;
                case "val": s = "o5"; break;
            }
            return s;
        }

        //A 1, B 2, C 3
        private Dictionary<int, string> StoreGenericCharUpper = new Dictionary<int, string>();
        private string GenericCharUpper(int forN)
        {
            string s;
            if (StoreGenericCharUpper.TryGetValue(forN, out s))
                return s;

            /*if (forN == 0)
            {
                s = "A";
                StoreGenericCharUpper[forN] = s;
                return s;
            }*/

            int n = forN;
            StringBuilder chr = new StringBuilder(forN % 26);
            char c;

            if (forN < 26)
            {
                c = (char)(n % 26 + 65);
                chr.Append(c);
            }
            else
            {
                do
                {
                    c = (char)(n % 26 + 65);
                    if (n < 26) c--;
                    chr.Append(c);
                    n = n / 26;
                }
                while (n > 0);
            }

            s = chr.ToString().ReverseString();
            Debug.WriteLine(forN.ToString() + " " + s);
            StoreGenericCharUpper[forN] = s;
            return s;
        }

        //A 1, B 2, C 3
        private Dictionary<int, string> StoreGenericCharLowerPlural = new Dictionary<int, string>();
        private string GenericCharLowerPlural(int forN)
        {
            string s;
            if (StoreGenericCharLowerPlural.TryGetValue(forN, out s))
                return s;

            s = $"{this.GenericCharLower(forN)}sA1l";

            StoreGenericCharLowerPlural[forN] = s;
            return s;
        }

        private NKeyHash<int, int, bool, string> StoreCubeXCubeYCubeZValue = new NKeyHash<int, int, bool, string>();
        //NKeyHash<X, NKeyHash<Y, NKeyHash<Z, VALUE>>>>
        //NKeyHash<A, NKeyHash<B, NKeyHash<C, NKeyHash<D, NKeyHash<, VALUE>>>> Values
        private string CubeXCubeYCubeZValue(int maxNode, int skipFirstFew, bool useMultiKeyValue)
        {
            string s;
            if (StoreCubeXCubeYCubeZValue.TryGetValue(maxNode, skipFirstFew, useMultiKeyValue, out s))
                return s;

            StringBuilder line2 = new StringBuilder(100);

            if (!useMultiKeyValue)
                line2.Append(" NKeyHash<");
            else
                line2.Append(" NKeyValue<");

            for (int n = skipFirstFew; n < maxNode; n++)
            {
                line2.Append(GenericCharUpper(n));

                if (n != maxNode - 1)
                {
                    if (!useMultiKeyValue)
                        line2.Append(", NKeyHash<");
                    else
                        line2.Append(", NKeyValue<");
                }
            }
            line2.Append(", VALUE");
            for (int n = skipFirstFew; n < maxNode; n++)
                line2.Append('>');

            s = line2.ToString();
            StoreCubeXCubeYCubeZValue[maxNode, skipFirstFew, useMultiKeyValue] = s;
            return s;
        }

        //<X, Y, Z, VALUE>
        private Dictionary<int, string> StoreXYZValue = new Dictionary<int, string>();
        private string XYZValue(int maxNode)
        {
            string s;
            if (StoreXYZValue.TryGetValue(maxNode, out s))
                return s;

            //<X, Y, Z, VALUE>
            StringBuilder line = new StringBuilder(100);
            line.Append("<");
            for (int n = 0; n < maxNode; n++)
            {
                line.Append(GenericCharUpper(n));
                line.Append(", ");
            }
            line.Append("VALUE>");

            s = line.ToString();
            StoreXYZValue[maxNode] = s;
            return s;
        }

        private Dictionary<int, string> StoreXxYyZz = new Dictionary<int, string>();
        //X x, Y y, Z z
        private string XxYyZz(int maxNode)
        {
            string s;
            if (StoreXxYyZz.TryGetValue(maxNode, out s))
                return s;

            StringBuilder line = new StringBuilder(10);
            for (int n = 0; n < maxNode; n++)
            {
                line.Append(this.GenericCharUpper(n));
                line.Append(' ');
                line.Append(this.GenericCharLower(n));

                if (n != maxNode - 1)
                    line.Append(", ");
            }

            s = line.ToString();
            StoreXxYyZz[maxNode] = s;
            return s;
        }

        private Dictionary<int, string> Storexyz = new Dictionary<int, string>();
        // x, y, z
        private string xyz(int maxNode)
        {
            string s;
            if (Storexyz.TryGetValue(maxNode, out s))
                return s;

            StringBuilder line = new StringBuilder(10);
            for (int n = 0; n < maxNode; n++)
            {
                line.Append(this.GenericCharLower(n));

                if (n != maxNode - 1)
                    line.Append(", ");
            }

            s = line.ToString();
            Storexyz[maxNode] = s;
            return s;
        }

        private void CubeFaces(int maxNode, ref List<string> lines)
        {
            lines.Add("");
            this.AddSummary(ref lines, SummaryDispose, null, null, 2);
            lines.Add("public void Dispose()", 2);
            lines.Add("{", 2);
            lines.Add("this.Values = null;", 3);
            lines.Add("}", 2);
            lines.Add("");


            lines.Add("");
            this.AddSummary(ref lines, SummaryEnumerator, null, null, 2);
            lines.Add("IEnumerator IEnumerable.GetEnumerator()", 2);
            lines.Add("{", 2);
            lines.Add("return GetEnumerator();", 3);
            lines.Add("}", 2);


            StringBuilder line = new StringBuilder();

            lines.Add("");
            this.AddSummary(ref lines, SummaryEnumerator, null, null, 2);
            lines.Add($"public IEnumerator<NKeyValue{XYZValue(maxNode)}> GetEnumerator()", 2);
            lines.Add("{", 2);

            int dent = 2;
            bool first = true;
            for (int n = 0; n < maxNode; n++)
            {
                line = new StringBuilder();
                line.Append("foreach (NKeyValue<");
                line.Append(this.CubeXCubeYCubeZValue(maxNode, n, false).Remove(0, 10));
                line.Append(" ");
                line.Append(this.GenericCharLower(n));
                line.Append(" in ");

                if (first)
                {
                    first = false;
                    line.Append(" this.Values");
                }
                else
                {
                    line.Append(this.GenericCharLower(n - 1));
                    line.Append(".Value");
                }
                line.Append(")");
                lines.Add(line, ++dent);

                lines.Add("{", dent);
            }

            /*
             private IEnumerator<NKeyValue<A, B, C, VALUE>> GetEnumerator()
            {
                foreach (NKeyValue<A, NKeyHash<B, NKeyHash<C, VALUE>>> a in Values)
                {
                    foreach (NKeyValue<B, NKeyHash<C, VALUE>> b in a.Value)
                    {
                        foreach (NKeyValue<C, VALUE> c in b.Value)
                        {
                            yield return new NKeyValue<A, B, C, VALUE>(a.Key, b.Key, c.Key, c.Value);
                        }
                    }
                }
            }
            
            
             private IEnumerator<NKeyValue<A, B, VALUE>> GetEnumerator()
            */



            //yield return new NKeyValue<X, Y, Z, VALUE>(x.Key, y.Key, z.Key, z.Value);
            //yield return new NKeyValue<A, NKeyValue<B, VALUE>>(a.Key, b.Key, z.Value);
            line = new StringBuilder();
            line.Append("yield return new NKeyValue");
            line.Append(this.XYZValue(maxNode));
            line.Append("(");

            for (int n = 0; n < maxNode; n++)
            {
                line.Append(this.GenericCharLower(n));
                line.Append(".Key, ");
            }

            line.Append(this.GenericCharLower(maxNode - 1));
            line.Append(".Value);");

            lines.Add(line, ++dent);


            for (int n = 0; n < maxNode + 1; n++)
            {
                lines.Add("}", --dent);
            }

            lines.Add("");

        }

        private void CubeCounts(int maxNode, ref List<string> lines)
        {
            StringBuilder line = new StringBuilder(100);

            /*
            private int Count(X x)
            {
                if (this.Values.ContainsKey(x))
                    return this.Values[x].Count;
                return 0;
            }
            
            private int Count(X x, Y y)
            {
                NKeyHash<Y, NKeyHash<Z, VALUE>> ys;
                if (this.Values.TryGetValue(x, out ys))
                {
                    NKeyHash<Z, VALUE> zs;
                    if (ys.TryGetValue(y, out zs))
                    {
                        return zs.Count;
                    }
                }
                return 0;
            }

            private int Count()
            {
                return this.Values.Count;
            }
            */


            for (int newMax = maxNode; newMax > 1; newMax--)
            {
                this.AddSummary(ref lines, SummaryCount, SummaryCountReturns, this.AddSummaryKeyValueParams(newMax - 1, false, false), 2);

                line = new StringBuilder(100);
                line.Append("public int Count(");
                line.Append(this.XxYyZz(newMax - 1));
                line.Append(")");
                lines.Add(line, 2);
                lines.Add("{", 2);




                int dent = 2;
                bool first = true;
                for (int n = 0; n < newMax - 1; n++)
                {
                    dent++;
                    lines.Add($"{this.CubeXCubeYCubeZValue(maxNode, n + 1, false).Substring(1)} {this.GenericCharLowerPlural(n + 1)};", dent);

                    line = new StringBuilder();
                    line.Append("if (");

                    if (first)
                    {
                        first = false;
                        line.Append("this.Values");
                    }
                    else
                    {
                        line.Append(this.GenericCharLowerPlural(n));
                    }

                    line.Append(".TryGetValue(");
                    line.Append(this.GenericCharLower(n));
                    line.Append(", out ");
                    line.Append(this.GenericCharLowerPlural(n + 1));
                    line.Append("))");
                    lines.Add(line, dent);

                    lines.Add("{", dent);
                }

                /*
                VALUE d;
                if (zs.TryGetValue(z, out d))
                {
                    exists = true;
                    return d;
                }
                */
                if (newMax - 1 > 0)
                {
                    dent++;
                    lines.Add($"return {this.GenericCharLowerPlural(newMax - 1)}.Count;", dent);
                    dent--;
                }


                for (int n = 0; n < newMax - 1; n++)
                {
                    lines.Add("}", dent);
                    dent--;
                }

                //return defaultData;
                lines.Add("return 0;", 3);
                lines.Add("}", 2);
                lines.Add("");
            }

        }

        private void CubeAdd(int maxNode, ref List<string> lines)
        {
            /*
             private void Add(X x, Y y, Z z, VALUE val)
            {
                this.Upsert(false, x, y, z, d);
            }
            */
            StringBuilder line = new StringBuilder(100);
            this.AddSummary(ref lines, SummaryCreate, null, this.AddSummaryKeyValueParams(maxNode, false, true), 2);
            line.Append("public void Add(");
            line.Append(this.XxYyZz(maxNode));
            line.Append(", VALUE val)");
            lines.Add(line, 2);

            lines.Add("{", 2);

            line = new StringBuilder();
            line.Append("this.Upsert(false, ");
            line.Append(this.xyz(maxNode));
            line.Append(", val);");
            lines.Add(line, 3);

            lines.Add("}", 2);
            lines.Add("");
        }

        private void CubeUpsert(int maxNode, ref List<string> lines)
        {
            /*
             private void Upsert(X x, Y y, Z z, VALUE val)
            {
                this.Upsert(true, x, y, z, d);
            }
            */

            this.AddSummary(ref lines, SummaryUpsert, null, this.AddSummaryKeyValueParams(maxNode, false, true), 2);
            lines.Add($"public void Upsert({this.XxYyZz(maxNode)}, VALUE val)", 2);

            lines.Add("{", 2);

            StringBuilder line = new StringBuilder();
            line.Append("this.Upsert(true, ");

            for (int n = 0; n < maxNode; n++)
            {
                line.Append(this.GenericCharLower(n));
                line.Append(", ");
            }

            line.Append(" val);");
            lines.Add(line, 3);

            lines.Add("}", 2);
            lines.Add("");






            /*
             private void Upsert(bool replaceExistingData, X x, Y y, Z z, VALUE val)
            {
                int level = 0;

                
                NKeyHash<Y, NKeyHash<Z, VALUE>> ys = null;
                if (this.Values.TryGetValue(x, out ys))
                {
                    NKeyHash<Z, VALUE> zs = null;
                    if (ys.TryGetValue(y, out zs))
                    {
                        if (zs.ContainsKey(z))
                        {
                            if (replaceExistingData)
                            {
                                zs[z] = d;
                                return;
                            }
                        }
                        else level = 3;
                    }
                    else level = 2;
                }
                else level = 1;

                if (level == 1) { ys = new NKeyHash<Y, NKeyHash<Z, VALUE>>(); this.Values.Add(x, ys); level++; }
                if (level == 2) { zs = new NKeyHash<Z, VALUE>(); ys.Add(y, zs); level++; }
                if (level == 3) { zs.Add(z, d); }
            }
            */








            List<KeyValuePair<string, string>> kvps = new List<KeyValuePair<string, string>>();
            kvps.Add(new KeyValuePair<string, string>("replaceExistingData", SummaryReplaceExistingData));
            kvps.AddRange(this.AddSummaryKeyValueParams(maxNode, false, true));
            this.AddSummary(ref lines, SummaryUpsert, null, kvps, 2);

            lines.Add($"public void Upsert(bool replaceExistingData, {this.XxYyZz(maxNode)}, VALUE val)", 2);

            lines.Add("{", 2);
            lines.Add("int level = 0;", 3);

            line = new StringBuilder(100);
            line.Append(this.CubeXCubeYCubeZValue(maxNode, 0, false));
            line.Append(" ");

            for (int n = 0; n < maxNode - 1; n++)
            {
                line = new StringBuilder();
                line.Append(this.CubeXCubeYCubeZValue(maxNode, n + 1, false).Substring(1));
                line.Append(" ");
                line.Append(this.GenericCharLowerPlural(n + 1));
                line.Append(" = null;");
                lines.Add(line, 3);
            }

            int dent = 3;
            bool first = true;
            for (int n = 0; n < maxNode - 1; n++)
            {
                line = new StringBuilder();
                line.Append("if (");

                if (first)
                {
                    first = false;
                    line.Append("this.Values");
                }
                else
                {
                    line.Append(this.GenericCharLowerPlural(n));
                }

                line.Append(".TryGetValue(");
                line.Append(this.GenericCharLower(n));
                line.Append(", out ");
                line.Append(this.GenericCharLowerPlural(n + 1));
                line.Append("))");
                lines.Add(line, dent);


                lines.Add("{", dent++);
            }




            /*
            if (zs.ContainsKey(z))
            {
                if (replaceExistingData)
                {
                    zs[z] = d;
                    return;
                }
            }
            */
            lines.Add($"if ({GenericCharLowerPlural(maxNode - 1)}.ContainsKey({GenericCharLower(maxNode - 1)}))", dent);
            lines.Add("{", dent);
            lines.Add("if (replaceExistingData)", ++dent);
            lines.Add("{", dent);
            lines.Add($"{GenericCharLowerPlural(maxNode - 1)}[{GenericCharLower(maxNode - 1)}] = val;", ++dent);
            lines.Add("}", --dent);
            lines.Add("return;", dent);
            lines.Add("}", --dent);
            lines.Add($"else level = {maxNode};", dent);






            for (int n = 0; n < maxNode - 1; n++)
            {
                lines.Add("}", --dent);
                lines.Add($"else level = {maxNode - n - 1};", dent);
            }
            lines.Add("");





            /*
            if (level == 1) { xs = new NKeyHash<X, NKeyHash<Y, NKeyHash<Z, VALUE>>>(); this.Values.Add(w, xs); level++; }
            if (level == 2) { ys = new NKeyHash<Y, NKeyHash<Z, VALUE>>(); xs.Add(x, ys); level++; }
            if (level == 3) { zs = new NKeyHash<Z, VALUE>(); ys.Add(y, zs); level++; }
            if (level == 4) { zs.Add(z, d); }
            */
            first = true;
            for (int n = 0; n < maxNode - 1; n++)
            {
                line = new StringBuilder(100);
                line.Append("if (level == ");
                line.Append(n + 1);
                line.Append(") { ");
                line.Append(GenericCharLowerPlural(n + 1));
                line.Append(" = new ");
                line.Append(CubeXCubeYCubeZValue(maxNode, n + 1, false));
                line.Append("(this.UnderlyingHashType); ");

                if (first)
                {
                    first = false;
                    line.Append("this.Values");
                }
                else
                {
                    line.Append(this.GenericCharLowerPlural(n));
                }

                line.Append(".Add(");
                line.Append(this.GenericCharLower(n));
                line.Append(", ");
                line.Append(this.GenericCharLowerPlural(n + 1));
                line.Append("); level++; }");
                lines.Add(line, 3);
            }

            /*line = new StringBuilder();
            line.Append("if (level == ");
            line.Append(maxNode);
            line.Append(" ");
            line.Append(this.GenericCharLowerPlural(maxNode - 1));
            line.Append(".Add(");
            line.Append(this.GenericCharLower(maxNode - 1));
            line.Append(", val); }");*/
            lines.Add($"if (level == {maxNode}) {{{this.GenericCharLowerPlural(maxNode - 1)}.Add({this.GenericCharLower(maxNode - 1)}, val); }}", 3);

            lines.Add("}", 2);
            lines.Add("");

        }

        private void CubeContainsKey(int maxNode, ref List<string> lines)
        {
            StringBuilder line;


            /*
             private bool ContainsKey(W w, X x, Y y, Z z)
            {
                if (this.Values.ContainsKey(w))
                    if (this.Values[w].ContainsKey(x))
                        if (this.Values[w][x].ContainsKey(y))
                            if (this.Values[w][x][y].ContainsKey(z))
                                return true;
                return false;
            }

             private bool ContainsKey(W w, X x, Y y)
            {
                if (this.Values.ContainsKey(w))
                    if (this.Values[w].ContainsKey(x))
                        if (this.Values[w][x].ContainsKey(y))
                            return true;
                return false;
            }

             private bool ContainsKey(W w, X x)
            {
                if (this.Values.ContainsKey(w))
                    if (this.Values[w].ContainsKey(x))
                        return true;
                return false;
            }

             private bool ContainsKey(W w)
            {
                if (this.Values.ContainsKey(w))
                    return true;
                return false;
            }
            */

            for (int n = 1; n <= maxNode; n++)
            {
                line = new StringBuilder();
                this.AddSummary(ref lines, SummaryContainsKey, SummaryAnyReturn, this.AddSummaryKeyValueParams(n, false, false), 2);
                line.Append("public bool ContainsKey(");
                line.Append(this.XxYyZz(n));
                line.Append(")");
                lines.Add(line, 2);

                lines.Add("{", 2);

                int dent = 2;

                for (int c = 0; c < n; c++)
                {
                    line = new StringBuilder();
                    line.Append("if (this.Values");
                    for (int a = 0; a < c; a++)
                    {
                        line.Append("[");
                        line.Append(this.GenericCharLower(a));
                        line.Append("]");
                    }
                    line.Append(".ContainsKey(");
                    line.Append(this.GenericCharLower(c));
                    line.Append("))");
                    lines.Add(line, ++dent);
                }

                lines.Add("return true;", ++dent);
                lines.Add("return false;", 3);
                lines.Add("}", 2);
                lines.Add("");
            }

        }

        private void CubeRemove(int maxNode, ref List<string> lines)
        {
            /*
             private void Remove(X x, Y y, Z z)
            {
                NKeyHash<Y, NKeyHash<Z, VALUE>> ys;
                if (this.Values.TryGetValue(x, out ys))
                {
                    NKeyHash<Z, VALUE> zs;
                    if (ys.TryGetValue(y, out zs))
                    {
                        zs.Remove(z);
                    }
                }
            }
            */

            StringBuilder line = new StringBuilder();
            this.AddSummary(ref lines, SummaryDelete, null, this.AddSummaryKeyValueParams(maxNode, false, false), 2);
            line.Append("public void Remove(");
            line.Append(this.XxYyZz(maxNode));
            line.Append(")");
            lines.Add(line, 2);

            lines.Add("{", 2);

            int dent = 2;
            bool first = true;
            for (int n = 0; n < maxNode - 1; n++)
            {
                dent++;
                line = new StringBuilder();
                line.Append(this.CubeXCubeYCubeZValue(maxNode, n + 1, false));
                line.Append(" ");
                line.Append(this.GenericCharLowerPlural(n + 1));
                line.Append(";");
                lines.Add(line, dent);


                line = new StringBuilder();
                line.Append("if (");

                if (first)
                {
                    first = false;
                    line.Append("this.Values");
                }
                else
                {
                    line.Append(this.GenericCharLowerPlural(n));
                }

                line.Append(".TryGetValue(");
                line.Append(this.GenericCharLower(n));
                line.Append(", out ");
                line.Append(this.GenericCharLowerPlural(n + 1));
                line.Append("))");
                lines.Add(line, dent);


                lines.Add("{", dent);
            }

            dent++;
            //zs.Remove(z);
            line = new StringBuilder(100);
            line.Append(GenericCharLowerPlural(maxNode - 1));
            line.Append(" .Remove(");
            line.Append(GenericCharLower(maxNode - 1));
            line.Append(");");
            lines.Add(line, dent);

            for (int n = 0; n < maxNode - 1; n++)
            {
                dent--;
                lines.Add("}", dent);
            }

            lines.Add("}", 2);
            lines.Add("");
        }

        private void CubeDelete(int maxNode, ref List<string> lines)
        {
            /*
             private void Delete(X x, Y y, Z z)
            {
                this.Remove(x, y, z);
            }
            */

            this.AddSummary(ref lines, SummaryDelete, null, this.AddSummaryKeyValueParams(maxNode, false, false), 2);

            lines.Add($"public void Delete({this.XxYyZz(maxNode)})", 2);
            lines.Add("{", 2);
            lines.Add($"this.Remove({this.xyz(maxNode)});", 3);
            lines.Add("}", 2);
            lines.Add("");
        }

        private void CubeClear(int maxNode, ref List<string> lines)
        {
            /*
             private void Clear()
            {
                this.Values = new NKeyHash<X, NKeyHash<Y, NKeyHash<Z, VALUE>>>();
            }
            */
            this.AddSummary(ref lines, SummaryClear, null, null, 2);
            lines.Add("public void Clear()", 2);
            lines.Add("{", 2);
            lines.Add($"this.Values = new{CubeXCubeYCubeZValue(maxNode, 0, false)}(this.UnderlyingHashType);", 3);
            lines.Add("}", 2);
            lines.Add("");
        }

        private void CubeTryGetValue(int maxNode, ref List<string> lines)
        {
            /*
             private bool TryGetValue(X x, Y y, Z z, out VALUE val)
            {
                bool exist = false;
                val = Get(out exist, default(VALUE), x, y, z);
                return exist;
            }
            */

            StringBuilder line = new StringBuilder(100);
            this.AddSummary(ref lines, SummaryGet, SummaryReturnsValue, this.AddSummaryKeyValueParams(maxNode, false, true), 2);
            line.Append("public bool TryGetValue(");
            line.Append(this.XxYyZz(maxNode));
            line.Append(", out VALUE val)");
            lines.Add(line, 2);
            lines.Add("{", 2);
            lines.Add("bool exist = false;", 3);
            line = new StringBuilder(100);
            line.Append("val = Get(out exist, default(VALUE), ");
            line.Append(this.xyz(maxNode));
            line.Append(");");
            lines.Add(line, 3);
            lines.Add("return exist;", 3);
            lines.Add("}", 2);
            lines.Add("");
        }

        private void CubeGet(int maxNode, ref List<string> lines)
        {
            /*
            private VALUE Get(X x, Y y, Z z)
            {
                return this.Values[x][y][z];
            }
            */

            StringBuilder line = new StringBuilder();
            this.AddSummary(ref lines, SummaryGet, SummaryReturnsValue, this.AddSummaryKeyValueParams(maxNode, false, false), 2);
            line.Append("public VALUE Get(");
            line.Append(this.XxYyZz(maxNode));
            line.Append(")");
            lines.Add(line, 2);
            lines.Add("{", 2);
            line = new StringBuilder();
            line.Append("return this.Values");
            for (int n = 0; n < maxNode; n++)
            {
                line.Append('[');
                line.Append(this.GenericCharLower(n));
                line.Append(']');
            }
            line.Append(";");
            lines.Add(line, 3);
            lines.Add("}", 2);
            lines.Add("");

            /*
             private VALUE Get(out bool exists, VALUE defaultData, W w, X x, Y y, Z z)
            {
                exists = false;
            */
            List<KeyValuePair<string, string>> kvps = new List<KeyValuePair<string, string>>();
            kvps.Add(new KeyValuePair<string, string>("exists", SummaryExists));
            kvps.Add(new KeyValuePair<string, string>("defaultData", SummaryDefaultData));
            kvps.AddRange(this.AddSummaryKeyValueParams(maxNode, false, false));
            this.AddSummary(ref lines, SummaryGet, SummaryReturnsValue, kvps, 2);
            line = new StringBuilder(100);
            line.Append("public VALUE Get(out bool exists, VALUE defaultData, ");
            line.Append(this.XxYyZz(maxNode));
            line.Append(")");
            lines.Add(line, 2);
            lines.Add("{", 2);
            lines.Add("exists = false;", 3);
            lines.Add("");





            /*   1       2       3           1
            NKeyHash<X, NKeyHash<Y, NKeyHash<Z, VALUE>>> xs;
                                    0      1
            if (this.Values.TryGetValue(w, out xs))
            {
                     2       3          2
                NKeyHash<Y, NKeyHash<Z, VALUE>> ys;
                if (xs.TryGetValue(x, out ys))
                {
                         3         3
                    NKeyHash<Z, VALUE> zs;
                    if (ys.TryGetValue(y, out zs))
                    {
            */

            int dent = 2;
            bool first = true;
            for (int n = 0; n < maxNode - 1; n++)
            {
                dent++;
                line = new StringBuilder();
                line.Append(this.CubeXCubeYCubeZValue(maxNode, n + 1, false).Substring(1));
                line.Append(" ");
                line.Append(this.GenericCharLowerPlural(n + 1));
                line.Append(";");
                lines.Add(line, dent);


                line = new StringBuilder();
                line.Append("if (");

                if (first)
                {
                    first = false;
                    line.Append("this.Values");
                }
                else
                {
                    line.Append(this.GenericCharLowerPlural(n));
                }

                line.Append(".TryGetValue(");
                line.Append(this.GenericCharLower(n));
                line.Append(", out ");
                line.Append(this.GenericCharLowerPlural(n + 1));
                line.Append("))");
                lines.Add(line, dent);


                lines.Add("{", dent);
            }

            /*
            VALUE d;
            if (zs.TryGetValue(z, out d))
            {
                exists = true;
                return d;
            }
            */
            dent++;
            lines.Add("VALUE val;", dent);
            line = new StringBuilder(100);
            line.Append("if (");
            line.Append(this.GenericCharLowerPlural(maxNode - 1));
            line.Append(".TryGetValue(");
            line.Append(this.GenericCharLower(maxNode - 1));
            line.Append(", out val))");
            lines.Add(line, dent);
            lines.Add("{", dent);
            dent++;
            lines.Add("exists = true;", dent);
            lines.Add("return val;", dent);
            dent--;
            lines.Add("}", dent);

            for (int n = 0; n < maxNode - 1; n++)
            {
                dent--;
                lines.Add("}", dent);
            }

            //return defaultData;
            lines.Add("return defaultData;", 3);
            lines.Add("}", 2);
            lines.Add("");

        }

        private void DexedProperty(int maxNode, ref List<string> lines)
        {

            /*
             private VALUE this[X x, Y y, Z z]
            {
                get { return Get(x, y, z); }
                set { this.Upsert(true, x, y, z, value); }
            }
            */

            this.AddSummary(ref lines, SummaryGetOrSet, SummaryReturnsValue, this.AddSummaryKeyValueParams(maxNode, false, false), 2);
            StringBuilder line = new StringBuilder(100);
            line.Append("public VALUE this[");
            line.Append(this.XxYyZz(maxNode));
            line.Append(']');
            lines.Add(line, 2);

            lines.Add("{", 2);

            line = new StringBuilder();
            line.Append("get { return Get(");
            for (int n = 0; n < maxNode; n++)
            {
                line.Append(this.GenericCharLower(n));
                if (n != maxNode - 1)
                    line.Append(", ");
            }
            line.Append("); }");
            lines.Add(line, 3);

            line = new StringBuilder();
            line.Append("set { this.Upsert(true, ");
            for (int n = 0; n < maxNode; n++)
            {
                line.Append(this.GenericCharLower(n));
                line.Append(", ");
            }
            line.Append("value); }");
            lines.Add(line, 3);

            lines.Add("}", 2);
            lines.Add("");
        }

        private void CubeAny(int maxNode, ref List<string> lines)
        {
            /*
             private bool Any()
            {
                return this.Values.Any();
            }
            */
            this.AddSummary(ref lines, SummaryAny, SummaryAnyReturn, null, 2);
            lines.Add("public bool Any()", 2);
            lines.Add("{", 2);
            lines.Add("return this.Values.Any();", 3);
            lines.Add("}", 2);
            lines.Add("");
        }

        private void CubeHeaders(int maxNode, ref List<string> lines)
        {
            //public class NKeyHash<X, Y, Z, VALUE> : IDisposable, IEnumerable<NKeyValue<X, Y, Z, VALUE>>
            this.AddSummary(ref lines, SummaryCube, null, null, 1);
            lines.Add($"public class NKeyHash{this.XYZValue(maxNode)} : IDisposable, IEnumerable<NKeyValue{this.XYZValue(maxNode)}>", 1);
            lines.Add("{", 1);

            this.AddSummary(ref lines, SummaryCubeUnderlyingParam, null, null, 2);
            lines.Add("public UnderlyingHashType UnderlyingHashType { get; private set; } = UnderlyingHashType.HashTable;", 2);

            this.AddSummary(ref lines, $"{SummaryCube}", null, new List<KeyValuePair<string, string>>() { new KeyValuePair<string, string>("cubeUnderlyingHashType", SummaryCubeUnderlyingParam) }, 2);
            lines.Add("public NKeyHash(UnderlyingHashType cubeUnderlyingHashType = UnderlyingHashType.Dictionary)", 2);
            lines.Add("{", 2);
            lines.Add("this.UnderlyingHashType = cubeUnderlyingHashType;", 3);
            lines.Add($"this.Values = new{CubeXCubeYCubeZValue(maxNode, 0, false)}(this.UnderlyingHashType);", 3);
            lines.Add("}", 2);

            //private NKeyHash<S, NKeyHash<T, NKeyHash<U, NKeyHash<V, NKeyHash<W, NKeyHash<X, NKeyHash<Y, NKeyHash<Z, VALUE>>>>>>>> Values
            //  = new NKeyHash<S, NKeyHash<T, NKeyHash<U, NKeyHash<V, NKeyHash<W, NKeyHash<X, NKeyHash<Y, NKeyHash<Z, VALUE>>>>>>>>();

            this.AddSummary(ref lines, "Private internal storage object for Values", null, null, 2);
            lines.Add($"private{CubeXCubeYCubeZValue(maxNode, 0, false)} Values;", 2);
            lines.Add("");
        }

        private void MultiKeyValueCloser(ref List<string> lines)
        {
            lines.Add("}", 1);
            lines.Add("");
            lines.Add("");
            lines.Add("");
        }

        private void MultiKeyValueToString(int maxNode, ref List<string> lines)
        {
            /*public override string ToString()
            {
                return $"{Key1} , {Key2} , {Key3} = {Value}";
            }*/

            StringBuilder line = new StringBuilder();
            this.AddSummary(ref lines, SummaryToString, null, null, 2);
            lines.Add("public override string ToString()", 2);
            lines.Add("{", 2);
            line.Append("return $\"");
            for (int n = 0; n < maxNode; n++)
            {
                line.Append("{Key");
                line.Append(n);
                line.Append("}");
                if (n != maxNode)
                    line.Append(", ");
            }
            line.Append("{Value}\";");
            lines.Add(line, 3);
            lines.Add("}", 2);
        }

        private StringBuilder MultiKeyValueDeclaration(int maxNode, ref List<string> lines)
        {
            this.AddSummary(ref lines, SummaryMultiKeyValue, null, null, 2);
            lines.Add("public NKeyValue()", 2);
            lines.Add("{", 2);
            lines.Add("}", 2);
            lines.Add("");

            StringBuilder line = new StringBuilder(100);
            //public NKeyValue(S key1, T key2, U key3, V key4, W key5, X key6, Y key7, Z key8, VALUE val)
            this.AddSummary(ref lines, SummaryMultiKeyValue, null, this.AddSummaryKeyValueParams(maxNode, true, true), 2);
            line.Append("public NKeyValue(");
            for (int n = 0; n < maxNode; n++)
            {
                line.Append(GenericCharUpper(n));
                line.Append(" key");
                line.Append(n);
                line.Append(", ");
            }
            line.Append(" VALUE val)");
            lines.Add(line, 2);

            /*{
                this.Key1 = key1;
                this.Key2 = key2;
                this.Key3 = key3;
                this.Value = val;
            }*/
            lines.Add("{", 2);
            for (int n = 0; n < maxNode; n++)
            {
                line = new StringBuilder(100);
                line.Append("this.Key");
                line.Append(n);
                line.Append(" = key");
                line.Append(n);
                line.Append(";");
                lines.Add(line, 3);
            }
            lines.Add("this.Value = val;", 3);
            lines.Add("}", 2);
            lines.Add("");
            return line;
        }

        private void MultiKeyValueHeaders(int maxNode, ref List<string> lines)
        {
            StringBuilder line;
            /*
            namespace Wulveagfin.NKeys
            {
            */
            lines.Add("namespace Wulveagfin.NKeys", 0);
            lines.Add("{");



            /*
            using System;
            using System.Collections;
            using System.Collections.Generic;
            */

            lines.Add("using System;", 1);
            lines.Add("using System.Collections;", 1);
            lines.Add("using System.Collections.Generic;", 1);

            this.AddSummary(ref lines, SummaryMultiKeyValue, null, null, 1);

            // public class NKeyValue<X, Y, Z, VALUE>
            line = new StringBuilder(100);
            line.Append("public class NKeyValue");
            line.Append(this.XYZValue(maxNode));
            lines.Add(line, 1);

            lines.Add("{", 1);

            //public S Key1 { get; set; }
            for (int n = 0; n < maxNode; n++)
            {
                line = new StringBuilder(100);
                this.AddSummary(ref lines, string.Format(SummaryKeyTemplate, n, GenericCharUpper(n)), null, null, 2);
                line.Append("public ");
                line.Append(GenericCharUpper(n));
                line.Append(" Key");
                line.Append(n);
                line.Append(" { get; set; }");
                lines.Add($"public {GenericCharUpper(n)} Key{n} {{ get; set; }}", 2);
            }

            this.AddSummary(ref lines, SummaryValue, null, null, 2);
            lines.Add("public VALUE Value { get; set; }", 2);

            lines.Add("");
        }

        private const string
            SummaryMultiKeyValue = "NKeyValue contains multiple keys that point to a single object Value. NKeyValue is used to express internal objects within the NKeyHash universe.",
            SummaryCube = "NKeyHash is a IEnumerable-enabled multidimensional array. It can currently use System.Collections.HashTable, System.Collections.Generic.Dictionary, System.Collections.Generic.SortedDictionary, or System.Collections.Concurrent.ConcurrentDictionary for the underlying base hashable object. NKeyHash uses generics to create nested hashable objects.",
            SummaryKeyTemplate = "Key{0} of type {1}, of [key0 key1.... keyN value] pair.",
            SummaryValue = "Value of [key0 key1.... keyN value] pair.",
            SummaryGet = "Gets the value associated with the specified [key0 key1.... keyN value].",
            SummaryGetOrSet = "Gets or Sets the value associated with the specified key.",
            SummaryCount = "Gets the number of [key key...key value] collections contained at the level of the [key0 key1.... keyN] specified.",
            SummaryCountReturns = "Gets the number of [key key...key value] collections contained at the level of the [key0 key1.... keyN] specified.",
            SummaryAny = "Determines whether a sequence contains any elements.",
            SummaryAnyReturn = "true if the source sequence contains any elements; otherwise, false.",
            SummaryCreate = "Adds the value associated with the specified [key0 key1.... keyN].",
            SummaryUpsert = "Upserts the value associated with the specified [key0 key1.... keyN].",
            SummaryDelete = "Deletes the value associated with the specified [key0 key1.... keyN].",
            SummaryDispose = "Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.",
            SummaryClear = "Removes all keys and values.",
            SummaryContainsKey = "Determines if the value associated with the specified [key0 key1.... keyN] exists.",
            SummaryEnumerator = "Returns an enumerator that iterates through the collection.",
            SummaryCopy = "Returns a copy of the underlying base NKeyHash object.  It could possibly be a reference copy depending on the underlying [key0 key1.... keyN] and value objects. If you wish to create a value-copy of the NKeyHash object, then you'll have to write one",
            SummaryDefaultData = "Specify the default for VALUE type you want returned if the [key0 key1.... keyN] is not found.",
            SummaryExists = "Returns if [key key...key value] exists",
            SummaryToString = "Generates a string view of keys and value",
            SummaryReturnsValue = "Returns the VALUE portion of [key0 key1.... keyN value], if it exists, otherwise Default(VALUE) (or if specified the defaultData) is returned.",
            SummaryReplaceExistingData = "Specify if the existing val should be overwritten if the [key0 key1.... keyN value] already exists.",
            SummaryCubeDeclareDefaultsTo = "UnderlyingHashType is defaulted to System.Collections.Generic.Dictionary.",
            SummaryCubeUnderlyingParam = "Used to set what the underlying object that is used to store and access the data.";

        private void AddSummary(ref List<string> lines,
                                string functionDesc,
                                string returns,
                                List<KeyValuePair<string, string>> parames,
                                int dent)
        {
            lines.Add("");

            if (string.IsNullOrWhiteSpace(functionDesc) == false)
            {
                lines.Add("/// <summary>", dent);
                lines.Add($"/// {functionDesc}", dent);
                lines.Add("/// </summary>", dent);
            }

            StringBuilder line = new StringBuilder();
            /*
             * /// <summary>
            /// 
            /// </summary>
            /// <param name="w"></param>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <param name="z"></param>*/

            if (parames != null)
            {
                foreach (KeyValuePair<string, string> parm in parames)
                {
                    line = new StringBuilder();
                    line.Append("/// <param name=\"");
                    line.Append($"{parm.Key}");
                    line.Append("\">");
                    line.Append($"{parm.Value}");
                    line.Append("</param>");
                    lines.Add(line, dent);
                }
            }

            if (string.IsNullOrWhiteSpace(returns) == false)
            {
                lines.Add($"/// <returns>{returns}</returns>", dent);
            }
        }

        private List<KeyValuePair<string, string>> AddSummaryKeyValueParams(int maxNode, bool useKeyHeader, bool alsoVALUE)
        {
            List<KeyValuePair<string, string>> kvps = new List<KeyValuePair<string, string>>(maxNode);
            for (int n = 0; n < maxNode; n++)
            {
                if (useKeyHeader)
                {
                    kvps.Add(new KeyValuePair<string, string>($"key{n}", string.Format(SummaryKeyTemplate, n, GenericCharUpper(n))));
                }
                else
                {
                    kvps.Add(new KeyValuePair<string, string>(GenericCharLower(n), string.Format(SummaryKeyTemplate, n, GenericCharUpper(n))));
                }
            }

            if (alsoVALUE)
            {
                kvps.Add(new KeyValuePair<string, string>("val", SummaryValue));
            }

            return kvps;
        }

    }

}
