using UnityEngine;
using System.Collections;

public class playerJumpClass : MonoBehaviour {

	public float jumpStrength;

	private Vector3 yVelocity;

	public float gravity;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {



		//give the player upwards velocity;
		transform.position += yVelocity * Time.deltaTime;

		if (transform.position.y > 1) {
			
			yVelocity.y -= gravity * Time.deltaTime;

		} else {

			yVelocity.y = 0;

			transform.position = new Vector3(transform.position.x,1.0f,transform.position.z);

			if (Input.GetKeyDown(KeyCode.Space)){

				//set the yvelocity to equal (0,jumpstrength,0) when we press space
				yVelocity = new Vector3(0, jumpStrength, 0);

			}
		}
	}
}
