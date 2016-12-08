using UnityEngine;
using System.Collections;

public class WindTunnel : MonoBehaviour {

	public Rigidbody target;
	private bool blowing;
	public float windSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider other)
	{
		blowing = true;
		target = other.attachedRigidbody;
	}

	void OnTriggerExit(Collider other)
	{
		blowing = false;
	}

	void FixedUpdate() {
		if (blowing)
		{
			target.AddForce(Vector3.right * windSpeed);
		}
	}
}
