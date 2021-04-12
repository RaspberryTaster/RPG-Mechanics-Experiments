using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Event_Managment.Runtimeset
{
    public abstract class Runtime_Set<T> : ScriptableObject
    {
        public List<T> Items = new List<T>();
        public virtual void Set_Items(List<T> items)
        {
            Items = items;
        }
        public virtual void Add(T subject)
        {
            if (!Items.Contains(subject))
                Items.Add(subject);
        }

        public virtual void Remove(T subject)
        {
            if (Items.Contains(subject))
                Items.Remove(subject);
        }
        public virtual void Clear()
		{
            Items.Clear();
		}
    }
}
