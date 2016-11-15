using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public int maxHealth;
	//making this public just so i can monitor it a bit.
	public int currentHealth;

	public Bullet bullet;

	// Use this for initialization
	void Start () {

		//set health to our max health value!
		currentHealth = maxHealth;
	
	}
	
	// Update is called once per frame
	void Update () {
	
		//check to see if we're DEAD
		if (currentHealth <= 0)
		{
			//for now we can just deactivate ourself ;)
			gameObject.SetActive(false);

		}

		if (Input.GetKeyDown(KeyCode.Space)){
			Shoot();
		}
	}

	void Shoot(){
		// here we declare a new bullet, and set it equal to a game object that we've instantiated from a prefab.
		Bullet newBullet = (Bullet) Instantiate(bullet, transform.position + transform.forward, transform.rotation);
		newBullet.direction = transform.forward;

	}

	//WE NEED A WAY TO GET HIT!!! Remember OnTriggerEnter? We'll use a similar function...
	void OnCollisionEnter(Collision col){
		if (col.collider.tag == "enemy") {
			
			currentHealth -= col.gameObject.GetComponent<Enemy>().damage;

		}

	}
}
