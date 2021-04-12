using Assets;
using Assets.Action_Select_GUI.Scripts;
using Assets.Queue.Enums;
using NaughtyAttributes;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Raspberry.Movement
{
    public class Player_Input : MonoBehaviour
    {
        public Vector3 cur_Mouse_Position;
        Camera cam;
        public Player_Controller player_Controller;
        public Queue_Component queue_Component;
        public Movement_Component movement_Component;
        public List<ITraversal_Method> traversal_Methods = new List<ITraversal_Method>();
        public int traversal_Index;
        public Body_Component Body_Component;
        private int fingerID = -1;
        public Move_Window Move_Window;
        void Start()
        {
            cam = Camera.main;
            Update_Unit();
        }

        [Button("Set Unit", EButtonEnableMode.Always)]
        public void Set_Unit()
        {
            queue_Component = player_Controller.queue_Component;
            movement_Component = player_Controller.movement_Component;
            Update_Unit();

        }

        [Button("Update Unit", EButtonEnableMode.Always)]
        private void Update_Unit()
        {
            if (movement_Component == null)
            {
                traversal_Methods.Clear();
            }
            else
            {
                ITraversal_Method teleport = new Traversal_Teleport(movement_Component.gameObject);
                ITraversal_Method walk = new Traversal_Nav_Move(movement_Component.NavMeshAgent);
                traversal_Methods = new List<ITraversal_Method> { teleport, walk };
            }
        }

        void Update()
        {
            if (EventSystem.current.IsPointerOverGameObject(fingerID)) return;
            if (Input.GetMouseButtonDown(0))
            {
                Move_Window.gameObject.SetActive(false);

                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit, 100))
                {
                    cur_Mouse_Position = hit.point;

                    ITargetable Targetable = hit.transform.gameObject.GetComponent<Targetable_Component>();
                    if (Targetable == null)
                    {
                        Targetable = new Targetable_Null();
                    }

                    IRange Range = hit.transform.gameObject.GetComponent<Range_Component>();
                    if (Range == null)
                    {
                        Range = new Range_Null();
                    }
                    if (traversal_Index > traversal_Methods.Count - 1) return;
                    Targetable.Targeted_For_Destination(this, Range, traversal_Methods[traversal_Index]);

                }
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                movement_Component.Movement_Handler.Idle();
            }
        }
        public void SetEnviromentDestination(Vector3 position, ITraversal_Method traversal_Method)
        {
            Range_Values range_Interface_Values = new Range_Values(0.1f, 0.1f, 0.1f);
            IRange range_Temp = new Range_Null(range_Interface_Values);
            Target_Position target = new Target_Position(position, range_Temp);
            IAction_Intent move_Intent = new Intent_None(0.1f);
            movement_Component.Move(target, traversal_Method, move_Intent, Action_Types.ENVIROMENT_MOVE);
        }

        public void SetObjectDestination(GameObject gameObject, IRange range, ITraversal_Method traversal_Method)
        {
            /*
            Body_Component body_Component = gameObject.GetComponent<Body_Component>();
            IInteractable interactable = new Null_Interactable();
            List<IInsitagtor_Intent> intents = new List<IInsitagtor_Intent>();
            IInteractable minor_interactable = gameObject.transform.GetComponent<IInteractable>();
            if (minor_interactable != null)
            {
                interactable = minor_interactable;
            }

            if (body_Component == null)
			{
                Debug.Log("Body component was null on " + gameObject.name);
                return;
			}

            Target_GameObject target = new Target_GameObject(gameObject, range);
            IInsitagtor_Intent intent = new Instigator_Intent_Attack(new Instigator_Standard(movement_Component), body_Component, target, traversal_Method);
            intents.Add(intent);

            Move_Window.gameObject.SetActive(false);
            Move_Window.Move_To_Mouse_Position();
            List<IExecutable> executables = interactable.Interact(intents);
            if (executables == null) return;
            Move_Window.gameObject.SetActive(true);
            Move_Window.Initalize(executables);
            */
            Action_Component action_Component= Body_Component.gameObject.GetComponent<Action_Component>();
            if (action_Component == null)
			{
                Debug.Log(action_Component == null);
                return;
			}
            action_Component.Execute(gameObject, range, traversal_Method, Move_Window);
        }
    }
}
