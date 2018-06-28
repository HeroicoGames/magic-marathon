using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MagicMarathon.Utils;

public class Gube : MonoBehaviour {

	private Properties.Color currentColor;
	private bool colorChange = false;
	private float speed = 2;
	private Properties.TouchStatus touchCorrectFloor = Properties.TouchStatus.Neutral;

    public AudioSource changeColorSound;

	public Properties.Color CurrentColor {
		/* Algorithm: ChangeColor
		Description: Set new color to cube
		*/
		get { return currentColor; }
		set { 
			currentColor = value;
			colorChange = true;
		}
	}

	public bool ColorChange {
		get { return colorChange; }
		set { colorChange = value; }
	}

	public float Speed {
		/* Algorithm: ChangeSpeed
		Description: Set new speed to cube
		*/
		get { return speed; }
		set { speed = value; }
	}

	public Properties.TouchStatus TouchCorrectFloor {
		get { return touchCorrectFloor; }
		set { touchCorrectFloor = value; }
	}

	public Properties.TouchStatus CheckTouchCorrectFloor (Properties.Color floorColor) {
		/* Algorithm: CheckTouchCorrectFloor
		Description: Check if cube touch a floor with same color

		floorColor

		START
			IF color is EQUAL TO floorColor
				RETURN true
			ELSE IF cube.color is NOT EQUAL TO floorColor
				RETURN false
		END
		*/
		if (floorColor != Properties.Color.White) {
			if (currentColor == floorColor) {
				return Properties.TouchStatus.Successful;
			} else if (currentColor != floorColor) {
				return Properties.TouchStatus.Failed;
			}
		}

		return Properties.TouchStatus.Neutral;
	}

	public void ChangeMaterialColor () {
		// Set renderer color
		Renderer rendererComponent = gameObject.GetComponent<Renderer> ();

		byte[] rgbaColor = Properties.rgbaColors[currentColor.ToString ()];

		rendererComponent.material.color = new Color32(
			rgbaColor[0], rgbaColor[1], rgbaColor[2], rgbaColor[3]
		);
	}

	public void ChangeColorClothing () {
		if (colorChange == true) {
			ChangeMaterialColor ();
			changeColorSound.Play ();

			ColorChange = false;
		}
	}

	private void MoveForward () {
		transform.Translate (new Vector3 (0, 0, Speed) * Time.deltaTime);
	}

	// TODO: Change for descriptive name
	private void CheckCollisionWithFloor (Collision collision) {

		if (collision.gameObject.tag == "Floor") {
			Floor floor = collision.gameObject.GetComponent <Floor> ();

			if (floor.last == true) {
				TouchCorrectFloor = Properties.TouchStatus.Final;
			}
			else if (floor.Touch == false) {
				TouchCorrectFloor = CheckTouchCorrectFloor (
					floor.color
				);
				floor.Touch = true;
			}
		}
	}

	void OnCollisionEnter (Collision collision) {
		CheckCollisionWithFloor (collision);
	}

	void Update () {
		MoveForward ();
		ChangeColorClothing ();
	}
}
