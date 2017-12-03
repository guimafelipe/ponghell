using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float speed = 5;
	private Vector3 velocity;
	public int dmg = 1;
	AudioManager audiomanager;

	// Use this for initialization
	void Start () {
		audiomanager = GameObject.Find ("_AudioManager").GetComponent<AudioManager> ();
	}
		
	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector3 (this.transform.position.x + velocity.x * Time.deltaTime * speed,
			this.transform.position.y + velocity.y * Time.deltaTime * speed,
			this.transform.position.z);
	}


	public void setInitialDirection(Vector3 direction){
		velocity = direction;
		velocity = velocity.normalized;
		//velocity = new Vector3 (velocity.x * speed, velocity.y * speed, velocity.z);
	}

	void OnCollisionEnter2D(Collision2D other){
		// TODO: Tentar fazer detectando o ponto de colisao e matemática vetorial
		if (other.gameObject.tag == "top" || other.gameObject.tag == "bottom") {
			invertVelocityY ();
			audiomanager.PlaySound ("Bounce");
		}
		if (other.gameObject.tag == "left" || other.gameObject.tag == "right") {
			invertVelocityX ();
			audiomanager.PlaySound ("Bounce");
		}
		if (other.gameObject.tag == "player1" || other.gameObject.tag == "player2") {
			//TODO: dar dano: Player = other.gameobject.getComponent<Player>()
			Player playerbhvr = other.gameObject.GetComponent<Player1>();
			if (!playerbhvr) {
				playerbhvr = other.gameObject.GetComponent<Player2>();
			}
			playerbhvr.takeDamage (dmg);
			audiomanager.PlaySound ("Damage2");
			Destroy(gameObject);
		}
	}

	void invertVelocityX(){
		velocity = new Vector3 (-velocity.x, velocity.y, velocity.z);
	}
		
	void invertVelocityY(){
		velocity = new Vector3 (velocity.x, -velocity.y, velocity.z);
	}

}
