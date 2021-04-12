using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IExecutable
{
	string Name { get; }
	void Execute();
}
