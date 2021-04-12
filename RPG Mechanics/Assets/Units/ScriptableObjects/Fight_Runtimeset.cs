using Assets.Units;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Fight runtimeset")]
public class Fight_Runtimeset : Unit_Runtime_Set
{

	public HealthBar_Distributer HealthBar_Distributer;
    public override void Add(Unit subject)
    {
        if (!Items.Contains(subject))
		{
            Items.Add(subject);
            HealthBar_Distributer.Set(subject.transform);
        }

    }

    public override void Remove(Unit subject)
    {
        if (Items.Contains(subject))
		{
            HealthBar_Distributer.Set(subject.transform);
            Items.Remove(subject);
        }

    }
    public override void Clear()
    {
		int count = Items.Count;
		for (int i = 0; i< count; i++)
		{
            Remove(Items[i]);
		}
    }
}
