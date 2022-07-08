namespace Wulveagfin.NKeys
{
	using System;
	using System.Collections;
	using System.Collections.Generic;

	/// <summary>
	/// NKeyValue contains multiple keys that point to a single object Value. NKeyValue is used to express internal objects within the NKeyHash universe.
	/// </summary>
	public class NKeyValue<A, B, C, VALUE>
	{

		/// <summary>
		/// Key0 of type A, of [key0 key1.... keyN value] pair.
		/// </summary>
		public A Key0 { get; set; }

		/// <summary>
		/// Key1 of type B, of [key0 key1.... keyN value] pair.
		/// </summary>
		public B Key1 { get; set; }

		/// <summary>
		/// Key2 of type C, of [key0 key1.... keyN value] pair.
		/// </summary>
		public C Key2 { get; set; }

		/// <summary>
		/// Value of [key0 key1.... keyN value] pair.
		/// </summary>
		public VALUE Value { get; set; }


		/// <summary>
		/// NKeyValue contains multiple keys that point to a single object Value. NKeyValue is used to express internal objects within the NKeyHash universe.
		/// </summary>
		public NKeyValue()
		{
		}


		/// <summary>
		/// NKeyValue contains multiple keys that point to a single object Value. NKeyValue is used to express internal objects within the NKeyHash universe.
		/// </summary>
		/// <param name="key0">Key0 of type A, of [key0 key1.... keyN value] pair.</param>
		/// <param name="key1">Key1 of type B, of [key0 key1.... keyN value] pair.</param>
		/// <param name="key2">Key2 of type C, of [key0 key1.... keyN value] pair.</param>
		/// <param name="val">Value of [key0 key1.... keyN value] pair.</param>
		public NKeyValue(A key0, B key1, C key2,  VALUE val)
		{
			this.Key0 = key0;
			this.Key1 = key1;
			this.Key2 = key2;
			this.Value = val;
		}


		/// <summary>
		/// Generates a string view of keys and value
		/// </summary>
		public override string ToString()
		{
			return $"{Key0}, {Key1}, {Key2}, {Value}";
		}
	}




	/// <summary>
	/// NKeyHash is a IEnumerable-enabled multidimensional array. It can currently use System.Collections.HashTable, System.Collections.Generic.Dictionary, System.Collections.Generic.SortedDictionary, or System.Collections.Concurrent.ConcurrentDictionary for the underlying base hashable object. NKeyHash uses generics to create nested hashable objects.
	/// </summary>
	public class NKeyHash<A, B, C, VALUE> : IDisposable, IEnumerable<NKeyValue<A, B, C, VALUE>>
	{

		/// <summary>
		/// Used to set what the underlying object that is used to store and access the data.
		/// </summary>
		public UnderlyingHashType UnderlyingHashType { get; private set; } = UnderlyingHashType.HashTable;

		/// <summary>
		/// NKeyHash is a IEnumerable-enabled multidimensional array. It can currently use System.Collections.HashTable, System.Collections.Generic.Dictionary, System.Collections.Generic.SortedDictionary, or System.Collections.Concurrent.ConcurrentDictionary for the underlying base hashable object. NKeyHash uses generics to create nested hashable objects.
		/// </summary>
		/// <param name="cubeUnderlyingHashType">Used to set what the underlying object that is used to store and access the data.</param>
		public NKeyHash(UnderlyingHashType cubeUnderlyingHashType = UnderlyingHashType.Dictionary)
		{
			this.UnderlyingHashType = cubeUnderlyingHashType;
			this.Values = new NKeyHash<A, NKeyHash<B, NKeyHash<C, VALUE>>>(this.UnderlyingHashType);
		}

		/// <summary>
		/// Private internal storage object for Values
		/// </summary>
		private NKeyHash<A, NKeyHash<B, NKeyHash<C, VALUE>>> Values;


		/// <summary>
		/// Determines whether a sequence contains any elements.
		/// </summary>
		/// <returns>true if the source sequence contains any elements; otherwise, false.</returns>
		public bool Any()
		{
			return this.Values.Any();
		}


		/// <summary>
		/// Gets the number of [key key...key value] collections contained at the level of the [key0 key1.... keyN] specified.
		/// </summary>
		/// <param name="a">Key0 of type A, of [key0 key1.... keyN value] pair.</param>
		/// <param name="b">Key1 of type B, of [key0 key1.... keyN value] pair.</param>
		/// <returns>Gets the number of [key key...key value] collections contained at the level of the [key0 key1.... keyN] specified.</returns>
		public int Count(A a, B b)
		{
			NKeyHash<B, NKeyHash<C, VALUE>> bsA1l;
			if (this.Values.TryGetValue(a, out bsA1l))
			{
				NKeyHash<C, VALUE> csA1l;
				if (bsA1l.TryGetValue(b, out csA1l))
				{
					return csA1l.Count;
				}
			}
			return 0;
		}


		/// <summary>
		/// Gets the number of [key key...key value] collections contained at the level of the [key0 key1.... keyN] specified.
		/// </summary>
		/// <param name="a">Key0 of type A, of [key0 key1.... keyN value] pair.</param>
		/// <returns>Gets the number of [key key...key value] collections contained at the level of the [key0 key1.... keyN] specified.</returns>
		public int Count(A a)
		{
			NKeyHash<B, NKeyHash<C, VALUE>> bsA1l;
			if (this.Values.TryGetValue(a, out bsA1l))
			{
				return bsA1l.Count;
			}
			return 0;
		}


		/// <summary>
		/// Gets or Sets the value associated with the specified key.
		/// </summary>
		/// <param name="a">Key0 of type A, of [key0 key1.... keyN value] pair.</param>
		/// <param name="b">Key1 of type B, of [key0 key1.... keyN value] pair.</param>
		/// <param name="c">Key2 of type C, of [key0 key1.... keyN value] pair.</param>
		/// <returns>Returns the VALUE portion of [key0 key1.... keyN value], if it exists, otherwise Default(VALUE) (or if specified the defaultData) is returned.</returns>
		public VALUE this[A a, B b, C c]
		{
			get { return Get(a, b, c); }
			set { this.Upsert(true, a, b, c, value); }
		}


		/// <summary>
		/// Gets the value associated with the specified [key0 key1.... keyN value].
		/// </summary>
		/// <param name="a">Key0 of type A, of [key0 key1.... keyN value] pair.</param>
		/// <param name="b">Key1 of type B, of [key0 key1.... keyN value] pair.</param>
		/// <param name="c">Key2 of type C, of [key0 key1.... keyN value] pair.</param>
		/// <returns>Returns the VALUE portion of [key0 key1.... keyN value], if it exists, otherwise Default(VALUE) (or if specified the defaultData) is returned.</returns>
		public VALUE Get(A a, B b, C c)
		{
			return this.Values[a][b][c];
		}


		/// <summary>
		/// Gets the value associated with the specified [key0 key1.... keyN value].
		/// </summary>
		/// <param name="exists">Returns if [key key...key value] exists</param>
		/// <param name="defaultData">Specify the default for VALUE type you want returned if the [key0 key1.... keyN] is not found.</param>
		/// <param name="a">Key0 of type A, of [key0 key1.... keyN value] pair.</param>
		/// <param name="b">Key1 of type B, of [key0 key1.... keyN value] pair.</param>
		/// <param name="c">Key2 of type C, of [key0 key1.... keyN value] pair.</param>
		/// <returns>Returns the VALUE portion of [key0 key1.... keyN value], if it exists, otherwise Default(VALUE) (or if specified the defaultData) is returned.</returns>
		public VALUE Get(out bool exists, VALUE defaultData, A a, B b, C c)
		{
			exists = false;

			NKeyHash<B, NKeyHash<C, VALUE>> bsA1l;
			if (this.Values.TryGetValue(a, out bsA1l))
			{
				NKeyHash<C, VALUE> csA1l;
				if (bsA1l.TryGetValue(b, out csA1l))
				{
					VALUE val;
					if (csA1l.TryGetValue(c, out val))
					{
						exists = true;
						return val;
					}
				}
			}
			return defaultData;
		}


		/// <summary>
		/// Gets the value associated with the specified [key0 key1.... keyN value].
		/// </summary>
		/// <param name="a">Key0 of type A, of [key0 key1.... keyN value] pair.</param>
		/// <param name="b">Key1 of type B, of [key0 key1.... keyN value] pair.</param>
		/// <param name="c">Key2 of type C, of [key0 key1.... keyN value] pair.</param>
		/// <param name="val">Value of [key0 key1.... keyN value] pair.</param>
		/// <returns>Returns the VALUE portion of [key0 key1.... keyN value], if it exists, otherwise Default(VALUE) (or if specified the defaultData) is returned.</returns>
		public bool TryGetValue(A a, B b, C c, out VALUE val)
		{
			bool exist = false;
			val = Get(out exist, default(VALUE), a, b, c);
			return exist;
		}


		/// <summary>
		/// Removes all keys and values.
		/// </summary>
		public void Clear()
		{
			this.Values = new NKeyHash<A, NKeyHash<B, NKeyHash<C, VALUE>>>(this.UnderlyingHashType);
		}


		/// <summary>
		/// Adds the value associated with the specified [key0 key1.... keyN].
		/// </summary>
		/// <param name="a">Key0 of type A, of [key0 key1.... keyN value] pair.</param>
		/// <param name="b">Key1 of type B, of [key0 key1.... keyN value] pair.</param>
		/// <param name="c">Key2 of type C, of [key0 key1.... keyN value] pair.</param>
		/// <param name="val">Value of [key0 key1.... keyN value] pair.</param>
		public void Add(A a, B b, C c, VALUE val)
		{
			this.Upsert(false, a, b, c, val);
		}


		/// <summary>
		/// Deletes the value associated with the specified [key0 key1.... keyN].
		/// </summary>
		/// <param name="a">Key0 of type A, of [key0 key1.... keyN value] pair.</param>
		/// <param name="b">Key1 of type B, of [key0 key1.... keyN value] pair.</param>
		/// <param name="c">Key2 of type C, of [key0 key1.... keyN value] pair.</param>
		public void Delete(A a, B b, C c)
		{
			this.Remove(a, b, c);
		}


		/// <summary>
		/// Deletes the value associated with the specified [key0 key1.... keyN].
		/// </summary>
		/// <param name="a">Key0 of type A, of [key0 key1.... keyN value] pair.</param>
		/// <param name="b">Key1 of type B, of [key0 key1.... keyN value] pair.</param>
		/// <param name="c">Key2 of type C, of [key0 key1.... keyN value] pair.</param>
		public void Remove(A a, B b, C c)
		{
			 NKeyHash<B, NKeyHash<C, VALUE>> bsA1l;
			if (this.Values.TryGetValue(a, out bsA1l))
			{
				 NKeyHash<C, VALUE> csA1l;
				if (bsA1l.TryGetValue(b, out csA1l))
				{
					csA1l .Remove(c);
				}
			}
		}


		/// <summary>
		/// Determines if the value associated with the specified [key0 key1.... keyN] exists.
		/// </summary>
		/// <param name="a">Key0 of type A, of [key0 key1.... keyN value] pair.</param>
		/// <returns>true if the source sequence contains any elements; otherwise, false.</returns>
		public bool ContainsKey(A a)
		{
			if (this.Values.ContainsKey(a))
				return true;
			return false;
		}


		/// <summary>
		/// Determines if the value associated with the specified [key0 key1.... keyN] exists.
		/// </summary>
		/// <param name="a">Key0 of type A, of [key0 key1.... keyN value] pair.</param>
		/// <param name="b">Key1 of type B, of [key0 key1.... keyN value] pair.</param>
		/// <returns>true if the source sequence contains any elements; otherwise, false.</returns>
		public bool ContainsKey(A a, B b)
		{
			if (this.Values.ContainsKey(a))
				if (this.Values[a].ContainsKey(b))
					return true;
			return false;
		}


		/// <summary>
		/// Determines if the value associated with the specified [key0 key1.... keyN] exists.
		/// </summary>
		/// <param name="a">Key0 of type A, of [key0 key1.... keyN value] pair.</param>
		/// <param name="b">Key1 of type B, of [key0 key1.... keyN value] pair.</param>
		/// <param name="c">Key2 of type C, of [key0 key1.... keyN value] pair.</param>
		/// <returns>true if the source sequence contains any elements; otherwise, false.</returns>
		public bool ContainsKey(A a, B b, C c)
		{
			if (this.Values.ContainsKey(a))
				if (this.Values[a].ContainsKey(b))
					if (this.Values[a][b].ContainsKey(c))
						return true;
			return false;
		}


		/// <summary>
		/// Upserts the value associated with the specified [key0 key1.... keyN].
		/// </summary>
		/// <param name="a">Key0 of type A, of [key0 key1.... keyN value] pair.</param>
		/// <param name="b">Key1 of type B, of [key0 key1.... keyN value] pair.</param>
		/// <param name="c">Key2 of type C, of [key0 key1.... keyN value] pair.</param>
		/// <param name="val">Value of [key0 key1.... keyN value] pair.</param>
		public void Upsert(A a, B b, C c, VALUE val)
		{
			this.Upsert(true, a, b, c,  val);
		}


		/// <summary>
		/// Upserts the value associated with the specified [key0 key1.... keyN].
		/// </summary>
		/// <param name="replaceExistingData">Specify if the existing val should be overwritten if the [key0 key1.... keyN value] already exists.</param>
		/// <param name="a">Key0 of type A, of [key0 key1.... keyN value] pair.</param>
		/// <param name="b">Key1 of type B, of [key0 key1.... keyN value] pair.</param>
		/// <param name="c">Key2 of type C, of [key0 key1.... keyN value] pair.</param>
		/// <param name="val">Value of [key0 key1.... keyN value] pair.</param>
		public void Upsert(bool replaceExistingData, A a, B b, C c, VALUE val)
		{
			int level = 0;
			NKeyHash<B, NKeyHash<C, VALUE>> bsA1l = null;
			NKeyHash<C, VALUE> csA1l = null;
			if (this.Values.TryGetValue(a, out bsA1l))
			{
				if (bsA1l.TryGetValue(b, out csA1l))
				{
					if (csA1l.ContainsKey(c))
					{
						if (replaceExistingData)
						{
							csA1l[c] = val;
						}
						return;
					}
					else level = 3;
				}
				else level = 2;
			}
			else level = 1;

			if (level == 1) { bsA1l = new  NKeyHash<B, NKeyHash<C, VALUE>>(this.UnderlyingHashType); this.Values.Add(a, bsA1l); level++; }
			if (level == 2) { csA1l = new  NKeyHash<C, VALUE>(this.UnderlyingHashType); bsA1l.Add(b, csA1l); level++; }
			if (level == 3) {csA1l.Add(c, val); }
		}



		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			this.Values = null;
		}



		/// <summary>
		/// Returns an enumerator that iterates through the collection.
		/// </summary>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}


		/// <summary>
		/// Returns an enumerator that iterates through the collection.
		/// </summary>
		public IEnumerator<NKeyValue<A, B, C, VALUE>> GetEnumerator()
		{
			foreach (NKeyValue<A, NKeyHash<B, NKeyHash<C, VALUE>>> a in  this.Values)
			{
				foreach (NKeyValue<B, NKeyHash<C, VALUE>> b in a.Value)
				{
					foreach (NKeyValue<C, VALUE> c in b.Value)
					{
						yield return new NKeyValue<A, B, C, VALUE>(a.Key, b.Key, c.Key, c.Value);
					}
				}
			}
		}

	}
}
