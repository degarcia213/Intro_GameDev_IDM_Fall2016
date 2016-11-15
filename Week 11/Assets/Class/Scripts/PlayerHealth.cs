using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

	public float maxHealth;
	public float currentHealth;

	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {

		if (currentHealth <= 0) {
			// this destroys the game object of the player (and crashes our scene);
			//Destroy(gameObject);

			SceneManager.LoadScene(0);

		}
	
	}

	void OnCollisionEnter(Collision col) {

		if (col.gameObject.tag == "enemy") {

			currentHealth -= col.gameObject.GetComponent<EnemyClass>().damage;

		}

	}
}
