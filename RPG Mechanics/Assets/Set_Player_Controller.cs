using Assets.Battles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set_Player_Controller : MonoBehaviour
{
	public Battle_Order_Manager battle_Order_Manager;
	public Player_Controller Player_Controller;


	public void Set_Unit()
	{
		Player_Controller.Select_Unit(battle_Order_Manager.Current_Unit);
	}
}
