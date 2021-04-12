using Assets.Battles;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Color_Based_On_Team : MonoBehaviour
{
    public Battle_Order_Manager Battle_Order_Manager;
    public Color team_Color;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [Button("Set Color", EButtonEnableMode.Always)]
    public void Set_Colors()
	{
		Assets.Units.Unit current_Unit = Battle_Order_Manager.Current_Unit;
        if (current_Unit == null) return;
		if (current_Unit?.Team == 2)
		{
            Renderer renderer = Battle_Order_Manager?.Current_Unit?.gameObject.GetComponent<Renderer>();
            renderer.material.color = team_Color;
		}
	}
}
