using UnityEngine;
using System.Collections;

public class moveToHelicopter : MonoBehaviour {

	public float speed;
	public float distance;

	private GameObject target;
	private Transform targetPos;
	private bool inHeli;

	private Animator myAnimator;

	void Start() {
		inHeli = false;
		target = GameObject.Find ("HelicopterModel");
	}

	void Update() {

		targetPos = target.transform;

		if (Vector3.Distance (transform.position, targetPos.position) < distance && !inHeli) {

			myAnimator = GetComponent<Animator> ();
			myAnimator.SetBool ("walking", true );

			RotateToHeli();

			float step = speed * Time.deltaTime;
			Vector3 newPos = Vector3.MoveTowards (transform.position, targetPos.position, step);
			newPos.y = transform.position.y;
			transform.position = newPos;
		}
	}

	void RotateToHeli() {
		Vector3 currentPosition = gameObject.transform.position;
		Vector3 nextPosition = targetPos.position;
		Vector3 newLookDirection = (nextPosition - currentPosition).normalized;
		Quaternion lookRotation = Quaternion.LookRotation(newLookDirection);
		gameObject.transform.rotation = lookRotation;
	}

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.name.StartsWith ("HelicopterModel")) {
			inHeli = true;
			civsInChopperManager.civs += 1;
		}
	}
}
