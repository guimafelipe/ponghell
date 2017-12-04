using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalaUI : MonoBehaviour, IUIzinha {


	public int maxBullets = 10;
	public int bullets;
	public int playerQueOlho;


	[SerializeField]
	Image[] balas;

	// Use this for initialization
	void Start () {
		bullets = maxBullets;
		balas = GetComponentsInChildren<Image> ();
		for (int i = 0; i < balas.Length; i++) {
			balas [i].GetComponent<Image>().enabled = false;
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
			playerbhvr.seInscrever (this.gameObject.GetComponent<BalaUI>());
		}
	}

	public void Atualizar(string action, int balasNovo){
		if (action != "bullets") {
			return;
		}
		Debug.Log ("atualizou bullets " + balasNovo);
		int i;
		for (i = 0; i < balasNovo; i++) {
			balas [i].GetComponent<Image>().enabled = true;
		}
		Debug.Log (i);
		for (int j = i; j < balas.Length; j++) {
			balas [j].GetComponent<Image>().enabled = false;
		}
	}


	// Update is called once per frame
	void Update () {
	}
}
