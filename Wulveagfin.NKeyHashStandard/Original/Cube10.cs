namespace Wulveagfin.Cubes
{
    using System;

    public class Cube<R, S, T, U, V, W, X, Y, Z, VALUE> : IDisposable
    {
        private Cube<R, Cube<S, Cube<T, Cube<U, Cube<V, Cube<W, Cube<X, Cube<Y, Cube<Z, VALUE>>>>>>>>> Values =
            new Cube<R, Cube<S, Cube<T, Cube<U, Cube<V, Cube<W, Cube<X, Cube<Y, Cube<Z, VALUE>>>>>>>>>();

        public VALUE this[R r, S s, T t, U u, V v, W w, X x, Y y, Z z]
        {
            get { return Get(r, s, t, u, v, w, x, y, z); }
            set { this.Upsert(true, r, s, t, u, v, w, x, y, z, value); }
        }

        public void Dispose()
        {
            this.Values = null;
        }

        public VALUE Get(R r, S s, T t, U u, V v, W w, X x, Y y, Z z)
        {
            return this.Values[r][s][t][u][v][w][x][y][z];
        }

        public bool TryGetValue(R r, S s, T t, U u, V v, W w, X x, Y y, Z z, out VALUE data)
        {
            bool exist = false;
            data = Get(out exist, default(VALUE), r, s, t, u, v, w, x, y, z);
            return exist;
        }

        public void Clear()
        {
            this.Values = new Cube<R, Cube<S, Cube<T, Cube<U, Cube<V, Cube<W, Cube<X, Cube<Y, Cube<Z, VALUE>>>>>>>>>();
        }

        public VALUE Get(out bool exists, VALUE defaultData, R r, S s, T t, U u, V v, W w, X x, Y y, Z z)
        {
            exists = false;

            Cube<S, Cube<T, Cube<U, Cube<V, Cube<W, Cube<X, Cube<Y, Cube<Z, VALUE>>>>>>>> ss;
            if (this.Values.TryGetValue(r, out ss))
            {
                Cube<T, Cube<U, Cube<V, Cube<W, Cube<X, Cube<Y, Cube<Z, VALUE>>>>>>> ts;
                if (ss.TryGetValue(s, out ts))
                {
                    Cube<U, Cube<V, Cube<W, Cube<X, Cube<Y, Cube<Z, VALUE>>>>>> us;
                    if (ts.TryGetValue(t, out us))
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
                }
            }

            return defaultData;
        }

        public void Add(R r, S s, T t, U u, V v, W w, X x, Y y, Z z, VALUE d)
        {
            this.Upsert(false, r, s, t, u, v, w, x, y, z, d);
        }

        public void Delete(R r, S s, T t, U u, V v, W w, X x, Y y, Z z)
        {
            this.Remove(r, s, t, u, v, w, x, y, z);
        }

        public void Remove(R r, S s, T t, U u, V v, W w, X x, Y y, Z z)
        {
            if (this.Values.ContainsKey(r))
                if (this.Values[r].ContainsKey(s))
                    if (this.Values[r][s].ContainsKey(t))
                        if (this.Values[r][s][t].ContainsKey(u))
                            if (this.Values[r][s][t][u].ContainsKey(v))
                                if (this.Values[r][s][t][u][v].ContainsKey(w))
                                    if (this.Values[r][s][t][u][v][w].ContainsKey(x))
                                        if (this.Values[r][s][t][u][v][w][x].ContainsKey(y))
                                            if (this.Values[r][s][t][u][v][w][x][y].ContainsKey(z))
                                                this.Values[r][s][t][u][v][w][x][y].Remove(z);
        }

        public bool ContainsKey(R r, S s, T t, U u, V v, W w, X x, Y y, Z z)
        {
            if (this.Values.ContainsKey(r))
                if (this.Values[r].ContainsKey(s))
                    if (this.Values[r][s].ContainsKey(t))
                        if (this.Values[r][s][t].ContainsKey(u))
                            if (this.Values[r][s][t][u].ContainsKey(v))
                                if (this.Values[r][s][t][u][v].ContainsKey(w))
                                    if (this.Values[r][s][t][u][v][w].ContainsKey(x))
                                        if (this.Values[r][s][t][u][v][w][x].ContainsKey(y))
                                            if (this.Values[r][s][t][u][v][w][x][y].ContainsKey(z))
                                                return true;
            return false;
        }

        public bool ContainsKey(R r, S s, T t, U u, V v, W w, X x, Y y)
        {
            if (this.Values.ContainsKey(r))
                if (this.Values[r].ContainsKey(s))
                    if (this.Values[r][s].ContainsKey(t))
                        if (this.Values[r][s][t].ContainsKey(u))
                            if (this.Values[r][s][t][u].ContainsKey(v))
                                if (this.Values[r][s][t][u][v].ContainsKey(w))
                                    if (this.Values[r][s][t][u][v][w].ContainsKey(x))
                                        if (this.Values[r][s][t][u][v][w][x].ContainsKey(y))
                                            return true;
            return false;
        }

        public bool ContainsKey(R r, S s, T t, U u, V v, W w, X x)
        {
            if (this.Values.ContainsKey(r))
                if (this.Values[r].ContainsKey(s))
                    if (this.Values[r][s].ContainsKey(t))
                        if (this.Values[r][s][t].ContainsKey(u))
                            if (this.Values[r][s][t][u].ContainsKey(v))
                                if (this.Values[r][s][t][u][v].ContainsKey(w))
                                    if (this.Values[r][s][t][u][v][w].ContainsKey(x))
                                        return true;
            return false;
        }

        public bool ContainsKey(R r, S s, T t, U u, V v, W w)
        {
            if (this.Values.ContainsKey(r))
                if (this.Values[r].ContainsKey(s))
                    if (this.Values[r][s].ContainsKey(t))
                        if (this.Values[r][s][t].ContainsKey(u))
                            if (this.Values[r][s][t][u].ContainsKey(v))
                                if (this.Values[r][s][t][u][v].ContainsKey(w))
                                    return true;
            return false;
        }

        public bool ContainsKey(R r, S s, T t, U u, V v)
        {
            if (this.Values.ContainsKey(r))
                if (this.Values[r].ContainsKey(s))
                    if (this.Values[r][s].ContainsKey(t))
                        if (this.Values[r][s][t].ContainsKey(u))
                            if (this.Values[r][s][t][u].ContainsKey(v))
                                return true;
            return false;
        }

        public bool ContainsKey(R r, S s, T t, U u)
        {
            if (this.Values.ContainsKey(r))
                if (this.Values[r].ContainsKey(s))
                    if (this.Values[r][s].ContainsKey(t))
                        if (this.Values[r][s][t].ContainsKey(u))
                            return true;
            return false;
        }

        public bool ContainsKey(R r, S s, T t)
        {
            if (this.Values.ContainsKey(r))
                if (this.Values[r].ContainsKey(s))
                    if (this.Values[r][s].ContainsKey(t))
                        return true;
            return false;
        }

        public bool ContainsKey(R r, S s)
        {
            if (this.Values.ContainsKey(r))
                if (this.Values[r].ContainsKey(s))
                    return true;
            return false;
        }

        public bool ContainsKey(R r)
        {
            if (this.Values.ContainsKey(r))
                return true;
            return false;
        }

        public void Upsert(bool replaceExistingData, R r, S s, T t, U u, V v, W w, X x, Y y, Z z, VALUE d)
        {
            Cube<S, Cube<T, Cube<U, Cube<V, Cube<W, Cube<X, Cube<Y, Cube<Z, VALUE>>>>>>>> ss = null;
            Cube<T, Cube<U, Cube<V, Cube<W, Cube<X, Cube<Y, Cube<Z, VALUE>>>>>>> ts = null;
            Cube<U, Cube<V, Cube<W, Cube<X, Cube<Y, Cube<Z, VALUE>>>>>> us = null;
            Cube<V, Cube<W, Cube<X, Cube<Y, Cube<Z, VALUE>>>>> vs = null;
            Cube<W, Cube<X, Cube<Y, Cube<Z, VALUE>>>> ws = null;
            Cube<X, Cube<Y, Cube<Z, VALUE>>> xs = null;
            Cube<Y, Cube<Z, VALUE>> ys = null;
            Cube<Z, VALUE> zs = null;

            int level = 0;
            if (this.Values.TryGetValue(r, out ss))
            {
                if (ss.TryGetValue(s, out ts))
                {
                    if (ts.TryGetValue(t, out us))
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
                                            else level = 9;
                                        }
                                        else level = 8;
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

            if (level == 1) { ss = new Cube<S, Cube<T, Cube<U, Cube<V, Cube<W, Cube<X, Cube<Y, Cube<Z, VALUE>>>>>>>>(); this.Values.Add(r, ss); level++; }
            if (level == 2) { ts = new Cube<T, Cube<U, Cube<V, Cube<W, Cube<X, Cube<Y, Cube<Z, VALUE>>>>>>>(); ss?.Add(s, ts); level++; }
            if (level == 3) { us = new Cube<U, Cube<V, Cube<W, Cube<X, Cube<Y, Cube<Z, VALUE>>>>>>(); ts?.Add(t, us); level++; }
            if (level == 4) { vs = new Cube<V, Cube<W, Cube<X, Cube<Y, Cube<Z, VALUE>>>>>(); us?.Add(u, vs); level++; }
            if (level == 5) { ws = new Cube<W, Cube<X, Cube<Y, Cube<Z, VALUE>>>>(); vs?.Add(v, ws); level++; }
            if (level == 6) { xs = new Cube<X, Cube<Y, Cube<Z, VALUE>>>(); ws?.Add(w, xs); level++; }
            if (level == 7) { ys = new Cube<Y, Cube<Z, VALUE>>(); xs?.Add(x, ys); level++; }
            if (level == 8) { zs = new Cube<Z, VALUE>(); ys?.Add(y, zs); level++; }
            if (level == 9) { zs?.Add(z, d); }
        }
    }


}