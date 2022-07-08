namespace Wulveagfin.Cubes
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class MultiKeyValue<W, X, Y, Z, VALUE>
    {
        /// <summary>
        /// 
        /// </summary>
        public W Key1 { get; set; }
        public X Key2 { get; set; }
        public Y Key3 { get; set; }
        public Z Key4 { get; set; }
        public VALUE Value { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public MultiKeyValue()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key1"></param>
        /// <param name="key2"></param>
        /// <param name="key3"></param>
        /// <param name="key4"></param>
        /// <param name="value"></param>
        public MultiKeyValue( W key1, X key2, Y key3, Z key4, VALUE value)
        {
            this.Key1 = key1;
            this.Key2 = key2;
            this.Key3 = key3;
            this.Key4 = key4;
            this.Value = value;
        }
    }

    public class Cube<W, X, Y, Z, VALUE> : IDisposable, IEnumerable<MultiKeyValue<W, X, Y, Z, VALUE>>
    {
        /// <summary>
        /// 
        /// </summary>
        private Cube<W, Cube<X, Cube<Y, Cube<Z, VALUE>>>> Values
                 = new Cube<W, Cube<X, Cube<Y, Cube<Z, VALUE>>>>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="w"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public VALUE this[W w, X x, Y y, Z z]
        {
            get { return Get(w, x, y, z); }
            set { this.Upsert(true, w, x, y, z, value); }
        }

        public void Dispose()
        {
            this.Values = null;
        }

        public VALUE Get(W w, X x, Y y, Z z)
        {
            bool exists;
            return Get(out exists, default(VALUE), w, x, y, z);
        }

        public bool TryGetValue(W w, X x, Y y, Z z, out VALUE data)
        {
            bool exist = false;
            data = Get(out exist, default(VALUE), w, x, y, z);
            return exist;
        }

        public void Clear()
        {
            this.Values = new Cube<W, Cube<X, Cube<Y, Cube<Z, VALUE>>>>();
        }

        public VALUE Get(out bool exists, VALUE defaultData, W w, X x, Y y, Z z)
        {
            exists = false;
            Cube<X, Cube<Y, Cube<Z, VALUE>>> xs;
            if (this.Values.TryGetValue(w, out xs))
            {
                Cube<Y, Cube<Z, VALUE>> ys;
                if (xs.TryGetValue(x, out ys))
                {
                    Cube<Z, VALUE> zs;
                    if (ys.TryGetValue(y, out zs))
                    {
                        VALUE d;
                        if (zs.TryGetValue(z, out d))
                        {
                            exists = true;
                            return d;
                        }
                    }
                }
            }
            return defaultData;
        }

        public void Delete(W w, X x, Y y, Z z)
        {
            this.Remove(w, x, y, z);
        }

        public void Remove(W w, X x, Y y, Z z)
        {
            Cube<X, Cube<Y, Cube<Z, VALUE>>> xs;
            if (this.Values.TryGetValue(w, out xs))
            {
                Cube<Y, Cube<Z, VALUE>> ys;
                if (xs.TryGetValue(x, out ys))
                {
                    Cube<Z, VALUE> zs;
                    if (ys.TryGetValue(y, out zs))
                    {
                        zs.Remove(z);
                    }
                }
            }
        }

        public bool ContainsKey(W w, X x, Y y, Z z)
        {
            if (this.Values.ContainsKey(w))
                if (this.Values[w].ContainsKey(x))
                    if (this.Values[w][x].ContainsKey(y))
                        if (this.Values[w][x][y].ContainsKey(z))
                            return true;
            return false;
        }

        public bool ContainsKey(W w, X x, Y y)
        {
            if (this.Values.ContainsKey(w))
                if (this.Values[w].ContainsKey(x))
                    if (this.Values[w][x].ContainsKey(y))
                        return true;
            return false;
        }

        public bool ContainsKey(W w, X x)
        {
            if (this.Values.ContainsKey(w))
                if (this.Values[w].ContainsKey(x))
                    return true;
            return false;
        }

        public bool ContainsKey(W w)
        {
            if (this.Values.ContainsKey(w))
                return true;
            return false;
        }

        public void Add(W w, X x, Y y, Z z, VALUE d)
        {
            this.Upsert(false, w, x, y, z, d);
        }

        public void Upsert(bool replaceData, W w, X x, Y y, Z z, VALUE d)
        {
            int level = 0;

            Cube<X, Cube<Y, Cube<Z, VALUE>>> xs = null;
            Cube<Y, Cube<Z, VALUE>> ys = null;
            Cube<Z, VALUE> zs = null;

            if (this.Values.TryGetValue(w, out xs))
            {
                if (xs.TryGetValue(x, out ys))
                {
                    if (ys.TryGetValue(y, out zs))
                    {
                        if (zs.ContainsKey(z))
                        {
                            if (replaceData)
                            {
                                zs[z] = d;
                                return;
                            }
                        }
                        else level = 4;
                    }
                    else level = 3;
                }
                else level = 2;
            }
            else level = 1;

            if (level == 1) { xs = new Cube<X, Cube<Y, Cube<Z, VALUE>>>(); this.Values.Add(w, xs); level++; }
            if (level == 2) { ys = new Cube<Y, Cube<Z, VALUE>>(); xs?.Add(x, ys); level++; }
            if (level == 3) { zs = new Cube<Z, VALUE>(); ys?.Add(y, zs); level++; }
            if (level == 4) { zs?.Add(z, d); }
        }

        public IEnumerator<MultiKeyValue<W, X, Y, Z, VALUE>> GetEnumerator()
        {
            foreach (MultiKeyValue<W, Cube<X, Cube<Y, Cube<Z, VALUE>>>> w in Values)
            {
                foreach (MultiKeyValue<X, Cube<Y, Cube<Z, VALUE>>> x in w.Value)
                {
                    foreach (MultiKeyValue<Y, Cube<Z, VALUE>> y in x.Value)
                    {
                        foreach (MultiKeyValue<Z, VALUE> z in y.Value)
                        {
                            yield return new MultiKeyValue<W, X, Y, Z, VALUE>(w.Key, x.Key, y.Key, z.Key, z.Value);
                        }
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}
