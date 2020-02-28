using System;
using System.Collections.Generic;

namespace Demo.CSharpExamples
{
	public class RecursiveIterators
	{
		public IEnumerable<T> FlattenNotYield<T>(IEnumerable<T> source, List<T> flatArray = null)
		{
			flatArray ??= new List<T>();
			foreach (var item in source)
			{
				if (item is IEnumerable<T> enumerable && !(enumerable is string))
				{
					FlattenNotYield(enumerable, flatArray);
				}
				else
				{
					flatArray.Add(item);
				}
			}

			return flatArray;
		}

		public IEnumerable<T> Flatten<T>(IEnumerable<T> source)
		{
			foreach (var item in source)
			{
				if (item is IEnumerable<T> && !(item is string))
				{

					foreach (var subItem in Flatten((IEnumerable<T>)item))
					{
						yield return subItem;
					}

				}
				else
				{
					yield return item;
				}
			}
		}


		public int SumTheIntervall(int s, int e)
		{
			if (s >= e)
			{
				return s;
			}

			s += SumTheIntervall(s + 1, e);
			return s;
		}

		public int PrintAllArraysInnerValues(int position, int[] source)
		{
			Console.WriteLine("unique numbers:" + source[position]);
			if (position >= source.Length - 1)
			{
				return source[position];
			}
			int sum = source[position] + PrintAllArraysInnerValues(position + 1, source);
			return sum;
		}

	}

	static class RecursiveIteratorsExtensions
	{
		public static IEnumerable<TResult> FlattenExt<TResult, TSource>(this IEnumerable<TSource> source, Func<TSource, TResult> msgEnricher)
		{
			foreach (var item in source)
			{
				if (item is IEnumerable<TSource> && !(item is string))
				{

					foreach (var subitem in FlattenExt((IEnumerable<TSource>)item, msgEnricher))
					{
						yield return subitem;
					}

				}
				else
				{
					yield return msgEnricher(item);
				}
			}
		}
	}
}

