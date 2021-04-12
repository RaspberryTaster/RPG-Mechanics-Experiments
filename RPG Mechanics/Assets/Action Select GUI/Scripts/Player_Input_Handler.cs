using Assets;
using Raspberry.Movement;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Player_Input_Handler : MonoBehaviour, IInstigator
{
    public Move_Window Move_Window;
    private int fingerID = -1;
    public IInsitagtor_Intent intent;
    public bool Can_Walk => true;

	public Movement_Component Movement_Component => null;

	void Update()
    {
        if(EventSystem.current.IsPointerOverGameObject(fingerID))return;
        if (Input.GetMouseButtonDown(0))
		{
            RaycastHit hit;
			IInteractable interactable = new Null_Interactable();
            List<IInsitagtor_Intent> intents = new List<IInsitagtor_Intent>();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
				IInteractable minor_interactable = hit.transform.GetComponent<IInteractable>();
				if (minor_interactable != null)
				{
                    interactable = minor_interactable;
				}
                /*
                other_Body = hit.transform.GetComponent<Body>();
                if(other_Body != null)
				{
                    intent = new Instigator_Intent_Attack(this, other_Body);
                    intents.Add(intent);
				}
                */
            }

            Move_Window.gameObject.SetActive(false);
            Move_Window.Move_To_Mouse_Position();
            List<IExecutable> executables = interactable.Interact(intents);
            if (executables == null) return;
            Move_Window.gameObject.SetActive(true);
            Move_Window.Initalize(executables);
        }
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            IInteractable interactable = new Null_Interactable();
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                IInteractable minor_interactable = hit.transform.GetComponent<IInteractable>();
                if (minor_interactable != null)
                {
                    interactable = minor_interactable;
                }
            }

            Move_Window.gameObject.SetActive(false);
            Move_Window.Move_To_Mouse_Position();
            List<IExecutable> executables = interactable.Alt_Interact(this);
            if (executables == null) return;
            Move_Window.gameObject.SetActive(true);
            Move_Window.Initalize(executables);
            
        }
    }
}
