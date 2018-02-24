using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour 
{
	public Vector3 direction;

	void Update () 
	{
		transform.position += direction * Time.deltaTime;

		// Destroy self when far enough away from player
		//TODO: There's probably a better way of doing this
		if (transform.position.x < -30.0f)
			Destroy(this.gameObject);
	}
}
