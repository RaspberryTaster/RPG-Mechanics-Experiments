using Assets.Body_Parts;
using Assets.Damage_Types;
using Assets.Stats;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torso : Body_Part
{
	public Torso(Health health, Armor armor, Barrier barrier, string name) : base(health, armor, barrier, name)
	{
	}

	public Torso(int health, int armor, int barrier, List<IDefence> defences, string name) : base(health, armor, barrier, defences, name)
	{
	}

	public Torso(Health health, Armor armor, Barrier barrier, List<IDefence> defences, string name) : base(health, armor, barrier, defences, name)
	{
	}

	public override void On_Crippled()
	{
		Debug.Log("Torso crippled");
	}

	public override void On_Destroyed()
	{
		Debug.Log("Torso destroyed");
		//Body_Part_Handler.Unit_Stats.Damage(Health);
		Body_Part_Handler.On_Body_Part_Destroyed();
	}

	public override string To_String()
	{
		return "Torso";
	}
}
