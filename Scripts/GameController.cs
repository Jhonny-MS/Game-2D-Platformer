using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	private float life;
	private GameObject player;
	public GameObject tutorialPanel;
	public Image Star;
	public Image Star1;
	public Image Star2;
	public GameObject menuPanel;
	public Button continueButton;
	bool paused;
	public Text menuMessage;



	void Start () {

		Time.timeScale = 1;
		life = 3;
		paused = false;
		menuPanel.SetActive (false);
		player = GameObject.Find ("Player");
	}

	public void AddingLife(){
		if (life < 3 && life > 0) {
			life++;
		}
	}
	public void LessLife(float damage){
		life = life - damage;
	}
	public IEnumerator SpeedUp(){
		
		player.GetComponent<PlayerScript> ().speed = 6.0f;
		yield return new WaitForSeconds (6.0f);
		player.GetComponent<PlayerScript> ().speed = 4.0f;
	}
	public void PowerUp(){
		StartCoroutine (SpeedUp ());
	}
	public IEnumerator SpeedDown(){
		player.GetComponent<PlayerScript> ().speed = 2.0f;
		yield return new WaitForSeconds (6.0f);
		player.GetComponent<PlayerScript> ().speed = 4.0f;
	}
	public void PowerDown(){
		StartCoroutine (SpeedDown ());
	}

	void SetVisualLife(){
		if (life == 3) {
			Star.enabled = true;
			Star1.enabled = true;
			Star2.enabled = true;
		} else if (life == 2) {
			Star.enabled = true;
			Star1.enabled = true;
			Star2.enabled = false;
		} else if (life == 1) {
			Star.enabled = true;
			Star1.enabled = false;
			Star2.enabled = false;
		} else {
			Star.enabled = false;
			Star1.enabled = false;
			Star2.enabled = false;
			Time.timeScale = 0;

			menuPanel.SetActive (true);
			continueButton.enabled = false;
			menuMessage.text = "GAMEOVER";
		}
	}
	public void PauseGame(){
		if (life > 0) {
			if (Input.GetKeyDown (KeyCode.Escape) && !paused) {
				paused = true;
				Time.timeScale = 0;
				menuPanel.SetActive (true);
				continueButton.enabled = true;
				menuMessage.text = "PAUSE";
			}
		}
	}
	public void UnpauseGame(){
		paused = false;
		Time.timeScale = 1;
		menuPanel.SetActive (false);
	}
	public void RestartButton(){
		SceneManager.LoadScene ("Game_scene");
	}
	public void QuitButton(){
		Application.Quit ();
	}
	public void EndTheGame(){
		Time.timeScale = 0;
		menuPanel.SetActive (true);
		menuPanel.GetComponent<Image> ().enabled = false;
		continueButton.enabled = false;
		menuMessage.text = "VICTORY";
	}
	public void OpenMessage(){
		if (tutorialPanel != null) {
			tutorialPanel.SetActive (true);
		}
	}
	public void CloseMessage(){
		if (tutorialPanel != null) {
			tutorialPanel.SetActive (false);
		}
	}

	void Update () {
		SetVisualLife ();
		PauseGame ();
	}
}
