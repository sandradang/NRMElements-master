using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MooseTigerController : MonoBehaviour {

	private bool isWalking = false;
	private bool hasCollided = false;
	private double walkTime = 0;
	public float speed = 0.7f;
	//private float sensorLenght = 2.0f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (isWalking || hasCollided) {
			GetComponent<Animator> ().SetBool ("isStartled", true);
			transform.Translate (speed * Time.deltaTime, 0, 0);
			walkTime += Time.deltaTime;
			if (walkTime > 4) {
				isWalking = false;
				GetComponent<Animator> ().SetBool ("isStartled", false);
				hasCollided = false;
				walkTime = 0;
			}
		}
	
	}

	public void setWalking(bool _isWalking){isWalking = _isWalking;}
	public void setCollided(bool _hasCollided){hasCollided = _hasCollided;}
}
