using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GManager : MonoBehaviour {


	public float timeToStart = 3;

	[SerializeField]
	TextMeshProUGUI countdownText;
	GameObject player1, player2;
	public bool comecou = false;

	enum stateOfGame{beforeStart, playing, paused, p1Win, p2Win};
	int state;


	// Use this for initialization
	void Start () {
		timeToStart = 3;
		player1 = GameObject.Find ("Player1");
		player2 = GameObject.Find ("Player2");
		player1.GetComponent<Player1> ().canMove = false;
		player2.GetComponent<Player2> ().canMove = false;
		state = (int)(stateOfGame.beforeStart);
	}

	// Update is called once per frame
	void Update () {
		if (state == (int)stateOfGame.beforeStart) {
			timeToStart -= Time.deltaTime;
			if (timeToStart > 0) {
				countdownText.text = Mathf.Ceil (timeToStart).ToString() + "!";
			} else {
				countdownText.text = "Let's Rock!!!";
				DoStartThings ();
				state = (int)stateOfGame.playing;
				comecou = true;
			}
		}
	}

	public void DoStartThings(){
		player1.GetComponent<Player1> ().canMove = true;
		player2.GetComponent<Player2> ().canMove = true;
	}

}
