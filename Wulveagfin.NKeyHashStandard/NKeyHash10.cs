namespace Wulveagfin.NKeys
{
	using System;
	using System.Collections;
	using System.Collections.Generic;

	/// <summary>
	/// NKeyValue contains multiple keys that point to a single object Value. NKeyValue is used to express internal objects within the NKeyHash universe.
	/// </summary>
	public class NKeyValue<A, B, C, D, E, F, G, H, I, J, VALUE>
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
		/// Key3 of type D, of [key0 key1.... keyN value] pair.
		/// </summary>
		public D Key3 { get; set; }

		/// <summary>
		/// Key4 of type E, of [key0 key1.... keyN value] pair.
		/// </summary>
		public E Key4 { get; set; }

		/// <summary>
		/// Key5 of type F, of [key0 key1.... keyN value] pair.
		/// </summary>
		public F Key5 { get; set; }

		/// <summary>
		/// Key6 of type G, of [key0 key1.... keyN value] pair.
		/// </summary>
		public G Key6 { get; set; }

		/// <summary>
		/// Key7 of type H, of [key0 key1.... keyN value] pair.
		/// </summary>
		public H Key7 { get; set; }

		/// <summary>
		/// Key8 of type I, of [key0 key1.... keyN value] pair.
		/// </summary>
		public I Key8 { get; set; }

		/// <summary>
		/// Key9 of type J, of [key0 key1.... keyN value] pair.
		/// </summary>
		public J Key9 { get; set; }

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
		/// <param name="key3">Key3 of type D, of [key0 key1.... keyN value] pair.</param>
		/// <param name="key4">Key4 of type E, of [key0 key1.... keyN value] pair.</param>
		/// <param name="key5">Key5 of type F, of [key0 key1.... keyN value] pair.</param>
		/// <param name="key6">Key6 of type G, of [key0 key1.... keyN value] pair.</param>
		/// <param name="key7">Key7 of type H, of [key0 key1.... keyN value] pair.</param>
		/// <param name="key8">Key8 of type I, of [key0 key1.... keyN value] pair.</param>
		/// <param name="key9">Key9 of type J, of [key0 key1.... keyN value] pair.</param>
		/// <param name="val">Value of [key0 key1.... keyN value] pair.</param>
		public NKeyValue(A key0, B key1, C key2, D key3, E key4, F key5, G key6, H key7, I key8, J key9,  VALUE val)
		{
			this.Key0 = key0;
			this.Key1 = key1;
			this.Key2 = key2;
			this.Key3 = key3;
			this.Key4 = key4;
			this.Key5 = key5;
			this.Key6 = key6;
			this.Key7 = key7;
			this.Key8 = key8;
			this.Key9 = key9;
			this.Value = val;
		}


		/// <summary>
		/// Generates a string view of keys and value
		/// </summary>
		public override string ToString()
		{
			return $"{Key0}, {Key1}, {Key2}, {Key3}, {Key4}, {Key5}, {Key6}, {Key7}, {Key8}, {Key9}, {Value}";
		}
	}




	/// <summary>
	/// NKeyHash is a IEnumerable-enabled multidimensional array. It can currently use System.Collections.HashTable, System.Collections.Generic.Dictionary, System.Collections.Generic.SortedDictionary, or System.Collections.Concurrent.ConcurrentDictionary for the underlying base hashable object. NKeyHash uses generics to create nested hashable objects.
	/// </summary>
	public class NKeyHash<A, B, C, D, E, F, G, H, I, J, VALUE> : IDisposable, IEnumerable<NKeyValue<A, B, C, D, E, F, G, H, I, J, VALUE>>
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
			this.Values = new NKeyHash<A, NKeyHash<B, NKeyHash<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>>>>>>>>(this.UnderlyingHashType);
		}

		/// <summary>
		/// Private internal storage object for Values
		/// </summary>
		private NKeyHash<A, NKeyHash<B, NKeyHash<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>>>>>>>> Values;


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
		/// <param name="c">Key2 of type C, of [key0 key1.... keyN value] pair.</param>
		/// <param name="d">Key3 of type D, of [key0 key1.... keyN value] pair.</param>
		/// <param name="e">Key4 of type E, of [key0 key1.... keyN value] pair.</param>
		/// <param name="f">Key5 of type F, of [key0 key1.... keyN value] pair.</param>
		/// <param name="g">Key6 of type G, of [key0 key1.... keyN value] pair.</param>
		/// <param name="h">Key7 of type H, of [key0 key1.... keyN value] pair.</param>
		/// <param name="i">Key8 of type I, of [key0 key1.... keyN value] pair.</param>
		/// <returns>Gets the number of [key key...key value] collections contained at the level of the [key0 key1.... keyN] specified.</returns>
		public int Count(A a, B b, C c, D d, E e, F f, G g, H h, I i)
		{
			NKeyHash<B, NKeyHash<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>>>>>>> bsA1l;
			if (this.Values.TryGetValue(a, out bsA1l))
			{
				NKeyHash<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>>>>>> csA1l;
				if (bsA1l.TryGetValue(b, out csA1l))
				{
					NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>>>>> dsA1l;
					if (csA1l.TryGetValue(c, out dsA1l))
					{
						NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>>>> esA1l;
						if (dsA1l.TryGetValue(d, out esA1l))
						{
							NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>>> fsA1l;
							if (esA1l.TryGetValue(e, out fsA1l))
							{
								NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>> gsA1l;
								if (fsA1l.TryGetValue(f, out gsA1l))
								{
									NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>> hsA1l;
									if (gsA1l.TryGetValue(g, out hsA1l))
									{
										NKeyHash<I, NKeyHash<J, VALUE>> isA1l;
										if (hsA1l.TryGetValue(h, out isA1l))
										{
											NKeyHash<J, VALUE> jsA1l;
											if (isA1l.TryGetValue(i, out jsA1l))
											{
												return jsA1l.Count;
											}
										}
									}
								}
							}
						}
					}
				}
			}
			return 0;
		}


		/// <summary>
		/// Gets the number of [key key...key value] collections contained at the level of the [key0 key1.... keyN] specified.
		/// </summary>
		/// <param name="a">Key0 of type A, of [key0 key1.... keyN value] pair.</param>
		/// <param name="b">Key1 of type B, of [key0 key1.... keyN value] pair.</param>
		/// <param name="c">Key2 of type C, of [key0 key1.... keyN value] pair.</param>
		/// <param name="d">Key3 of type D, of [key0 key1.... keyN value] pair.</param>
		/// <param name="e">Key4 of type E, of [key0 key1.... keyN value] pair.</param>
		/// <param name="f">Key5 of type F, of [key0 key1.... keyN value] pair.</param>
		/// <param name="g">Key6 of type G, of [key0 key1.... keyN value] pair.</param>
		/// <param name="h">Key7 of type H, of [key0 key1.... keyN value] pair.</param>
		/// <returns>Gets the number of [key key...key value] collections contained at the level of the [key0 key1.... keyN] specified.</returns>
		public int Count(A a, B b, C c, D d, E e, F f, G g, H h)
		{
			NKeyHash<B, NKeyHash<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>>>>>>> bsA1l;
			if (this.Values.TryGetValue(a, out bsA1l))
			{
				NKeyHash<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>>>>>> csA1l;
				if (bsA1l.TryGetValue(b, out csA1l))
				{
					NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>>>>> dsA1l;
					if (csA1l.TryGetValue(c, out dsA1l))
					{
						NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>>>> esA1l;
						if (dsA1l.TryGetValue(d, out esA1l))
						{
							NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>>> fsA1l;
							if (esA1l.TryGetValue(e, out fsA1l))
							{
								NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>> gsA1l;
								if (fsA1l.TryGetValue(f, out gsA1l))
								{
									NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>> hsA1l;
									if (gsA1l.TryGetValue(g, out hsA1l))
									{
										NKeyHash<I, NKeyHash<J, VALUE>> isA1l;
										if (hsA1l.TryGetValue(h, out isA1l))
										{
											return isA1l.Count;
										}
									}
								}
							}
						}
					}
				}
			}
			return 0;
		}


		/// <summary>
		/// Gets the number of [key key...key value] collections contained at the level of the [key0 key1.... keyN] specified.
		/// </summary>
		/// <param name="a">Key0 of type A, of [key0 key1.... keyN value] pair.</param>
		/// <param name="b">Key1 of type B, of [key0 key1.... keyN value] pair.</param>
		/// <param name="c">Key2 of type C, of [key0 key1.... keyN value] pair.</param>
		/// <param name="d">Key3 of type D, of [key0 key1.... keyN value] pair.</param>
		/// <param name="e">Key4 of type E, of [key0 key1.... keyN value] pair.</param>
		/// <param name="f">Key5 of type F, of [key0 key1.... keyN value] pair.</param>
		/// <param name="g">Key6 of type G, of [key0 key1.... keyN value] pair.</param>
		/// <returns>Gets the number of [key key...key value] collections contained at the level of the [key0 key1.... keyN] specified.</returns>
		public int Count(A a, B b, C c, D d, E e, F f, G g)
		{
			NKeyHash<B, NKeyHash<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>>>>>>> bsA1l;
			if (this.Values.TryGetValue(a, out bsA1l))
			{
				NKeyHash<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>>>>>> csA1l;
				if (bsA1l.TryGetValue(b, out csA1l))
				{
					NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>>>>> dsA1l;
					if (csA1l.TryGetValue(c, out dsA1l))
					{
						NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>>>> esA1l;
						if (dsA1l.TryGetValue(d, out esA1l))
						{
							NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>>> fsA1l;
							if (esA1l.TryGetValue(e, out fsA1l))
							{
								NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>> gsA1l;
								if (fsA1l.TryGetValue(f, out gsA1l))
								{
									NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>> hsA1l;
									if (gsA1l.TryGetValue(g, out hsA1l))
									{
										return hsA1l.Count;
									}
								}
							}
						}
					}
				}
			}
			return 0;
		}


		/// <summary>
		/// Gets the number of [key key...key value] collections contained at the level of the [key0 key1.... keyN] specified.
		/// </summary>
		/// <param name="a">Key0 of type A, of [key0 key1.... keyN value] pair.</param>
		/// <param name="b">Key1 of type B, of [key0 key1.... keyN value] pair.</param>
		/// <param name="c">Key2 of type C, of [key0 key1.... keyN value] pair.</param>
		/// <param name="d">Key3 of type D, of [key0 key1.... keyN value] pair.</param>
		/// <param name="e">Key4 of type E, of [key0 key1.... keyN value] pair.</param>
		/// <param name="f">Key5 of type F, of [key0 key1.... keyN value] pair.</param>
		/// <returns>Gets the number of [key key...key value] collections contained at the level of the [key0 key1.... keyN] specified.</returns>
		public int Count(A a, B b, C c, D d, E e, F f)
		{
			NKeyHash<B, NKeyHash<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>>>>>>> bsA1l;
			if (this.Values.TryGetValue(a, out bsA1l))
			{
				NKeyHash<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>>>>>> csA1l;
				if (bsA1l.TryGetValue(b, out csA1l))
				{
					NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>>>>> dsA1l;
					if (csA1l.TryGetValue(c, out dsA1l))
					{
						NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>>>> esA1l;
						if (dsA1l.TryGetValue(d, out esA1l))
						{
							NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>>> fsA1l;
							if (esA1l.TryGetValue(e, out fsA1l))
							{
								NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>> gsA1l;
								if (fsA1l.TryGetValue(f, out gsA1l))
								{
									return gsA1l.Count;
								}
							}
						}
					}
				}
			}
			return 0;
		}


		/// <summary>
		/// Gets the number of [key key...key value] collections contained at the level of the [key0 key1.... keyN] specified.
		/// </summary>
		/// <param name="a">Key0 of type A, of [key0 key1.... keyN value] pair.</param>
		/// <param name="b">Key1 of type B, of [key0 key1.... keyN value] pair.</param>
		/// <param name="c">Key2 of type C, of [key0 key1.... keyN value] pair.</param>
		/// <param name="d">Key3 of type D, of [key0 key1.... keyN value] pair.</param>
		/// <param name="e">Key4 of type E, of [key0 key1.... keyN value] pair.</param>
		/// <returns>Gets the number of [key key...key value] collections contained at the level of the [key0 key1.... keyN] specified.</returns>
		public int Count(A a, B b, C c, D d, E e)
		{
			NKeyHash<B, NKeyHash<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>>>>>>> bsA1l;
			if (this.Values.TryGetValue(a, out bsA1l))
			{
				NKeyHash<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>>>>>> csA1l;
				if (bsA1l.TryGetValue(b, out csA1l))
				{
					NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>>>>> dsA1l;
					if (csA1l.TryGetValue(c, out dsA1l))
					{
						NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>>>> esA1l;
						if (dsA1l.TryGetValue(d, out esA1l))
						{
							NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>>> fsA1l;
							if (esA1l.TryGetValue(e, out fsA1l))
							{
								return fsA1l.Count;
							}
						}
					}
				}
			}
			return 0;
		}


		/// <summary>
		/// Gets the number of [key key...key value] collections contained at the level of the [key0 key1.... keyN] specified.
		/// </summary>
		/// <param name="a">Key0 of type A, of [key0 key1.... keyN value] pair.</param>
		/// <param name="b">Key1 of type B, of [key0 key1.... keyN value] pair.</param>
		/// <param name="c">Key2 of type C, of [key0 key1.... keyN value] pair.</param>
		/// <param name="d">Key3 of type D, of [key0 key1.... keyN value] pair.</param>
		/// <returns>Gets the number of [key key...key value] collections contained at the level of the [key0 key1.... keyN] specified.</returns>
		public int Count(A a, B b, C c, D d)
		{
			NKeyHash<B, NKeyHash<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>>>>>>> bsA1l;
			if (this.Values.TryGetValue(a, out bsA1l))
			{
				NKeyHash<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>>>>>> csA1l;
				if (bsA1l.TryGetValue(b, out csA1l))
				{
					NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>>>>> dsA1l;
					if (csA1l.TryGetValue(c, out dsA1l))
					{
						NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>>>> esA1l;
						if (dsA1l.TryGetValue(d, out esA1l))
						{
							return esA1l.Count;
						}
					}
				}
			}
			return 0;
		}


		/// <summary>
		/// Gets the number of [key key...key value] collections contained at the level of the [key0 key1.... keyN] specified.
		/// </summary>
		/// <param name="a">Key0 of type A, of [key0 key1.... keyN value] pair.</param>
		/// <param name="b">Key1 of type B, of [key0 key1.... keyN value] pair.</param>
		/// <param name="c">Key2 of type C, of [key0 key1.... keyN value] pair.</param>
		/// <returns>Gets the number of [key key...key value] collections contained at the level of the [key0 key1.... keyN] specified.</returns>
		public int Count(A a, B b, C c)
		{
			NKeyHash<B, NKeyHash<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>>>>>>> bsA1l;
			if (this.Values.TryGetValue(a, out bsA1l))
			{
				NKeyHash<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>>>>>> csA1l;
				if (bsA1l.TryGetValue(b, out csA1l))
				{
					NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>>>>> dsA1l;
					if (csA1l.TryGetValue(c, out dsA1l))
					{
						return dsA1l.Count;
					}
				}
			}
			return 0;
		}


		/// <summary>
		/// Gets the number of [key key...key value] collections contained at the level of the [key0 key1.... keyN] specified.
		/// </summary>
		/// <param name="a">Key0 of type A, of [key0 key1.... keyN value] pair.</param>
		/// <param name="b">Key1 of type B, of [key0 key1.... keyN value] pair.</param>
		/// <returns>Gets the number of [key key...key value] collections contained at the level of the [key0 key1.... keyN] specified.</returns>
		public int Count(A a, B b)
		{
			NKeyHash<B, NKeyHash<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>>>>>>> bsA1l;
			if (this.Values.TryGetValue(a, out bsA1l))
			{
				NKeyHash<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>>>>>> csA1l;
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
			NKeyHash<B, NKeyHash<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>>>>>>> bsA1l;
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
		/// <param name="d">Key3 of type D, of [key0 key1.... keyN value] pair.</param>
		/// <param name="e">Key4 of type E, of [key0 key1.... keyN value] pair.</param>
		/// <param name="f">Key5 of type F, of [key0 key1.... keyN value] pair.</param>
		/// <param name="g">Key6 of type G, of [key0 key1.... keyN value] pair.</param>
		/// <param name="h">Key7 of type H, of [key0 key1.... keyN value] pair.</param>
		/// <param name="i">Key8 of type I, of [key0 key1.... keyN value] pair.</param>
		/// <param name="j">Key9 of type J, of [key0 key1.... keyN value] pair.</param>
		/// <returns>Returns the VALUE portion of [key0 key1.... keyN value], if it exists, otherwise Default(VALUE) (or if specified the defaultData) is returned.</returns>
		public VALUE this[A a, B b, C c, D d, E e, F f, G g, H h, I i, J j]
		{
			get { return Get(a, b, c, d, e, f, g, h, i, j); }
			set { this.Upsert(true, a, b, c, d, e, f, g, h, i, j, value); }
		}


		/// <summary>
		/// Gets the value associated with the specified [key0 key1.... keyN value].
		/// </summary>
		/// <param name="a">Key0 of type A, of [key0 key1.... keyN value] pair.</param>
		/// <param name="b">Key1 of type B, of [key0 key1.... keyN value] pair.</param>
		/// <param name="c">Key2 of type C, of [key0 key1.... keyN value] pair.</param>
		/// <param name="d">Key3 of type D, of [key0 key1.... keyN value] pair.</param>
		/// <param name="e">Key4 of type E, of [key0 key1.... keyN value] pair.</param>
		/// <param name="f">Key5 of type F, of [key0 key1.... keyN value] pair.</param>
		/// <param name="g">Key6 of type G, of [key0 key1.... keyN value] pair.</param>
		/// <param name="h">Key7 of type H, of [key0 key1.... keyN value] pair.</param>
		/// <param name="i">Key8 of type I, of [key0 key1.... keyN value] pair.</param>
		/// <param name="j">Key9 of type J, of [key0 key1.... keyN value] pair.</param>
		/// <returns>Returns the VALUE portion of [key0 key1.... keyN value], if it exists, otherwise Default(VALUE) (or if specified the defaultData) is returned.</returns>
		public VALUE Get(A a, B b, C c, D d, E e, F f, G g, H h, I i, J j)
		{
			return this.Values[a][b][c][d][e][f][g][h][i][j];
		}


		/// <summary>
		/// Gets the value associated with the specified [key0 key1.... keyN value].
		/// </summary>
		/// <param name="exists">Returns if [key key...key value] exists</param>
		/// <param name="defaultData">Specify the default for VALUE type you want returned if the [key0 key1.... keyN] is not found.</param>
		/// <param name="a">Key0 of type A, of [key0 key1.... keyN value] pair.</param>
		/// <param name="b">Key1 of type B, of [key0 key1.... keyN value] pair.</param>
		/// <param name="c">Key2 of type C, of [key0 key1.... keyN value] pair.</param>
		/// <param name="d">Key3 of type D, of [key0 key1.... keyN value] pair.</param>
		/// <param name="e">Key4 of type E, of [key0 key1.... keyN value] pair.</param>
		/// <param name="f">Key5 of type F, of [key0 key1.... keyN value] pair.</param>
		/// <param name="g">Key6 of type G, of [key0 key1.... keyN value] pair.</param>
		/// <param name="h">Key7 of type H, of [key0 key1.... keyN value] pair.</param>
		/// <param name="i">Key8 of type I, of [key0 key1.... keyN value] pair.</param>
		/// <param name="j">Key9 of type J, of [key0 key1.... keyN value] pair.</param>
		/// <returns>Returns the VALUE portion of [key0 key1.... keyN value], if it exists, otherwise Default(VALUE) (or if specified the defaultData) is returned.</returns>
		public VALUE Get(out bool exists, VALUE defaultData, A a, B b, C c, D d, E e, F f, G g, H h, I i, J j)
		{
			exists = false;

			NKeyHash<B, NKeyHash<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>>>>>>> bsA1l;
			if (this.Values.TryGetValue(a, out bsA1l))
			{
				NKeyHash<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>>>>>> csA1l;
				if (bsA1l.TryGetValue(b, out csA1l))
				{
					NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>>>>> dsA1l;
					if (csA1l.TryGetValue(c, out dsA1l))
					{
						NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>>>> esA1l;
						if (dsA1l.TryGetValue(d, out esA1l))
						{
							NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>>> fsA1l;
							if (esA1l.TryGetValue(e, out fsA1l))
							{
								NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>> gsA1l;
								if (fsA1l.TryGetValue(f, out gsA1l))
								{
									NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>> hsA1l;
									if (gsA1l.TryGetValue(g, out hsA1l))
									{
										NKeyHash<I, NKeyHash<J, VALUE>> isA1l;
										if (hsA1l.TryGetValue(h, out isA1l))
										{
											NKeyHash<J, VALUE> jsA1l;
											if (isA1l.TryGetValue(i, out jsA1l))
											{
												VALUE val;
												if (jsA1l.TryGetValue(j, out val))
												{
													exists = true;
													return val;
												}
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


		/// <summary>
		/// Gets the value associated with the specified [key0 key1.... keyN value].
		/// </summary>
		/// <param name="a">Key0 of type A, of [key0 key1.... keyN value] pair.</param>
		/// <param name="b">Key1 of type B, of [key0 key1.... keyN value] pair.</param>
		/// <param name="c">Key2 of type C, of [key0 key1.... keyN value] pair.</param>
		/// <param name="d">Key3 of type D, of [key0 key1.... keyN value] pair.</param>
		/// <param name="e">Key4 of type E, of [key0 key1.... keyN value] pair.</param>
		/// <param name="f">Key5 of type F, of [key0 key1.... keyN value] pair.</param>
		/// <param name="g">Key6 of type G, of [key0 key1.... keyN value] pair.</param>
		/// <param name="h">Key7 of type H, of [key0 key1.... keyN value] pair.</param>
		/// <param name="i">Key8 of type I, of [key0 key1.... keyN value] pair.</param>
		/// <param name="j">Key9 of type J, of [key0 key1.... keyN value] pair.</param>
		/// <param name="val">Value of [key0 key1.... keyN value] pair.</param>
		/// <returns>Returns the VALUE portion of [key0 key1.... keyN value], if it exists, otherwise Default(VALUE) (or if specified the defaultData) is returned.</returns>
		public bool TryGetValue(A a, B b, C c, D d, E e, F f, G g, H h, I i, J j, out VALUE val)
		{
			bool exist = false;
			val = Get(out exist, default(VALUE), a, b, c, d, e, f, g, h, i, j);
			return exist;
		}


		/// <summary>
		/// Removes all keys and values.
		/// </summary>
		public void Clear()
		{
			this.Values = new NKeyHash<A, NKeyHash<B, NKeyHash<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>>>>>>>>(this.UnderlyingHashType);
		}


		/// <summary>
		/// Adds the value associated with the specified [key0 key1.... keyN].
		/// </summary>
		/// <param name="a">Key0 of type A, of [key0 key1.... keyN value] pair.</param>
		/// <param name="b">Key1 of type B, of [key0 key1.... keyN value] pair.</param>
		/// <param name="c">Key2 of type C, of [key0 key1.... keyN value] pair.</param>
		/// <param name="d">Key3 of type D, of [key0 key1.... keyN value] pair.</param>
		/// <param name="e">Key4 of type E, of [key0 key1.... keyN value] pair.</param>
		/// <param name="f">Key5 of type F, of [key0 key1.... keyN value] pair.</param>
		/// <param name="g">Key6 of type G, of [key0 key1.... keyN value] pair.</param>
		/// <param name="h">Key7 of type H, of [key0 key1.... keyN value] pair.</param>
		/// <param name="i">Key8 of type I, of [key0 key1.... keyN value] pair.</param>
		/// <param name="j">Key9 of type J, of [key0 key1.... keyN value] pair.</param>
		/// <param name="val">Value of [key0 key1.... keyN value] pair.</param>
		public void Add(A a, B b, C c, D d, E e, F f, G g, H h, I i, J j, VALUE val)
		{
			this.Upsert(false, a, b, c, d, e, f, g, h, i, j, val);
		}


		/// <summary>
		/// Deletes the value associated with the specified [key0 key1.... keyN].
		/// </summary>
		/// <param name="a">Key0 of type A, of [key0 key1.... keyN value] pair.</param>
		/// <param name="b">Key1 of type B, of [key0 key1.... keyN value] pair.</param>
		/// <param name="c">Key2 of type C, of [key0 key1.... keyN value] pair.</param>
		/// <param name="d">Key3 of type D, of [key0 key1.... keyN value] pair.</param>
		/// <param name="e">Key4 of type E, of [key0 key1.... keyN value] pair.</param>
		/// <param name="f">Key5 of type F, of [key0 key1.... keyN value] pair.</param>
		/// <param name="g">Key6 of type G, of [key0 key1.... keyN value] pair.</param>
		/// <param name="h">Key7 of type H, of [key0 key1.... keyN value] pair.</param>
		/// <param name="i">Key8 of type I, of [key0 key1.... keyN value] pair.</param>
		/// <param name="j">Key9 of type J, of [key0 key1.... keyN value] pair.</param>
		public void Delete(A a, B b, C c, D d, E e, F f, G g, H h, I i, J j)
		{
			this.Remove(a, b, c, d, e, f, g, h, i, j);
		}


		/// <summary>
		/// Deletes the value associated with the specified [key0 key1.... keyN].
		/// </summary>
		/// <param name="a">Key0 of type A, of [key0 key1.... keyN value] pair.</param>
		/// <param name="b">Key1 of type B, of [key0 key1.... keyN value] pair.</param>
		/// <param name="c">Key2 of type C, of [key0 key1.... keyN value] pair.</param>
		/// <param name="d">Key3 of type D, of [key0 key1.... keyN value] pair.</param>
		/// <param name="e">Key4 of type E, of [key0 key1.... keyN value] pair.</param>
		/// <param name="f">Key5 of type F, of [key0 key1.... keyN value] pair.</param>
		/// <param name="g">Key6 of type G, of [key0 key1.... keyN value] pair.</param>
		/// <param name="h">Key7 of type H, of [key0 key1.... keyN value] pair.</param>
		/// <param name="i">Key8 of type I, of [key0 key1.... keyN value] pair.</param>
		/// <param name="j">Key9 of type J, of [key0 key1.... keyN value] pair.</param>
		public void Remove(A a, B b, C c, D d, E e, F f, G g, H h, I i, J j)
		{
			 NKeyHash<B, NKeyHash<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>>>>>>> bsA1l;
			if (this.Values.TryGetValue(a, out bsA1l))
			{
				 NKeyHash<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>>>>>> csA1l;
				if (bsA1l.TryGetValue(b, out csA1l))
				{
					 NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>>>>> dsA1l;
					if (csA1l.TryGetValue(c, out dsA1l))
					{
						 NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>>>> esA1l;
						if (dsA1l.TryGetValue(d, out esA1l))
						{
							 NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>>> fsA1l;
							if (esA1l.TryGetValue(e, out fsA1l))
							{
								 NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>> gsA1l;
								if (fsA1l.TryGetValue(f, out gsA1l))
								{
									 NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>> hsA1l;
									if (gsA1l.TryGetValue(g, out hsA1l))
									{
										 NKeyHash<I, NKeyHash<J, VALUE>> isA1l;
										if (hsA1l.TryGetValue(h, out isA1l))
										{
											 NKeyHash<J, VALUE> jsA1l;
											if (isA1l.TryGetValue(i, out jsA1l))
											{
												jsA1l .Remove(j);
											}
										}
									}
								}
							}
						}
					}
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
		/// Determines if the value associated with the specified [key0 key1.... keyN] exists.
		/// </summary>
		/// <param name="a">Key0 of type A, of [key0 key1.... keyN value] pair.</param>
		/// <param name="b">Key1 of type B, of [key0 key1.... keyN value] pair.</param>
		/// <param name="c">Key2 of type C, of [key0 key1.... keyN value] pair.</param>
		/// <param name="d">Key3 of type D, of [key0 key1.... keyN value] pair.</param>
		/// <returns>true if the source sequence contains any elements; otherwise, false.</returns>
		public bool ContainsKey(A a, B b, C c, D d)
		{
			if (this.Values.ContainsKey(a))
				if (this.Values[a].ContainsKey(b))
					if (this.Values[a][b].ContainsKey(c))
						if (this.Values[a][b][c].ContainsKey(d))
							return true;
			return false;
		}


		/// <summary>
		/// Determines if the value associated with the specified [key0 key1.... keyN] exists.
		/// </summary>
		/// <param name="a">Key0 of type A, of [key0 key1.... keyN value] pair.</param>
		/// <param name="b">Key1 of type B, of [key0 key1.... keyN value] pair.</param>
		/// <param name="c">Key2 of type C, of [key0 key1.... keyN value] pair.</param>
		/// <param name="d">Key3 of type D, of [key0 key1.... keyN value] pair.</param>
		/// <param name="e">Key4 of type E, of [key0 key1.... keyN value] pair.</param>
		/// <returns>true if the source sequence contains any elements; otherwise, false.</returns>
		public bool ContainsKey(A a, B b, C c, D d, E e)
		{
			if (this.Values.ContainsKey(a))
				if (this.Values[a].ContainsKey(b))
					if (this.Values[a][b].ContainsKey(c))
						if (this.Values[a][b][c].ContainsKey(d))
							if (this.Values[a][b][c][d].ContainsKey(e))
								return true;
			return false;
		}


		/// <summary>
		/// Determines if the value associated with the specified [key0 key1.... keyN] exists.
		/// </summary>
		/// <param name="a">Key0 of type A, of [key0 key1.... keyN value] pair.</param>
		/// <param name="b">Key1 of type B, of [key0 key1.... keyN value] pair.</param>
		/// <param name="c">Key2 of type C, of [key0 key1.... keyN value] pair.</param>
		/// <param name="d">Key3 of type D, of [key0 key1.... keyN value] pair.</param>
		/// <param name="e">Key4 of type E, of [key0 key1.... keyN value] pair.</param>
		/// <param name="f">Key5 of type F, of [key0 key1.... keyN value] pair.</param>
		/// <returns>true if the source sequence contains any elements; otherwise, false.</returns>
		public bool ContainsKey(A a, B b, C c, D d, E e, F f)
		{
			if (this.Values.ContainsKey(a))
				if (this.Values[a].ContainsKey(b))
					if (this.Values[a][b].ContainsKey(c))
						if (this.Values[a][b][c].ContainsKey(d))
							if (this.Values[a][b][c][d].ContainsKey(e))
								if (this.Values[a][b][c][d][e].ContainsKey(f))
									return true;
			return false;
		}


		/// <summary>
		/// Determines if the value associated with the specified [key0 key1.... keyN] exists.
		/// </summary>
		/// <param name="a">Key0 of type A, of [key0 key1.... keyN value] pair.</param>
		/// <param name="b">Key1 of type B, of [key0 key1.... keyN value] pair.</param>
		/// <param name="c">Key2 of type C, of [key0 key1.... keyN value] pair.</param>
		/// <param name="d">Key3 of type D, of [key0 key1.... keyN value] pair.</param>
		/// <param name="e">Key4 of type E, of [key0 key1.... keyN value] pair.</param>
		/// <param name="f">Key5 of type F, of [key0 key1.... keyN value] pair.</param>
		/// <param name="g">Key6 of type G, of [key0 key1.... keyN value] pair.</param>
		/// <returns>true if the source sequence contains any elements; otherwise, false.</returns>
		public bool ContainsKey(A a, B b, C c, D d, E e, F f, G g)
		{
			if (this.Values.ContainsKey(a))
				if (this.Values[a].ContainsKey(b))
					if (this.Values[a][b].ContainsKey(c))
						if (this.Values[a][b][c].ContainsKey(d))
							if (this.Values[a][b][c][d].ContainsKey(e))
								if (this.Values[a][b][c][d][e].ContainsKey(f))
									if (this.Values[a][b][c][d][e][f].ContainsKey(g))
										return true;
			return false;
		}


		/// <summary>
		/// Determines if the value associated with the specified [key0 key1.... keyN] exists.
		/// </summary>
		/// <param name="a">Key0 of type A, of [key0 key1.... keyN value] pair.</param>
		/// <param name="b">Key1 of type B, of [key0 key1.... keyN value] pair.</param>
		/// <param name="c">Key2 of type C, of [key0 key1.... keyN value] pair.</param>
		/// <param name="d">Key3 of type D, of [key0 key1.... keyN value] pair.</param>
		/// <param name="e">Key4 of type E, of [key0 key1.... keyN value] pair.</param>
		/// <param name="f">Key5 of type F, of [key0 key1.... keyN value] pair.</param>
		/// <param name="g">Key6 of type G, of [key0 key1.... keyN value] pair.</param>
		/// <param name="h">Key7 of type H, of [key0 key1.... keyN value] pair.</param>
		/// <returns>true if the source sequence contains any elements; otherwise, false.</returns>
		public bool ContainsKey(A a, B b, C c, D d, E e, F f, G g, H h)
		{
			if (this.Values.ContainsKey(a))
				if (this.Values[a].ContainsKey(b))
					if (this.Values[a][b].ContainsKey(c))
						if (this.Values[a][b][c].ContainsKey(d))
							if (this.Values[a][b][c][d].ContainsKey(e))
								if (this.Values[a][b][c][d][e].ContainsKey(f))
									if (this.Values[a][b][c][d][e][f].ContainsKey(g))
										if (this.Values[a][b][c][d][e][f][g].ContainsKey(h))
											return true;
			return false;
		}


		/// <summary>
		/// Determines if the value associated with the specified [key0 key1.... keyN] exists.
		/// </summary>
		/// <param name="a">Key0 of type A, of [key0 key1.... keyN value] pair.</param>
		/// <param name="b">Key1 of type B, of [key0 key1.... keyN value] pair.</param>
		/// <param name="c">Key2 of type C, of [key0 key1.... keyN value] pair.</param>
		/// <param name="d">Key3 of type D, of [key0 key1.... keyN value] pair.</param>
		/// <param name="e">Key4 of type E, of [key0 key1.... keyN value] pair.</param>
		/// <param name="f">Key5 of type F, of [key0 key1.... keyN value] pair.</param>
		/// <param name="g">Key6 of type G, of [key0 key1.... keyN value] pair.</param>
		/// <param name="h">Key7 of type H, of [key0 key1.... keyN value] pair.</param>
		/// <param name="i">Key8 of type I, of [key0 key1.... keyN value] pair.</param>
		/// <returns>true if the source sequence contains any elements; otherwise, false.</returns>
		public bool ContainsKey(A a, B b, C c, D d, E e, F f, G g, H h, I i)
		{
			if (this.Values.ContainsKey(a))
				if (this.Values[a].ContainsKey(b))
					if (this.Values[a][b].ContainsKey(c))
						if (this.Values[a][b][c].ContainsKey(d))
							if (this.Values[a][b][c][d].ContainsKey(e))
								if (this.Values[a][b][c][d][e].ContainsKey(f))
									if (this.Values[a][b][c][d][e][f].ContainsKey(g))
										if (this.Values[a][b][c][d][e][f][g].ContainsKey(h))
											if (this.Values[a][b][c][d][e][f][g][h].ContainsKey(i))
												return true;
			return false;
		}


		/// <summary>
		/// Determines if the value associated with the specified [key0 key1.... keyN] exists.
		/// </summary>
		/// <param name="a">Key0 of type A, of [key0 key1.... keyN value] pair.</param>
		/// <param name="b">Key1 of type B, of [key0 key1.... keyN value] pair.</param>
		/// <param name="c">Key2 of type C, of [key0 key1.... keyN value] pair.</param>
		/// <param name="d">Key3 of type D, of [key0 key1.... keyN value] pair.</param>
		/// <param name="e">Key4 of type E, of [key0 key1.... keyN value] pair.</param>
		/// <param name="f">Key5 of type F, of [key0 key1.... keyN value] pair.</param>
		/// <param name="g">Key6 of type G, of [key0 key1.... keyN value] pair.</param>
		/// <param name="h">Key7 of type H, of [key0 key1.... keyN value] pair.</param>
		/// <param name="i">Key8 of type I, of [key0 key1.... keyN value] pair.</param>
		/// <param name="j">Key9 of type J, of [key0 key1.... keyN value] pair.</param>
		/// <returns>true if the source sequence contains any elements; otherwise, false.</returns>
		public bool ContainsKey(A a, B b, C c, D d, E e, F f, G g, H h, I i, J j)
		{
			if (this.Values.ContainsKey(a))
				if (this.Values[a].ContainsKey(b))
					if (this.Values[a][b].ContainsKey(c))
						if (this.Values[a][b][c].ContainsKey(d))
							if (this.Values[a][b][c][d].ContainsKey(e))
								if (this.Values[a][b][c][d][e].ContainsKey(f))
									if (this.Values[a][b][c][d][e][f].ContainsKey(g))
										if (this.Values[a][b][c][d][e][f][g].ContainsKey(h))
											if (this.Values[a][b][c][d][e][f][g][h].ContainsKey(i))
												if (this.Values[a][b][c][d][e][f][g][h][i].ContainsKey(j))
													return true;
			return false;
		}


		/// <summary>
		/// Upserts the value associated with the specified [key0 key1.... keyN].
		/// </summary>
		/// <param name="a">Key0 of type A, of [key0 key1.... keyN value] pair.</param>
		/// <param name="b">Key1 of type B, of [key0 key1.... keyN value] pair.</param>
		/// <param name="c">Key2 of type C, of [key0 key1.... keyN value] pair.</param>
		/// <param name="d">Key3 of type D, of [key0 key1.... keyN value] pair.</param>
		/// <param name="e">Key4 of type E, of [key0 key1.... keyN value] pair.</param>
		/// <param name="f">Key5 of type F, of [key0 key1.... keyN value] pair.</param>
		/// <param name="g">Key6 of type G, of [key0 key1.... keyN value] pair.</param>
		/// <param name="h">Key7 of type H, of [key0 key1.... keyN value] pair.</param>
		/// <param name="i">Key8 of type I, of [key0 key1.... keyN value] pair.</param>
		/// <param name="j">Key9 of type J, of [key0 key1.... keyN value] pair.</param>
		/// <param name="val">Value of [key0 key1.... keyN value] pair.</param>
		public void Upsert(A a, B b, C c, D d, E e, F f, G g, H h, I i, J j, VALUE val)
		{
			this.Upsert(true, a, b, c, d, e, f, g, h, i, j,  val);
		}


		/// <summary>
		/// Upserts the value associated with the specified [key0 key1.... keyN].
		/// </summary>
		/// <param name="replaceExistingData">Specify if the existing val should be overwritten if the [key0 key1.... keyN value] already exists.</param>
		/// <param name="a">Key0 of type A, of [key0 key1.... keyN value] pair.</param>
		/// <param name="b">Key1 of type B, of [key0 key1.... keyN value] pair.</param>
		/// <param name="c">Key2 of type C, of [key0 key1.... keyN value] pair.</param>
		/// <param name="d">Key3 of type D, of [key0 key1.... keyN value] pair.</param>
		/// <param name="e">Key4 of type E, of [key0 key1.... keyN value] pair.</param>
		/// <param name="f">Key5 of type F, of [key0 key1.... keyN value] pair.</param>
		/// <param name="g">Key6 of type G, of [key0 key1.... keyN value] pair.</param>
		/// <param name="h">Key7 of type H, of [key0 key1.... keyN value] pair.</param>
		/// <param name="i">Key8 of type I, of [key0 key1.... keyN value] pair.</param>
		/// <param name="j">Key9 of type J, of [key0 key1.... keyN value] pair.</param>
		/// <param name="val">Value of [key0 key1.... keyN value] pair.</param>
		public void Upsert(bool replaceExistingData, A a, B b, C c, D d, E e, F f, G g, H h, I i, J j, VALUE val)
		{
			int level = 0;
			NKeyHash<B, NKeyHash<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>>>>>>> bsA1l = null;
			NKeyHash<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>>>>>> csA1l = null;
			NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>>>>> dsA1l = null;
			NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>>>> esA1l = null;
			NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>>> fsA1l = null;
			NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>> gsA1l = null;
			NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>> hsA1l = null;
			NKeyHash<I, NKeyHash<J, VALUE>> isA1l = null;
			NKeyHash<J, VALUE> jsA1l = null;
			if (this.Values.TryGetValue(a, out bsA1l))
			{
				if (bsA1l.TryGetValue(b, out csA1l))
				{
					if (csA1l.TryGetValue(c, out dsA1l))
					{
						if (dsA1l.TryGetValue(d, out esA1l))
						{
							if (esA1l.TryGetValue(e, out fsA1l))
							{
								if (fsA1l.TryGetValue(f, out gsA1l))
								{
									if (gsA1l.TryGetValue(g, out hsA1l))
									{
										if (hsA1l.TryGetValue(h, out isA1l))
										{
											if (isA1l.TryGetValue(i, out jsA1l))
											{
												if (jsA1l.ContainsKey(j))
												{
													if (replaceExistingData)
													{
														jsA1l[j] = val;
													}
													return;
												}
												else level = 10;
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

			if (level == 1) { bsA1l = new  NKeyHash<B, NKeyHash<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>>>>>>>(this.UnderlyingHashType); this.Values.Add(a, bsA1l); level++; }
			if (level == 2) { csA1l = new  NKeyHash<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>>>>>>(this.UnderlyingHashType); bsA1l.Add(b, csA1l); level++; }
			if (level == 3) { dsA1l = new  NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>>>>>(this.UnderlyingHashType); csA1l.Add(c, dsA1l); level++; }
			if (level == 4) { esA1l = new  NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>>>>(this.UnderlyingHashType); dsA1l.Add(d, esA1l); level++; }
			if (level == 5) { fsA1l = new  NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>>>(this.UnderlyingHashType); esA1l.Add(e, fsA1l); level++; }
			if (level == 6) { gsA1l = new  NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>>(this.UnderlyingHashType); fsA1l.Add(f, gsA1l); level++; }
			if (level == 7) { hsA1l = new  NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>(this.UnderlyingHashType); gsA1l.Add(g, hsA1l); level++; }
			if (level == 8) { isA1l = new  NKeyHash<I, NKeyHash<J, VALUE>>(this.UnderlyingHashType); hsA1l.Add(h, isA1l); level++; }
			if (level == 9) { jsA1l = new  NKeyHash<J, VALUE>(this.UnderlyingHashType); isA1l.Add(i, jsA1l); level++; }
			if (level == 10) {jsA1l.Add(j, val); }
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
		public IEnumerator<NKeyValue<A, B, C, D, E, F, G, H, I, J, VALUE>> GetEnumerator()
		{
			foreach (NKeyValue<A, NKeyHash<B, NKeyHash<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>>>>>>>> a in  this.Values)
			{
				foreach (NKeyValue<B, NKeyHash<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>>>>>>> b in a.Value)
				{
					foreach (NKeyValue<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>>>>>> c in b.Value)
					{
						foreach (NKeyValue<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>>>>> d in c.Value)
						{
							foreach (NKeyValue<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>>>> e in d.Value)
							{
								foreach (NKeyValue<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>>> f in e.Value)
								{
									foreach (NKeyValue<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, VALUE>>>> g in f.Value)
									{
										foreach (NKeyValue<H, NKeyHash<I, NKeyHash<J, VALUE>>> h in g.Value)
										{
											foreach (NKeyValue<I, NKeyHash<J, VALUE>> i in h.Value)
											{
												foreach (NKeyValue<J, VALUE> j in i.Value)
												{
													yield return new NKeyValue<A, B, C, D, E, F, G, H, I, J, VALUE>(a.Key, b.Key, c.Key, d.Key, e.Key, f.Key, g.Key, h.Key, i.Key, j.Key, j.Value);
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}

	}
}
