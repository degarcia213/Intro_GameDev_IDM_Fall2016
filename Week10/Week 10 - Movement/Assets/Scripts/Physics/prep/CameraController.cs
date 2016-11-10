using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	// 2 cam swap stuff
	//public Camera cam1;
	//public Camera cam2;



	//multi camera stuff
	int currentCam; //we'll use this to keep track of which camera we want to use.

	public Camera[] cams; //here we're declaring an ARRAY of cameras. We initialize these in the inspector.

	// Runs when object is born (ours is born immediately).
	void Start () {

		// 2 cam swap stuff
		//cam1.enabled = true;
		//cam2.enabled = false;

		//Enable the first camera by default. Arrays start at index 0.
		cams[0].enabled = true;
		currentCam = 0;
	
	}
	
	// Update is called once per frame.
	void Update () {

		if (Input.GetKeyDown(KeyCode.Space))
		{
			//this works for switching between two cameras.... but...
			/*
			cam1.enabled = !cam1.enabled;
			cam2.enabled = !cam2.enabled;
			*/

			//...if we want to use a ton of cameras, we can call the function "Deactivate All Cams" which you can find below.
			DeactivateAllCams();

			//then we up our "currentCam" value, which corresponds to which camera in the array we want to use,
			//UNLESS we've reached the end of the array already, in which case we better go back to 0.
			if (currentCam < cams.Length - 1)
			{
				currentCam += 1;
			} else {
				currentCam = 0;
			}
			//...and enable the camera at that index in our camera array.
			ActivateCam(currentCam);

		}
	
	}

	//notice that this function requires an ARGUMENT of type INT. 
	public void ActivateCam(int _index) {
		//enables the camera at index "_index", which we passed into the function as an argument when we called it.
		cams[_index].enabled = true;

		// this isn't strictly necessary, but we might call this from another object, in which case
		// we might also want to be at the right place in our array.
		currentCam = _index;
	}

	public void DeactivateAllCams(){
		//this will work for as many as we want!
		//first we use a for loop to deactivate ALL of the cameras...
		for (int i = 0; i < cams.Length; i++)
		{
			cams[i].enabled = false;
		}
	}
}
