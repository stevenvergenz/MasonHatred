using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
	public float targetVelocity = 10;
	public Vector3 startDirection = new Vector3(-1, -1, 0);
	
	// Use this for initialization
	void Start ()
	{
		rigidbody.AddForce( 300 * startDirection.normalized );
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		//Debug.Log( "Speed: " + rigidbody.velocity.magnitude );
		// try to keep ball velocity close to value
		if( rigidbody.velocity.magnitude - targetVelocity > 1 ){
			rigidbody.drag = 5;
		}
		else if( rigidbody.velocity.magnitude - targetVelocity < -1 ){
			rigidbody.AddForce( rigidbody.velocity.normalized );
		}
		else {
			rigidbody.drag = 0;
		}
	}
}
