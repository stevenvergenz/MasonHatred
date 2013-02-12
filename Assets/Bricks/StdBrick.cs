using UnityEngine;
using System.Collections;

public class StdBrick : MonoBehaviour
{
	public Material[] healthMaterials;
	public int health;
	
	public AudioClip breakSound;
	public AudioClip weakenSound;
	
	
	// Use this for initialization
	void Start ()
	{
		//health = Random.Range(0, healthMaterials.Length)+1;
		//health = 2;
		renderer.material = healthMaterials[health-1];
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	
	void OnCollisionExit( Collision collisionInfo )
	{
		//Debug.Log("Health was " + health);
		health--;
		if( health == 0 ){
			AudioSource.PlayClipAtPoint(breakSound, transform.position);
			Destroy( gameObject );
		}
		else {
			AudioSource.PlayClipAtPoint(weakenSound, transform.position);
			renderer.material = healthMaterials[health-1];
		}
	}
}
