using UnityEngine;
using System.Collections;

public class moveToShelter : MonoBehaviour {

	public Transform target;

	public float speed;

	public float distance;

	void Start() {
	}

	void Update() {

		if (Vector3.Distance (transform.position, target.position) < distance) {

			RotateToShelter ();

			float step = speed * Time.deltaTime;
			Vector3 newPos = Vector3.MoveTowards (transform.position, target.position, step);
			newPos.y = transform.position.y;
			transform.position = newPos;
		}
	}

	void RotateToShelter() {
		Vector3 currentPosition = gameObject.transform.position;
		Vector3 nextPosition = target.position;
		Vector3 newLookDirection = (nextPosition - currentPosition).normalized;
		Quaternion lookRotation = Quaternion.LookRotation(newLookDirection);
		gameObject.transform.rotation = lookRotation;
	}

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.name.StartsWith ("Shelter")) {
			ScoreManager.score += 1;
			Destroy (gameObject);
		}
	}
}
