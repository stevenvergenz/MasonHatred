using UnityEngine;
using System.Collections;

public class BrickManager : MonoBehaviour
{
	public Transform[] bricks;
	
	// brick spawn range: x[-8,8], y[0,4.75]
	//private static float columns[] = {0.0f, 1.05f, 2.1f, 3.15f, 4.2f, 5.25f, 6.3f};
	
	// Use this for initialization
	void Start ()
	{
		int column = 0, row = 0;
		for( float i=-6.3f; i<7; i+=1.05f )
		{
			row = 0;
			for( float j=0; j<4.5f; j+=0.3f )
			{
				int type = (row+column)%2;
				Instantiate(bricks[type], new Vector3(i,j,0), Quaternion.identity);
				row++;
			}
			column++;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
