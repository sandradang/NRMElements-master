using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeoLocation : MonoBehaviour {

	public static GeoLocation Instance {set; get;}

	public float latitude;
	public float longitude;
	public Text debugText;

	// Use this for initialization
	void Start () {

		Instance = this;
		DontDestroyOnLoad (gameObject);
		StartCoroutine (StartLocationService ());

	}

	private IEnumerator StartLocationService(){

		if (!Input.location.isEnabledByUser) {
			Debug.Log ("User has not enabled GPS"); 
			debugText.text = "User has not enabled GPS";
			yield break;
		}

		Input.location.Start ();
		int maxWait = 20;
		while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0) {
			yield return new WaitForSeconds (1);
			maxWait--;
		}

		if (maxWait <= 0) {
			Debug.Log ("Timed out");
			debugText.text = "Timed out";
			yield break;
		}

		if(Input.location.status == LocationServiceStatus.Failed){
			Debug.Log("Unable to deterimin device location");
			debugText.text = "Unable to deterimin device location";
			yield break;
		}

		latitude = Input.location.lastData.latitude;
		longitude = Input.location.lastData.longitude;

		Debug.Log("latitude: " + latitude);
		Debug.Log("Longitude: " + longitude);

	}
}
