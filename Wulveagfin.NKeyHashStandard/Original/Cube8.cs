namespace Wulveagfin.Cubes
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class MultiKeyValue< T, U, V, W, X, Y, Z, VALUE>
    {
        public T Key1 { get; set; }
        public U Key2 { get; set; }
        public V Key3 { get; set; }
        public W Key4 { get; set; }
        public X Key5 { get; set; }
        public Y Key6 { get; set; }
        public Z Key7 { get; set; }
        public VALUE Value { get; set; }

        public MultiKeyValue()
        {
        }

        public MultiKeyValue( T key1, U key2, V key3, W key4, X key5, Y key6, Z key7, VALUE value)
        {
            this.Key1 = key1;
            this.Key2 = key2;
            this.Key3 = key3;
            this.Key4 = key4;
            this.Key5 = key5;
            this.Key6 = key6;
            this.Key6 = key6;
            this.Key7 = key7;
            this.Value = value;
        }
    }

    public class Cube<T, U, V, W, X, Y, Z, VALUE> : IDisposable, IEnumerable<MultiKeyValue<T, U, V, W, X, Y, Z, VALUE>>
    {
        private Cube<T, Cube<U, Cube<V, Cube<W, Cube<X, Cube<Y, Cube<Z, VALUE>>>>>>> Values
                 = new Cube<T, Cube<U, Cube<V, Cube<W, Cube<X, Cube<Y, Cube<Z, VALUE>>>>>>>();

        public VALUE this[T t, U u, V v, W w, X x, Y y, Z z]
        {
            get { return Get(t, u, v, w, x, y, z); }
            set { this.Upsert(true, t, u, v, w, x, y, z, value); }
        }

        public void Dispose()
        {
            this.Values = null;
        }

        public void Clear()
        {
            this.Values = new Cube<T, Cube<U, Cube<V, Cube<W, Cube<X, Cube<Y, Cube<Z, VALUE>>>>>>>();
        }

        public VALUE Get(T t, U u, V v, W w, X x, Y y, Z z)
        {
            return this.Values[t][u][v][w][x][y][z];
        }

        public bool TryGetValue(T t, U u, V v, W w, X x, Y y, Z z, out VALUE data)
        {
            bool exist = false;
            data = Get(out exist, default(VALUE), t, u, v, w, x, y, z);
            return exist;
        }

        public VALUE Get(out bool exists, VALUE defaultData, T t, U u, V v, W w, X x, Y y, Z z)
        {
            exists = false;

            Cube<U, Cube<V, Cube<W, Cube<X, Cube<Y, Cube<Z, VALUE>>>>>> us;
            if (this.Values.TryGetValue(t, out us))
            {
                Cube<V, Cube<W, Cube<X, Cube<Y, Cube<Z, VALUE>>>>> vs;
                if (us.TryGetValue(u, out vs))
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
            }

            return defaultData;
        }

        public void Add(T t, U u, V v, W w, X x, Y y, Z z, VALUE d)
        {
            this.Upsert(false, t, u, v, w, x, y, z, d);
        }

        public void Delete(T t, U u, V v, W w, X x, Y y, Z z)
        {
            this.Remove(t, u, v, w, x, y, z);
        }

        public void Remove(T t, U u, V v, W w, X x, Y y, Z z)
        {
            if (this.Values.ContainsKey(t))
                if (this.Values[t].ContainsKey(u))
                    if (this.Values[t][u].ContainsKey(v))
                        if (this.Values[t][u][v].ContainsKey(w))
                            if (this.Values[t][u][v][w].ContainsKey(x))
                                if (this.Values[t][u][v][w][x].ContainsKey(y))
                                    if (this.Values[t][u][v][w][x][y].ContainsKey(z))
                                        this.Values[t][u][v][w][x][y].Remove(z);
        }

        public bool ContainsKey(T t, U u, V v, W w, X x, Y y, Z z)
        {
            if (this.Values.ContainsKey(t))
                if (this.Values[t].ContainsKey(u))
                    if (this.Values[t][u].ContainsKey(v))
                        if (this.Values[t][u][v].ContainsKey(w))
                            if (this.Values[t][u][v][w].ContainsKey(x))
                                if (this.Values[t][u][v][w][x].ContainsKey(y))
                                    if (this.Values[t][u][v][w][x][y].ContainsKey(z))
                                        return true;
            return false;
        }

        public bool ContainsKey(T t, U u, V v, W w, X x, Y y)
        {
            if (this.Values.ContainsKey(t))
                if (this.Values[t].ContainsKey(u))
                    if (this.Values[t][u].ContainsKey(v))
                        if (this.Values[t][u][v].ContainsKey(w))
                            if (this.Values[t][u][v][w].ContainsKey(x))
                                if (this.Values[t][u][v][w][x].ContainsKey(y))
                                    return true;
            return false;
        }

        public bool ContainsKey(T t, U u, V v, W w, X x)
        {
            if (this.Values.ContainsKey(t))
                if (this.Values[t].ContainsKey(u))
                    if (this.Values[t][u].ContainsKey(v))
                        if (this.Values[t][u][v].ContainsKey(w))
                            if (this.Values[t][u][v][w].ContainsKey(x))
                                return true;
            return false;
        }

        public bool ContainsKey(T t, U u, V v, W w)
        {
            if (this.Values.ContainsKey(t))
                if (this.Values[t].ContainsKey(u))
                    if (this.Values[t][u].ContainsKey(v))
                        if (this.Values[t][u][v].ContainsKey(w))
                            return true;
            return false;
        }

        public bool ContainsKey(T t, U u, V v)
        {
            if (this.Values.ContainsKey(t))
                if (this.Values[t].ContainsKey(u))
                    if (this.Values[t][u].ContainsKey(v))
                        return true;
            return false;
        }

        public bool ContainsKey(T t, U u)
        {
            if (this.Values.ContainsKey(t))
                if (this.Values[t].ContainsKey(u))
                    return true;
            return false;
        }

        public bool ContainsKey(T t)
        {
            if (this.Values.ContainsKey(t))
                return true;
            return false;
        }

        public void Upsert(bool replaceExistingData, T t, U u, V v, W w, X x, Y y, Z z, VALUE d)
        {
            Cube<U, Cube<V, Cube<W, Cube<X, Cube<Y, Cube<Z, VALUE>>>>>> us = null;
            Cube<V, Cube<W, Cube<X, Cube<Y, Cube<Z, VALUE>>>>> vs = null;
            Cube<W, Cube<X, Cube<Y, Cube<Z, VALUE>>>> ws = null;
            Cube<X, Cube<Y, Cube<Z, VALUE>>> xs = null;
            Cube<Y, Cube<Z, VALUE>> ys = null;
            Cube<Z, VALUE> zs = null;

            int level = 0;
            if (this.Values.TryGetValue(t, out us))
            {
                if (us.TryGetValue(u, out vs))
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
                                    else level = 7;
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

            if (level == 1) { us = new Cube<U, Cube<V, Cube<W, Cube<X, Cube<Y, Cube<Z, VALUE>>>>>>(); this.Values.Add(t, us); level++; }
            if (level == 2) { vs = new Cube<V, Cube<W, Cube<X, Cube<Y, Cube<Z, VALUE>>>>>(); us?.Add(u, vs); level++; }
            if (level == 3) { ws = new Cube<W, Cube<X, Cube<Y, Cube<Z, VALUE>>>>(); vs?.Add(v, ws); level++; }
            if (level == 4) { xs = new Cube<X, Cube<Y, Cube<Z, VALUE>>>(); ws?.Add(w, xs); level++; }
            if (level == 5) { ys = new Cube<Y, Cube<Z, VALUE>>(); xs?.Add(x, ys); level++; }
            if (level == 6) { zs = new Cube<Z, VALUE>(); ys?.Add(y, zs); level++; }
            if (level == 7) { zs?.Add(z, d); }
        }

        public IEnumerator<MultiKeyValue<T, U, V, W, X, Y, Z, VALUE>> GetEnumerator()
        {
            foreach (MultiKeyValue<T, Cube<U, Cube<V, Cube<W, Cube<X, Cube<Y, Cube<Z, VALUE>>>>>>> t in Values)
            {
                foreach (MultiKeyValue<U, Cube<V, Cube<W, Cube<X, Cube<Y, Cube<Z, VALUE>>>>>> u in t.Value)
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
                                        yield return new MultiKeyValue<T, U, V, W, X, Y, Z, VALUE>(t.Key, u.Key, v.Key, w.Key, x.Key, y.Key, z.Key, z.Value);
                                    }
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
