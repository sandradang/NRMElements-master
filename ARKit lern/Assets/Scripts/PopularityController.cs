using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PopularityController : MonoBehaviour {

	private int likeCount;
	private int tempInt;
	private bool hasLikedBefore = false;
	//public string animal;

	void Start () {
		likeCount = 0; //IMPORTANT! When we have a database set up, this should be changed to the likes that are saved in the database.
		//likeCount = this.GetComponent<DataBaseManager> ().GetPopularity();
	}


	public void CheckLikedBefore(GameObject hitObject){

		Image emptyHeart = hitObject.GetComponent<ClampText> ().instLabel.GetComponentsInChildren<Image> ()[1];
		Image filledHeart = hitObject.GetComponent<ClampText> ().instLabel.GetComponentsInChildren<Image> ()[2];

		if (hasLikedBefore) {
			RemoveLike (hitObject, emptyHeart, filledHeart);
		} else {
			AddLike (hitObject, emptyHeart, filledHeart);
		}
	}


	/*This function is called in the TouchController when the user hits the popularity tag. 
	 *What it does is:
	 * - increases the likes in the database with 1 (likeCount)
	 * - takes in the object that carries the popularity text (hitObject)
	 * - gets the text component that writes out the popularity in the scene
	 * - checks if it is an int
	 * - if it is, then the text in the scene will be updated with the new value that is in the database (likeCount)
	 */
	public void AddLike (GameObject hitObject, Image emptyHeart, Image filledHeart) {
		//Set new like in database
		likeCount += 1;
		hasLikedBefore = true;
		//Checks textcomponent if its an integer
		string popularityText = hitObject.GetComponent<ClampText> ().instLabel.GetComponentInChildren<Text>().text;
		bool isInt = int.TryParse(popularityText, out tempInt);
		//Writes new database like to the screen
		if (isInt) {
			
			hitObject.GetComponent<ClampText>().instLabel.GetComponentInChildren<Text>().text = likeCount.ToString();
			Debug.Log ("Added");
		}
		emptyHeart.enabled = false;
		filledHeart.enabled = true;

	}

	public void RemoveLike(GameObject hitObject, Image emptyHeart, Image filledHeart){
		
		if (likeCount > 0) {
			//Set new like in database
			likeCount -= 1;
			hasLikedBefore = false;
			//Checks textcomponent if its an integer
			string popularityText = hitObject.GetComponent<ClampText> ().instLabel.GetComponentInChildren<Text>().text;
			bool isInt = int.TryParse(popularityText, out tempInt);
			//Writes new database like to the screen
			if (isInt) {
				
				hitObject.GetComponent<ClampText>().instLabel.GetComponentInChildren<Text>().text = likeCount.ToString();
				Debug.Log ("Removed");
			}

			emptyHeart.enabled = true;
			filledHeart.enabled = false;

		} 
	}
}
