using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

	public BulletClass bullet;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Space)){
			Shoot();
		}
	
	}

	void Shoot() {
		
		bullet.direction = transform.forward;
		// create a bullet, at our position, with our rotation.
		Instantiate(bullet, transform.position + transform.forward, transform.rotation);


	}
}
