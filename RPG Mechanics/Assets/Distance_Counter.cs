using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distance_Counter : MonoBehaviour
{
	public int Movement_Points;
    [SerializeField] private float distance; //variable for total distance
    private Vector3 oldPos = new Vector3(0.0f, 0.0f, 0.0f);
	public bool Reached_Max_Distance { get => Movement_Points <= distance; }
	private void FixedUpdate()
	{
		oldPos = transform.position;
	}
	private void LateUpdate()
	{
		distance += Vector3.Distance(oldPos, transform.position);
	}
}
