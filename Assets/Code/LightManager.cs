using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour {

	static LightManager _instance;

	public List<LightSource> Sources = new List<LightSource>();

	public static LightManager Instance {
		get {
			return _instance;
		}
	}

	void Awake()
	{
		_instance = this;
	}

	// Use this for initialization
	void Start () {
		
	}


	public void Register(LightSource source)
	{
		if (!Sources.Contains(source)) {
			Sources.Add(source);
		}
	}

	public void UnRegister(LightSource source)
	{
		if (Sources.Contains(source)) {
			Sources.Remove(source);
		}
	}
}
