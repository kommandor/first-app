using UnityEngine;
using System.Collections;

public class CamevaMovement : MonoBehaviour {
	private float screenWidth, screenHeight;

	public float speed,border;
	// Use this for initialization
	void Start () {
		screenWidth = Screen.width;
		screenHeight = Screen.height;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis ("Mouse ScrollWheel") > 0&& Camera.main.orthographicSize!=0) {
			Camera.main.orthographicSize=Camera.main.orthographicSize - 1;
		}
		if (Input.GetAxis ("Mouse ScrollWheel") < 0 ) {
			Camera.main.orthographicSize=Camera.main.orthographicSize + 1;
		}

		Vector3 myvect = transform.position;

		if (Input.mousePosition.x > screenWidth - border) {
			myvect.x+=speed*Time.deltaTime;
			transform.position=myvect;
		}
		if (Input.mousePosition.x < border) {
			myvect.x-=speed*Time.deltaTime;
			transform.position=myvect;
		}
		if (Input.mousePosition.y > screenHeight - border) {
			myvect.y+=speed*Time.deltaTime;
			transform.position=myvect;
		}
		if (Input.mousePosition.y < border) {
			myvect.y-=speed*Time.deltaTime;
			transform.position=myvect;
		}
	}


}
