using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Wulveagfin.NKeys
{
    public partial class Generator
    {
        private void GenerateUnitTests(int maxNode)
        {
            List<string> lines = new List<string>();

            this.UnitTestSetup(maxNode, ref lines);

            for (int n = 2; n < maxNode; n++)
            {
                this.UnitTestAdd(n, ref lines);
                this.UnitTestUpsert(n, ref lines);
                this.UnitTestDelete(n, ref lines);
                this.UnitTestRemove(n, ref lines);
                this.UnitTestContainsKey(n, ref lines);
                this.UnitTestClear(n, ref lines);
                this.UnitTestGet(n, ref lines);
                this.UnitTestIndexer(n, ref lines);
                this.UnitTestTryGetValue(n, ref lines);
                this.UnitTestCount(n, ref lines);
                this.UnitTestAny(n, ref lines);
                this.UnitTestForloop(n, ref lines);
            }

            lines.Add("}", 1);
            lines.Add("}");

            string file = $@"C:\Code\Wulveagfin.NKeys\Wulveagfin.NKeyHash.Test\UnitTests.cs";
            //string file = $@"E:\Wulveagfin.NKeys\Wulveagfin.NKeyHash.Test\UnitTests.cs";
            using (StreamWriter sw = new StreamWriter(file))
            {
                foreach (string ln in lines)
                {
                    sw.WriteLine(ln);
                }
            }
        }

        private const int TypeMin = 0, TypeMax = 5;
        private enum Types : int
        {
            Bool = 0,
            Shorted = 1,
            Inted = 2,
            Longed = 3,
            Doubled = 4,
            Floated = 5,
        }

        private string TypeToString(Types type)
        {
            switch (type)
            {
                case Types.Bool: return "bool";
                case Types.Shorted: return "short";
                case Types.Inted: return "int";
                case Types.Longed: return "long";
                case Types.Doubled: return "double";
                case Types.Floated: return "float";
            }
            return string.Empty;
        }

        private void UnitTestSetup(int maxNode, ref List<string> lines)
        {
            /*
            [SetUp]
            public void Setup()
            {
            }
            */

            //lines.Add("using System.Collections.Generic;");
            lines.Add("using NUnit.Framework;");
            lines.Add("using Wulveagfin.NKeys;");
            lines.Add("");
            lines.Add("namespace Tests");
            lines.Add("{");
            lines.Add("public partial class UnitTests", 1);
            lines.Add("{", 1);
            lines.Add("[SetUp]", 2);
            lines.Add("public void Setup()", 2);
            lines.Add("{", 2);
            lines.Add("}", 2);
            lines.Add("");
        }

        private string UnitTestNKeyHashDeclare(int maxNode,
                                            List<Types> randTypes,
                                            UnderlyingHashType under,
                                            bool fullDeclare)
        {
            //NKeyHash<short, string, long, float, double> nKeysHash5 = new NKeyHash<short, string, long, float, double>();
            string line = TypesList(maxNode, randTypes);

            if (fullDeclare)
                return $"NKeyHash<{line}> nKeyHash = new NKeyHash<{line}>(UnderlyingHashType.{under});";
            return $"nKeyHash = new NKeyHash<{line}>(UnderlyingHashType.{under});";
        }

        private string TypesList(int maxNode, List<Types> randTypes)
        {
            StringBuilder line = new StringBuilder();

            for (int r = 0; r <= maxNode; r++)
            {
                Types rt = randTypes[r];
                line.Append(this.TypeToString(rt));

                if (r != maxNode)
                    line.Append(", ");
            }

            return line.ToString();
        }

        private List<string> TestHeader(int maxNode,
                                        ref List<string> lines,
                                        string funcationName,
                                        List<Types> randTypes,
                                        int extraTestRandsAdded,
                                        bool useArray)
        {
            for (int c = 0; c < 10; c++)
            {
                lines.Add($"[TestCase({this.GetRandomTestingValues(randTypes, useArray)})]", 2);
            }

            lines.Add($"public void {funcationName}({this.GetRandomCorrectValue(maxNode, randTypes, useArray)})", 2);
            lines.Add("{", 2);
            return lines;
        }

        private List<Types> GetRandomTypes(int maxNode, bool excludeBools)
        {
            List<Types> randTypes = new List<Types>();
            int x;
            for (int r = 0; r < maxNode + 1; r++)
            {
                if (excludeBools == false)
                    x = (int)RandomClusive(TypeMin, TypeMax);
                else
                    x = (int)RandomClusive(TypeMin + 1, TypeMax);
                randTypes.Add((Types)x);
            }
            return randTypes;
        }

        private Types GetRandomType()
        {
            return (Types)RandomClusive(TypeMin, TypeMax);
        }

        private Random Rand = new Random();
        private long RandomClusive(long min, long max)
        {
            double r = Rand.NextDouble();
            //Thread.Sleep(1);
            return (int)((max - min) * r + min);
        }

        private double RandomClusivePoints(double min, double max)
        {
            double r = Rand.NextDouble();
            // Thread.Sleep(1);
            return r;
        }

        private string GetRandomTestingValues(List<Types> randTypes, bool useArray)
        {
            StringBuilder line = new StringBuilder();


            int[] basd = new int[] { 23, 5, 2, 5 };
            string str = string.Empty;


            for (int r = 0; r < randTypes.Count; r++)
            {
                Types rt = randTypes[r];

                if (useArray)
                {
                    StringBuilder str2 = new StringBuilder();

                    for (int x = 1; x <= 10; x++)
                    {
                        switch (rt)
                        {
                            case Types.Bool: str = (RandomClusive(0, 2) >= 1).ToString().ToLower(); break;
                            default:
                            case Types.Shorted: str = RandomClusive(-9999, 9999).ToString(); break;
                            case Types.Inted: str = RandomClusive(-9999, 9999).ToString(); break;
                            case Types.Longed: str = RandomClusive(-9999, 9999).ToString(); break;
                            case Types.Doubled: str = RandomClusivePoints(-9999, 9999).ToString(); break;
                            case Types.Floated: str = RandomClusivePoints(-9999, 9999).ToString(); break;
                        }

                        str2.Append(str);
                        if (x != 10) str2.Append(", ");
                    }

                    str = $"new {this.TypeToString(rt)}[] {{ {str2.ToString()} }}";
                }
                else
                {
                    str = string.Empty;

                    switch (rt)
                    {
                        case Types.Bool: str = (RandomClusive(0, 2) >= 1).ToString().ToLower(); break;
                        case Types.Shorted: str = RandomClusive(-9999, 9999).ToString(); break;
                        case Types.Inted: str = RandomClusive(-9999, 9999).ToString(); break;
                        case Types.Longed: str = RandomClusive(-9999, 9999).ToString(); break;
                        case Types.Doubled: str = RandomClusivePoints(-9999, 9999).ToString(); break;
                        case Types.Floated: str = RandomClusivePoints(-9999, 9999).ToString(); break;
                    }
                }

                line.Append(str);

                if (r != randTypes.Count - 1)
                    line.Append(", ");
            }

            return line.ToString();
        }

        private string GetRandomCorrectValue(int maxNode,
                                            List<Types> randTypes,
                                            bool useArrays)
        {
            StringBuilder line = new StringBuilder();


            int valLoc = maxNode - 0;


            for (int r = 0; r < randTypes.Count; r++)
            {
                Types rt = randTypes[r];
                line.Append(this.TypeToString(rt));
                if (useArrays)
                {
                    line.Append("[]");
                }

                line.Append(" ");

                if (r < valLoc)
                {
                    line.Append(GenericCharLower(r));
                }
                else if (r == valLoc)
                {
                    line.Append("val");
                }
                else
                {
                    line.Append($"newVal{valLoc - r + 2}");
                }

                if (r != randTypes.Count - 1)
                    line.Append(", ");
            }

            return line.ToString();
        }

        private void UnitTestAdd(int maxNode, ref List<string> lines)
        {
            lines.Add("");
            List<Types> randTypes = this.GetRandomTypes(maxNode, false);
            lines = TestHeader(maxNode, ref lines, "Add", randTypes, 0, false);

            /*
            NKeyHash<short, string, long, float, double> NKeyHash = new NKeyHash<short, string, long, float, double>();
            nKeyHash.Add(a, b, c, d, val);
            Assert.AreEqual(val, nKeyHash.Get(a, b, c, d));
            */

            string abcd = this.xyz(maxNode);
            string e = this.GenericCharLower(maxNode);

            for (int u = 0; u <= 3; u++)
            {
                UnderlyingHashType under = (UnderlyingHashType)u;
                lines.Add(this.UnitTestNKeyHashDeclare(maxNode, randTypes, under, u == 0), 3);
                lines.Add($"nKeyHash.Add({abcd}, val);", 3);
                lines.Add($"Assert.AreEqual(val, nKeyHash.Get({abcd}));", 3);
                if (u != 3) lines.Add($"");
            }

            lines.Add("}", 2);
        }

        private void UnitTestUpsert(int maxNode, ref List<string> lines)
        {
            /*
            NKeyHash<bool, int, long> nKeyHash = new NKeyHash<bool, int, long>();
            long newValue = 0;
            nKeyHash.Add(a, b, val);
            nKeyHash.Upsert(a, b, newValue);
            Assert.AreEqual(newValue, nKeyHash.Get(a, b));
            */

            lines.Add("");
            List<Types> randTypes = this.GetRandomTypes(maxNode, false);
            randTypes.Add(randTypes[randTypes.Count - 1]);

            lines = TestHeader(maxNode, ref lines, "Upsert", randTypes, 1, false);

            string abcd = this.xyz(maxNode);

            for (int u = 0; u <= 3; u++)
            {
                UnderlyingHashType under = (UnderlyingHashType)u;
                lines.Add(this.UnitTestNKeyHashDeclare(maxNode, randTypes, under, u == 0), 3);
                lines.Add($"nKeyHash.Add({abcd}, val);", 3);
                lines.Add($"Assert.AreEqual(val, nKeyHash.Get({abcd}));", 3);
                lines.Add($"nKeyHash.Upsert({abcd}, newVal1);", 3);
                lines.Add($"Assert.AreEqual(newVal1, nKeyHash.Get({abcd}));", 3);
                if (u != 3) lines.Add($"");
            }

            lines.Add("}", 2);
        }

        private void UnitTestDelete(int maxNode, ref List<string> lines)
        {
            lines.Add("");
            List<Types> randTypes = this.GetRandomTypes(maxNode, false);
            lines = TestHeader(maxNode, ref lines, "Delete", randTypes, 0, false);

            string abcd = this.xyz(maxNode);

            for (int u = 0; u <= 3; u++)
            {
                UnderlyingHashType under = (UnderlyingHashType)u;
                lines.Add(this.UnitTestNKeyHashDeclare(maxNode, randTypes, under, u == 0), 3);
                lines.Add($"nKeyHash.Add({abcd}, val);", 3);
                lines.Add($"Assert.IsTrue(nKeyHash.ContainsKey({abcd}));", 3);
                lines.Add($"nKeyHash.Delete({abcd});", 3);
                lines.Add($"Assert.IsFalse(nKeyHash.ContainsKey({abcd}));", 3);
                if (u != 3) lines.Add($"");
            }

            lines.Add("}", 2);
        }

        private void UnitTestRemove(int maxNode, ref List<string> lines)
        {
            lines.Add("");
            List<Types> randTypes = this.GetRandomTypes(maxNode, false);
            lines = TestHeader(maxNode, ref lines, "Remove", randTypes, 0, false);

            string abcd = this.xyz(maxNode);

            for (int u = 0; u <= 3; u++)
            {
                UnderlyingHashType under = (UnderlyingHashType)u;
                lines.Add(this.UnitTestNKeyHashDeclare(maxNode, randTypes, under, u == 0), 3);
                lines.Add($"nKeyHash.Add({abcd}, val);", 3);
                lines.Add($"Assert.IsTrue(nKeyHash.ContainsKey({abcd}));", 3);
                lines.Add($"nKeyHash.Remove({abcd});", 3);
                lines.Add($"Assert.IsFalse(nKeyHash.ContainsKey({abcd}));", 3);
                if (u != 3) lines.Add($"");
            }

            lines.Add("}", 2);
        }

        private void UnitTestContainsKey(int maxNode, ref List<string> lines)
        {
            lines.Add("");
            List<Types> randTypes = this.GetRandomTypes(maxNode, false);
            lines = TestHeader(maxNode, ref lines, "ContainsKey", randTypes, 0, false);

            string abcd = this.xyz(maxNode);

            for (int u = 0; u <= 3; u++)
            {
                UnderlyingHashType under = (UnderlyingHashType)u;
                lines.Add(this.UnitTestNKeyHashDeclare(maxNode, randTypes, under, u == 0), 3);
                lines.Add($"nKeyHash.Add({abcd}, val);", 3);
                lines.Add($"Assert.IsTrue(nKeyHash.ContainsKey({abcd}));", 3);
                lines.Add($"nKeyHash.Delete({abcd});", 3);
                lines.Add($"Assert.IsFalse(nKeyHash.ContainsKey({abcd}));", 3);
                if (u != 3) lines.Add($"");
            }

            lines.Add("}", 2);
        }

        private void UnitTestClear(int maxNode, ref List<string> lines)
        {
            lines.Add("");
            List<Types> randTypes = this.GetRandomTypes(maxNode, false);
            lines = TestHeader(maxNode, ref lines, "Clear", randTypes, 0, false);

            string abcd = this.xyz(maxNode);

            for (int u = 0; u <= 3; u++)
            {
                UnderlyingHashType under = (UnderlyingHashType)u;
                lines.Add(this.UnitTestNKeyHashDeclare(maxNode, randTypes, under, u == 0), 3);
                lines.Add($"nKeyHash.Add({abcd}, val);", 3);
                lines.Add($"Assert.IsTrue(nKeyHash.ContainsKey({abcd}));", 3);
                lines.Add($"nKeyHash.Clear();", 3);
                lines.Add($"Assert.IsFalse(nKeyHash.ContainsKey({abcd}));", 3);
                lines.Add($"Assert.AreEqual(nKeyHash.Count({this.xyz(maxNode - 1)}), 0);", 3);
                if (u != 3) lines.Add($"");
            }

            lines.Add("}", 2);
        }

        private void UnitTestIndexer(int maxNode, ref List<string> lines)
        {
        }

        private void UnitTestTryGetValue(int maxNode, ref List<string> lines)
        {
            lines.Add("");
            List<Types> randTypes = this.GetRandomTypes(maxNode, false);
            lines = TestHeader(maxNode, ref lines, "TryGetValue", randTypes, 0, false);

            string abcd = this.xyz(maxNode);

            lines.Add($"{TypeToString(randTypes[randTypes.Count - 1])} fetch;", 3);
            lines.Add("bool b1;", 3);

            for (int u = 0; u <= 3; u++)
            {
                UnderlyingHashType under = (UnderlyingHashType)u;
                lines.Add(this.UnitTestNKeyHashDeclare(maxNode, randTypes, under, u == 0), 3);
                lines.Add($"b1 = nKeyHash.TryGetValue({abcd}, out fetch);", 3);
                lines.Add($"Assert.IsFalse(b1);", 3);
                lines.Add($"Assert.AreEqual(fetch, default({this.TypeToString(randTypes[randTypes.Count - 1])}));", 3);
                lines.Add($"nKeyHash.Add({abcd}, val);", 3);
                lines.Add($"b1 = nKeyHash.TryGetValue({abcd}, out fetch);", 3);
                lines.Add($"Assert.IsTrue(b1);", 3);
                lines.Add($"Assert.AreEqual(fetch, val);", 3);
                if (u != 3) lines.Add($"");
            }

            lines.Add("}", 2);
        }

        private void UnitTestCount(int maxNode, ref List<string> lines)
        {
            lines.Add("");
            List<Types> randTypes = this.GetRandomTypes(maxNode, true);
            lines = TestHeader(maxNode, ref lines, "Count", randTypes, 0, true);

            string abc = this.xyz(maxNode - 1);
            StringBuilder line = new StringBuilder(100);

            for (int u = 0; u <= 3; u++)
            {
                UnderlyingHashType under = (UnderlyingHashType)u;
                lines.Add(this.UnitTestNKeyHashDeclare(maxNode, randTypes, under, u == 0), 3);

                int dent = 3;
                int dex = 0;

                for (int t = 0; t < 9; t++)
                {
                    line = new StringBuilder();
                    line.Append("nKeyHash.Add(");

                    for (int n = 0; n <= maxNode; n++)
                    {
                        if (n == maxNode - 1)
                        {
                            dex = t;
                        }
                        else
                        {
                            dex = 0;
                        }

                        if (n != maxNode)
                        {
                            line.Append($"{this.GenericCharLower(n)}[{dex}],");
                        }
                        else
                        {
                            line.Append($"val[{t}]");
                        }
                    }

                    line.Append(");");
                    lines.Add(line, dent);
                }



                line = new StringBuilder();

                line.Append("Assert.AreEqual(nKeyHash.Count(");
                for (int n = 0; n < maxNode - 1; n++)
                {
                    line.Append($"{this.GenericCharLower(n)}[0]");
                    if (n != maxNode - 2)
                    {
                        line.Append(",");
                    }
                }
                line.Append("), 9);");
                lines.Add(line, dent);





                if (u != 3) lines.Add($"");
            }

            lines.Add("}", 2);
        }

        private void UnitTestGet(int maxNode, ref List<string> lines)
        {
            lines.Add("");
            List<Types> randTypes = this.GetRandomTypes(maxNode, false);
            lines = TestHeader(maxNode, ref lines, "Get", randTypes, 0, false);

            string abcd = this.xyz(maxNode);

            for (int u = 0; u <= 3; u++)
            {
                UnderlyingHashType under = (UnderlyingHashType)u;
                lines.Add(this.UnitTestNKeyHashDeclare(maxNode, randTypes, under, u == 0), 3);
                lines.Add($"nKeyHash.Add({abcd}, val);", 3);
                lines.Add($"Assert.IsTrue(nKeyHash.ContainsKey({abcd}));", 3);
                if (u != 3) lines.Add($"");
            }

            lines.Add("}", 2);
        }

        private void UnitTestAny(int maxNode, ref List<string> lines)
        {
            lines.Add("");
            List<Types> randTypes = this.GetRandomTypes(maxNode, false);
            lines = TestHeader(maxNode, ref lines, "Any", randTypes, 0, true);

            int dent = 3;

            for (int u = 0; u <= 3; u++)
            {
                UnderlyingHashType under = (UnderlyingHashType)u;
                lines.Add(this.UnitTestNKeyHashDeclare(maxNode, randTypes, under, u == 0), 3);
                lines.Add("Assert.IsFalse(nKeyHash.Any());", dent);

                this.ArrayAdds(maxNode, ref lines, dent);

                lines.Add("Assert.IsTrue(nKeyHash.Any());", dent);
                lines.Add("nKeyHash.Clear();", dent);
                lines.Add("Assert.IsFalse(nKeyHash.Any());", dent);

                if (u != 3) lines.Add($"");
            }

            lines.Add("}", 2);
        }

        private void ArrayAdds(int maxNode, ref List<string> lines, int dent)
        {
            for (int t = 0; t < 9; t++)
            {
                ArrayAddRemoveNKeyHash(maxNode, ref lines, dent, t, false);
            }
        }

        private void ArrayAddRemoveNKeyHash(int maxNode, ref List<string> lines, int dent, int t, bool forDelete)
        {
            StringBuilder line = new StringBuilder();
            string action = forDelete ? "Remove" : "Add";
            line.Append($"nKeyHash.{action}(");

            for (int n = 0; n <= maxNode; n++)
            {
                if (n != maxNode)
                {
                    if (n != 0) line.Append(',');

                    line.Append($"{this.GenericCharLower(n)}[{t}]");
                }
                else if(forDelete == false)
                {
                    line.Append($",val[{t}]");
                }
            }

            line.Append(");");
            lines.Add(line, dent);
        }

        private void UnitTestForloop(int maxNode, ref List<string> lines)
        {
            lines.Add("");
            List<Types> randTypes = this.GetRandomTypes(maxNode, true);
            lines = TestHeader(maxNode, ref lines, "Forloop", randTypes, 0, true);

            int dent = 3;
            StringBuilder line;

            string keyTypes = TypesList(maxNode, randTypes);


            lines.Add($"bool[] found = new bool[9];", dent);
            lines.Add("bool allFound = false;", dent);

            for (int u = 0; u <= 3; u++)
            {
                UnderlyingHashType under = (UnderlyingHashType)u;
                lines.Add(this.UnitTestNKeyHashDeclare(maxNode, randTypes, under, u == 0), 3);
                this.ArrayAdds(maxNode, ref lines, dent);

                lines.Add($"", dent);
                lines.Add($"found = new bool[9];", dent);
                lines.Add($"", dent);

                lines.Add($"foreach (NKeyValue<{keyTypes}> mkv in nKeyHash)", dent);
                lines.Add("{", dent++);

                for (int t = 0; t < 9; t++)
                {
                    line = new StringBuilder();
                    line.Append($"if(found[{t}] == false ");

                    for (int n = 0; n < maxNode; n++)
                    {
                        line.Append($" && mkv.Key{n} == {GenericCharLower(n)}[{t}]");
                    }
                    line.Append($" && mkv.Value == val[{t}]");

                    line.Append(")");
                    lines.Add(line, dent);
                    // lines.Add($"if (found[0] == false && mkv.Key0 == a[0] && mkv.Key1 == b[0] && mkv.Key2 == c[0] && mkv.Value == val[0])", dent);

                    lines.Add("{", dent++);
                    lines.Add($"found[{t}] = true;", dent);
                    lines.Add($"continue;", dent);
                    lines.Add("}", --dent);
                    lines.Add($"");
                }

                lines.Add("");
                lines.Add("throw new System.Exception(\"Too many found\");", dent);

                lines.Add("}", --dent);

                lines.Add("");

                line = new StringBuilder();
                line.Append("allFound = ");

                for (int t = 0; t < 9; t++)
                {
                    line.Append($"found[{t}]");
                    if (t != 8)
                    {
                        line.Append(" &&");
                    }
                }
                line.Append(";");
                lines.Add(line, dent);

                lines.Add("Assert.IsTrue(allFound);", dent);
                lines.Add($"", dent);



                ArrayAddRemoveNKeyHash(maxNode, ref lines, dent, 7, true);
                ArrayAddRemoveNKeyHash(maxNode, ref lines, dent, 8, true);
                lines.Add($"", dent);





                lines.Add($"found = new bool[9];", dent);
                lines.Add($"", dent);

                lines.Add($"foreach (NKeyValue<{keyTypes}> mkv in nKeyHash)", dent);
                lines.Add("{", dent++);

                for (int t = 0; t < 7; t++)
                {
                    line = new StringBuilder();
                    line.Append($"if(found[{t}] == false ");

                    for (int n = 0; n < maxNode; n++)
                    {
                        line.Append($" && mkv.Key{n} == {GenericCharLower(n)}[{t}]");
                    }
                    line.Append($" && mkv.Value == val[{t}]");

                    line.Append(")");
                    lines.Add(line, dent);
                    // lines.Add($"if (found[0] == false && mkv.Key0 == a[0] && mkv.Key1 == b[0] && mkv.Key2 == c[0] && mkv.Value == val[0])", dent);

                    lines.Add("{", dent++);
                    lines.Add($"found[{t}] = true;", dent);
                    lines.Add($"continue;", dent);
                    lines.Add("}", --dent);
                    lines.Add($"");
                }

                lines.Add("");
                lines.Add("throw new System.Exception(\"Too many found\");", dent);

                lines.Add("}", --dent);

                lines.Add("");

                line = new StringBuilder();
                line.Append("allFound = ");

                for (int t = 0; t < 7; t++)
                {
                    line.Append($"found[{t}]");
                    if (t != 6)
                    {
                        line.Append(" &&");
                    }
                }
                line.Append(";");
                lines.Add(line, dent);

                lines.Add("Assert.IsTrue(allFound);", dent);




                if (u != 3) lines.Add($"");
            }






            lines.Add("}", 2);
        }

    }
}
