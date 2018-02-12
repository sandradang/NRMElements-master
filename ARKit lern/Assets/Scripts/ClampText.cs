using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClampText : MonoBehaviour {

	private GameObject canv;
	public Component popularityLabel;
	public Component instLabel;

	
	// Update is called once per frame

	void Awake(){
		canv = GameObject.FindGameObjectWithTag ("Canvas");
		instLabel = Instantiate (popularityLabel);
		instLabel.transform.SetParent (canv.transform);
	}

	void Update () {

		Vector3 labelPos = Camera.main.WorldToScreenPoint (this.transform.position);
		instLabel.transform.position = labelPos;

	}
}
