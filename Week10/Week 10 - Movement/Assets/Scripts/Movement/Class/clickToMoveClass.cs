using UnityEngine;
using System.Collections;

public class clickToMoveClass : MonoBehaviour {

	private Vector3 destination;

	Vector3 move;

	public float moveSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//check if the player is clicking
		if (Input.GetMouseButton(0)) {

		//see where they're clicking
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast(ray, out hit) && hit.collider.tag == "ground")
			{
				//move the player to that point
				destination = hit.point;

 				//make sure the destination is at the player's current height
				destination = new Vector3(destination.x, transform.position.y, destination.z);



				move = destination - transform.position;

				move = move.normalized;


				transform.position += move * Time.deltaTime * moveSpeed;
				//transform.position = Vector3.Lerp(transform.position, destination, .2f);

			}
		}
	}
}
