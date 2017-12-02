using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour {

	protected float speed = 3;
	protected float rotSpeed = 125;
	protected int maxHp = 5;
	protected int hp;
	protected GameObject shootPoint;

	protected GameObject getChildGameObject(string _name){
		Transform[] ts = this.gameObject.transform.GetComponentsInChildren<Transform> (true);
		foreach (Transform t in ts) {
			Debug.Log (t.gameObject.name);
			if (t.gameObject.name == _name)
				return t.gameObject;
		}
		return null;
	}

	void Start(){
		hp = maxHp;

	}

	void Update(){

	}

	#region movMethods
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
	#endregion
	public void takeDamage(int dmg){
		hp -= dmg;
	}

	public void Shoot (GameObject _bullet){
		GameObject bullet;
		bullet = Instantiate (_bullet.gameObject) as GameObject;
		bullet.transform.position = shootPoint.transform.position;
		bullet.transform.rotation = Quaternion.identity;
		Bullet bulletbhvr = bullet.GetComponent<Bullet> ();
		if (bulletbhvr) {
			Vector3 direction;
			direction = bullet.transform.position - this.transform.position;
			Debug.Log (direction);
			bulletbhvr.setInitialDirection (direction);
		} else {
			DestroyImmediate (bullet);
		}
	}

}
