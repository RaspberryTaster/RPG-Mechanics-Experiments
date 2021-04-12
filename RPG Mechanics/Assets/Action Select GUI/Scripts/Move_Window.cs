using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move_Window : MonoBehaviour
{
    public Executable_Button prefab;
    public int inital_Count = 5;
    public List<Executable_Button> children;

    private void Awake()
    {

        Executable_Button[] children = GetComponentsInChildren<Executable_Button>();
        for (int i = 0; i < children.Length; i++)
		{
            if (this.children.Contains(children[i])) return;
            this.children.Add(children[i]);
		}
        if(children.Length < inital_Count)
		{
            int value = inital_Count - this.children.Count;
            for(int i = 0; i < value; i++)
			{
                Executable_Button temp = Instantiate(prefab, transform);
                this.children.Add(temp);
			}
		}
        gameObject.SetActive(false);
	}
	public void Move_To_Mouse_Position()
	{
        transform.position = Input.mousePosition;
    }

    public void Initalize(List<IExecutable> executables)
	{
        Clear();

        int iteration_Count = executables.Count;
        if(iteration_Count > children.Count)
		{
            iteration_Count = children.Count;
		}
        for(int i = 0; i < iteration_Count; i++)
		{
            Debug.Log(iteration_Count + " " + i);
            children[i].Initalize(executables[i]);
            children[i].gameObject.SetActive(true);
        }
	}

    public void Clear()
	{
        for (int i = 0; i < children.Count; i++)
        {
            children[i].gameObject.SetActive(false);
        }
    }

    public void Set_Up(List<IExecutable> executables)
	{
        gameObject.SetActive(false);
        Move_To_Mouse_Position();
        if (executables == null) return;
        gameObject.SetActive(true);
        Initalize(executables);
    }
}
