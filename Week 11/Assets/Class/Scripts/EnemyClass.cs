using UnityEngine;
using System.Collections;

public class EnemyClass : MonoBehaviour {

	//we'll initialize this to the thing we want to follow
	public Transform target;

	public float moveSpeed;
	public float damage;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 direction = target.position - transform.position;

		//turn our enemy to look in the direction of the vector.
		transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), .2f);



		//move our enemy in the direction of the player
		transform.position += direction.normalized * Time.deltaTime * moveSpeed;
	
	}
}
