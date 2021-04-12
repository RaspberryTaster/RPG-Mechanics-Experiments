using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRequire_Position
{
	void Set_Position(Vector3 position);
}

public class Spawn_A_Ball_ : MonoBehaviour, IRequire_Position
{
    public GameObject prefab;

	public void Set_Position(Vector3 position)
	{
		Spawn(position);
	}

	public void Spawn(Vector3 position)
	{
		Instantiate(prefab, position, Quaternion.identity);
		Debug.Log(prefab + " has been spawned.");
	}
}
