using UnityEngine;
using System.Collections;

public class CivSpawnPoint : MonoBehaviour {

	public GameObject objectToSpawn;
	public int numObjects;

	private float widthX;
	private float widthZ;
	private float newX;
	private float newZ;
	private Vector3 tempPosition;

	// Use this for initialization
	void Start () {

		tempPosition = transform.position;
		widthX = gameObject.GetComponent<Renderer>().bounds.size.x;
		widthZ = gameObject.GetComponent<Renderer>().bounds.size.z;

		for (int i = 0; i < numObjects; i++) {
			newX = Random.Range (-widthX, widthX);
			newZ = Random.Range (-widthZ, widthZ);
			tempPosition.x += newX;
			tempPosition.z += newZ;

			Instantiate (objectToSpawn, tempPosition, Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
