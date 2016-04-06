using UnityEngine;
using System.Collections;

public class FireHelicopter : MonoBehaviour {
	public GameObject MissleFirePoint;
	public GameObject BulletFirePoint;
	public Rigidbody Missle;
	public Rigidbody Bullet;

	private bool missleReady;


	// Use this for initialization
	void Start () {
		missleReady = true;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)  && missleReady) { //left mouse button
			FireMissle ();
			StartCoroutine (wait ());
		}
		if (Input.GetMouseButton (1)) { //right mouse button
			FireBullet ();
		}
	}

	void FireMissle() {
		if (Missle != null) {
			Vector3 v3 = Input.mousePosition;
			v3.z = 100.0f;
			v3 = Camera.main.ScreenToWorldPoint(v3);
			Rigidbody missle = Instantiate (Missle, MissleFirePoint.transform.position, MissleFirePoint.transform.rotation) as Rigidbody;
			missle.transform.LookAt (v3);
			missle.transform.Rotate(0, 90, 0);
			missle.velocity = missle.transform.TransformDirection (Vector3.left * 20);
			//missle.transform.rotation = Quaternion.AngleAxis(-90, Vector3.up);
			//Vector3 newDir = Vector3.RotateTowards(missle.position, v3 - missle.position, 10 * Time.deltaTime, 0.0f);
			//missle.transform.rotation = Quaternion.LookRotation(newDir);
		}
	}

	void FireBullet() {
		if (Bullet != null) {
			Vector3 v3 = Input.mousePosition;
			v3.z = 100.0f;
			v3 = Camera.main.ScreenToWorldPoint(v3);
			Rigidbody bullet = Instantiate (Bullet, BulletFirePoint.transform.position, BulletFirePoint.transform.rotation) as Rigidbody;
			bullet.transform.LookAt (v3);
			bullet.velocity = bullet.transform.TransformDirection (Vector3.forward * 20);
			//missle.transform.rotation = Quaternion.AngleAxis(-90, Vector3.up);
			//Vector3 newDir = Vector3.RotateTowards(missle.position, v3 - missle.position, 10 * Time.deltaTime, 0.0f);
			//missle.transform.rotation = Quaternion.LookRotation(newDir);
		}
	}

	IEnumerator wait() {
		missleReady = false;
		yield return new WaitForSeconds(1);
		missleReady = true;
	}

}