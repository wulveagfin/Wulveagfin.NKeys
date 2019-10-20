namespace Wulveagfin.Cubes
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class MultiKeyValue< U, V, W, X, Y, Z, VALUE>
    {
        public U Key1 { get; set; }
        public V Key2 { get; set; }
        public W Key3 { get; set; }
        public X Key4 { get; set; }
        public Y Key5 { get; set; }
        public Z Key6 { get; set; }
        public VALUE Value { get; set; }

        public MultiKeyValue()
        {
        }

        public MultiKeyValue(U key1, V key2, W key3, X key4, Y key5, Z key6, VALUE value)
        {
            this.Key1 = key1;
            this.Key2 = key2;
            this.Key3 = key3;
            this.Key4 = key4;
            this.Key5 = key5;
            this.Key6 = key6;
            this.Value = value;
        }
    }

    public class Cube<U, V, W, X, Y, Z, VALUE> : IDisposable, IEnumerable<MultiKeyValue<U, V, W, X, Y, Z, VALUE>>
    {
        private Cube<U, Cube<V, Cube<W, Cube<X, Cube<Y, Cube<Z, VALUE>>>>>> Values
                 = new Cube<U, Cube<V, Cube<W, Cube<X, Cube<Y, Cube<Z, VALUE>>>>>>();

        public VALUE this[U u, V v, W w, X x, Y y, Z z]
        {
            get { return Get(u, v, w, x, y, z); }
            set { this.Upsert(true, u, v, w, x, y, z, value); }
        }

        public void Dispose()
        {
            this.Values = null;
        }

        public VALUE Get(U u, V v, W w, X x, Y y, Z z)
        {
            return this.Values[u][v][w][x][y][z];
        }

        public void Clear()
        {
            this.Values = new Cube<U, Cube<V, Cube<W, Cube<X, Cube<Y, Cube<Z, VALUE>>>>>>();
        }

        public bool TryGetValue(U u, V v, W w, X x, Y y, Z z, out VALUE data)
        {
            bool exist = false;
            data = Get(out exist, default(VALUE), u, v, w, x, y, z);
            return exist;
        }

        public VALUE Get(out bool exists, VALUE defaultData, U u, V v, W w, X x, Y y, Z z)
        {
            exists = false;

            Cube<V, Cube<W, Cube<X, Cube<Y, Cube<Z, VALUE>>>>> vs;
            if (this.Values.TryGetValue(u, out vs))
            {
                Cube<W, Cube<X, Cube<Y, Cube<Z, VALUE>>>> ws;
                if (vs.TryGetValue(v, out ws))
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
            }

            return defaultData;
        }

        public void Add(U u, V v, W w, X x, Y y, Z z, VALUE d)
        {
            this.Upsert(false, u, v, w, x, y, z, d);
        }

        public void Delete(U u, V v, W w, X x, Y y, Z z)
        {
            this.Remove(u, v, w, x, y, z);
        }

        public void Remove(U u, V v, W w, X x, Y y, Z z)
        {
            if (this.Values.ContainsKey(u))
                if (this.Values[u].ContainsKey(v))
                    if (this.Values[u][v].ContainsKey(w))
                        if (this.Values[u][v][w].ContainsKey(x))
                            if (this.Values[u][v][w][x].ContainsKey(y))
                                if (this.Values[u][v][w][x][y].ContainsKey(z))
                                    this.Values[u][v][w][x][y].Remove(z);
        }

        public bool ContainsKey(U u, V v, W w, X x, Y y, Z z)
        {
            if (this.Values.ContainsKey(u))
                if (this.Values[u].ContainsKey(v))
                    if (this.Values[u][v].ContainsKey(w))
                        if (this.Values[u][v][w].ContainsKey(x))
                            if (this.Values[u][v][w][x].ContainsKey(y))
                                if (this.Values[u][v][w][x][y].ContainsKey(z))
                                    return true;
            return false;
        }

        public bool ContainsKey(U u, V v, W w, X x, Y y)
        {
            if (this.Values.ContainsKey(u))
                if (this.Values[u].ContainsKey(v))
                    if (this.Values[u][v].ContainsKey(w))
                        if (this.Values[u][v][w].ContainsKey(x))
                            if (this.Values[u][v][w][x].ContainsKey(y))
                                return true;
            return false;
        }

        public bool ContainsKey(U u, V v, W w, X x)
        {
            if (this.Values.ContainsKey(u))
                if (this.Values[u].ContainsKey(v))
                    if (this.Values[u][v].ContainsKey(w))
                        if (this.Values[u][v][w].ContainsKey(x))
                            return true;
            return false;
        }

        public bool ContainsKey(U u, V v, W w)
        {
            if (this.Values.ContainsKey(u))
                if (this.Values[u].ContainsKey(v))
                    if (this.Values[u][v].ContainsKey(w))
                        return true;
            return false;
        }

        public bool ContainsKey(U u, V v)
        {
            if (this.Values.ContainsKey(u))
                if (this.Values[u].ContainsKey(v))
                    return true;
            return false;
        }

        public bool ContainsKey(U u)
        {
            if (this.Values.ContainsKey(u))
                return true;
            return false;
        }

        public void Upsert(bool replaceExistingData, U u, V v, W w, X x, Y y, Z z, VALUE d)
        {
            int level = 0;

            Cube<V, Cube<W, Cube<X, Cube<Y, Cube<Z, VALUE>>>>> vs = null;
            Cube<W, Cube<X, Cube<Y, Cube<Z, VALUE>>>> ws = null;
            Cube<X, Cube<Y, Cube<Z, VALUE>>> xs = null;
            Cube<Y, Cube<Z, VALUE>> ys = null;
            Cube<Z, VALUE> zs = null;

            if (this.Values.TryGetValue(u, out vs))
            {
                if (vs.TryGetValue(v, out ws))
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
                                else level = 6;
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

            if (level == 1) { vs = new Cube<V, Cube<W, Cube<X, Cube<Y, Cube<Z, VALUE>>>>>(); this.Values.Add(u, vs); level++; }
            if (level == 2) { ws = new Cube<W, Cube<X, Cube<Y, Cube<Z, VALUE>>>>(); vs?.Add(v, ws); level++; }
            if (level == 3) { xs = new Cube<X, Cube<Y, Cube<Z, VALUE>>>(); ws?.Add(w, xs); level++; }
            if (level == 4) { ys = new Cube<Y, Cube<Z, VALUE>>(); xs?.Add(x, ys); level++; }
            if (level == 5) { zs = new Cube<Z, VALUE>(); ys?.Add(y, zs); level++; }
            if (level == 6) { zs?.Add(z, d); }
        }

        public IEnumerator<MultiKeyValue<U, V, W, X, Y, Z, VALUE>> GetEnumerator()
        {
            foreach (MultiKeyValue<U, Cube<V, Cube<W, Cube<X, Cube<Y, Cube<Z, VALUE>>>>>> u in Values)
            {
                foreach (MultiKeyValue<V, Cube<W, Cube<X, Cube<Y, Cube<Z, VALUE>>>>> v in u.Value)
                {
                    foreach (MultiKeyValue<W, Cube<X, Cube<Y, Cube<Z, VALUE>>>> w in v.Value)
                    {
                        foreach (MultiKeyValue<X, Cube<Y, Cube<Z, VALUE>>> x in w.Value)
                        {
                            foreach (MultiKeyValue<Y, Cube<Z, VALUE>> y in x.Value)
                            {
                                foreach (MultiKeyValue<Z, VALUE> z in y.Value)
                                {
                                    yield return new MultiKeyValue<U, V, W, X, Y, Z, VALUE>(u.Key, v.Key, w.Key, x.Key, y.Key, z.Key, z.Value);
                                }
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
