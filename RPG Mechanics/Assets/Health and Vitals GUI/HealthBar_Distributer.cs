using Assets.Units;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Health bar distriutor")]
public class HealthBar_Distributer : ScriptableObject
{
    public HealthBar HealthBar;

    public void Set(Transform transform)
	{
        HealthBar.SetHealthBarData(transform);
	}
}
