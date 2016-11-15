using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float speed;
	public Vector3 direction;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.position += direction.normalized * Time.deltaTime * speed;

	}



	void OnCollisionEnter(Collision col) {
		
		if(col.collider.tag == "enemy") {
			col.gameObject.GetComponent<Enemy>().Kill();
			Destroy(gameObject);
		} else {
			Destroy(gameObject);
		}
	}
}
