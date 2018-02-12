using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatHorseController : MonoBehaviour {


	public Transform animal;

	string state = "patrol";
	public GameObject[] waypoints;
	int currentWP;
	public float rotSpeed = 1.0f;
	public float speed = 1.5f;
	public float accuracyWP = 2.0f; 	//test if the WP is reached,  if it passes the WP it will consider it got there
	public GameObject explosion;
	private double circlingTime = 0;
	private Rigidbody rbody;


	// Use this for initialization
	void Start () {

		currentWP = Random.Range (0, waypoints.Length);
		rbody = this.GetComponent<Rigidbody> ();

		//Waypoint positioning
		int posX = -3;
		int posZ = 3;
		for (int i = 0; i < 3; i++) {
			Vector3 pos = new Vector3 (Camera.main.transform.position.x + posX, Camera.main.transform.position.y + 3, Camera.main.transform.position.z + posZ);
			Instantiate (waypoints[i], pos, Quaternion.identity);
			posX += 3;
			posZ -= posX;
		}

	}

	// Update is called once per frame
	void Update () {

		Vector3 direction = animal.position - this.transform.position;
		direction.y = 0;

		if (state == "patrol" && waypoints.Length > 0) {

			this.gameObject.GetComponent<Animator> ().SetBool ("hasCollided", false);
			if (Vector3.Distance (waypoints [currentWP].transform.position, transform.position) < accuracyWP) {
				currentWP = Random.Range (0, waypoints.Length);
			}

			//rotate towards new WP
			direction = waypoints [currentWP].transform.position - transform.position;
			this.transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (direction), rotSpeed * Time.deltaTime);
			this.transform.Translate (0, 0, speed * Time.deltaTime);
		}

		else if (state == "collission") {
			this.gameObject.GetComponent<Animator>().SetBool("hasCollided",true);
			Instantiate (explosion, transform.position, transform.rotation);
			state = "patrol";
		}

		else if (state == "isStartled") {

			transform.LookAt(Camera.main.transform); 
			rbody.velocity = transform.forward * speed; 

			this.GetComponent<Animator> ().SetBool ("isStartled", true);
			circlingTime += Time.deltaTime;
			if (circlingTime > 5) {
				this.GetComponent<Animator> ().SetBool ("isStartled", false);
				rbody.velocity = Vector3.zero;
				circlingTime = 0;
				state = "patrol";
			}

		}


	}

	//SHOULD BE MOVED TO SEPERATE GENERAL SCRIPT
	void OnTriggerEnter (Collider other){
		if (other.tag == "BatHorse") {
			Debug.Log ("triggered");
			state = "collission";
		} else if (other.tag == "MooseTiger") {
			other.GetComponent<MooseTigerController> ().setCollided (true);
			state = "collission";
		}
	}

	public void setState(string _state){ state = _state;}

}
