using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MagicMarathon.Utils;

public class BoardActions : MonoBehaviour {

	// Only for interface connection
	private Marathon marathon;

	// public Dictionary <string, GameObject> buttons = new Dictionary <string, GameObject> ();
	// TODO: better solution for this
	public GameObject[] buttons;
	GameObject buttonPressed;

	public GameObject ButtonPressed {
		get { return buttonPressed; }
		set { buttonPressed = value; }
	}

	private void SetButtonPressed (Properties.Color buttonColor) {
		/* Algorithm: SetButtonPressed
		Description: Intermediate logic for set pressed button for player

		colorButtonPressed
		
		START
			buttonPressed <-- SEARCH colorButtonPressed in buttons INDEX
		END
		*/
		if (buttonColor == Properties.Color.Red) {
			ButtonPressed = buttons [0];
		} else if (buttonColor == Properties.Color.Green) {
			ButtonPressed = buttons [1];
		} else if  (buttonColor == Properties.Color.Blue) {
			ButtonPressed = buttons [2];
		}
		marathon.gameObject.SendMessage ("AssignNewColorToCube");
	}

	public Properties.Color GetColorFromButton () {
		return buttonPressed.GetComponent <ActionButton> ().CurrentColor;
	}

	void Start () {
		// TODO: agnostic assignation (not depend of name)
		marathon = GameObject.Find (
			"Marathon"
		).GetComponent <Marathon> ();
	}

}