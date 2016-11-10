using UnityEngine;
using System.Collections;

public class CaneraTriggerClass : MonoBehaviour {

	//public GameObject camToActivate;
	public int camNumber;

	public CameraControllerClass controller;

	void OnTriggerEnter(Collider other){

		controller.DeactivateCameras();
		controller.activateCamera(camNumber);

	}
}
