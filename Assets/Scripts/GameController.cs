using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour 
{
	public float timePerTile = 1.0f;
	private float lastTileTime = 0;

	public GameObject tileObject;
	public Transform tileTransform;

	// Use this for initialization
	void Start () 
	{
		
	}

	void Update () 
	{
		if (Time.time > lastTileTime)
		{
			lastTileTime = Time.time + timePerTile;
			GameObject.Instantiate(tileObject, tileTransform);
		}
	}
}
