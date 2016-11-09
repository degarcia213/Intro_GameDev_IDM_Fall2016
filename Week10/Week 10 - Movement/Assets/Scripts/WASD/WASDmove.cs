using UnityEngine;
using System.Collections;

public class WASDmove : MonoBehaviour {


	private Transform myTransform;
	public float moveSpeed;

	// Use this for initialization
	void Start () {
		myTransform = GetComponent<Transform>();

	}
	
	// Update is called once per frame
	void Update () {



		//here's our movement code. we check for keypresses on WASD or Arrows, then we add VECTORS to the transform.position vector.
		// the transform.forward and transform.right variables are always relative to our player transform. Handy!
		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
		{
			myTransform.position += myTransform.forward * Time.deltaTime * moveSpeed;
		}

		if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
		{
			myTransform.position -= myTransform.forward * Time.deltaTime * moveSpeed;
		}

		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
		{
			myTransform.position -= myTransform.right * Time.deltaTime * moveSpeed;
		}

		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
		{
			//hehe, turns out we didn't need to create myTransform -- Unity already has a shortcut for that. You can just use "transform"
			//to get the Transform componenet of the object you're accessing (in this case, the one our script is attached to.)
			transform.position += transform.right * Time.deltaTime * moveSpeed;
		}

		//the way we've coded this, we're technically at a higher top speed if we move diagonally. We could alternatively store our direction
		//in a different Vector3 -- maybe we'd call it... direction... -- and then we'd NORMALIZE it. check it out:
		/*

		direction = new Vector3(0,0,0);


			if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
		{
			direction += transform.forward;
		}

		if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
		{
			direction -= transform.forward;
		}

		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
		{
			direction -= transform.right;
		}

		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
		{
			direction += transform.right;
		}

		//NOW we have to normalize it. Normalizing a vector keeps its direction but gives it a magnitude (length) of 1.
		direction = direction.normalized;

		//now we add THAT to our position, multiplied by deltaTime and moveSpeed.
		transform.position += direction * Time.deltaTime * moveSpeed;

		*/

	}
}
