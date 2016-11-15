using UnityEngine;
using System.Collections;

public class BulletClass : MonoBehaviour {

	public Vector3 direction;
	public float speed;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.position += direction * Time.deltaTime * speed;
	
	}

	void OnCollisionEnter(Collision col) {

		if (col.gameObject.tag == "enemy")
		{

			Destroy(col.gameObject);
			Destroy(gameObject);

		} else {

			Destroy(gameObject);

		}

	}


}
