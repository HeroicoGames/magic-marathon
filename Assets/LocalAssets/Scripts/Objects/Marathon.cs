using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MagicMarathon.Utils;

public class Marathon : MonoBehaviour {

	public GameObject cube;
	public GameObject[] floors;
	public GameObject boardActions;
	public GameObject retryMenu;
	// TODO: Best solution for this
	public GameObject boardActionButtons;
	public AudioSource backGroundMusic;
	public AudioSource winnerSound;
	public AudioSource loserSound;

	public void CheckGameStatus () {
		/* Algorithm: CheckGameStatus
		Description: Verifies if user lost or won

		START
			IF cube TOUCH THE CORRECT FLOOR
				CALL TO UpdatePoints
				CALL TO ShowPoints
			ELSE IF cube TOUCH THE INCORRECT FLOOR
				CALL TO 0
		END
		*/
		Gube cubeComponent = cube.GetComponent <Gube> ();

		if (cubeComponent.TouchCorrectFloor == Properties.TouchStatus.Failed) {
			GameOver ();
		}
		else if (cubeComponent.TouchCorrectFloor == Properties.TouchStatus.Final) {
			YouWon ();
		}

		// Reset status
		cubeComponent.TouchCorrectFloor = Properties.TouchStatus.Neutral;
	}

	private void AssignNewColorToCube () {
		/* Algorithm: AssignNewColorToCube
		Description: Set new color to cube from Board Actions buttons

		START
			newColor <-- BoardActions.GetColorFromButton
			cube.ChangeColor with newColor
		END
		*/
		cube.GetComponent <Gube> ().CurrentColor = 
			boardActions.GetComponent <BoardActions> ().GetColorFromButton ();

	}

	void GameOver () {
		/* Algorithm: GameOver
		Description: Show game over menu

		START
			INSTANCE game over menu
		END
		*/
		Time.timeScale = 0;
		backGroundMusic.Stop ();
		loserSound.Play ();

		boardActionButtons.SetActive (false);
		Instantiate (retryMenu);
	}

	void YouWon () {
		/* Algorithm: YouWon
		Description: Show you won menu

		START
			INSTANCE you won menu
		END
		*/
		Time.timeScale = 0;
		backGroundMusic.Stop ();
		winnerSound.Play ();
	}

	void Start () {
		backGroundMusic.Play ();
	}

	void Update () {
		CheckGameStatus ();
	}

}