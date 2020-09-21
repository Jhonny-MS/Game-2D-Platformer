using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCollector : MonoBehaviour {

	private GameObject gameC;

	void Start () {
		gameC = GameObject.Find ("GameController");
	}

	void Blink(){
		if (Time.fixedTime % 5 < .2) {
			GetComponent<SpriteRenderer> ().enabled = false;
		} else {
			GetComponent<SpriteRenderer> ().enabled = true;
		}
	}

	void Update () {
		Blink ();
	}
	void OnTriggerEnter2D(Collider2D coll){
		if (coll.tag == "Player"){
			gameC.GetComponent<GameController> ().AddingLife ();
			Destroy (this.gameObject);
		}
}
}