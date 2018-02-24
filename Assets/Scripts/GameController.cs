using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour 
{
	public float timePerTile = 1.0f;
	private float lastTileTime = 0;

	public GameObject tileObject;
	public Transform tileTransform;

	public UnityEngine.UI.Text timeText;

	private float time;

	// Use this for initialization
	void Start () 
	{
		time = 0;
	}

	void Update () 
	{
		time = Time.time;
		timeText.text = "Time: " + time.ToString("N");

		if (time > lastTileTime)
		{
			lastTileTime = time + timePerTile;
			GameObject.Instantiate(tileObject, tileTransform);
		}
	}
}
