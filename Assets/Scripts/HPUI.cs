﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPUI : MonoBehaviour, IUIzinha {

	public int maxLifes = 7;
	public int lifes;
	public int playerQueOlho;


	[SerializeField]
	Image[] vidas;

	// Use this for initialization
	void Start () {
		lifes = maxLifes;
		vidas = GetComponentsInChildren<Image> ();
		for (int i = 0; i < vidas.Length; i++) {
			vidas [i].GetComponent<Image>().enabled = false;
		}
		StartCoroutine (LateStart ());
	}
		
	IEnumerator LateStart(){
		yield return new WaitForEndOfFrame();
		seInscreverNoPlayer ();
	}

	private void seInscreverNoPlayer(){
		string player = "Player" + playerQueOlho.ToString();
		Debug.Log (GameObject.Find (player));
		Player playerbhvr;
		if (playerQueOlho == 1) {
			playerbhvr = GameObject.Find (player).GetComponent<Player1> ();
		} else {
			playerbhvr = GameObject.Find (player).GetComponent<Player2> ();
		}

		if (playerbhvr != null) {
			playerbhvr.seInscrever (this.gameObject.GetComponent<HPUI>());
		}
	}

	public void Atualizar(string action, int hpNovo){
		if (action != "hp") {
			return;
		}
		int i;
		for (i = 0; i < hpNovo; i++) {
			vidas [i].GetComponent<Image>().enabled = true;
		}
		Debug.Log (i);
		for (int j = i; j < vidas.Length; j++) {
			vidas [j].GetComponent<Image>().enabled = false;
		}
	}

	
	// Update is called once per frame
	void Update () {
	}
}
