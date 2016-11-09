using UnityEngine;
using System.Collections;

public class mouseLook : MonoBehaviour {

	// Use this for initialization
	void Start () {

		//optional cursor locking
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;

	}
	
	// Update is called once per frame
	void Update () {
	
		//this is really rough, but it'll get the job done for us for now.
		transform.RotateAround(transform.position,transform.up,Input.GetAxis("Mouse X"));

	}
}
