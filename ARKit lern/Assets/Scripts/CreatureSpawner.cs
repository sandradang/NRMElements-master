using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatureSpawner : MonoBehaviour
{

	public GameObject BatHorse;
	public GameObject MooseTiger;

	public int distance = 0;
	public float batSpeed = 1f;

    private Quaternion mRotate = Quaternion.identity;
    private Quaternion eRotate = Quaternion.identity;
    private Quaternion dRotate = Quaternion.identity;

	private Vector3 camPos;

	void Awake ()
	{
        Cursor.visible = false;

		camPos = Camera.main.transform.position;

	
		PlaceBH ();
		PlaceMT ();
		
	}

	void PlaceBH ()
	{
		int posX = -3;
		int posZ = 3;
		for (int i = 0; i < 3; i++) {
			Vector3 pos = new Vector3 (camPos.x + posX, camPos.y + 1, camPos.z + posZ);
			Instantiate (BatHorse, pos, Quaternion.identity);
			posX += 3;
			posZ -= posX;
		}
	}

	void PlaceMT ()
	{
		for (int i = 0; i < 3; i++) {
			
			mRotate.eulerAngles = new Vector3 (0, 70, 0);
			Vector3 pos = camPos + Camera.main.transform.forward * distance;
			Vector3 mPos = new Vector3(pos.x + 0.5f,gameObject.transform.position.y,pos.z+5);
			transform.LookAt (Camera.main.transform);
			GameObject instantiedAnimal = Instantiate (MooseTiger, mPos, mRotate);
		}

	}
		
}
