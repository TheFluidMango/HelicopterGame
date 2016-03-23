using UnityEngine;
using System.Collections;

public class moveToHelicopter : MonoBehaviour {

	public float speed;
	public float distance;

	private GameObject target;
	private Transform targetPos;
	private bool inHeli;

	void Start() {
		inHeli = false;
		target = GameObject.Find ("HelicopterModel");
	}

	void Update() {

		targetPos = target.transform;

		if (Vector3.Distance (transform.position, targetPos.position) < distance && !inHeli) {
			float step = speed * Time.deltaTime;
			Vector3 newPos = Vector3.MoveTowards (transform.position, targetPos.position, step);
			newPos.y = transform.position.y;
			transform.position = newPos;
		}
	}

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.name.StartsWith ("HelicopterModel")) {
			inHeli = true;
		}
	}
}
