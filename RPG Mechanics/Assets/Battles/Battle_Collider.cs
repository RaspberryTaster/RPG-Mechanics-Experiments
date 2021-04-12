using Assets.Units;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle_Collider : MonoBehaviour
{
	public Unit_Runtime_Set Fight_Runtime_Set;
	public void OnTriggerEnter(Collider other)
	{
		Debug.Log(other.name);
		Unit unit = other.GetComponent<Unit>();
		if (unit == null) return;
		Fight_Runtime_Set.Add(unit);

	}

	public void OnTriggerExit(Collider other)
	{
		Unit unit = other.GetComponent<Unit>();
		if (unit == null) return;
		Fight_Runtime_Set.Remove(unit);
	}
}
