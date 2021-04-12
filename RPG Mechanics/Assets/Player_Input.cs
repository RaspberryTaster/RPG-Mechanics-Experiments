using Assets.Units;
using Raspberry.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Input_State
{
    CHARACTER_SELECT, CASTING
}
public class Player_Input : MonoBehaviour
{
    public Player_Controller Player_Controller;
    Camera cam;
    Vector3 cur_Mouse_Position;
    public Input_State Input_State;
	private void OnEnable()
	{
        Player_Controller.On_Casting += Set_Casting;
    }
	// Start is called before the first frame update
	void Awake()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100))
            {
                cur_Mouse_Position = hit.point;


                Unit unit = hit.transform.gameObject.GetComponent<Unit>();
                if (unit == null) return;
                if (Input_State == Input_State.CHARACTER_SELECT)
                {
                    Player_Controller.Select_Unit(unit);
                }
                else if (Input_State == Input_State.CASTING)
                {
                    Player_Controller.Targeting_Component?.targets.Add(unit);
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Input_State = Input_State.CHARACTER_SELECT;
            Player_Controller.Targeting_Component?.On_Interrupt();
        }
    }

    public void Set_Casting()
	{
        Input_State = Input_State.CASTING;
	}

	public void OnDisable()
	{
        Player_Controller.On_Casting -= Set_Casting;
    }
}
