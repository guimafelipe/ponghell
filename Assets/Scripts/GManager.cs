using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GManager : MonoBehaviour {


	public float timeToStart = 3;
	private int tempoantes = 3;
	[SerializeField]
	TextMeshProUGUI countdownText;
	[SerializeField]
	TextMeshProUGUI wintext;
	[SerializeField]
	GameObject pressSpace;


	GameObject player1, player2;
	public bool comecou = false;
	AudioManager audiomanager;

	enum stateOfGame{beforeStart, playing, paused, p1Win, p2Win, endGame};
	int state;


	// Use this for initialization
	void Start () {
		timeToStart = 3;
		player1 = GameObject.Find ("Player1");
		player2 = GameObject.Find ("Player2");
		player1.GetComponent<Player1> ().canMove = false;
		player2.GetComponent<Player2> ().canMove = false;
		audiomanager = GameObject.Find ("_AudioManager").GetComponent<AudioManager> ();
		state = (int)(stateOfGame.beforeStart);
		wintext.enabled = false;
		pressSpace.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		if (state == (int)stateOfGame.beforeStart) {
			timeToStart -= Time.deltaTime;
			if (timeToStart > 0) {
				if (tempoantes > timeToStart) {
					audiomanager.PlaySound (tempoantes.ToString());
					Debug.Log (tempoantes);
					tempoantes--;
				}
				countdownText.text = Mathf.Ceil (timeToStart).ToString() + "!";
			} else {
				countdownText.text = "Let's Rock!!!";
				audiomanager.PlaySound ("LetsRock");
				DoStartThings ();
				state = (int)stateOfGame.playing;
				comecou = true;
			}
		}
		if (state == (int)stateOfGame.endGame) {
			if (Input.GetKeyDown (KeyCode.Space)) {
				SceneManager.LoadScene(0);
			}
		}
	}

	public void Player2Morreu(){
		if (state == (int)stateOfGame.playing) {
			player1.GetComponent<Player1> ().canTakeDamage = false;
			player1.GetComponent<Player1> ().canMove = false;
			state = (int)stateOfGame.p1Win;
			StartCoroutine (Player1WinScene ());
		}
	}

	public void Player1Morreu(){
		if (state == (int)stateOfGame.playing) {
			player2.GetComponent<Player2> ().canTakeDamage = false;
			player2.GetComponent<Player2> ().canMove = false;
			state = (int)stateOfGame.p2Win;
			StartCoroutine (Player2WinScene ());
		}
	}

	IEnumerator Player1WinScene(){
		yield return new WaitForSeconds (2f);
		audiomanager.PlaySound ("P1win");
		wintext.enabled = true;
		wintext.text = "Player 1 wins!";
		yield return new WaitForSeconds (2.5f);
		pressSpace.SetActive (true);
		state = (int)stateOfGame.endGame;
	}

	IEnumerator Player2WinScene(){
		yield return new WaitForSeconds (2f);
		audiomanager.PlaySound ("P2win");
		wintext.enabled = true;
		wintext.text = "Player 2 wins!";
		yield return new WaitForSeconds (2.5f);
		pressSpace.SetActive (true);
		state = (int)stateOfGame.endGame;
	}

	public void DoStartThings(){
		player1.GetComponent<Player1> ().canMove = true;
		player2.GetComponent<Player2> ().canMove = true;
	}

}
