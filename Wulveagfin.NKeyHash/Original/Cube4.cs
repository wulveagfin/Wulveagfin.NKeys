namespace Wulveagfin.Cubes
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class MultiKeyValue<X, Y, Z, VALUE>
    {
        public X Key0 { get; set; }
        public Y Key1 { get; set; }
        public Z Key2 { get; set; }
        public VALUE Value { get; set; }

        public MultiKeyValue()
        {
        }

        public MultiKeyValue(X key1, Y key2, Z key3, VALUE value)
        {
            this.Key0 = key1;
            this.Key1 = key2;
            this.Key2 = key3;
            this.Value = value;
        }

        public override string ToString()
        {
            return $"{Key0} , {Key1} , {Key2} = {Value}";
        }
    }

    public class Cube<X, Y, Z, VALUE> : IDisposable, IEnumerable<MultiKeyValue<X, Y, Z, VALUE>>
    {
        /// <summary>
        /// used to set what the underlying object that is used to store and access the data
        /// </summary>
        private readonly CubeUnderlyingHashType UnderlyingHashType;

        /// <summary>
        /// Cube is a IEnumerable-enabled multidimensional array using the Dictionary class as its base. Cube uses generics to create nested Dictionary objects.  
        /// CubeUnderlyingHashType is defaulted to System.Collections.Generic.Dictionary
        /// </summary>
        public Cube()
        {
            this.UnderlyingHashType = CubeUnderlyingHashType.Dictionary;
            this.Values = new Cube<X, Cube<Y, Cube<Z, VALUE>>>(this.UnderlyingHashType);
        }

        /// <summary>
        /// Cube is a IEnumerable-enabled multidimensional array using the Dictionary class as its base. Cube uses generics to create nested Dictionary objects.  
        /// </summary>
        /// <param name="cubeUnderlyingHashType">cubeUnderlyingHashType is used to set what the underlying object that is used to store and access the data</param>
        public Cube(CubeUnderlyingHashType cubeUnderlyingHashType)
        {
            this.UnderlyingHashType = cubeUnderlyingHashType;
            this.Values = new Cube<X, Cube<Y, Cube<Z, VALUE>>>(this.UnderlyingHashType);
        }

        private Cube<X, Cube<Y, Cube<Z, VALUE>>> Values;

        public bool Any()
        {
            return this.Values.Any();
        }

        public int Count()
        {
            return this.Values.Count;
        }

        public int Count(X x)
        {
            if (this.Values.ContainsKey(x))
                return this.Values[x].Count;
            return 0;
        }

        public int Count(X x, Y y)
        {
            Cube<Y, Cube<Z, VALUE>> ys;
            if (this.Values.TryGetValue(x, out ys))
            {
                Cube<Z, VALUE> zs;
                if (ys.TryGetValue(y, out zs))
                {
                    return zs.Count;
                }
            }
            return 0;
        }

        public VALUE this[X x, Y y, Z z]
        {
            get { return Get(x, y, z); }
            set { this.Upsert(true, x, y, z, value); }
        }

        /*public Cube<Y, Z, VALUE> this[X x]
        {
            get { return this.Values.Get(x); }
        }*/

        public void Dispose()
        {
            this.Values = null;
        }

        public VALUE Get(X x, Y y, Z z)
        {
            return this.Values[x][y][z];
        }

        public bool TryGetValue(X x, Y y, Z z, out VALUE data)
        {
            bool exist = false;
            data = Get(out exist, default(VALUE), x, y, z);
            return exist;
        }

        public void Clear()
        {
            this.Values = new Cube<X, Cube<Y, Cube<Z, VALUE>>>(this.UnderlyingHashType);
        }

        public VALUE Get(out bool exists, VALUE defaultData, X x, Y y, Z z)
        {
            exists = false;
            Cube<Y, Cube<Z, VALUE>> ys;
            if (this.Values.TryGetValue(x, out ys))
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
            return defaultData;
        }

        public void Add(X x, Y y, Z z, VALUE d)
        {
            this.Upsert(false, x, y, z, d);
        }

        public void Delete(X x, Y y, Z z)
        {
            this.Remove(x, y, z);
        }

        public void Remove(X x, Y y, Z z)
        {
            Cube<Y, Cube<Z, VALUE>> ys;
            if (this.Values.TryGetValue(x, out ys))
            {
                Cube<Z, VALUE> zs;
                if (ys.TryGetValue(y, out zs))
                {
                    zs.Remove(z);
                }
            }
        }

        public bool ContainsKey(X x, Y y, Z z)
        {
            if (this.Values.ContainsKey(x))
                if (this.Values[x].ContainsKey(y))
                    if (this.Values[x][y].ContainsKey(z))
                        return true;
            return false;
        }

        public bool ContainsKey(X x, Y y)
        {
            if (this.Values.ContainsKey(x))
                if (this.Values[x].ContainsKey(y))
                    return true;
            return false;
        }

        public bool ContainsKey(X x)
        {
            if (this.Values.ContainsKey(x))
                return true;
            return false;
        }

        public void Upsert(X x, Y y, Z z, VALUE d)
        {
            this.Upsert(true, x, y, z, d);
        }

        public void Upsert(bool replaceExistingData, X x, Y y, Z z, VALUE d)
        {
            int level = 0;

            Cube<Y, Cube<Z, VALUE>> ys = null;
            Cube<Z, VALUE> zs = null;

            if (this.Values.TryGetValue(x, out ys))
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
                    else level = 3;
                }
                else level = 2;
            }
            else level = 1;

            if (level == 1) { ys = new Cube<Y, Cube<Z, VALUE>>(this.UnderlyingHashType); this.Values.Add(x, ys); level++; }
            if (level == 2) { zs = new Cube<Z, VALUE>(this.UnderlyingHashType); ys?.Add(y, zs); level++; }
            if (level == 3) { zs?.Add(z, d); }
        }

        public IEnumerator<MultiKeyValue<X, Y, Z, VALUE>> GetEnumerator()
        {
            foreach (MultiKeyValue<X, Cube<Y, Cube<Z, VALUE>>> x in Values)
            {
                foreach (MultiKeyValue<Y, Cube<Z, VALUE>> y in x.Value)
                {
                    foreach (MultiKeyValue<Z, VALUE> z in y.Value)
                    {
                        yield return new MultiKeyValue<X, Y, Z, VALUE>(x.Key, y.Key, z.Key, z.Value);
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
