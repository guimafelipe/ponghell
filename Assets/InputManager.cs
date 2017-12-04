using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

	public static InputManager instance;

	Dictionary<string, KeyCode> buttonKeys;

	void Awake(){
		if(instance != null){
			if (instance != this) {
				Destroy (this.gameObject);
			}
		}else{
			instance = this;
			DontDestroyOnLoad (this);
		}
	}


	// Use this for initialization
	void Start () {
		buttonKeys = new Dictionary<string, KeyCode> ();
		buttonKeys ["P1Up"] = KeyCode.W;
		buttonKeys ["P1Down"] = KeyCode.S;
		buttonKeys ["P1Left"] = KeyCode.A;
		buttonKeys ["P1Right"] = KeyCode.D;
		buttonKeys ["P1RotateLeft"] = KeyCode.Q;
		buttonKeys ["P1RotateRight"] = KeyCode.E;
		buttonKeys ["P1Shoot"] = KeyCode.Space;
		buttonKeys ["P2Up"] = KeyCode.I;
		buttonKeys ["P2Down"] = KeyCode.K;
		buttonKeys ["P2Left"] = KeyCode.J;
		buttonKeys ["P2Right"] = KeyCode.L;
		buttonKeys ["P2RotateLeft"] = KeyCode.U;
		buttonKeys ["P2RotateRight"] = KeyCode.O;
		buttonKeys ["P2Shoot"] = KeyCode.N;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool GetButtonDown(string buttonName){
		if (buttonKeys.ContainsKey (buttonName) == false) {
			Debug.LogError ("InputManager::GetButtonDown -- No button named:" + buttonName);
			return false;
		}
		return Input.GetKeyDown (buttonKeys [buttonName]);

	}

	public bool GetButton(string buttonName){
		if (buttonKeys.ContainsKey (buttonName) == false) {
			Debug.LogError ("InputManager::GetButtonDown -- No button named:" + buttonName);
			return false;
		}
		return Input.GetKey (buttonKeys [buttonName]);

	}

}
