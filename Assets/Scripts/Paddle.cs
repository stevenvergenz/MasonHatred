using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour
{
	public float maximumSkew = 300;
	public float deadZone = 0.15f;
	
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		float delta = Input.GetAxis("Mouse X");
		transform.position += new Vector3(delta, 0, 0);
	}
	
	void OnCollisionExit(Collision collisionInfo)
	{
		// convert collision to local coords
		Vector3 collisionPoint = transform.InverseTransformPoint(
			collisionInfo.contacts[0].point );
		
		// skew bounce based on collision location
		if( Mathf.Abs(collisionPoint.y) >= deadZone )
		{
			float scale;
			if( collisionPoint.y > 0 )
				scale = (collisionPoint.y - deadZone)/(1-deadZone);
			else
				scale = (collisionPoint.y + deadZone)/(1-deadZone);
			collisionInfo.rigidbody.AddForce( new Vector3(-scale*maximumSkew, 0, 0) );
		}
		//collisionInfo.gameObject.rigidbody.AddForce();
		
	}
}
