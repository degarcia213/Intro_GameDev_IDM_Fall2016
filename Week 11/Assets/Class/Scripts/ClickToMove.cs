using UnityEngine;
using System.Collections;

public class ClickToMove : MonoBehaviour {

	// for moving
	public float moveSpeed;
	Vector3 move;

	// for jumping
	public float jumpStrength;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
			move = new Vector3(0,0,0);

			//check if player is clicking
			if (Input.GetMouseButton(0)){



				//move player object to where player clicked.... but this is more complicated...
				//find out where player click is overlapping with the ground plane
				//we'll use a raycast. We need to declare a RayCast hit that we can output to...
				RaycastHit hit;
				//...and also a ray we want to use. Specifically, one that uses our camera to shoot through a point on the screen (our mouse).
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

				//if our raycast hits, then we'll move toward the point we hit.
				//BUT! We should also check if the thing we hit is the ground, which we can do using tags (set on the gameobject in unity)
				if (Physics.Raycast(ray, out hit) && hit.collider.tag == "ground"){

					//rotate the player toward the point, but make sure it's not looking down.
					Vector3 lookPoint = new Vector3(hit.point.x, transform.position.y, hit.point.z);
					transform.rotation = Quaternion.LookRotation(lookPoint - transform.position);
					//reset

					//move the player to the point
					Vector3 destination = hit.point;

					// this smooth lerp is okay for certain kinds of games
					//transform.position = Vector3.Lerp(transform.position, destination, .2f);

					// first, we get the direction the same way we used it to get the rotation.
					move = destination - transform.position;

					//this should not account for our y speed!
					move = new Vector3(move.x, 0, move.z);

					//transform.position += move; <-- we could just do this, but then we'd be teleporting.
					//instead, let's give ourselves a consistent speed, starting by NORMALIZING our vector.
					//that sets the magnitude to 1.
					move.Normalize();
				}
			}

			//now we add it to our position
			transform.position += move * Time.deltaTime * moveSpeed;
	}
}
