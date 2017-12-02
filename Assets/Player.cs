using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour {

	protected float speed = 3;
	protected float rotSpeed = 75;

	public void goUp(){
		this.transform.position = new Vector3 (this.transform.position.x,
			this.transform.position.y + speed*Time.deltaTime,
			this.transform.position.z);
	}

	public void goDown(){
		this.transform.position = new Vector3 (this.transform.position.x,
			this.transform.position.y - speed*Time.deltaTime,
			this.transform.position.z);
	}

	public void goLeft(){
		this.transform.position = new Vector3 (this.transform.position.x - speed*Time.deltaTime,
			this.transform.position.y,
			this.transform.position.z);
	}

	public void goRight(){
		this.transform.position = new Vector3 (this.transform.position.x + speed*Time.deltaTime,
			this.transform.position.y,
			this.transform.position.z);
	}

	public void rotateLeft(){
		Vector3 eulerRotation = this.transform.rotation.eulerAngles;
		this.transform.rotation = Quaternion.Euler (eulerRotation.x, eulerRotation.y, eulerRotation.z + rotSpeed*Time.deltaTime);
	}

	public void rotateRight(){
		Vector3 eulerRotation = this.transform.rotation.eulerAngles;
		this.transform.rotation = Quaternion.Euler (eulerRotation.x, eulerRotation.y, eulerRotation.z - rotSpeed*Time.deltaTime);
	}

}
