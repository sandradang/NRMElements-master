using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalController : MonoBehaviour {

	public void SetAnimalStateTrue (GameObject hitAnimal) {

		if (hitAnimal.tag == "MooseTiger") {
			hitAnimal.GetComponent<MooseTigerController> ().setWalking (true);
		} 
	} 

	public void SetAnimalStateFalse (GameObject hitAnimal){
		hitAnimal.GetComponent<Animator> ().SetBool ("isStartled", false);
	}
}

