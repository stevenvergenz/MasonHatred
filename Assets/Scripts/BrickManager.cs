using UnityEngine;
using System.Collections;

public class BrickManager : MonoBehaviour
{
	public Transform[] bricks;
	
	// brick spawn range: x[-8,8], y[0,4.75]
	// Use this for initialization
	void Start ()
	{
		for( float i=-7; i<7; i+=1.05f )
		{
			for( float j=0; j<4.5f; j+=0.3f )
			{
				int type = Random.Range(0, bricks.Length);
				Instantiate(bricks[type], new Vector3(i,j,0), Quaternion.identity);
			}
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
