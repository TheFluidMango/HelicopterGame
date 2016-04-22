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
		bool isOnGround = gameObject.GetComponent<HelicopterController> ().IsOnGround;
		if (Vector3.Distance (transform.position, target.position) < distance && isOnGround) {
			if (collector != null && releasePoint != null) {

				SetReleasePoint ();

				GameObject objectToRelease = collector.getNext ();
				if (objectToRelease != null) {
					civsInChopperManager.civs -= 1;
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

	void SetReleasePoint() {
		Vector3 currentPosition = gameObject.transform.position;
		Vector3 nextPosition = target.position;
		Vector3 newLookDirection = (nextPosition - currentPosition).normalized;
		//releasePoint.transform.position = newLookDirection;
		//Quaternion lookRotation = Quaternion.LookRotation(newLookDirection);
		//gameObject.transform.rotation = lookRotation;
		releasePoint.transform.position = Vector3.Lerp(transform.position, target.position, .2f);
	}
}