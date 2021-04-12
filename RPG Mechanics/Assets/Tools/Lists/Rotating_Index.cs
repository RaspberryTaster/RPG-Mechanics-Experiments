using System;
using System.Collections.Generic;
using UnityEngine;

namespace Raspberry.Tools
{
	[Serializable]
	public class Rotating_Index<T> where T : class
	{
		private List<T> items = new List<T>();

		public Rotating_Index(List<T> list)
		{
			items = list;
		}

		public T Indexed_Item => items.Count == 0 ? null : items[Index];
		[SerializeField] private int index;
		public int Index
		{
			get 
			{
				int count = items.Count;
				int max_list_Index = count - 1;
				if (count == 0)
				{
					index = 0;
				}
				else if(index > max_list_Index)
				{
					index = max_list_Index;
				}

				return index;
				//items.Count != 0 ? index : 0;
			} 

			set
			{
				int max_list_Index = items.Count - 1;
				
				if (items.Count == 0)
				{
					index = 0;
				}
				else if (value > max_list_Index)
				{
					index = 0;
				}
				else if (value < 0)
				{
					index = max_list_Index;
				}
				else
				{
					index = value;
				}
			}
		}

		public void Next()
		{
			Index++;
		}
		public void Back()
		{
			Index--;
		}
		public void Remove(T item)
		{
			if (items.Contains(item))
				items.Remove(item);
		}
	}
}
