using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTextScript : MonoBehaviour {

	private GameObject player;
	public GameObject playerTextPanel;

	void Start () {

		player = GameObject.Find ("Player");
		playerTextPanel.SetActive (false);
	}

	public IEnumerator GoodTextWait(){
		playerTextPanel.SetActive (true);
		playerTextPanel.GetComponentInChildren<Text> ().text = "I love fresh apples, they make me faster...";
		yield return new WaitForSeconds (4.5f);
		playerTextPanel.SetActive (false);
	}
	public IEnumerator BadTextWait(){
		playerTextPanel.SetActive (true);
		playerTextPanel.GetComponentInChildren<Text> ().text = "Gross, this apple is not good, i feel heavy...";
		yield return new WaitForSeconds (4.5f);
		playerTextPanel.SetActive (false);
	}
	public void SetGoodAppleText(){
		StartCoroutine (GoodTextWait ());
	}
	public void SetBadAppleText(){
		StartCoroutine (BadTextWait ());
	}
	public void ActivateThePlayerText(){
		if (player.GetComponent<PlayerScript> ().speed == 2.0f) {
			SetBadAppleText ();
		} else if (player.GetComponent<PlayerScript> ().speed == 6.0f) {
			SetGoodAppleText ();
		}

	}
	void Update () {
		ActivateThePlayerText ();
	}
}
