using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownEnabler : MonoBehaviour {

	Animator anim;
	GManager gmanager;
	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator> ();
		gmanager = GameObject.Find ("_GM").GetComponent<GManager>();
	}

	public void TerminouCountDown (){
		anim.SetBool ("comecou", true);
	}

	// Update is called once per frame
	void Update () {
		if (gmanager.comecou) {
			TerminouCountDown ();
		}
	}
}
