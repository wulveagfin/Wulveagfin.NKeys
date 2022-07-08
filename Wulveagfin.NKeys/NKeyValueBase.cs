namespace Wulveagfin.NKeys
{
    using System;
    using System.Collections;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// NKeyValue is used to express internal objects within the NKeyHash universe.
    /// </summary>
    /// <typeparam name="A">Key A, of [key0 key1.... keyN value] pair</typeparam>
    /// <typeparam name="VALUE">Value of [key0 key1.... keyN value] pair</typeparam>
    public class NKeyValue<A, VALUE>
    {
        /// <summary>
        /// Key A, of [key0 key1.... keyN value] pair
        /// </summary>
        public A Key { get; set; }

        /// <summary>
        /// Value of [key0 key1.... keyN value] pair
        /// </summary>
        public VALUE Value { get; set; }

        /// <summary>
        /// NKeyValue is used to express internal objects within the NKeyHash universe.
        /// </summary>
        public NKeyValue()
        {
        }

        /// <summary>
        /// NKeyValue is used to express internal objects within the NKeyHash universe.
        /// </summary>
        /// <param name="key">Key A, of [key0 key1.... keyN value] pair</param>
        /// <param name="value">Value of [key0 key1.... keyN value] pair</param>
        public NKeyValue(A key, VALUE value)
        {
            this.Key = key;
            this.Value = value;
        }
    }

    /// <summary>
    /// UnderlyingHashType is used to set what the underlying object that is used to store and access the data
    /// </summary>
    public enum UnderlyingHashType : int
    {
        /// <summary>
        /// System.Collections.Generic.Dictionary
        /// </summary>
        Dictionary = 0,
        /// <summary>
        /// System.Collections.Concurrent.ConcurrentDictionary
        /// </summary>
        ConcurrentDictionary = 1,
        /// <summary>
        /// System.Collections.Generic.SortedDictionary
        /// </summary>
        SortedDictionary = 2,
        /// <summary>
        /// System.Collections.HashTable
        /// </summary>
        HashTable = 3
    }

    /// <summary>
    /// NKeyHash is a IEnumerable-enabled multidimensional array using the Dictionary class as its base. NKeyHash uses generics to create nested Dictionary objects.
    /// <summary>
    public class NKeyHash<A, VALUE> : IDisposable, IEnumerable<NKeyValue<A, VALUE>>
    {
        /// <summary>
        /// Used to set what the underlying object that is used to store and access the data.
        /// </summary>
        public UnderlyingHashType UnderlyingHashType { get; private set; } = UnderlyingHashType.HashTable;

        /// <summary>
        /// NKeyHash is a IEnumerable-enabled multidimensional array. It can currently use System.Collections.HashTable, System.Collections.Generic.Dictionary, System.Collections.Generic.SortedDictionary, or System.Collections.Concurrent.ConcurrentDictionary for the underlying base hashable object. NKeyHash uses generics to create nested hashable objects.  
        /// </summary>
        /// <param name="cubeUnderlyingHashType">cubeUnderlyingHashType is used to set what the underlying object that is used to store and access the data</param>
        public NKeyHash(UnderlyingHashType cubeUnderlyingHashType = UnderlyingHashType.Dictionary)
        {
            this.UnderlyingHashType = cubeUnderlyingHashType;
        }

        /// <summary>
        /// Private internal storage object for Values
        /// </summary>
        private Dictionary<A, VALUE> ValuesDictionary = new Dictionary<A, VALUE>();

        /// <summary>
        /// Private internal storage object for Values
        /// </summary>
        private ConcurrentDictionary<A, VALUE> ValuesConcurrent = new ConcurrentDictionary<A, VALUE>();

        /// <summary>
        /// Private internal storage object for Values
        /// </summary>
        private SortedDictionary<A, VALUE> ValuesSorted = new SortedDictionary<A, VALUE>();

        /// <summary>
        /// Private internal storage object for Values
        /// </summary>
        private Hashtable ValuesHash = new Hashtable();

        /// <summary>
        /// Converts base Values object to Dictionary object
        /// </summary>
        public object BaseObject
        {
            get
            {
                switch (this.UnderlyingHashType)
                {
                    default:
                    case UnderlyingHashType.Dictionary: return this.ValuesDictionary;
                    case UnderlyingHashType.ConcurrentDictionary: return this.ValuesConcurrent;
                    case UnderlyingHashType.HashTable: return this.ValuesHash;
                    case UnderlyingHashType.SortedDictionary: return this.ValuesSorted;
                }
            }
        }

        /// <summary>
        /// Determines whether a sequence contains any elements
        /// </summary>
        /// <returns></returns>
        public bool Any()
        {
            switch (this.UnderlyingHashType)
            {
                default:
                case UnderlyingHashType.Dictionary: return this.ValuesDictionary.Any();
                case UnderlyingHashType.ConcurrentDictionary: return this.ValuesConcurrent.Any();
                case UnderlyingHashType.HashTable: return this.ValuesHash.Count != 0;
                case UnderlyingHashType.SortedDictionary: return this.ValuesSorted.Any();
            }
        }

        /// <summary>
        /// Gets the number of key/value collections contained
        /// </summary>
        public int Count
        {
            get
            {
                switch (this.UnderlyingHashType)
                {
                    default:
                    case UnderlyingHashType.Dictionary: return this.ValuesDictionary.Count;
                    case UnderlyingHashType.ConcurrentDictionary: return this.ValuesConcurrent.Count;
                    case UnderlyingHashType.HashTable: return this.ValuesHash.Count;
                    case UnderlyingHashType.SortedDictionary: return this.ValuesSorted.Count;
                }
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources
        /// </summary>
        public void Dispose()
        {
            switch (this.UnderlyingHashType)
            {
                default:
                case UnderlyingHashType.Dictionary: this.ValuesDictionary = null; break;
                case UnderlyingHashType.ConcurrentDictionary: this.ValuesConcurrent = null; break;
                case UnderlyingHashType.HashTable: this.ValuesHash = null; break;
                case UnderlyingHashType.SortedDictionary: this.ValuesSorted = null; break;
            }
        }

        /// <summary>
        /// Removes all keys and values
        /// </summary>
        public void Clear()
        {
            switch (this.UnderlyingHashType)
            {
                default:
                case UnderlyingHashType.Dictionary: this.ValuesDictionary = new Dictionary<A, VALUE>(); break;
                case UnderlyingHashType.ConcurrentDictionary: this.ValuesConcurrent = new ConcurrentDictionary<A, VALUE>(); break;
                case UnderlyingHashType.HashTable: this.ValuesHash = new Hashtable(); break;
                case UnderlyingHashType.SortedDictionary: this.ValuesSorted = new SortedDictionary<A, VALUE>(); break;
            }
        }

        /// <summary>
        /// Gets the value associated with the specified key
        /// </summary>
        /// <param name="z"></param>
        /// <returns></returns>
        public VALUE this[A z]
        {
            get { return Get(z); }
            set { this.Upsert(true, z, value); }
        }

        /// <summary>
        /// Gets the value associated with the specified key
        /// </summary>
        /// <param name="z"></param>
        /// <returns></returns>
        public VALUE Get(A z)
        {
            bool ext;
            return Get(out ext, default(VALUE), z);
        }

        /// <summary>
        /// Gets the value associated with the specified key
        /// </summary>
        /// <param name="z"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool TryGetValue(A z, out VALUE data)
        {
            bool exist = false;
            data = Get(out exist, default(VALUE), z);
            return exist;
        }

        /// <summary>
        /// Global Lock object
        /// </summary>
        protected static object Lock = new object();

        /// <summary>
        /// Gets the value associated with the specified key
        /// </summary>
        /// <param name="exists"></param>
        /// <param name="defaultData"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public VALUE Get(out bool exists, VALUE defaultData, A z)
        {
            exists = false;
            VALUE d;

            switch (this.UnderlyingHashType)
            {
                default:
                case UnderlyingHashType.Dictionary:
                    if (this.ValuesDictionary.TryGetValue(z, out d))
                    {
                        exists = true;
                        return d;
                    }
                    break;

                case UnderlyingHashType.ConcurrentDictionary:
                    if (this.ValuesConcurrent.TryGetValue(z, out d))
                    {
                        exists = true;
                        return d;
                    }
                    break;

                case UnderlyingHashType.HashTable:
                    if (this.ValuesHash.ContainsKey(z))
                    {
                        exists = true;
                        return (VALUE)this.ValuesHash[z];
                    }
                    break;

                case UnderlyingHashType.SortedDictionary:
                    if (this.ValuesSorted.TryGetValue(z, out d))
                    {
                        exists = true;
                        return d;
                    }
                    break;
            }

            return defaultData;
        }

        /// <summary>
        /// Deletes the value associated with the specified key
        /// </summary>
        /// <param name="z"></param>
        public void Delete(A z)
        {
            this.Remove(z);
        }

        /// <summary>
        /// Deletes the value associated with the specified key
        /// </summary>
        /// <param name="z"></param>
        public void Remove(A z)
        {
            lock (Lock)
            {
                switch (this.UnderlyingHashType)
                {
                    default:
                    case UnderlyingHashType.Dictionary:
                        if (this.ValuesDictionary.ContainsKey(z))
                            this.ValuesDictionary.Remove(z);
                        break;

                    case UnderlyingHashType.ConcurrentDictionary:
                        VALUE v1;
                        if (this.ValuesConcurrent.ContainsKey(z))
                            this.ValuesConcurrent.TryRemove(z, out v1);
                        break;

                    case UnderlyingHashType.HashTable:
                        if (this.ValuesHash.ContainsKey(z))
                            this.ValuesHash.Remove(z);
                        break;

                    case UnderlyingHashType.SortedDictionary:
                        if (this.ValuesSorted.ContainsKey(z))
                            this.ValuesSorted.Remove(z);
                        break;
                }
            }
        }

        /// <summary>
        /// Gets the value associated with the specified key
        /// </summary>
        /// <param name="z"></param>
        /// <returns></returns>
        public VALUE this[NKeyValue<A, VALUE> z]
        {
            get { return Get(z); }
            set { this.Upsert(true, z.Key, value); }
        }

        /// <summary>
        /// Gets the value associated with the specified key
        /// </summary>
        /// <param name="z"></param>
        /// <returns></returns>
        public VALUE Get(NKeyValue<A, VALUE> z)
        {
            return this.Get(z.Key);
        }

        /// <summary>
        /// Gets the value associated with the specified key
        /// </summary>
        /// <param name="exists"></param>
        /// <param name="defaultData"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public VALUE Get(out bool exists, VALUE defaultData, NKeyValue<A, VALUE> z)
        {
            return this.Get(out exists, defaultData, z.Key);
        }

        /// <summary>
        /// Deletes the value associated with the specified key
        /// </summary>
        /// <param name="z"></param>
        public void Delete(NKeyValue<A, VALUE> z)
        {
            this.Remove(z.Key);
        }

        /// <summary>
        /// Deletes the value associated with the specified key
        /// </summary>
        /// <param name="z"></param>
        public void Remove(NKeyValue<A, VALUE> z)
        {
            this.Remove(z.Key);
        }

        /// <summary>
        /// Determines if the value associated with the specified key exists
        /// </summary>
        /// <param name="z"></param>
        public void ContainsKey(NKeyValue<A, VALUE> z)
        {
            this.ContainsKey(z.Key);
        }

        /// <summary>
        /// Adds the value associated with the specified key
        /// </summary>
        /// <param name="z"></param>
        /// <param name="d"></param>
        public void Add(NKeyValue<A, VALUE> z, VALUE d)
        {
            this.Add(z.Key, d);
        }

        /// <summary>
        /// Determines if the value associated with the specified key exists
        /// </summary>
        /// <param name="z"></param>
        /// <returns></returns>
        public bool ContainsKey(A z)
        {
            switch (this.UnderlyingHashType)
            {
                default:
                case UnderlyingHashType.Dictionary: return this.ValuesDictionary.ContainsKey(z);
                case UnderlyingHashType.ConcurrentDictionary: return this.ValuesConcurrent.ContainsKey(z);
                case UnderlyingHashType.HashTable: return this.ValuesHash.ContainsKey(z);
                case UnderlyingHashType.SortedDictionary: return this.ValuesSorted.ContainsKey(z);
            }
        }

        /// <summary>
        /// Adds the value associated with the specified key
        /// </summary>
        /// <param name="z"></param>
        /// <param name="d"></param>
        public void Add(A z, VALUE d)
        {
            this.Upsert(false, z, d);
        }

        /// <summary>
        /// Upserts the value associated with the specified key
        /// </summary>
        /// <param name="z"></param>
        /// <param name="d"></param>
        public void Upsert(A z, VALUE d)
        {
            this.Upsert(true, z, d);
        }

        /// <summary>
        /// Upserts the value associated with the specified key
        /// </summary>
        /// <param name="replaceExistingData">Replace Existing Data</param>
        /// <param name="z"></param>
        /// <param name="d"></param>
        public void Upsert(bool replaceExistingData, A z, VALUE d)
        {
            lock (Lock)
            {
                int level = 0;
                switch (this.UnderlyingHashType)
                {
                    default:
                    case UnderlyingHashType.Dictionary:
                        if (this.ValuesDictionary.ContainsKey(z))
                        {
                            if (replaceExistingData)
                            {
                                this.ValuesDictionary[z] = d;
                                return;
                            }
                        }
                        else level = 1;

                        if (level == 1) { this.ValuesDictionary.Add(z, d); }
                        break;

                    case UnderlyingHashType.ConcurrentDictionary:
                        if (this.ValuesConcurrent.ContainsKey(z))
                        {
                            if (replaceExistingData)
                            {
                                this.ValuesConcurrent[z] = d;
                                return;
                            }
                        }
                        else level = 1;

                        if (level == 1) { this.ValuesConcurrent.TryAdd(z, d); }
                        break;

                    case UnderlyingHashType.HashTable:
                        if (this.ValuesHash.ContainsKey(z))
                        {
                            if (replaceExistingData)
                            {
                                this.ValuesHash[z] = d;
                                return;
                            }
                        }
                        else level = 1;

                        if (level == 1) { this.ValuesHash.Add(z, d); }
                        break;

                    case UnderlyingHashType.SortedDictionary:
                        if (this.ValuesSorted.ContainsKey(z))
                        {
                            if (replaceExistingData)
                            {
                                this.ValuesSorted[z] = d;
                                return;
                            }
                        }
                        else level = 1;

                        if (level == 1) { this.ValuesSorted.Add(z, d); }
                        break;
                }
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection
        /// </summary>
        /// <returns></returns>
        public IEnumerator<NKeyValue<A, VALUE>> GetEnumerator()
        {
            switch (this.UnderlyingHashType)
            {
                default:
                case UnderlyingHashType.Dictionary:
                    foreach (KeyValuePair<A, VALUE> z in ValuesDictionary)
                    {
                        yield return new NKeyValue<A, VALUE>(z.Key, z.Value);
                    }
                    break;

                case UnderlyingHashType.ConcurrentDictionary:
                    foreach (KeyValuePair<A, VALUE> z in ValuesConcurrent)
                    {
                        yield return new NKeyValue<A, VALUE>(z.Key, z.Value);
                    }
                    break;

                case UnderlyingHashType.HashTable:
                    foreach (DictionaryEntry z in ValuesHash)
                    {
                        yield return new NKeyValue<A, VALUE>((A)z.Key, (VALUE)z.Value);
                    }
                    break;

                case UnderlyingHashType.SortedDictionary:
                    foreach (KeyValuePair<A, VALUE> z in ValuesSorted)
                    {
                        yield return new NKeyValue<A, VALUE>(z.Key, z.Value);
                    }
                    break;
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Returns a copy of the underlying base NKeyHash object.  It could possibly be a reference copy depending on the underlying key and value objects. If you wish to create a value-copy of the NKeyHash object, then you'll have to write one.
        /// </summary>
        /// <returns></returns>
        public NKeyHash<A, VALUE> Copy()
        {
            NKeyHash<A, VALUE> cpy = new NKeyHash<A, VALUE>(this.UnderlyingHashType);
            foreach (var kvp in this)
            {
                cpy.Upsert(true, kvp.Key, kvp.Value);
            }
            return cpy;
        }
    }


}
