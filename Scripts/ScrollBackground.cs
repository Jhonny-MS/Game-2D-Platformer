using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour {

	public Renderer aux;
	public float speed = 0.1f;
	private float h;
	private GameObject player;
	private float playerPosX, playerPosY;

	void Start () {

		player = GameObject.Find ("Player");
	}
	

	void Update () {
		playerPosX = player.transform.position.x;
		playerPosY = player.transform.position.y;
		this.gameObject.transform.position = new Vector2 (playerPosX, playerPosY);
		h = Input.GetAxis ("Horizontal") * speed;
		if (h != 0) {
			if (h > 0) {
				Vector2 offset = new Vector2 (Time.time / 10, 0);
				aux.material.mainTextureOffset = offset;
			} else if (h < 0) {
				Vector2 offset = new Vector2 (-Time.time / 10, 0);
				aux.material.mainTextureOffset = offset;
			}
		}
	
	}
}
