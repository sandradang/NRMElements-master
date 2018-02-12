using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Firebase;
//using Firebase.Database;
//using Firebase.Unity.Editor;


public class DataBaseManager : MonoBehaviour {

//	private DatabaseReference db;
	public static PopularityController Instance;
	public long popularityLikes = 0;
	private long currentLikes;

	//WHAT IS THIS BELOW?????
	public delegate void ScoreAction ();
	public static event ScoreAction TopScoreUpdated;


/*	void Awake () {

		if (Instance == null) Instance = this;

		// Set this before calling into the realtime database.
		FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://bathorse-795cd.firebaseio.com/");

		// Get the root reference location of the database, from which we will operate on the database.
		db = FirebaseDatabase.DefaultInstance.GetReference("Popularity");

		// Get top score, listen for changes.

		//GetPopularity ();
		db.ValueChanged += HandleTopScoreChange; 


	}


	public void GetPopularity(){

		db.GetValueAsync().ContinueWith(task => {
			if (task.IsFaulted) {
				// ERROR HANDLER
			}
			else if (task.IsCompleted) {
				Dictionary<string, object> results = (Dictionary<string, object>) task.Result.Value;
				popularityLikes = (long) results["topScore"];
			}
		});
	}

	public void LogScore(long s) {
		currentLikes = s;
		if (currentLikes > popularityLikes) {
			db.RunTransaction (UpdateTopScore);
		}
	}


	//CHECK FOR LIKES AT THE SAME TIME?

	private TransactionResult UpdateTopScore(MutableData md) {
		if (md.Value != null) {
			Dictionary<string,object> updatedScore = md.Value as Dictionary<string,object>;
			popularityLikes = (long) updatedScore ["topScore"];
		}

		// Compare the cur score to the top score.
		if (currentLikes > popularityLikes) { // Update topScore, triggers other UpdateTopScores to retry
			popularityLikes = currentLikes;
			md.Value = new Dictionary<string,object>(){{"topScore", currentLikes}};
			return TransactionResult.Success(md);
		}
		return TransactionResult.Abort (); // Aborts the transaction
	}

	void HandleTopScoreChange(object sender, ValueChangedEventArgs args) {
		Dictionary<string,object> update = (Dictionary<string,object>)args.Snapshot.Value;
		popularityLikes = (long) update["topScore"];
		Debug.Log ("New Top Score: " + popularityLikes);
		if (popularityLikes != null) TopScoreUpdated ();
	}*/
}
