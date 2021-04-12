using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Selected_Unit_UI : MonoBehaviour
{
    public Player_Controller player_Controller;
    public TextMeshProUGUI text;
   
    public void Update_UI()
	{
        string message = "Selected Unit: None";
        if(player_Controller.Current_Unit != null)
		{
            message = $"Selected Unit {player_Controller.Current_Unit}";
		}

        text.text = message;
	}
}
