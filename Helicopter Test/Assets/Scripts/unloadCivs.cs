using UnityEngine;
using System.Collections;

public class unloadCivs : MonoBehaviour {
	public GameObject releasePoint;
	public Collector collector;
	public float distance;
	public Transform target;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (transform.position, target.position) < distance) {
			if (collector != null && releasePoint != null) {
				GameObject objectToRelease = collector.getNext ();
				if (objectToRelease != null) {
					Rigidbody civilian = objectToRelease.GetComponent<Rigidbody>();
					civilian.transform.position = releasePoint.transform.position;
					Transform dropPoint = releasePoint.transform.parent;
					civilian.velocity = dropPoint.TransformDirection (Vector3.forward * 2);
				}
			} else {
				Debug.Log ("Error");
			}
		}
	}

	void OnCollisionEnter(Collision other) {
		/*if (other.gameObject.name.StartsWith ("HelicopterModel")) {
			if (collector != null && releasePoint != null) {
				GameObject objectToRelease = collector.getNext ();
				if (objectToRelease != null) {
					Rigidbody civilian = objectToRelease.GetComponent<Rigidbody>();
					civilian.transform.position = releasePoint.transform.position;
					Transform dropPoint = releasePoint.transform.parent;
					civilian.velocity = dropPoint.TransformDirection (Vector3.forward * 20);
				}
			} else {
				Debug.Log ("Error");
			}
		}*/
	}



}