using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class P1KeyBind : MonoBehaviour {

	InputManager inputmanager;
	public GameObject keyItemPrefab;

	// Use this for initialization
	void Start () {
		inputmanager = GameObject.Find ("_InputManager").GetComponent<InputManager> ();
		string[] buttonNames = inputmanager.GetButtonNames ();

		foreach (string bn in buttonNames) {
			if (bn [1] == '2') {
				continue;
			}
			GameObject go = Instantiate (keyItemPrefab, this.transform) as GameObject;
			go.transform.localScale = Vector3.one;

			TextMeshProUGUI buttonNameText = go.transform.Find ("ButtonName").GetComponent<TextMeshProUGUI> ();
			buttonNameText.text = bn.Substring(2);

			TextMeshProUGUI keyNameText = go.transform.Find ("Button/KeyName").GetComponent<TextMeshProUGUI> ();
			keyNameText.text = inputmanager.GetKeyNameForButton(bn);
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
