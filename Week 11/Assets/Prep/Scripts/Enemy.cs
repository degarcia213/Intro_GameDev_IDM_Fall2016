using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	//we'll instantiate this target variable in the Enemy's inspector, by setting it to the player.
	public Transform target;
	public float moveSpeed;
	public int damage;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//get the direction toward the player
		Vector3 myDirection = target.position - transform.position;

		//turn the enemy to look in that direction
		transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(myDirection), .2f);

		//move the enemy in that direction
		transform.position += myDirection.normalized * Time.deltaTime * moveSpeed;
	
	}

	public void Kill(){

		Destroy(gameObject);

	}
}
