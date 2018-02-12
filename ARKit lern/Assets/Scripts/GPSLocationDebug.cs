using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GPSLocationDebug : MonoBehaviour {

	public Text coordinates;

	void Update () {
		coordinates.text = "Lat: " + GeoLocation.Instance.latitude.ToString () + " Long: " + GeoLocation.Instance.longitude.ToString ();

	}
}
