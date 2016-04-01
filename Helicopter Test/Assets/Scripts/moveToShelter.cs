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
			float step = speed * Time.deltaTime;
			Vector3 newPos = Vector3.MoveTowards (transform.position, target.position, step);
			newPos.y = transform.position.y;
			transform.position = newPos;
		}
	}

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.name.StartsWith ("Shelter")) {
			ScoreManager.score += 1;
			Destroy (gameObject);
		}
	}
}
