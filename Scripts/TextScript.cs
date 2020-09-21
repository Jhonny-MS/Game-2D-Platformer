using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour {

	public int count;
	private GameObject textPanel;
	private GameObject gameC;

	void Start () {
		gameC = GameObject.Find ("GameController");
		gameC.GetComponent<GameController> ().CloseMessage ();
		textPanel = GameObject.Find ("Canvas").gameObject.transform.GetChild (4).gameObject;

	}
	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.tag == "Player")
		{
			if(count == 1)
			{
				gameC.GetComponent<GameController>().OpenMessage();
				textPanel.gameObject.GetComponentInChildren<Text>().text = "To go to the left press 'A', and to the right press 'D'";
				Destroy(this.gameObject);
			}

			if(count == 2)
			{
				gameC.GetComponent<GameController>().OpenMessage();
				textPanel.gameObject.GetComponentInChildren<Text>().text = "Jump with the 'SPACE'";
				Destroy(this.gameObject);
			}

			if(count == 3)
			{
				gameC.GetComponent<GameController>().OpenMessage();
				textPanel.gameObject.GetComponentInChildren<Text>().text = "Collect a life star by passing by it";
				Destroy(this.gameObject);
			}

			if(count == 4)
			{
				gameC.GetComponent<GameController>().OpenMessage();
				textPanel.gameObject.GetComponentInChildren<Text>().text = "Collect an item pressing 'Z' close to the item";
				Destroy(this.gameObject);
			}
		}
	}

	void Update () {
		
	}
}
