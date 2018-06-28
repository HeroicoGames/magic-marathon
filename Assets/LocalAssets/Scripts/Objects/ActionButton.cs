using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MagicMarathon.Utils;

public class ActionButton : MonoBehaviour {

	public Properties.Color currentColor;

	// Only for interface connection
	private BoardActions boardActions;

	public Properties.Color CurrentColor {
		get { return currentColor; }
		set { currentColor = value; }
	}

	void CheckPressedButton (Properties.Color color) {
		/* Algorithm: CheckPressedButton
		Description: Get button pressed and send this to BoardAction

		START
			SEND color button to INTERFACE action in BoardAction
		END
		*/
		boardActions.gameObject.SendMessage ("SetButtonPressed", color);
	}

	void Start () {
		// TODO: agnostic assignation (not depend of name)
		boardActions = GameObject.Find (
			"BoardActions"
		).GetComponent <BoardActions> ();

		gameObject.GetComponent <Button> ().onClick.AddListener (
			() => CheckPressedButton(CurrentColor)
		);
	}

}