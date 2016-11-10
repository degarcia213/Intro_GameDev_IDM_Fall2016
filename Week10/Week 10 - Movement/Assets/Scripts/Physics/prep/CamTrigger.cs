using UnityEngine;
using System.Collections;

public class CamTrigger : MonoBehaviour {

	public Camera camToActivate;
	public CameraController controller;

	//I deleted start and update because this simple script doesn't really need them.


	// this OnTriggerEnter is automatically called when something enters the collider, as long
	// as our collider's "isTrigger" field is set to true in the inspector.
	void OnTriggerEnter(Collider other) {

		// if our camera is not enabled, then we call our controller's deactivate camera function
		// and then we enabled the camera we've initialized on this object in the inspector.
		if(!camToActivate.enabled){
			
			controller.DeactivateAllCams();
			camToActivate.enabled = true;

		}

	}
}
