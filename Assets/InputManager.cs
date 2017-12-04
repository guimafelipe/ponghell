using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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

	void OnEnable(){
		buttonKeys = new Dictionary<string, KeyCode> ();
		buttonKeys ["P1Up"] = KeyCode.W;
		buttonKeys ["P1Down"] = KeyCode.S;
		buttonKeys ["P1Left"] = KeyCode.A;
		buttonKeys ["P1Right"] = KeyCode.D;
		buttonKeys ["P1Rotate Left"] = KeyCode.Q;
		buttonKeys ["P1Rotate Right"] = KeyCode.E;
		buttonKeys ["P1Shoot"] = KeyCode.Space;
		buttonKeys ["P2Up"] = KeyCode.I;
		buttonKeys ["P2Down"] = KeyCode.K;
		buttonKeys ["P2Left"] = KeyCode.J;
		buttonKeys ["P2Right"] = KeyCode.L;
		buttonKeys ["P2Rotate Left"] = KeyCode.U;
		buttonKeys ["P2Rotate Right"] = KeyCode.O;
		buttonKeys ["P2Shoot"] = KeyCode.N;
	}

	// Use this for initialization
	void Start () {

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

	public string[] GetButtonNames(){
		return buttonKeys.Keys.ToArray ();
	}

	public string GetKeyNameForButton(string buttonName){
		if (buttonKeys.ContainsKey (buttonName) == false) {
			Debug.LogError ("InputManager::GetButtonDown -- No button named:" + buttonName);
			return "N/A";
		}
		return buttonKeys [buttonName].ToString ();
	}
}
