using Assets.Body_Parts;
using Assets.Damage_Types;
using Assets.Stats;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Body_Part
{
	public string Name;
	public Health Health;
	public Armor Armor;
	public Barrier Barrier;
	public List<IDefence> Defences = new List<IDefence>();
	public IBody_Part_Handler Body_Part_Handler;
	public Body_Part_Combat Body_Part_Combat;
	public Body_Part(int health, int armor, int barrier, List<IDefence> defences, string name)
	{
		Armor = new Armor(armor);
		Health = new Health(health);
		Barrier = new Barrier(barrier);
		Body_Part_Combat = new Body_Part_Combat(this);
		Defences = defences;
		Name = name;
	}

	public Body_Part(Health health, Armor armor, Barrier barrier, string name)
	{
		Health = health;
		Armor = armor;
		Barrier = barrier;
		Body_Part_Combat = new Body_Part_Combat(this);
		Name = name;
	}

	protected Body_Part(Health health, Armor armor, Barrier barrier, List<IDefence> defences, string name)
	{
		Health = health;
		Armor = armor;
		Barrier = barrier;
		Defences = defences;
		Body_Part_Combat = new Body_Part_Combat(this);
		Name = name;
	}

	public abstract void On_Crippled();
	public abstract void On_Destroyed();
	public abstract string To_String();
}
