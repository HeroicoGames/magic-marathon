using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MagicMarathon.Utils;

public class Floor : MonoBehaviour {
	
	public Properties.Color color;
	public bool conveyor = false;
	public bool last = false;
	public GameObject pointTransport;

	private bool touch = false;

	public bool Touch {
		get { return touch; }
		set { touch = value; }
	}

	private void RemoveColor (GameObject player) {
		if (player.tag == "Cube" && color != Properties.Color.White) {
			if (color == player.GetComponent <Gube> ().CurrentColor && conveyor == false) {
				gameObject.GetComponent <Renderer> ().material.color = Color.white;
			}
		}
	}

	private void Transport (GameObject objectToTransport) {
		if (objectToTransport.tag == "Cube" && conveyor == true) {
			objectToTransport.transform.position = pointTransport.transform.position;
		}
	}

	void OnCollisionEnter (Collision collision) {
		GameObject collisionGameObject = collision.gameObject;

		Transport (collisionGameObject);
		RemoveColor (collisionGameObject);
	}

}
