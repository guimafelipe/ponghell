using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : Player {

	// Use this for initialization
	public GameObject bulletPrefab;

	void Start () {
		shootPoint = getChildGameObject ("ShootPoint");
		hp = maxHp;
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
		if (Input.GetKeyDown ("space")) {
			Shoot (bulletPrefab);
		}
	}
}
