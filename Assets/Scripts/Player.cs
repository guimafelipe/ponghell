using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour {

	protected float speed = 3;
	protected float rotSpeed = 125;
	protected int maxHp = 7;
	protected int hp;
	protected int maxBullets = 7;
	protected int bullets;
	public float maxReloadTime = 3f;
	protected float reloadTime;

	protected GameObject shootPoint;

	public bool canMove;
	public bool canTakeDamage;

	AudioManager audiomanager;
	protected InputManager inputmanager;
	protected GManager gmanager;

	protected int playertype = 0;

	[SerializeField]
	protected IUIzinha[] obsUIs;

	protected GameObject getChildGameObject(string _name){
		Transform[] ts = this.gameObject.transform.GetComponentsInChildren<Transform> (true);
		foreach (Transform t in ts) {
			if (t.gameObject.name == _name)
				return t.gameObject;
		}
		return null;
	}

	public void seInscrever(IUIzinha uinova){
		//Debug.Log (obsUIs);
		if (null == obsUIs) {
			obsUIs = new IUIzinha[2];
			obsUIs.SetValue (uinova, 0);
		} else {
			obsUIs.SetValue (uinova, obsUIs.Length - 1);
		}
	}

	private void atualizarUIs(string action, int value){
		foreach (IUIzinha ui in obsUIs) {
			ui.Atualizar (action, value);
		}
	}

	public void Start(){
		canMove = false;
		canTakeDamage = true;
		shootPoint = getChildGameObject ("ShootPoint");
		hp = maxHp;
		reloadTime = maxReloadTime;
		bullets = maxBullets;
		audiomanager = GameObject.Find ("_AudioManager").GetComponent<AudioManager> ();
		gmanager = GameObject.Find ("_GM").GetComponent<GManager> ();
		inputmanager = GameObject.Find ("_InputManager").GetComponent<InputManager> ();
		StartCoroutine (primeiraAttUIs ());
	}

	IEnumerator primeiraAttUIs(){
		yield return new WaitForEndOfFrame ();
		atualizarUIs ("hp", hp);
		atualizarUIs ("bullets", bullets);
	}

	protected void Update(){
		if (canMove) {
			reloadTime -= Time.deltaTime;
		}
		if (reloadTime <= 0) {
			Reload ();
		}
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
		if (!canTakeDamage) {
			return;
		}
		hp -= dmg;
		atualizarUIs ("hp", hp);  //Observer
		if (hp <= 0) {
			Die ();
		}
	}

	protected virtual void Die(){
		audiomanager.PlaySound ("Morte");
		// TODO: Instanciar animação de morte aqui
		Destroy (this.gameObject);
		if (playertype == 1) {
			gmanager.Player1Morreu ();
		} else if (playertype == 2) {
			gmanager.Player2Morreu ();
		}
	}

	public void Reload(){
		if (!canMove) {
			return;
		}
		if (bullets < maxBullets) {
			bullets++;
		}
		atualizarUIs ("bullets", bullets);
		reloadTime = maxReloadTime;
	}

	public void Shoot (GameObject _bullet){
		if (bullets <= 0) {
			return;
		}
		if (bullets > 0) {
			bullets--;
		}
		atualizarUIs ("bullets", bullets);
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
			audiomanager.PlaySound ("Shoot");
		} else {
			DestroyImmediate (bullet);
		}
	}

}
