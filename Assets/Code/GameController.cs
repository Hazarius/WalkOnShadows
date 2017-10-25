using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	public Transform playerSpawn;
	public GameObject playerPrefab;
	// Use this for initialization
	void Start ()
	{
		Instantiate(playerPrefab, playerSpawn.transform.position, playerSpawn.transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
