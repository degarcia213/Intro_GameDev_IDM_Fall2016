using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public Transform[] spawnPoints;
	public Enemy basic;
	public Enemy tough;
	public Player player;
	public float toughEnemySpawnChance;

	// Use this for initialization
	void Start () {

		//this is going to call our Spawn function once every second.
		InvokeRepeating("Spawn", 1f, 1f);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Spawn() {
		//quit spawning if we're DEAD
		if (player.currentHealth > 0){

			//first, we'll decide whether to spawn a basic enemy or a tough enemy, by picking a random number between 0 and 1.
			float randomNum = Random.Range(0.0f,1.0f);

			//if our randomNum is less than our toughEnemySpawnChance, we'll Instatiate a TOUGH Enemy. Otherwise, a basic.
			if (randomNum < toughEnemySpawnChance) {

				//We'll instantiate an enemy similar to how we did our bullets. But we'll pick a random spawn point from an array we create in
				//our Unity scene.
				Enemy newEnemy = (Enemy) Instantiate(tough, spawnPoints[Random.Range(0,spawnPoints.Length)].position, Quaternion.identity);
				// we also need to set the enemy's target to our player.
				newEnemy.target = player.transform;

			} else {
				//same as above, but we use a basic enemy.
				Enemy newEnemy = (Enemy) Instantiate(basic, spawnPoints[Random.Range(0,spawnPoints.Length)].position, Quaternion.identity);
				newEnemy.target = player.transform;
			}
		}


	}
}
