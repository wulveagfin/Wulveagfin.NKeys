using System;
using System.Collections.Generic;
using System.Text;

namespace Wulveagfin.NKeyHash.Test
{
    public class Class1
    {

		[TestCase(7308, 6302, -6741, 0.131569717606329, -5100, -23, false, 7953, 0.830592497638703, 0.437541370949494)]
		[TestCase(2866, -7369, 9874, 0.322036151458526, -2250, 4228, true, -7655, 0.137531564169345, 0.235212369000172)]
		[TestCase(22, -2693, -2488, 0.142624691660807, -7602, 3029, false, 9592, 0.210581003786335, 0.764550120925787)]
		[TestCase(7254, 1397, 5568, 0.016957281630932, 5285, 1287, true, 7391, 0.950636906992009, 0.297224949718092)]
		[TestCase(-4463, -6066, -4599, 0.540422147857222, 382, -3919, false, -6254, 0.573740696801683, 0.55823364600457)]
		[TestCase(4353, 9094, -2668, 0.718477995935119, -2343, 2, false, -9593, 0.0117293829152963, 0.593440462180153)]
		[TestCase(-372, -3570, 3742, 0.0660423767129157, 1495, -8530, false, 9535, 0.557730464524464, 0.823065972804588)]
		[TestCase(6654, 8278, -6668, 0.840306614451253, 9167, -3910, false, 6702, 0.623514158475918, 0.815831997346055)]
		[TestCase(-3390, 6603, -1880, 0.652347357781766, -9061, 8159, false, -8799, 0.634150943548489, 0.264180241275663)]
		[TestCase(-7502, 7166, 7156, 0.357196444811857, 6316, 9105, true, -5920, 0.965623350797977, 0.445669076147335)]
		public void Get(int a, short b, int c, double d, short e, int f, bool g, int h, double i, double val)
		{
			NKeyHash<int, short, int, double, short, int, bool, int, double, double> nKeyHash = new NKeyHash<int, short, int, double, short, int, bool, int, double, double>(UnderlyingHashType.Dictionary);
			nKeyHash.Add(a, b, c, d, e, f, g, h, i, val);
			Assert.IsTrue(nKeyHash.ContainsKey(a, b, c, d, e, f, g, h, i));

			nKeyHash = new NKeyHash<int, short, int, double, short, int, bool, int, double, double>(UnderlyingHashType.ConcurrentDictionary);
			nKeyHash.Add(a, b, c, d, e, f, g, h, i, val);
			Assert.IsTrue(nKeyHash.ContainsKey(a, b, c, d, e, f, g, h, i));

			nKeyHash = new NKeyHash<int, short, int, double, short, int, bool, int, double, double>(UnderlyingHashType.SortedDictionary);
			nKeyHash.Add(a, b, c, d, e, f, g, h, i, val);
			Assert.IsTrue(nKeyHash.ContainsKey(a, b, c, d, e, f, g, h, i));

			nKeyHash = new NKeyHash<int, short, int, double, short, int, bool, int, double, double>(UnderlyingHashType.HashTable);
			nKeyHash.Add(a, b, c, d, e, f, g, h, i, val);
			Assert.IsTrue(nKeyHash.ContainsKey(a, b, c, d, e, f, g, h, i));
		}

	}
}
