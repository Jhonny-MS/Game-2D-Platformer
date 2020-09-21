using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour {

	public bool isPowerUp;
	bool collected;
	private GameObject gameC;

	void Start () {
		gameC = GameObject.Find ("GameController");
		collected = false;
	}

	void OnTriggerStay2D(Collider2D coll){
		if (coll.tag == "Player") {
			if (Input.GetKeyDown (KeyCode.Z)) {
				collected = true;
				gameC.GetComponent<GameController> ().PowerUp ();
				GetComponent<SpriteRenderer> ().enabled = false;
				Destroy (this.gameObject, 6.1f);
			} else if (!isPowerUp && !collected) {
				collected = true;
				gameC.GetComponent<GameController> ().PowerDown ();
				GetComponent<SpriteRenderer> ().enabled = false;
				Destroy (this.gameObject, 6.1f);
			}
		}
	}

	void Update () {
		
	}
}
