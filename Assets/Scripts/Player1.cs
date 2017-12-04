using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : Player {

	// Use this for initialization
	public GameObject bulletPrefab;

	void Start () {
		base.Start ();
		playertype = 1;
		//obsUIs = new IUIzinha[0];

	}
	
	// Update is called once per frame
	void Update () {
		if (canMove) {
			if (inputmanager.GetButton ("P1Up")) {
				goUp ();
			} else if (inputmanager.GetButton ("P1Down")) {
				goDown ();
			}
			if (inputmanager.GetButton ("P1Left")) {
				goLeft ();
			} else if (inputmanager.GetButton ("P1Right")) {
				goRight ();
			}
			if (inputmanager.GetButton ("P1Rotate Left")) {
				rotateLeft ();
			} else if (inputmanager.GetButton ("P1Rotate Right")) {
				rotateRight ();
			}
			if (inputmanager.GetButtonDown ("P1Shoot")) {
				Shoot (bulletPrefab);
			}
		}
	}
}
