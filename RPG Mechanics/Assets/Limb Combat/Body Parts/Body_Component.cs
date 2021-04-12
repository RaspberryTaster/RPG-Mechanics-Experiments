using Assets.Attacks;
using Assets.Body_Parts;
using Assets.Damage_Types;
using Assets.Stats;
using System.Collections.Generic;
using UnityEngine;

public class Body_Component : MonoBehaviour
{
	public int Inital_Barrier;
	public int Inital_Endurance;
	public int Inital_Health;
	public int Inital_Armor;
	public IBody_Part_Handler Non_Vital;
	public IBody_Part_Handler Vitals;
	public Body_Combat Body_Combat;
	public bool Evading;
	private void Awake()
	{
		Barrier barrier = new Barrier(Inital_Barrier);
		Body_Combat = new Body_Combat(new Endurance(Inital_Endurance), barrier);

		List<IDefence> defence = new List<IDefence>() { new Slash_Defence(Defence_Value.IMMMUNE), new Pierce_Defence(Defence_Value.WEAKNESS), new Blunt_Defence(Defence_Value.STANDARD) };
		Torso torso = new Torso(new Health(Inital_Health), new Armor(Inital_Armor), barrier, defence, "Bulky Torso");

		List<Body_Part> body_Parts = new List<Body_Part>() { torso };
		Non_Vital = new Non_Vital_Body_Part_Handler(this);
		Vitals = new Vital_Body_Part_Handler(this, body_Parts);

	}

	public void Die()
	{
		Debug.Log("Dead");
	}

	public void Attack(Body_Part body_Part, Damaging_Attack damaging_Attack)
	{
		bool capable_Of_Evading_Blow = Body_Combat.Endurance.Value > damaging_Attack.Value && Evading;
		if (capable_Of_Evading_Blow)
		{
			Body_Combat.On_Evade(damaging_Attack);
		}
		else
		{
			Body_Combat.On_Hit(body_Part, damaging_Attack);
		}

	}
	public void Add_Barrier(int value)
	{
		Body_Combat.Add_Barrier(value);
	}
	public void Heal(int value)
	{
		Body_Combat.Heal(value);
	}
}
