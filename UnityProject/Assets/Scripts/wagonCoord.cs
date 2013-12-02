using UnityEngine;
using System.Collections;

public class wagonCoord : MonoBehaviour {

	public GameObject train;
	public trainMovement traintoFollow;
	public Queue prevX = new Queue();
	public Queue prevY = new Queue();
	private float counter=0f;
	public float speed;


	void Start(){
		traintoFollow = train.GetComponent<trainMovement> ();
		speed = traintoFollow.speed;
	}

	void Update () {
		if (counter >= 1) {
			transform.position = new Vector3 (Mathf.Round (transform.position.x), Mathf.Round (transform.position.y), transform.position.z);
			float x=(float)prevX.Dequeue();
			float y=(float)prevY.Dequeue();
			transform.position=new Vector3(x,y,transform.position.z);
		}

		prevX.Enqueue(transform.parent.position.x);
		prevY.Enqueue(transform.parent.position.y);
		counter += speed;
	}
}
