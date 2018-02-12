using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchController : MonoBehaviour {

	public Text touchDetect;
	private LayerMask lm;
	GameObject hitObject;
	private string animPlaying;
	private float acumTime;

	// Use this for initialization
	void Start () {

		//anim = GetComponent<Animator>();
		touchDetect.text = "Debug";

	}

	// Update is called once per frame
	void Update () {

		if(Input.touchCount > 0){

			Touch touch = Input.GetTouch (0);
			acumTime += touch.deltaTime;

			Vector3 touchposFar = new Vector3 (touch.position.x, touch.position.y, Camera.main.farClipPlane);
			Vector3 touchposNear = new Vector3 (touch.position.x, touch.position.y, Camera.main.nearClipPlane);

			Vector3 touchposF = Camera.main.ScreenToWorldPoint (touchposFar);
			Vector3 touchposN = Camera.main.ScreenToWorldPoint (touchposNear);

			RaycastHit hit;
			Ray ray = new Ray(touchposN, (touchposF - touchposN));

			if (Physics.Raycast(ray,out hit,100)){	

				if (touch.phase == TouchPhase.Began) {
					hitObject = hit.transform.gameObject;
					lm = hitObject.layer;
					touchDetect.text = "Touch detected. Object layer is " + lm.value;

					if (lm == 8) {
						//Do the script of AnimalController
						this.GetComponent<AnimalController> ().SetAnimalStateTrue (hitObject);

					} else if (lm == 9) {
						//Do the script of PopularityController
						this.GetComponent<PopularityController> ().CheckLikedBefore (hitObject);
					} else if (lm == 11) {
						//Do the script of FavouriteCreature
						this.GetComponent<FavouriteCreature> ().SetFavourite(hitObject);
					}
				} 

				if (touch.phase == TouchPhase.Ended) {
					touchDetect.text = "Touch released";
					if (lm == 8) {
						this.GetComponent<AnimalController> ().SetAnimalStateFalse (hitObject);
					}
				}
			}
		}

	}
}
