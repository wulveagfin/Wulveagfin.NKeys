namespace Wulveagfin.Cubes
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class CubeContent<Z, VALUE>
    {
        public Z Key { get; set; }
        public VALUE Value { get; set; }

        public CubeContent()
        {
        }

        public CubeContent(Z key, VALUE value)
        {
            this.Key = key;
            this.Value = value;
        }
    }

    public class Cube<Z, VALUE> : IDisposable, IEnumerable<CubeContent<Z, VALUE>>
    {
        private Dictionary<Z, VALUE> Values = new Dictionary<Z, VALUE>();

        public Dictionary<Z, VALUE> ToDictionary
        {
            get
            {
                return this.Values;
            }
        }

        public bool Any()
        {
            return this.Values.Any();
        }

        public int Count
        {
            get
            {
                return this.Values.Count;
            }
        }

        public void Dispose()
        {
            this.Values = null;
        }

        public void Clear()
        {
            this.Values = new Dictionary<Z, VALUE>();
        }

        public VALUE this[Z z]
        {
            get { return Get(z); }
            set { this.Upsert(true, z, value); }
        }

        public VALUE Get(Z z)
        {
            bool ext;
            return Get(out ext, default(VALUE), z);
        }

        public bool TryGetValue(Z z, out VALUE data)
        {
            bool exist = false;
            data = Get(out exist, default(VALUE), z);
            return exist;
        }

        public static object Lock = new object();

        public VALUE Get(out bool exists, VALUE defaultData, Z z)
        {
            //lock(Lock)
            {
                exists = false;
                VALUE d;
                if (this.Values.TryGetValue(z, out d))
                {
                    exists = true;
                    return d;
                }
                return defaultData;
            }
        }

        public void Delete(Z z)
        {
            this.Remove(z);
        }

        public void Remove(Z z)
        {
            lock (Lock)
            {
                //VALUE d;
                if (this.Values.ContainsKey(z))
                    this.Values.Remove(z);
            }
        }

        public VALUE this[CubeContent<Z, VALUE> z]
        {
            get { return Get(z); }
            set { this.Upsert(true, z.Key, value); }
        }

        public VALUE Get(CubeContent<Z, VALUE> z)
        {
            return this.Get(z.Key);
        }

        public VALUE Get(out bool exists, VALUE defaultData, CubeContent<Z, VALUE> z)
        {
            return this.Get(out exists, defaultData, z.Key);
        }

        public void Delete(CubeContent<Z, VALUE> z)
        {
            this.Remove(z.Key);
        }

        public void Remove(CubeContent<Z, VALUE> z)
        {
            this.Remove(z.Key);
        }

        public void ContainsKey(CubeContent<Z, VALUE> z)
        {
            this.ContainsKey(z.Key);
        }

        public void Add(CubeContent<Z, VALUE> z, VALUE d)
        {
            this.Add(z.Key, d);
        }

        public bool ContainsKey(Z z)
        {
            return this.Values.ContainsKey(z);
        }

        public void Add(Z z, VALUE d)
        {
            this.Upsert(false, z, d);
        }

        public void Upsert(Z z, VALUE d)
        {
            this.Upsert(true, z, d);
        }

        //private static object Lock = new object();
        public void Upsert(bool replaceData, Z z, VALUE d)
        {
            lock (Lock)
            {
                int level = 0;
                if (this.Values.ContainsKey(z))
                {
                    if (replaceData)
                    {
                        this.Values[z] = d;
                        return;
                    }
                }
                else level = 1;

                if (level == 1) { this.Values.Add(z, d); }
            }
        }

        public IEnumerator<CubeContent<Z, VALUE>> GetEnumerator()
        {
            foreach (KeyValuePair<Z, VALUE> z in Values)
            {
                yield return new CubeContent<Z, VALUE>(z.Key, z.Value);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Cube<Z, VALUE> Copy()
        {
            Cube<Z, VALUE> cpy = new Cube<Z, VALUE>();
            foreach (var kvp in this)
            {
                cpy.Upsert(true, kvp.Key, kvp.Value);
            }
            return cpy;
        }
    }


}
