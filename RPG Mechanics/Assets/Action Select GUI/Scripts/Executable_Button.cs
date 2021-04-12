using Assets;
using TMPro;
using UnityEngine;

public class Executable_Button : MonoBehaviour
{
	public IExecutable executable = new Null_Executable();
	public TextMeshProUGUI text_Box;

	public void Initalize(IExecutable executable)
	{
		this.executable = executable;
		text_Box.text = this.executable.Name;
	}
	public void Execute()
	{
		executable.Execute();
	}
}
