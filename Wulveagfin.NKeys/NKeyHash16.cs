namespace Wulveagfin.NKeys
{
	using System;
	using System.Collections;
	using System.Collections.Generic;

	/// <summary>
	/// NKeyValue contains multiple keys that point to a single object Value. NKeyValue is used to express internal objects within the NKeyHash universe.
	/// </summary>
	public class NKeyValue<A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, VALUE>
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
		/// Key10 of type K, of [key0 key1.... keyN value] pair.
		/// </summary>
		public K Key10 { get; set; }

		/// <summary>
		/// Key11 of type L, of [key0 key1.... keyN value] pair.
		/// </summary>
		public L Key11 { get; set; }

		/// <summary>
		/// Key12 of type M, of [key0 key1.... keyN value] pair.
		/// </summary>
		public M Key12 { get; set; }

		/// <summary>
		/// Key13 of type N, of [key0 key1.... keyN value] pair.
		/// </summary>
		public N Key13 { get; set; }

		/// <summary>
		/// Key14 of type O, of [key0 key1.... keyN value] pair.
		/// </summary>
		public O Key14 { get; set; }

		/// <summary>
		/// Key15 of type P, of [key0 key1.... keyN value] pair.
		/// </summary>
		public P Key15 { get; set; }

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
		/// <param name="key10">Key10 of type K, of [key0 key1.... keyN value] pair.</param>
		/// <param name="key11">Key11 of type L, of [key0 key1.... keyN value] pair.</param>
		/// <param name="key12">Key12 of type M, of [key0 key1.... keyN value] pair.</param>
		/// <param name="key13">Key13 of type N, of [key0 key1.... keyN value] pair.</param>
		/// <param name="key14">Key14 of type O, of [key0 key1.... keyN value] pair.</param>
		/// <param name="key15">Key15 of type P, of [key0 key1.... keyN value] pair.</param>
		/// <param name="val">Value of [key0 key1.... keyN value] pair.</param>
		public NKeyValue(A key0, B key1, C key2, D key3, E key4, F key5, G key6, H key7, I key8, J key9, K key10, L key11, M key12, N key13, O key14, P key15,  VALUE val)
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
			this.Key10 = key10;
			this.Key11 = key11;
			this.Key12 = key12;
			this.Key13 = key13;
			this.Key14 = key14;
			this.Key15 = key15;
			this.Value = val;
		}


		/// <summary>
		/// Generates a string view of keys and value
		/// </summary>
		public override string ToString()
		{
			return $"{Key0}, {Key1}, {Key2}, {Key3}, {Key4}, {Key5}, {Key6}, {Key7}, {Key8}, {Key9}, {Key10}, {Key11}, {Key12}, {Key13}, {Key14}, {Key15}, {Value}";
		}
	}




	/// <summary>
	/// NKeyHash is a IEnumerable-enabled multidimensional array. It can currently use System.Collections.HashTable, System.Collections.Generic.Dictionary, System.Collections.Generic.SortedDictionary, or System.Collections.Concurrent.ConcurrentDictionary for the underlying base hashable object. NKeyHash uses generics to create nested hashable objects.
	/// </summary>
	public class NKeyHash<A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, VALUE> : IDisposable, IEnumerable<NKeyValue<A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, VALUE>>
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
			this.Values = new NKeyHash<A, NKeyHash<B, NKeyHash<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>>>>>>(this.UnderlyingHashType);
		}

		/// <summary>
		/// Private internal storage object for Values
		/// </summary>
		private NKeyHash<A, NKeyHash<B, NKeyHash<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>>>>>> Values;


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
		/// <param name="j">Key9 of type J, of [key0 key1.... keyN value] pair.</param>
		/// <param name="k">Key10 of type K, of [key0 key1.... keyN value] pair.</param>
		/// <param name="l">Key11 of type L, of [key0 key1.... keyN value] pair.</param>
		/// <param name="m">Key12 of type M, of [key0 key1.... keyN value] pair.</param>
		/// <param name="n">Key13 of type N, of [key0 key1.... keyN value] pair.</param>
		/// <param name="o">Key14 of type O, of [key0 key1.... keyN value] pair.</param>
		/// <returns>Gets the number of [key key...key value] collections contained at the level of the [key0 key1.... keyN] specified.</returns>
		public int Count(A a, B b, C c, D d, E e, F f, G g, H h, I i, J j, K k, L l, M m, N n, O o)
		{
			NKeyHash<B, NKeyHash<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>>>>> bsA1l;
			if (this.Values.TryGetValue(a, out bsA1l))
			{
				NKeyHash<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>>>> csA1l;
				if (bsA1l.TryGetValue(b, out csA1l))
				{
					NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>>> dsA1l;
					if (csA1l.TryGetValue(c, out dsA1l))
					{
						NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>> esA1l;
						if (dsA1l.TryGetValue(d, out esA1l))
						{
							NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>> fsA1l;
							if (esA1l.TryGetValue(e, out fsA1l))
							{
								NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>> gsA1l;
								if (fsA1l.TryGetValue(f, out gsA1l))
								{
									NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>> hsA1l;
									if (gsA1l.TryGetValue(g, out hsA1l))
									{
										NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>> isA1l;
										if (hsA1l.TryGetValue(h, out isA1l))
										{
											NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>> jsA1l;
											if (isA1l.TryGetValue(i, out jsA1l))
											{
												NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>> ksA1l;
												if (jsA1l.TryGetValue(j, out ksA1l))
												{
													NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>> lsA1l;
													if (ksA1l.TryGetValue(k, out lsA1l))
													{
														NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>> msA1l;
														if (lsA1l.TryGetValue(l, out msA1l))
														{
															NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>> nsA1l;
															if (msA1l.TryGetValue(m, out nsA1l))
															{
																NKeyHash<O, NKeyHash<P, VALUE>> osA1l;
																if (nsA1l.TryGetValue(n, out osA1l))
																{
																	NKeyHash<P, VALUE> psA1l;
																	if (osA1l.TryGetValue(o, out psA1l))
																	{
																		return psA1l.Count;
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
		/// <param name="i">Key8 of type I, of [key0 key1.... keyN value] pair.</param>
		/// <param name="j">Key9 of type J, of [key0 key1.... keyN value] pair.</param>
		/// <param name="k">Key10 of type K, of [key0 key1.... keyN value] pair.</param>
		/// <param name="l">Key11 of type L, of [key0 key1.... keyN value] pair.</param>
		/// <param name="m">Key12 of type M, of [key0 key1.... keyN value] pair.</param>
		/// <param name="n">Key13 of type N, of [key0 key1.... keyN value] pair.</param>
		/// <returns>Gets the number of [key key...key value] collections contained at the level of the [key0 key1.... keyN] specified.</returns>
		public int Count(A a, B b, C c, D d, E e, F f, G g, H h, I i, J j, K k, L l, M m, N n)
		{
			NKeyHash<B, NKeyHash<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>>>>> bsA1l;
			if (this.Values.TryGetValue(a, out bsA1l))
			{
				NKeyHash<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>>>> csA1l;
				if (bsA1l.TryGetValue(b, out csA1l))
				{
					NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>>> dsA1l;
					if (csA1l.TryGetValue(c, out dsA1l))
					{
						NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>> esA1l;
						if (dsA1l.TryGetValue(d, out esA1l))
						{
							NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>> fsA1l;
							if (esA1l.TryGetValue(e, out fsA1l))
							{
								NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>> gsA1l;
								if (fsA1l.TryGetValue(f, out gsA1l))
								{
									NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>> hsA1l;
									if (gsA1l.TryGetValue(g, out hsA1l))
									{
										NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>> isA1l;
										if (hsA1l.TryGetValue(h, out isA1l))
										{
											NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>> jsA1l;
											if (isA1l.TryGetValue(i, out jsA1l))
											{
												NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>> ksA1l;
												if (jsA1l.TryGetValue(j, out ksA1l))
												{
													NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>> lsA1l;
													if (ksA1l.TryGetValue(k, out lsA1l))
													{
														NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>> msA1l;
														if (lsA1l.TryGetValue(l, out msA1l))
														{
															NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>> nsA1l;
															if (msA1l.TryGetValue(m, out nsA1l))
															{
																NKeyHash<O, NKeyHash<P, VALUE>> osA1l;
																if (nsA1l.TryGetValue(n, out osA1l))
																{
																	return osA1l.Count;
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
		/// <param name="i">Key8 of type I, of [key0 key1.... keyN value] pair.</param>
		/// <param name="j">Key9 of type J, of [key0 key1.... keyN value] pair.</param>
		/// <param name="k">Key10 of type K, of [key0 key1.... keyN value] pair.</param>
		/// <param name="l">Key11 of type L, of [key0 key1.... keyN value] pair.</param>
		/// <param name="m">Key12 of type M, of [key0 key1.... keyN value] pair.</param>
		/// <returns>Gets the number of [key key...key value] collections contained at the level of the [key0 key1.... keyN] specified.</returns>
		public int Count(A a, B b, C c, D d, E e, F f, G g, H h, I i, J j, K k, L l, M m)
		{
			NKeyHash<B, NKeyHash<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>>>>> bsA1l;
			if (this.Values.TryGetValue(a, out bsA1l))
			{
				NKeyHash<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>>>> csA1l;
				if (bsA1l.TryGetValue(b, out csA1l))
				{
					NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>>> dsA1l;
					if (csA1l.TryGetValue(c, out dsA1l))
					{
						NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>> esA1l;
						if (dsA1l.TryGetValue(d, out esA1l))
						{
							NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>> fsA1l;
							if (esA1l.TryGetValue(e, out fsA1l))
							{
								NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>> gsA1l;
								if (fsA1l.TryGetValue(f, out gsA1l))
								{
									NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>> hsA1l;
									if (gsA1l.TryGetValue(g, out hsA1l))
									{
										NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>> isA1l;
										if (hsA1l.TryGetValue(h, out isA1l))
										{
											NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>> jsA1l;
											if (isA1l.TryGetValue(i, out jsA1l))
											{
												NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>> ksA1l;
												if (jsA1l.TryGetValue(j, out ksA1l))
												{
													NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>> lsA1l;
													if (ksA1l.TryGetValue(k, out lsA1l))
													{
														NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>> msA1l;
														if (lsA1l.TryGetValue(l, out msA1l))
														{
															NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>> nsA1l;
															if (msA1l.TryGetValue(m, out nsA1l))
															{
																return nsA1l.Count;
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
		/// <param name="i">Key8 of type I, of [key0 key1.... keyN value] pair.</param>
		/// <param name="j">Key9 of type J, of [key0 key1.... keyN value] pair.</param>
		/// <param name="k">Key10 of type K, of [key0 key1.... keyN value] pair.</param>
		/// <param name="l">Key11 of type L, of [key0 key1.... keyN value] pair.</param>
		/// <returns>Gets the number of [key key...key value] collections contained at the level of the [key0 key1.... keyN] specified.</returns>
		public int Count(A a, B b, C c, D d, E e, F f, G g, H h, I i, J j, K k, L l)
		{
			NKeyHash<B, NKeyHash<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>>>>> bsA1l;
			if (this.Values.TryGetValue(a, out bsA1l))
			{
				NKeyHash<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>>>> csA1l;
				if (bsA1l.TryGetValue(b, out csA1l))
				{
					NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>>> dsA1l;
					if (csA1l.TryGetValue(c, out dsA1l))
					{
						NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>> esA1l;
						if (dsA1l.TryGetValue(d, out esA1l))
						{
							NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>> fsA1l;
							if (esA1l.TryGetValue(e, out fsA1l))
							{
								NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>> gsA1l;
								if (fsA1l.TryGetValue(f, out gsA1l))
								{
									NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>> hsA1l;
									if (gsA1l.TryGetValue(g, out hsA1l))
									{
										NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>> isA1l;
										if (hsA1l.TryGetValue(h, out isA1l))
										{
											NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>> jsA1l;
											if (isA1l.TryGetValue(i, out jsA1l))
											{
												NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>> ksA1l;
												if (jsA1l.TryGetValue(j, out ksA1l))
												{
													NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>> lsA1l;
													if (ksA1l.TryGetValue(k, out lsA1l))
													{
														NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>> msA1l;
														if (lsA1l.TryGetValue(l, out msA1l))
														{
															return msA1l.Count;
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
		/// <param name="i">Key8 of type I, of [key0 key1.... keyN value] pair.</param>
		/// <param name="j">Key9 of type J, of [key0 key1.... keyN value] pair.</param>
		/// <param name="k">Key10 of type K, of [key0 key1.... keyN value] pair.</param>
		/// <returns>Gets the number of [key key...key value] collections contained at the level of the [key0 key1.... keyN] specified.</returns>
		public int Count(A a, B b, C c, D d, E e, F f, G g, H h, I i, J j, K k)
		{
			NKeyHash<B, NKeyHash<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>>>>> bsA1l;
			if (this.Values.TryGetValue(a, out bsA1l))
			{
				NKeyHash<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>>>> csA1l;
				if (bsA1l.TryGetValue(b, out csA1l))
				{
					NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>>> dsA1l;
					if (csA1l.TryGetValue(c, out dsA1l))
					{
						NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>> esA1l;
						if (dsA1l.TryGetValue(d, out esA1l))
						{
							NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>> fsA1l;
							if (esA1l.TryGetValue(e, out fsA1l))
							{
								NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>> gsA1l;
								if (fsA1l.TryGetValue(f, out gsA1l))
								{
									NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>> hsA1l;
									if (gsA1l.TryGetValue(g, out hsA1l))
									{
										NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>> isA1l;
										if (hsA1l.TryGetValue(h, out isA1l))
										{
											NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>> jsA1l;
											if (isA1l.TryGetValue(i, out jsA1l))
											{
												NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>> ksA1l;
												if (jsA1l.TryGetValue(j, out ksA1l))
												{
													NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>> lsA1l;
													if (ksA1l.TryGetValue(k, out lsA1l))
													{
														return lsA1l.Count;
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
		/// <param name="i">Key8 of type I, of [key0 key1.... keyN value] pair.</param>
		/// <param name="j">Key9 of type J, of [key0 key1.... keyN value] pair.</param>
		/// <returns>Gets the number of [key key...key value] collections contained at the level of the [key0 key1.... keyN] specified.</returns>
		public int Count(A a, B b, C c, D d, E e, F f, G g, H h, I i, J j)
		{
			NKeyHash<B, NKeyHash<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>>>>> bsA1l;
			if (this.Values.TryGetValue(a, out bsA1l))
			{
				NKeyHash<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>>>> csA1l;
				if (bsA1l.TryGetValue(b, out csA1l))
				{
					NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>>> dsA1l;
					if (csA1l.TryGetValue(c, out dsA1l))
					{
						NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>> esA1l;
						if (dsA1l.TryGetValue(d, out esA1l))
						{
							NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>> fsA1l;
							if (esA1l.TryGetValue(e, out fsA1l))
							{
								NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>> gsA1l;
								if (fsA1l.TryGetValue(f, out gsA1l))
								{
									NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>> hsA1l;
									if (gsA1l.TryGetValue(g, out hsA1l))
									{
										NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>> isA1l;
										if (hsA1l.TryGetValue(h, out isA1l))
										{
											NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>> jsA1l;
											if (isA1l.TryGetValue(i, out jsA1l))
											{
												NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>> ksA1l;
												if (jsA1l.TryGetValue(j, out ksA1l))
												{
													return ksA1l.Count;
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
		/// <param name="i">Key8 of type I, of [key0 key1.... keyN value] pair.</param>
		/// <returns>Gets the number of [key key...key value] collections contained at the level of the [key0 key1.... keyN] specified.</returns>
		public int Count(A a, B b, C c, D d, E e, F f, G g, H h, I i)
		{
			NKeyHash<B, NKeyHash<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>>>>> bsA1l;
			if (this.Values.TryGetValue(a, out bsA1l))
			{
				NKeyHash<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>>>> csA1l;
				if (bsA1l.TryGetValue(b, out csA1l))
				{
					NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>>> dsA1l;
					if (csA1l.TryGetValue(c, out dsA1l))
					{
						NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>> esA1l;
						if (dsA1l.TryGetValue(d, out esA1l))
						{
							NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>> fsA1l;
							if (esA1l.TryGetValue(e, out fsA1l))
							{
								NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>> gsA1l;
								if (fsA1l.TryGetValue(f, out gsA1l))
								{
									NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>> hsA1l;
									if (gsA1l.TryGetValue(g, out hsA1l))
									{
										NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>> isA1l;
										if (hsA1l.TryGetValue(h, out isA1l))
										{
											NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>> jsA1l;
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
			NKeyHash<B, NKeyHash<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>>>>> bsA1l;
			if (this.Values.TryGetValue(a, out bsA1l))
			{
				NKeyHash<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>>>> csA1l;
				if (bsA1l.TryGetValue(b, out csA1l))
				{
					NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>>> dsA1l;
					if (csA1l.TryGetValue(c, out dsA1l))
					{
						NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>> esA1l;
						if (dsA1l.TryGetValue(d, out esA1l))
						{
							NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>> fsA1l;
							if (esA1l.TryGetValue(e, out fsA1l))
							{
								NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>> gsA1l;
								if (fsA1l.TryGetValue(f, out gsA1l))
								{
									NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>> hsA1l;
									if (gsA1l.TryGetValue(g, out hsA1l))
									{
										NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>> isA1l;
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
			NKeyHash<B, NKeyHash<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>>>>> bsA1l;
			if (this.Values.TryGetValue(a, out bsA1l))
			{
				NKeyHash<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>>>> csA1l;
				if (bsA1l.TryGetValue(b, out csA1l))
				{
					NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>>> dsA1l;
					if (csA1l.TryGetValue(c, out dsA1l))
					{
						NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>> esA1l;
						if (dsA1l.TryGetValue(d, out esA1l))
						{
							NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>> fsA1l;
							if (esA1l.TryGetValue(e, out fsA1l))
							{
								NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>> gsA1l;
								if (fsA1l.TryGetValue(f, out gsA1l))
								{
									NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>> hsA1l;
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
			NKeyHash<B, NKeyHash<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>>>>> bsA1l;
			if (this.Values.TryGetValue(a, out bsA1l))
			{
				NKeyHash<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>>>> csA1l;
				if (bsA1l.TryGetValue(b, out csA1l))
				{
					NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>>> dsA1l;
					if (csA1l.TryGetValue(c, out dsA1l))
					{
						NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>> esA1l;
						if (dsA1l.TryGetValue(d, out esA1l))
						{
							NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>> fsA1l;
							if (esA1l.TryGetValue(e, out fsA1l))
							{
								NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>> gsA1l;
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
			NKeyHash<B, NKeyHash<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>>>>> bsA1l;
			if (this.Values.TryGetValue(a, out bsA1l))
			{
				NKeyHash<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>>>> csA1l;
				if (bsA1l.TryGetValue(b, out csA1l))
				{
					NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>>> dsA1l;
					if (csA1l.TryGetValue(c, out dsA1l))
					{
						NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>> esA1l;
						if (dsA1l.TryGetValue(d, out esA1l))
						{
							NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>> fsA1l;
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
			NKeyHash<B, NKeyHash<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>>>>> bsA1l;
			if (this.Values.TryGetValue(a, out bsA1l))
			{
				NKeyHash<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>>>> csA1l;
				if (bsA1l.TryGetValue(b, out csA1l))
				{
					NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>>> dsA1l;
					if (csA1l.TryGetValue(c, out dsA1l))
					{
						NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>> esA1l;
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
			NKeyHash<B, NKeyHash<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>>>>> bsA1l;
			if (this.Values.TryGetValue(a, out bsA1l))
			{
				NKeyHash<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>>>> csA1l;
				if (bsA1l.TryGetValue(b, out csA1l))
				{
					NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>>> dsA1l;
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
			NKeyHash<B, NKeyHash<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>>>>> bsA1l;
			if (this.Values.TryGetValue(a, out bsA1l))
			{
				NKeyHash<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>>>> csA1l;
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
			NKeyHash<B, NKeyHash<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>>>>> bsA1l;
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
		/// <param name="k">Key10 of type K, of [key0 key1.... keyN value] pair.</param>
		/// <param name="l">Key11 of type L, of [key0 key1.... keyN value] pair.</param>
		/// <param name="m">Key12 of type M, of [key0 key1.... keyN value] pair.</param>
		/// <param name="n">Key13 of type N, of [key0 key1.... keyN value] pair.</param>
		/// <param name="o">Key14 of type O, of [key0 key1.... keyN value] pair.</param>
		/// <param name="p">Key15 of type P, of [key0 key1.... keyN value] pair.</param>
		/// <returns>Returns the VALUE portion of [key0 key1.... keyN value], if it exists, otherwise Default(VALUE) (or if specified the defaultData) is returned.</returns>
		public VALUE this[A a, B b, C c, D d, E e, F f, G g, H h, I i, J j, K k, L l, M m, N n, O o, P p]
		{
			get { return Get(a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p); }
			set { this.Upsert(true, a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p, value); }
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
		/// <param name="k">Key10 of type K, of [key0 key1.... keyN value] pair.</param>
		/// <param name="l">Key11 of type L, of [key0 key1.... keyN value] pair.</param>
		/// <param name="m">Key12 of type M, of [key0 key1.... keyN value] pair.</param>
		/// <param name="n">Key13 of type N, of [key0 key1.... keyN value] pair.</param>
		/// <param name="o">Key14 of type O, of [key0 key1.... keyN value] pair.</param>
		/// <param name="p">Key15 of type P, of [key0 key1.... keyN value] pair.</param>
		/// <returns>Returns the VALUE portion of [key0 key1.... keyN value], if it exists, otherwise Default(VALUE) (or if specified the defaultData) is returned.</returns>
		public VALUE Get(A a, B b, C c, D d, E e, F f, G g, H h, I i, J j, K k, L l, M m, N n, O o, P p)
		{
			return this.Values[a][b][c][d][e][f][g][h][i][j][k][l][m][n][o][p];
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
		/// <param name="k">Key10 of type K, of [key0 key1.... keyN value] pair.</param>
		/// <param name="l">Key11 of type L, of [key0 key1.... keyN value] pair.</param>
		/// <param name="m">Key12 of type M, of [key0 key1.... keyN value] pair.</param>
		/// <param name="n">Key13 of type N, of [key0 key1.... keyN value] pair.</param>
		/// <param name="o">Key14 of type O, of [key0 key1.... keyN value] pair.</param>
		/// <param name="p">Key15 of type P, of [key0 key1.... keyN value] pair.</param>
		/// <returns>Returns the VALUE portion of [key0 key1.... keyN value], if it exists, otherwise Default(VALUE) (or if specified the defaultData) is returned.</returns>
		public VALUE Get(out bool exists, VALUE defaultData, A a, B b, C c, D d, E e, F f, G g, H h, I i, J j, K k, L l, M m, N n, O o, P p)
		{
			exists = false;

			NKeyHash<B, NKeyHash<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>>>>> bsA1l;
			if (this.Values.TryGetValue(a, out bsA1l))
			{
				NKeyHash<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>>>> csA1l;
				if (bsA1l.TryGetValue(b, out csA1l))
				{
					NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>>> dsA1l;
					if (csA1l.TryGetValue(c, out dsA1l))
					{
						NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>> esA1l;
						if (dsA1l.TryGetValue(d, out esA1l))
						{
							NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>> fsA1l;
							if (esA1l.TryGetValue(e, out fsA1l))
							{
								NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>> gsA1l;
								if (fsA1l.TryGetValue(f, out gsA1l))
								{
									NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>> hsA1l;
									if (gsA1l.TryGetValue(g, out hsA1l))
									{
										NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>> isA1l;
										if (hsA1l.TryGetValue(h, out isA1l))
										{
											NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>> jsA1l;
											if (isA1l.TryGetValue(i, out jsA1l))
											{
												NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>> ksA1l;
												if (jsA1l.TryGetValue(j, out ksA1l))
												{
													NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>> lsA1l;
													if (ksA1l.TryGetValue(k, out lsA1l))
													{
														NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>> msA1l;
														if (lsA1l.TryGetValue(l, out msA1l))
														{
															NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>> nsA1l;
															if (msA1l.TryGetValue(m, out nsA1l))
															{
																NKeyHash<O, NKeyHash<P, VALUE>> osA1l;
																if (nsA1l.TryGetValue(n, out osA1l))
																{
																	NKeyHash<P, VALUE> psA1l;
																	if (osA1l.TryGetValue(o, out psA1l))
																	{
																		VALUE val;
																		if (psA1l.TryGetValue(p, out val))
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
		/// <param name="k">Key10 of type K, of [key0 key1.... keyN value] pair.</param>
		/// <param name="l">Key11 of type L, of [key0 key1.... keyN value] pair.</param>
		/// <param name="m">Key12 of type M, of [key0 key1.... keyN value] pair.</param>
		/// <param name="n">Key13 of type N, of [key0 key1.... keyN value] pair.</param>
		/// <param name="o">Key14 of type O, of [key0 key1.... keyN value] pair.</param>
		/// <param name="p">Key15 of type P, of [key0 key1.... keyN value] pair.</param>
		/// <param name="val">Value of [key0 key1.... keyN value] pair.</param>
		/// <returns>Returns the VALUE portion of [key0 key1.... keyN value], if it exists, otherwise Default(VALUE) (or if specified the defaultData) is returned.</returns>
		public bool TryGetValue(A a, B b, C c, D d, E e, F f, G g, H h, I i, J j, K k, L l, M m, N n, O o, P p, out VALUE val)
		{
			bool exist = false;
			val = Get(out exist, default(VALUE), a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p);
			return exist;
		}


		/// <summary>
		/// Removes all keys and values.
		/// </summary>
		public void Clear()
		{
			this.Values = new NKeyHash<A, NKeyHash<B, NKeyHash<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>>>>>>(this.UnderlyingHashType);
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
		/// <param name="k">Key10 of type K, of [key0 key1.... keyN value] pair.</param>
		/// <param name="l">Key11 of type L, of [key0 key1.... keyN value] pair.</param>
		/// <param name="m">Key12 of type M, of [key0 key1.... keyN value] pair.</param>
		/// <param name="n">Key13 of type N, of [key0 key1.... keyN value] pair.</param>
		/// <param name="o">Key14 of type O, of [key0 key1.... keyN value] pair.</param>
		/// <param name="p">Key15 of type P, of [key0 key1.... keyN value] pair.</param>
		/// <param name="val">Value of [key0 key1.... keyN value] pair.</param>
		public void Add(A a, B b, C c, D d, E e, F f, G g, H h, I i, J j, K k, L l, M m, N n, O o, P p, VALUE val)
		{
			this.Upsert(false, a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p, val);
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
		/// <param name="k">Key10 of type K, of [key0 key1.... keyN value] pair.</param>
		/// <param name="l">Key11 of type L, of [key0 key1.... keyN value] pair.</param>
		/// <param name="m">Key12 of type M, of [key0 key1.... keyN value] pair.</param>
		/// <param name="n">Key13 of type N, of [key0 key1.... keyN value] pair.</param>
		/// <param name="o">Key14 of type O, of [key0 key1.... keyN value] pair.</param>
		/// <param name="p">Key15 of type P, of [key0 key1.... keyN value] pair.</param>
		public void Delete(A a, B b, C c, D d, E e, F f, G g, H h, I i, J j, K k, L l, M m, N n, O o, P p)
		{
			this.Remove(a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p);
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
		/// <param name="k">Key10 of type K, of [key0 key1.... keyN value] pair.</param>
		/// <param name="l">Key11 of type L, of [key0 key1.... keyN value] pair.</param>
		/// <param name="m">Key12 of type M, of [key0 key1.... keyN value] pair.</param>
		/// <param name="n">Key13 of type N, of [key0 key1.... keyN value] pair.</param>
		/// <param name="o">Key14 of type O, of [key0 key1.... keyN value] pair.</param>
		/// <param name="p">Key15 of type P, of [key0 key1.... keyN value] pair.</param>
		public void Remove(A a, B b, C c, D d, E e, F f, G g, H h, I i, J j, K k, L l, M m, N n, O o, P p)
		{
			 NKeyHash<B, NKeyHash<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>>>>> bsA1l;
			if (this.Values.TryGetValue(a, out bsA1l))
			{
				 NKeyHash<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>>>> csA1l;
				if (bsA1l.TryGetValue(b, out csA1l))
				{
					 NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>>> dsA1l;
					if (csA1l.TryGetValue(c, out dsA1l))
					{
						 NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>> esA1l;
						if (dsA1l.TryGetValue(d, out esA1l))
						{
							 NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>> fsA1l;
							if (esA1l.TryGetValue(e, out fsA1l))
							{
								 NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>> gsA1l;
								if (fsA1l.TryGetValue(f, out gsA1l))
								{
									 NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>> hsA1l;
									if (gsA1l.TryGetValue(g, out hsA1l))
									{
										 NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>> isA1l;
										if (hsA1l.TryGetValue(h, out isA1l))
										{
											 NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>> jsA1l;
											if (isA1l.TryGetValue(i, out jsA1l))
											{
												 NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>> ksA1l;
												if (jsA1l.TryGetValue(j, out ksA1l))
												{
													 NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>> lsA1l;
													if (ksA1l.TryGetValue(k, out lsA1l))
													{
														 NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>> msA1l;
														if (lsA1l.TryGetValue(l, out msA1l))
														{
															 NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>> nsA1l;
															if (msA1l.TryGetValue(m, out nsA1l))
															{
																 NKeyHash<O, NKeyHash<P, VALUE>> osA1l;
																if (nsA1l.TryGetValue(n, out osA1l))
																{
																	 NKeyHash<P, VALUE> psA1l;
																	if (osA1l.TryGetValue(o, out psA1l))
																	{
																		psA1l .Remove(p);
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
		/// <param name="k">Key10 of type K, of [key0 key1.... keyN value] pair.</param>
		/// <returns>true if the source sequence contains any elements; otherwise, false.</returns>
		public bool ContainsKey(A a, B b, C c, D d, E e, F f, G g, H h, I i, J j, K k)
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
													if (this.Values[a][b][c][d][e][f][g][h][i][j].ContainsKey(k))
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
		/// <param name="k">Key10 of type K, of [key0 key1.... keyN value] pair.</param>
		/// <param name="l">Key11 of type L, of [key0 key1.... keyN value] pair.</param>
		/// <returns>true if the source sequence contains any elements; otherwise, false.</returns>
		public bool ContainsKey(A a, B b, C c, D d, E e, F f, G g, H h, I i, J j, K k, L l)
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
													if (this.Values[a][b][c][d][e][f][g][h][i][j].ContainsKey(k))
														if (this.Values[a][b][c][d][e][f][g][h][i][j][k].ContainsKey(l))
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
		/// <param name="k">Key10 of type K, of [key0 key1.... keyN value] pair.</param>
		/// <param name="l">Key11 of type L, of [key0 key1.... keyN value] pair.</param>
		/// <param name="m">Key12 of type M, of [key0 key1.... keyN value] pair.</param>
		/// <returns>true if the source sequence contains any elements; otherwise, false.</returns>
		public bool ContainsKey(A a, B b, C c, D d, E e, F f, G g, H h, I i, J j, K k, L l, M m)
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
													if (this.Values[a][b][c][d][e][f][g][h][i][j].ContainsKey(k))
														if (this.Values[a][b][c][d][e][f][g][h][i][j][k].ContainsKey(l))
															if (this.Values[a][b][c][d][e][f][g][h][i][j][k][l].ContainsKey(m))
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
		/// <param name="k">Key10 of type K, of [key0 key1.... keyN value] pair.</param>
		/// <param name="l">Key11 of type L, of [key0 key1.... keyN value] pair.</param>
		/// <param name="m">Key12 of type M, of [key0 key1.... keyN value] pair.</param>
		/// <param name="n">Key13 of type N, of [key0 key1.... keyN value] pair.</param>
		/// <returns>true if the source sequence contains any elements; otherwise, false.</returns>
		public bool ContainsKey(A a, B b, C c, D d, E e, F f, G g, H h, I i, J j, K k, L l, M m, N n)
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
													if (this.Values[a][b][c][d][e][f][g][h][i][j].ContainsKey(k))
														if (this.Values[a][b][c][d][e][f][g][h][i][j][k].ContainsKey(l))
															if (this.Values[a][b][c][d][e][f][g][h][i][j][k][l].ContainsKey(m))
																if (this.Values[a][b][c][d][e][f][g][h][i][j][k][l][m].ContainsKey(n))
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
		/// <param name="k">Key10 of type K, of [key0 key1.... keyN value] pair.</param>
		/// <param name="l">Key11 of type L, of [key0 key1.... keyN value] pair.</param>
		/// <param name="m">Key12 of type M, of [key0 key1.... keyN value] pair.</param>
		/// <param name="n">Key13 of type N, of [key0 key1.... keyN value] pair.</param>
		/// <param name="o">Key14 of type O, of [key0 key1.... keyN value] pair.</param>
		/// <returns>true if the source sequence contains any elements; otherwise, false.</returns>
		public bool ContainsKey(A a, B b, C c, D d, E e, F f, G g, H h, I i, J j, K k, L l, M m, N n, O o)
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
													if (this.Values[a][b][c][d][e][f][g][h][i][j].ContainsKey(k))
														if (this.Values[a][b][c][d][e][f][g][h][i][j][k].ContainsKey(l))
															if (this.Values[a][b][c][d][e][f][g][h][i][j][k][l].ContainsKey(m))
																if (this.Values[a][b][c][d][e][f][g][h][i][j][k][l][m].ContainsKey(n))
																	if (this.Values[a][b][c][d][e][f][g][h][i][j][k][l][m][n].ContainsKey(o))
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
		/// <param name="k">Key10 of type K, of [key0 key1.... keyN value] pair.</param>
		/// <param name="l">Key11 of type L, of [key0 key1.... keyN value] pair.</param>
		/// <param name="m">Key12 of type M, of [key0 key1.... keyN value] pair.</param>
		/// <param name="n">Key13 of type N, of [key0 key1.... keyN value] pair.</param>
		/// <param name="o">Key14 of type O, of [key0 key1.... keyN value] pair.</param>
		/// <param name="p">Key15 of type P, of [key0 key1.... keyN value] pair.</param>
		/// <returns>true if the source sequence contains any elements; otherwise, false.</returns>
		public bool ContainsKey(A a, B b, C c, D d, E e, F f, G g, H h, I i, J j, K k, L l, M m, N n, O o, P p)
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
													if (this.Values[a][b][c][d][e][f][g][h][i][j].ContainsKey(k))
														if (this.Values[a][b][c][d][e][f][g][h][i][j][k].ContainsKey(l))
															if (this.Values[a][b][c][d][e][f][g][h][i][j][k][l].ContainsKey(m))
																if (this.Values[a][b][c][d][e][f][g][h][i][j][k][l][m].ContainsKey(n))
																	if (this.Values[a][b][c][d][e][f][g][h][i][j][k][l][m][n].ContainsKey(o))
																		if (this.Values[a][b][c][d][e][f][g][h][i][j][k][l][m][n][o].ContainsKey(p))
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
		/// <param name="k">Key10 of type K, of [key0 key1.... keyN value] pair.</param>
		/// <param name="l">Key11 of type L, of [key0 key1.... keyN value] pair.</param>
		/// <param name="m">Key12 of type M, of [key0 key1.... keyN value] pair.</param>
		/// <param name="n">Key13 of type N, of [key0 key1.... keyN value] pair.</param>
		/// <param name="o">Key14 of type O, of [key0 key1.... keyN value] pair.</param>
		/// <param name="p">Key15 of type P, of [key0 key1.... keyN value] pair.</param>
		/// <param name="val">Value of [key0 key1.... keyN value] pair.</param>
		public void Upsert(A a, B b, C c, D d, E e, F f, G g, H h, I i, J j, K k, L l, M m, N n, O o, P p, VALUE val)
		{
			this.Upsert(true, a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p,  val);
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
		/// <param name="k">Key10 of type K, of [key0 key1.... keyN value] pair.</param>
		/// <param name="l">Key11 of type L, of [key0 key1.... keyN value] pair.</param>
		/// <param name="m">Key12 of type M, of [key0 key1.... keyN value] pair.</param>
		/// <param name="n">Key13 of type N, of [key0 key1.... keyN value] pair.</param>
		/// <param name="o">Key14 of type O, of [key0 key1.... keyN value] pair.</param>
		/// <param name="p">Key15 of type P, of [key0 key1.... keyN value] pair.</param>
		/// <param name="val">Value of [key0 key1.... keyN value] pair.</param>
		public void Upsert(bool replaceExistingData, A a, B b, C c, D d, E e, F f, G g, H h, I i, J j, K k, L l, M m, N n, O o, P p, VALUE val)
		{
			int level = 0;
			NKeyHash<B, NKeyHash<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>>>>> bsA1l = null;
			NKeyHash<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>>>> csA1l = null;
			NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>>> dsA1l = null;
			NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>> esA1l = null;
			NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>> fsA1l = null;
			NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>> gsA1l = null;
			NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>> hsA1l = null;
			NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>> isA1l = null;
			NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>> jsA1l = null;
			NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>> ksA1l = null;
			NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>> lsA1l = null;
			NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>> msA1l = null;
			NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>> nsA1l = null;
			NKeyHash<O, NKeyHash<P, VALUE>> osA1l = null;
			NKeyHash<P, VALUE> psA1l = null;
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
												if (jsA1l.TryGetValue(j, out ksA1l))
												{
													if (ksA1l.TryGetValue(k, out lsA1l))
													{
														if (lsA1l.TryGetValue(l, out msA1l))
														{
															if (msA1l.TryGetValue(m, out nsA1l))
															{
																if (nsA1l.TryGetValue(n, out osA1l))
																{
																	if (osA1l.TryGetValue(o, out psA1l))
																	{
																		if (psA1l.ContainsKey(p))
																		{
																			if (replaceExistingData)
																			{
																				psA1l[p] = val;
																			}
																			return;
																		}
																		else level = 16;
																	}
																	else level = 15;
																}
																else level = 14;
															}
															else level = 13;
														}
														else level = 12;
													}
													else level = 11;
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

			if (level == 1) { bsA1l = new  NKeyHash<B, NKeyHash<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>>>>>(this.UnderlyingHashType); this.Values.Add(a, bsA1l); level++; }
			if (level == 2) { csA1l = new  NKeyHash<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>>>>(this.UnderlyingHashType); bsA1l.Add(b, csA1l); level++; }
			if (level == 3) { dsA1l = new  NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>>>(this.UnderlyingHashType); csA1l.Add(c, dsA1l); level++; }
			if (level == 4) { esA1l = new  NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>>(this.UnderlyingHashType); dsA1l.Add(d, esA1l); level++; }
			if (level == 5) { fsA1l = new  NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>(this.UnderlyingHashType); esA1l.Add(e, fsA1l); level++; }
			if (level == 6) { gsA1l = new  NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>(this.UnderlyingHashType); fsA1l.Add(f, gsA1l); level++; }
			if (level == 7) { hsA1l = new  NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>(this.UnderlyingHashType); gsA1l.Add(g, hsA1l); level++; }
			if (level == 8) { isA1l = new  NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>(this.UnderlyingHashType); hsA1l.Add(h, isA1l); level++; }
			if (level == 9) { jsA1l = new  NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>(this.UnderlyingHashType); isA1l.Add(i, jsA1l); level++; }
			if (level == 10) { ksA1l = new  NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>(this.UnderlyingHashType); jsA1l.Add(j, ksA1l); level++; }
			if (level == 11) { lsA1l = new  NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>(this.UnderlyingHashType); ksA1l.Add(k, lsA1l); level++; }
			if (level == 12) { msA1l = new  NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>(this.UnderlyingHashType); lsA1l.Add(l, msA1l); level++; }
			if (level == 13) { nsA1l = new  NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>(this.UnderlyingHashType); msA1l.Add(m, nsA1l); level++; }
			if (level == 14) { osA1l = new  NKeyHash<O, NKeyHash<P, VALUE>>(this.UnderlyingHashType); nsA1l.Add(n, osA1l); level++; }
			if (level == 15) { psA1l = new  NKeyHash<P, VALUE>(this.UnderlyingHashType); osA1l.Add(o, psA1l); level++; }
			if (level == 16) {psA1l.Add(p, val); }
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
		public IEnumerator<NKeyValue<A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, VALUE>> GetEnumerator()
		{
			foreach (NKeyValue<A, NKeyHash<B, NKeyHash<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>>>>>> a in  this.Values)
			{
				foreach (NKeyValue<B, NKeyHash<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>>>>> b in a.Value)
				{
					foreach (NKeyValue<C, NKeyHash<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>>>> c in b.Value)
					{
						foreach (NKeyValue<D, NKeyHash<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>>> d in c.Value)
						{
							foreach (NKeyValue<E, NKeyHash<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>>> e in d.Value)
							{
								foreach (NKeyValue<F, NKeyHash<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>>> f in e.Value)
								{
									foreach (NKeyValue<G, NKeyHash<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>>> g in f.Value)
									{
										foreach (NKeyValue<H, NKeyHash<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>>> h in g.Value)
										{
											foreach (NKeyValue<I, NKeyHash<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>>> i in h.Value)
											{
												foreach (NKeyValue<J, NKeyHash<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>>> j in i.Value)
												{
													foreach (NKeyValue<K, NKeyHash<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>>> k in j.Value)
													{
														foreach (NKeyValue<L, NKeyHash<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>>> l in k.Value)
														{
															foreach (NKeyValue<M, NKeyHash<N, NKeyHash<O, NKeyHash<P, VALUE>>>> m in l.Value)
															{
																foreach (NKeyValue<N, NKeyHash<O, NKeyHash<P, VALUE>>> n in m.Value)
																{
																	foreach (NKeyValue<O, NKeyHash<P, VALUE>> o in n.Value)
																	{
																		foreach (NKeyValue<P, VALUE> p in o.Value)
																		{
																			yield return new NKeyValue<A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, VALUE>(a.Key, b.Key, c.Key, d.Key, e.Key, f.Key, g.Key, h.Key, i.Key, j.Key, k.Key, l.Key, m.Key, n.Key, o.Key, p.Key, p.Value);
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
					}
				}
			}
		}

	}
}
