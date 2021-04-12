using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Selected_Unit_State_UI : MonoBehaviour
{
    public Player_Controller player_Controller;
    public TextMeshProUGUI textMeshProUGUI;
    Targeting_Component targeting_Component;
    public void Initalize()
	{
        if(targeting_Component != null)
		{
            targeting_Component.Is_Casting -= Update_GUI;
            targeting_Component.Is_Interupted -= Update_GUI;
        }

        targeting_Component = player_Controller.Targeting_Component;
        
        if(targeting_Component != null)
		{
            targeting_Component.Is_Casting += Update_GUI;
            targeting_Component.Is_Interupted += Update_GUI;
        }

	}
    public void Update_GUI()
	{
        string message = "Selected Unit State: N/A";

        if(targeting_Component != null)
		{
            if(targeting_Component.target_State == State.Casting)
			{
                message = "Selected Unit State: Casting";
            }
            else if(targeting_Component.target_State == State.Neutral)
			{
                message = "Selected Unit State: Neutral";
            }
		}

        textMeshProUGUI.text = message;
	}

	private void OnDisable()
	{
        if (targeting_Component != null)
        {
            targeting_Component.Is_Casting -= Update_GUI;
            targeting_Component.Is_Interupted -= Update_GUI;
        }
    }
}
