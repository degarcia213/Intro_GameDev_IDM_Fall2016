using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private Animator anim;
	public camShake myCam;

	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator>();
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey(KeyCode.UpArrow))
			{
			anim.SetBool("walking", true);
		} else {

			anim.SetBool("walking", false);
		}

		if (Input.GetKeyDown(KeyCode.Space))
		{

			//myCam.ShakeCam(.2f, 2.0f);
			StartCoroutine(HitPause(.2f));

		}
	}


	public IEnumerator HitPause(float pauseTime)
	{
		Time.timeScale = 0.0f;
		float pauseEndtime = Time.realtimeSinceStartup + pauseTime;

		while (Time.realtimeSinceStartup < pauseEndtime){
			yield return 0;
		}

		Time.timeScale = 1;
	}

}
