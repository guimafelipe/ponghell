using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : Player {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("w")) {
			goUp ();
		} else if (Input.GetKey ("s")) {
			goDown ();
		}
		if (Input.GetKey ("a")) {
			goLeft ();
		} else if(Input.GetKey("d")){
			goRight();
		}
		if (Input.GetKey ("q")) {
			rotateLeft ();
		} else if (Input.GetKey ("e")) {
			rotateRight ();
		}
	}
}
