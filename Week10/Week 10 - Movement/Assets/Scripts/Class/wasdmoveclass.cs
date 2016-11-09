using UnityEngine;
using System.Collections;

public class wasdmoveclass : MonoBehaviour {

	private Transform myTransform;

	public float moveSpeed;

	// Use this for initialization
	void Start () {
	
		myTransform = GetComponent<Transform>();

	}

	// Update is called once per frame
	void Update () {

		if ( Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)){

			myTransform.position += transform.forward * Time.deltaTime * moveSpeed;

		}

		if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)){

			myTransform.position -= transform.forward * Time.deltaTime * moveSpeed;
		}

		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){

			myTransform.position -= transform.right * Time.deltaTime * moveSpeed;

		}

		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){

			myTransform.position += transform.right * Time.deltaTime * moveSpeed;

		}
	
	}
}
