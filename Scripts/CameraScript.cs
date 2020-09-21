using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	private Transform player;
	public Vector3 offset;

	void Start () {
		player = GameObject.Find ("Player").transform;	
	}

	void FollowPlayer(){
		transform.position = new Vector3 (player.position.x + offset.x, player.position.y + offset.y, offset.z);
	}

	void Update () {
		FollowPlayer ();
	}
}
