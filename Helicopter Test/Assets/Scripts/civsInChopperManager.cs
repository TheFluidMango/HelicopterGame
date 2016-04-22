using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class civsInChopperManager : MonoBehaviour
{
	public static int civs;        // The player's score.


	Text text;                      // Reference to the Text component.


	void Awake ()
	{
		// Set up the reference.
		text = GetComponent <Text> ();

		// Reset the score.
		civs = 0;
	}


	void Update ()
	{
		// Set the displayed text to be the word "Score" followed by the score value.
		text.text = "Civs in Chopper: " + civs;
	}
}