using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class KeyBindController : MonoBehaviour {

	InputManager inputmanager;
	public GameObject keyItemPrefab;

	string buttonToRebind = null;
	protected char playerquesou;

	Dictionary<string, TextMeshProUGUI> buttonsToLabel;

	// Use this for initialization
	protected void Start () {
		inputmanager = GameObject.Find ("_InputManager").GetComponent<InputManager> ();
		string[] buttonNames = inputmanager.GetButtonNames ();
		buttonsToLabel = new Dictionary<string, TextMeshProUGUI> ();


		for(int i = 0; i < buttonNames.Length; i++) {
			string bn = buttonNames [i];
			if (bn [1] != playerquesou) {
				continue;
			}
			GameObject go = Instantiate (keyItemPrefab, this.transform) as GameObject;
			go.transform.localScale = Vector3.one;

			TextMeshProUGUI buttonNameText = go.transform.Find ("ButtonName").GetComponent<TextMeshProUGUI> ();
			buttonNameText.text = bn.Substring(2);

			TextMeshProUGUI keyNameText = go.transform.Find ("Button/KeyName").GetComponent<TextMeshProUGUI> ();
			keyNameText.text = inputmanager.GetKeyNameForButton(bn);
			buttonsToLabel [bn] = keyNameText;

			Button keyBindButton = go.transform.Find ("Button").GetComponent<Button> ();
			keyBindButton.onClick.AddListener (() => {StartRebindFor(bn);});

		}

	}

	void StartRebindFor(string buttonName){
		buttonToRebind = buttonName;
	}

	// Update is called once per frame
	protected void Update () {
		if (buttonToRebind != null) {
			if (Input.anyKeyDown) {
				foreach (KeyCode kc in Enum.GetValues(typeof (KeyCode))) {
					if (Input.GetKeyDown (kc)) {

						inputmanager.SetButtonForKey (buttonToRebind, kc);
						buttonsToLabel [buttonToRebind].text = kc.ToString();
						break;
					}
				}
				buttonToRebind = null;
			}
		}
	}
}
