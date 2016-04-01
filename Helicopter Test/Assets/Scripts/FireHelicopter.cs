using UnityEngine;
using System.Collections;

public class FireHelicopter : MonoBehaviour {
	public GameObject firePoint;
	public GameObject missle;


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter(Collision other) {
		if (Input.GetKeyDown(KeyCode.Mouse0)) {
			GameObject objectToFire = missle;
			if (objectToFire != null) {
				Rigidbody objToFire = objectToFire.GetComponent<Rigidbody>();
				objToFire.transform.position = firePoint.transform.position;
				Transform canon = firePoint.transform.parent;
				objToFire.velocity = canon.TransformDirection (-Vector3.forward * 20);
				Destroy (other.gameObject);
			}
		} else {
			Debug.Log ("Error: Set firePoint and collector");
		}
	}



}