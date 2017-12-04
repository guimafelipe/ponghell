using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : Player {

	// Use this for initialization
	public GameObject bulletPrefab;

	void Start () {
		base.Start ();
		playertype = 2;
	}
	
	// Update is called once per frame
	void Update () {
		if (canMove) {
			if (inputmanager.GetButton ("P2Up")) {
				goUp ();
			} else if (inputmanager.GetButton ("P2Down")) {
				goDown ();
			}
			if (inputmanager.GetButton ("P2Left")) {
				goLeft ();
			} else if (inputmanager.GetButton ("P2Right")) {
				goRight ();
			}
			if (inputmanager.GetButton ("P2Rotate Left")) {
				rotateLeft ();
			} else if (inputmanager.GetButton ("P2Rotate Right")) {
				rotateRight ();
			}
			if (inputmanager.GetButtonDown ("P2Shoot")) {
				Shoot (bulletPrefab);
			}
		}
		base.Update ();
	}	
}
