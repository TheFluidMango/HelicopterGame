using UnityEngine;
using System.Collections;

public class FireHelicopter : MonoBehaviour {
	public GameObject FirePoint;
	public Rigidbody Missle;


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			if (Missle != null) {
				Rigidbody missle = Instantiate (Missle, FirePoint.transform.position, FirePoint.transform.rotation) as Rigidbody;
				missle.velocity = FirePoint.transform.TransformDirection (Vector3.right * 10);
			}
		}
	}



}