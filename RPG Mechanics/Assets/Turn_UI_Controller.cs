using Assets.Battles;
using Raspberry.Events;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Turn_UI_Controller : MonoBehaviour
{
	public Battle_Order_Manager Order_Manager;
	public Battle_Round_Manager Round_Manager;
	public TextMeshProUGUI New_Round_Text;
	public TextMeshProUGUI Current_Unit_Text;

	
	public void Update_Unit_GUI()
	{
		if(Order_Manager.Current_Unit != null)
		{
			Current_Unit_Text.text = $"It's, {Order_Manager.Current_Unit}'s turn!";
		}
		else
		{
			Current_Unit_Text.text = $"It's, nobody's turn :(";
		}
	}
	public void Update_Round_GUI()
	{
		New_Round_Text.text = "Current Round: " + Round_Manager.Current_Round;
	}
}
