using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
	private Rigidbody2D body;
	private Vector2 jumpVelocity = new Vector2(0, 6);

	// Use this for initialization
	void Start () 
	{
		body = this.gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			body.velocity = jumpVelocity;
		}
	}
}
