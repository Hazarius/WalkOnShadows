﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class LightSource : MonoBehaviour
{
	void Awake ()
	{
		LightManager.Instance.Register(this);
	}
}
