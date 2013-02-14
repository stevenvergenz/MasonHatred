using UnityEngine;
using System.Collections;

public class BrickManager : MonoBehaviour
{
	public Transform[] bricks;
	public Transform well;
	
	private int _bricksRemaining = 0;
	public int bricksRemaining { 
		get { return _bricksRemaining; }
		set
		{
			_bricksRemaining = value;
			if( _bricksRemaining == 0 ){
				Debug.Log("You win!");
			}
		}
	}
	
	// brick spawn range: x[-8,8], y[0,4.75]
	//private static float columns[] = {0.0f, 1.05f, 2.1f, 3.15f, 4.2f, 5.25f, 6.3f};
	
	// Use this for initialization
	void Start ()
	{
		int column = 0, row = 0;
		for( float i=-6; i<7; i+=1 )
		{
			row = 0;
			for( float j=0; j<4; j+=0.25f )
			{
				int type = (row+column)%2;
				Transform brick = Instantiate(
					bricks[type], new Vector3(i,j,0), Quaternion.identity) as Transform;
				brick.parent = transform;
				bricksRemaining++;
				row++;
			}
			column++;
		}
		
		StartCoroutine( "SpawnGravityWell" );
	}
	
	IEnumerator SpawnGravityWell()
	{
		yield return new WaitForSeconds(2);
		Instantiate( well );
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
