using System.Collections.Generic;
using NUnit.Framework;
using Wulveagfin.NKeys;

namespace Tests
{
    public partial class UnitTestsOG
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(true, 2133697448, -2147483648)]
        public void Add(bool a, int b, long val)
        {
            NKeyHash<bool, int, long> cube = new NKeyHash<bool, int, long>();
            cube.Add(a, b, val);
            Assert.AreEqual(val, cube.Get(a, b));
        }

        [TestCase(true, 2133697448, -2147483648)]
        public void Upsert(bool a, int b, long val)
        {
            NKeyHash<bool, int, long> cube = new NKeyHash<bool, int, long>();
            long newValue = 0;
            cube.Add(a, b, val);
            cube.Upsert(a, b, newValue);
            Assert.AreEqual(newValue, cube.Get(a, b));
        }

        [TestCase(true, 3, 4)]
        public void Delete(bool a, int b, long val)
        {
            NKeyHash<bool, int, long> cube = new NKeyHash<bool, int, long>();
            cube.Add(a, b, val);
            Assert.IsTrue(cube.ContainsKey(a, b));
            cube.Delete(a, b);
            Assert.IsFalse(cube.ContainsKey(a, b));
        }

        [TestCase(1)]
        public void ContainsKey(short a)
        {
        }

        [TestCase(1)]
        public void Clear(short a)
        {
        }

        [TestCase(1)]
        public void Get(short a)
        {
        }

        [TestCase(1)]
        public void GetBadKey(short a)
        {
        }

        [TestCase(1)]
        public void Indexer(short a)
        {
        }

        [TestCase(1)]
        public void IndexerBadKey(short a)
        {
        }

        [TestCase(1)]
        public void TryGetValue(short a)
        {
        }

        [TestCase(1)]
        public void TryGetValueBadKey(short a)
        {
        }

        [TestCase(1)]
        public void Count(short a)
        {
        }

        [TestCase(1)]
        public void Any(short a)
        {
        }

        public struct Expected4
        {
            public long E1 { get; set; }
            public decimal E2 { get; set; }
            public float E3 { get; set; }
            public string E4 { get; set; }
        }


        [Test]
        public void Forloop4()
        {
            List<Expected4> data4 = new List<Expected4>();
            data4.Add(new Expected4 { E1 = 1, E2 = 3, E3 = 5, E4 = "zxcv" });
            data4.Add(new Expected4 { E1 = 5, E2 = 2, E3 = 15, E4 = "asdf" });
            data4.Add(new Expected4 { E1 = 3, E2 = 6, E3 = -5, E4 = "4t6a" });

            NKeyHash<long, decimal, float, string> cube4 = new NKeyHash<long, decimal, float, string>();

            foreach (Expected4 x in data4)
            {
                cube4.Add(x.E1, x.E2, x.E3, x.E4);
            }

            foreach (NKeyValue<long, decimal, float, string> cc4 in cube4)
            {
                Assert.IsTrue(data4.Contains(new Expected4 { E1 = cc4.Key0, E2 = cc4.Key1, E3 = cc4.Key2, E4 = cc4.Value }), "Cube4 does not contain what Data4 contains");
            }

            foreach (Expected4 x in data4)
            {
                Assert.AreEqual(x.E4, cube4.Get(x.E1, x.E2, x.E3), "Data4 does not contain what Cube4 contains");
            }
        }

        [TestCase(new double[] { 0.576994093403683, 0.341832873104994, 0.669684596205915, 0.276992349548727, 0.0812887191219668, 0.124288544582337, 0.745561365850997, 0.0999129293951732, 0.434851829165058, 0.426136370946717 }, new int[] { -4999, -9747, 67, 9659, 761, 8386, -2361, 8248, -2088, -9091 }, new double[] { 0.66290082208016, 0.704363754812797, 0.991474674544984, 0.933242084893045, 0.382661859683069, 0.358262404034968, 0.147021870662934, 0.357896166554604, 0.247843601390647, 0.356518578881639 }, new long[] { 7972, -6534, 7485, 8479, 1660, 8960, -4037, 7804, -5317, -3243 })]
        public void Forloop(double[] a, int[] b, double[] c, long[] val)
        {
            NKeyHash<double, int, double, long> cube = new NKeyHash<double, int, double, long>(UnderlyingHashType.Dictionary);
            cube.Add(a[0], b[0], c[0], val[0]);
            cube.Add(a[1], b[1], c[1], val[1]);
            cube.Add(a[2], b[2], c[2], val[2]);
            cube.Add(a[3], b[3], c[3], val[3]);
            cube.Add(a[4], b[4], c[4], val[4]);
            cube.Add(a[5], b[5], c[5], val[5]);

            bool[] found = new bool[6];

            foreach (NKeyValue<double, int, double, long> mkv in cube)
            {
                if (found[0] == false && mkv.Key0 == a[0] && mkv.Key1 == b[0] && mkv.Key2 == c[0] && mkv.Value == val[0])
                {
                    found[0] = true;
                    continue;
                }

                if (found[1] == false && mkv.Key0 == a[1] && mkv.Key1 == b[1] && mkv.Key2 == c[1] && mkv.Value == val[1])
                {
                    found[1] = true;
                    continue;
                }

                if (found[2] == false && mkv.Key0 == a[2] && mkv.Key1 == b[2] && mkv.Key2 == c[2] && mkv.Value == val[2])
                {
                    found[2] = true;
                    continue;
                }

                if (found[3] == false && mkv.Key0 == a[3] && mkv.Key1 == b[3] && mkv.Key2 == c[3] && mkv.Value == val[3])
                {
                    found[3] = true;
                    continue;
                }

                if (found[4] == false && mkv.Key0 == a[4] && mkv.Key1 == b[4] && mkv.Key2 == c[4] && mkv.Value == val[4])
                {
                    found[4] = true;
                    continue;
                }

                if (found[5] == false && mkv.Key0 == a[5] && mkv.Key1 == b[5] && mkv.Key2 == c[5] && mkv.Value == val[5])
                {
                    found[5] = true;
                    continue;
                }

                throw new System.Exception("Too many found");
            }

            bool allFound = found[0] && found[1] && found[2] && found[3] && found[4] && found[5];
            Assert.IsTrue(allFound);
        }


    }
}