using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
	public Transform MainPlane;
	static WorldManager _instance;

	public static WorldManager Instance {
		get {
			return _instance;
		}
	}
	
	void Awake()
	{
		_instance = this;
	}

	public void Append(Transform unit)
	{
		unit.transform.SetParent(MainPlane);
		unit.transform.position = new Vector3(unit.transform.position.x, unit.transform.position.y, MainPlane.transform.position.z);
	}

	// Use this for initialization
	void Start ()
	{

	}
}
