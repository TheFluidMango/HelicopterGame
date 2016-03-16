using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Collector : MonoBehaviour {

	private Stack<GameObject> inventory;

	// Use this for initialization
	void Start () {
		inventory = new Stack<GameObject> (); //Unlike C++, you need to create objects, one is not created automatically

	}

	// Update is called once per frame
	void Update () {

	}

	//As in C++, must be public for other objects to access it
	//You should use the <summary> ... </summary> tags (with three slashes) to add documentation to your functions that communicate with other scripts
	/// <summary>
	/// Gets the next game object to fire that has been stored in the collector, returns null if nothing is currently stored
	/// </summary>
	/// <returns>A game object to fire, or null if there is nothing stored</returns>
	public GameObject getNext() {
		GameObject returnValue = null;

		if (inventory.Count > 0) {
			returnValue = inventory.Pop ();
		}

		return returnValue;
	}

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.name.StartsWith ("Civilian")) {
			GameObject civObject = other.gameObject;
			Vector3 newPosition = civObject.transform.position;
			//Move the ball under the world temporarily (don't Destroy, because it causes an error on the stack)
			newPosition.y -= 100;
			civObject.transform.position = newPosition; 
			inventory.Push (civObject);
		}
	}
}