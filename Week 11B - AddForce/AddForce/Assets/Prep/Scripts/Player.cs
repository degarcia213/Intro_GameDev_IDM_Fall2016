using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	Rigidbody rb;
	public float jumpStrength;
	bool grounded = false;
	private bool jump = false;
	public float walkSpeed;
	private float currentWalk;

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody>();
	
	}
	
	// Update is called once per frame
	void Update () {

		//We'll turn pressing the A and D keys, but it's not too different from how we turned in the past.
		if (Input.GetKey (KeyCode.A))
		{
			transform.RotateAround(transform.position, transform.up, -5);
		}

		if (Input.GetKey (KeyCode.D))
		{
			transform.RotateAround(transform.position, transform.up, 5);
		}

		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (grounded)
			{
				//because this is a one time addition (note the forcemode is velocity change, not something continuous like acceleration)
				//we can do it in regular Update.
				rb.AddForce(Vector3.up * jumpStrength, ForceMode.VelocityChange);
			}
		}

		if (Input.GetKey(KeyCode.W))
		{
			if (grounded)
			{
				currentWalk = walkSpeed;
			} else {
				//here we're just saying "make it harder to move in the air". This is totally optional, just a kinesthetic thing.
				currentWalk = walkSpeed/2;
			}
		} else {
			currentWalk = 0;
		}
	}

	void OnCollisionStay(Collision col)
	{
		if (col.collider.tag == "Ground")
		{
			grounded = true;
		}
	}

	void OnCollisionExit(Collision col)
	{
		if (col.collider.tag == "Ground")
		{
			grounded = false;
		}
	}

	void FixedUpdate()
	{
		//because this is a continuous force, we want to make sure it's applied every time the physics system updates.
		//so we put it in FixedUpdate!
		rb.AddForce(transform.forward * walkSpeed, ForceMode.Acceleration);
	}
}
