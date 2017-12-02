using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float speed = 20;
	private Vector3 velocity;

	// Use this for initialization
	void Start () {
		//setInitialDirection (new Vector3 (1f, 1f));
	}
		
	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector3 (this.transform.position.x + velocity.x * Time.deltaTime,
			this.transform.position.y + velocity.y * Time.deltaTime,
			this.transform.position.z);
	}


	public void setInitialDirection(Vector3 direction){
		velocity = direction;
		velocity = velocity.normalized;
		velocity = new Vector3 (velocity.x * speed, velocity.y * speed, velocity.z);
	}

	void OnCollisionEnter2D(Collision2D other){
		// TODO: Tentar fazer detectando o ponto de colisao e matemática vetorial
		if (other.gameObject.tag == "top" || other.gameObject.tag == "bottom") {
			invertVelocityY ();
		}
		if (other.gameObject.tag == "left" || other.gameObject.tag == "right") {
			invertVelocityX ();
		}
		if (other.gameObject.tag == "player1" || other.gameObject.tag == "player2") {
			//TODO: dar dano: Player = other.gameobject.getComponent<Player>()
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
