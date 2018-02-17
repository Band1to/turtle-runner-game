using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
	private Rigidbody2D body;
	private Vector2 jumpVelocity = new Vector2(0, 6);
	private Vector3 groundedVector = new Vector3(0, -1.0f, 0);

	// Use this for initialization
	void Start () 
	{
		body = this.gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		Debug.DrawLine(transform.position, transform.position + groundedVector, Color.yellow);

		if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
		{
			body.velocity = jumpVelocity;
		}
	}

	bool isGrounded()
	{
		int blockedMask = (1 << LayerMask.NameToLayer("Impassable"));
		return Physics2D.Linecast(transform.position, transform.position + groundedVector, blockedMask);
	}
}
