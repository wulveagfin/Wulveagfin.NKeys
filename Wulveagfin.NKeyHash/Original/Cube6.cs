namespace Wulveagfin.Cubes
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class MultiKeyValue< V, W, X, Y, Z, VALUE>
    {
        public V Key1 { get; set; }
        public W Key2 { get; set; }
        public X Key3 { get; set; }
        public Y Key4 { get; set; }
        public Z Key5 { get; set; }
        public VALUE Value { get; set; }

        public MultiKeyValue()
        {
        }

        public MultiKeyValue(V key1, W key2, X key3, Y key4, Z key5, VALUE value)
        {
            this.Key1 = key1;
            this.Key2 = key2;
            this.Key3 = key3;
            this.Key4 = key4;
            this.Key5 = key5;
            this.Value = value;
        }
    }

    public class Cube<V, W, X, Y, Z, VALUE> : IDisposable, IEnumerable<MultiKeyValue<V, W, X, Y, Z, VALUE>>
    {
        private Cube<V, Cube<W, Cube<X, Cube<Y, Cube<Z, VALUE>>>>> Values
                 = new Cube<V, Cube<W, Cube<X, Cube<Y, Cube<Z, VALUE>>>>>();

        public void Dispose()
        {
            this.Values = null;
        }

        public void Clear()
        {
            this.Values = new Cube<V, Cube<W, Cube<X, Cube<Y, Cube<Z, VALUE>>>>>();
        }

        public VALUE this[V v, W w, X x, Y y, Z z]
        {
            get { return Get(v, w, x, y, z); }
            set { this.Upsert(true, v, w, x, y, z, value); }
        }

        public VALUE Get(V v, W w, X x, Y y, Z z)
        {
            bool exist;
            return Get(out exist, default(VALUE), v, w, x, y, z);
        }

        public bool TryGetValue(V v, W w, X x, Y y, Z z, out VALUE data)
        {
            bool exist = false;
            data = Get(out exist, default(VALUE), v, w, x, y, z);
            return exist;
        }

        public VALUE Get(out bool exists, VALUE defaultData, V v, W w, X x, Y y, Z z)
        {
            exists = false;
            Cube<W, Cube<X, Cube<Y, Cube<Z, VALUE>>>> ws;
            if (this.Values.TryGetValue(v, out ws))
            {
                Cube<X, Cube<Y, Cube<Z, VALUE>>> xs;
                if (ws.TryGetValue(w, out xs))
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
            }
            return defaultData;
        }

        public void Delete(V v, W w, X x, Y y, Z z)
        {
            this.Remove(v, w, x, y, z);
        }

        public void Remove(V v, W w, X x, Y y, Z z)
        {
            if (this.Values.ContainsKey(v))
                if (this.Values[v].ContainsKey(w))
                    if (this.Values[v][w].ContainsKey(x))
                        if (this.Values[v][w][x].ContainsKey(y))
                            if (this.Values[v][w][x][y].ContainsKey(z))
                                this.Values[v][w][x][y].Remove(z);
        }

        public bool ContainsKey(V v, W w, X x, Y y, Z z)
        {
            if (this.Values.ContainsKey(v))
                if (this.Values[v].ContainsKey(w))
                    if (this.Values[v][w].ContainsKey(x))
                        if (this.Values[v][w][x].ContainsKey(y))
                            if (this.Values[v][w][x][y].ContainsKey(z))
                                return true;
            return false;
        }

        public bool ContainsKey(V v, W w, X x, Y y)
        {
            if (this.Values.ContainsKey(v))
                if (this.Values[v].ContainsKey(w))
                    if (this.Values[v][w].ContainsKey(x))
                        if (this.Values[v][w][x].ContainsKey(y))
                            return true;
            return false;
        }

        public bool ContainsKey(V v, W w, X x)
        {
            if (this.Values.ContainsKey(v))
                if (this.Values[v].ContainsKey(w))
                    if (this.Values[v][w].ContainsKey(x))
                        return true;
            return false;
        }

        public bool ContainsKey(V v, W w)
        {
            if (this.Values.ContainsKey(v))
                if (this.Values[v].ContainsKey(w))
                    return true;
            return false;
        }

        public bool ContainsKey(V v)
        {
            if (this.Values.ContainsKey(v))
                return true;
            return false;
        }

        public void Add(V v, W w, X x, Y y, Z z, VALUE d)
        {
            this.Upsert(false, v, w, x, y, z, d);
        }

        public void Upsert(bool replaceExistingData, V v, W w, X x, Y y, Z z, VALUE d)
        {
            int level = 0;

            Cube<W, Cube<X, Cube<Y, Cube<Z, VALUE>>>> ws = null;
            Cube<X, Cube<Y, Cube<Z, VALUE>>> xs = null;
            Cube<Y, Cube<Z, VALUE>> ys = null;
            Cube<Z, VALUE> zs = null;

            if (this.Values.TryGetValue(v, out ws))
            {
                if (ws.TryGetValue(w, out xs))
                {
                    if (xs.TryGetValue(x, out ys))
                    {
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
                            else level = 5;
                        }
                        else level = 4;
                    }
                    else level = 3;
                }
                else level = 2;
            }
            else level = 1;

            if (level == 1) { ws = new Cube<W, Cube<X, Cube<Y, Cube<Z, VALUE>>>>(); this.Values.Add(v, ws); level++; }
            if (level == 2) { xs = new Cube<X, Cube<Y, Cube<Z, VALUE>>>(); ws?.Add(w, xs); level++; }
            if (level == 3) { ys = new Cube<Y, Cube<Z, VALUE>>(); xs?.Add(x, ys); level++; }
            if (level == 4) { zs = new Cube<Z, VALUE>(); ys?.Add(y, zs); level++; }
            if (level == 5) { zs?.Add(z, d); }
        }

        public IEnumerator<MultiKeyValue<V, W, X, Y, Z, VALUE>> GetEnumerator()
        {
            foreach (MultiKeyValue<V, Cube<W, Cube<X, Cube<Y, Cube<Z, VALUE>>>>> v in Values)
            {
                foreach (MultiKeyValue<W, Cube<X, Cube<Y, Cube<Z, VALUE>>>> w in v.Value)
                {
                    foreach (MultiKeyValue<X, Cube<Y, Cube<Z, VALUE>>> x in w.Value)
                    {
                        foreach (MultiKeyValue<Y, Cube<Z, VALUE>> y in x.Value)
                        {
                            foreach (MultiKeyValue<Z, VALUE> z in y.Value)
                            {
                                yield return new MultiKeyValue<V, W, X, Y, Z, VALUE>(v.Key, w.Key, x.Key, y.Key, z.Key, z.Value);
                            }
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
