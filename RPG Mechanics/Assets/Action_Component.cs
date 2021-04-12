using Assets;
using Assets.Action_Select_GUI.Scripts;
using Raspberry.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Component : MonoBehaviour
{
    [SerializeField] private Body_Component body_Component;
    [SerializeField] private Movement_Component movement_Component;
    [SerializeField] private IInteractable interactable;
    public bool In_Attack_State;
	private void Awake()
	{
        interactable = GetComponent<IInteractable>();
        if(interactable == null)
		{
            interactable = new Null_Interactable();

        }

    }

	public void Execute(GameObject gameObject, IRange range, ITraversal_Method traversal_Method, Move_Window Move_Window)
    {
        List<IInsitagtor_Intent> intents = new List<IInsitagtor_Intent>();
        if(In_Attack_State)
		{
            if (body_Component == null)
            {
                Debug.Log("Body component was null on " + gameObject.name);
                return;
            }

            Target_GameObject target = new Target_GameObject(gameObject, range);
            IInsitagtor_Intent intent = new Instigator_Intent_Attack(new Instigator_Standard(movement_Component), body_Component, target, traversal_Method);
            intents.Add(intent);
            Move_Window.Set_Up(interactable.Interact(intents));
        }
    }
}
