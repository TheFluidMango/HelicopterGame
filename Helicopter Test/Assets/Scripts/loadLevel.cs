using UnityEngine;
using System.Collections;

public class loadLevel : MonoBehaviour {

	public void GoToLevel (string level) {
		Application.LoadLevel (level);
	}

	public void exit () {
		Application.Quit();
	}
}
