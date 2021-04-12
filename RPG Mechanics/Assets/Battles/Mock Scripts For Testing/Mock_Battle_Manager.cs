using Assets.Battles;
using Assets.Units;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Mock
{
    [CreateAssetMenu]
    public class Mock_Battle_Manager : ScriptableObject
    {
        public Battle_Order_Manager battle_Order_Manager;
        public void Remove_Random()
		{
            if (battle_Order_Manager.orderd_Units.Count == 0) return;
            int index = 0;
            Unit selected_Unit;
            if (battle_Order_Manager.orderd_Units.Count > 1)
			{
                index = Random.Range(0, battle_Order_Manager.orderd_Units.Count - 1);
                selected_Unit = battle_Order_Manager.orderd_Units[index];

            }
            else
			{
                selected_Unit = battle_Order_Manager.orderd_Units[index];
            }

            Debug.Log(index + " is the unit index.");
            battle_Order_Manager.Remove_From_Queue(selected_Unit);
        }
    }
}

