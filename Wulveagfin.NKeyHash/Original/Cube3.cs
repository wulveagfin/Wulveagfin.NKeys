namespace Wulveagfin.Cubes
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class MultiKeyValue<Y, Z, VALUE>
    {
        public Y Key0 { get; set; }
        public Z Key1 { get; set; }
        public VALUE Value { get; set; }

        public MultiKeyValue()
        {
        }

        public MultiKeyValue(Y key1, Z key2, VALUE value)
        {
            this.Key0 = key1;
            this.Key1 = key2;
            this.Value = value;
        }
    }

    [Serializable]
    public class Cube<Y, Z, VALUE> : IDisposable, IEnumerable<MultiKeyValue<Y, Z, VALUE>>
    {
        private Cube<Y, Cube<Z, VALUE>> Values = new Cube<Y, Cube<Z, VALUE>>();

        public bool Any()
        {
            return this.Values.Any();
        }

        public int Count()
        {
            return this.Values.Count;
        }

        public int Count(Y y)
        {
            if (this.Values.ContainsKey(y))
                return this.Values[y].Count;
            return 0;
        }

        public void Clear()
        {
            this.Values = new Cube<Y, Cube<Z, VALUE>>();
        }

        public void Dispose()
        {
            this.Values = null;
        }

        public VALUE this[Y y, Z z]
        {
            get { return Get(y, z); }
            set { this.Upsert(true, y, z, value); }
        }

        public VALUE Get(Y y, Z z)
        {
            bool exists;
            return Get(out exists, default(VALUE), y, z);
        }

        public bool TryGetValue(Y y, Z z, out VALUE data)
        {
            bool exist = false;
            data = Get(out exist, default(VALUE), y, z);
            return exist;
        }

        public bool TryGetValue(Y y, out Cube<Z, VALUE> data)
        {
            if (this.Values.TryGetValue(y, out data))
            {
                return true;
            }
            data = null;
            return false;
        }

        public VALUE Get(out bool exists, VALUE defaultData, Y y, Z z)
        {
            exists = false;
            Cube<Z, VALUE> zs;
            if (this.Values.TryGetValue(y, out zs))
            {
                VALUE data;
                if (zs.TryGetValue(z, out data))
                {
                    exists = true;
                    return data;
                }
            }
            return defaultData;
        }

        public void Delete(Y y, Z z)
        {
            this.Remove(y, z);
        }

        public void Remove(Y y, Z z)
        {
            Cube<Z, VALUE> zs;
            if (this.Values.TryGetValue(y, out zs))
            {
                if (zs.ContainsKey(z))
                    this.Values[y].Remove(z);
            }
        }

        public bool ContainsKey(Y y, Z z)
        {
            if (this.Values.ContainsKey(y))
                if (this.Values[y].ContainsKey(z))
                    return true;
            return false;
        }

        public bool ContainsKey(Y y)
        {
            if (this.Values.ContainsKey(y))
                return true;
            return false;
        }

        public void Add(Y y, Z z, VALUE d)
        {
            this.Upsert(false, y, z, d);
        }

        public void Upsert(Y y, Z z, VALUE d)
        {
            this.Upsert(true, y, z, d);
        }

        public void Upsert(bool replaceExistingData, Y y, Z z, VALUE d)
        {
            int level = 0;

            Cube<Z, VALUE> zs = null;

            if (this.Values.TryGetValue(y, out zs))
            {
                if (zs.ContainsKey(z))
                {
                    if (replaceExistingData)
                    {
                        zs[z] = d;
                        return;
                    }
                }
                else level = 2;
            }
            else level = 1;

            if (level == 1) { zs = new Cube<Z, VALUE>(); this.Values.Add(y, zs); level++; }
            if (level == 2) { zs?.Add(z, d); }
        }

        public IEnumerator<MultiKeyValue<Y, Z, VALUE>> GetEnumerator()
        {
            foreach (MultiKeyValue<Y, Cube<Z, VALUE>> y in Values)
            {
                foreach (MultiKeyValue<Z, VALUE> z in y.Value)
                {
                    yield return new MultiKeyValue<Y, Z, VALUE>(y.Key, z.Key, z.Value);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}
