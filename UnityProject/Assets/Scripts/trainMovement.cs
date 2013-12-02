using UnityEngine;
using System.Collections;

public class trainMovement : MonoBehaviour {
	public float speed;
	public float scaleChange=45f;
	public float angle = 3*Mathf.PI/2;
	public int newDirection=1;
	public int worldDirection=0;
	public Vector3 center;

	private float target;
	private float counter = 0f;
	public int prevDirection;
	
	void Start(){
		center = new Vector3 (transform.position.x-Mathf.Cos (angle) ,transform.position.y -Mathf.Sin (angle),transform.position.z);
	}

	// Update is called once per frame
	void LateUpdate () {
				float curX = transform.position.x;
				float curY = transform.position.y;
						if (counter >= 0.99f) {
								prevDirection=newDirection;
								newDirection = Random.Range (0, 3);
								counter = 0;
						} else {
								counter += speed;
						}
		


//		print ("counter="+counter);
		speed=Mathf.Round (speed*100)/100;
		transform.position=new Vector3(Mathf.Round (transform.position.x*100)/100,Mathf.Round(transform.position.y*100)/100,transform.position.z);
		center.x=Mathf.Round (center.x*100)/100;
		center.y=Mathf.Round (center.y*100)/100;
		//		defineCircleCenter ();
//		Quaternion target = Quaternion.Euler (0, 0, scaleChange*Time.fixedDeltaTime);
//		transform.rotation = Quaternion.Slerp (transform.rotation, target, speed);
//		scaleChange += 45f;

		print ("x=" + transform.position.x.ToString () + " y= " + transform.position.y.ToString () + " angle" + angle.ToString () + " worldDirect=" + worldDirection.ToString () + " direction=" + newDirection.ToString () + " centx=" + center.x.ToString () + " centy=" + center.y.ToString ());
				if (newDirection == 0) {
						if (worldDirection == 0) {
								transform.position = new Vector3 (curX - Mathf.Sin (angle) * speed, curY + Mathf.Cos (angle) * speed, transform.position.z);
								center = leftPos (angle, center, speed);
						} else {
								transform.position = new Vector3 (curX + Mathf.Sin (angle) * speed, curY - Mathf.Cos (angle) * speed, transform.position.z);
								center = rightPos (angle, center, speed);
						}
						if(counter>0.99f){transform.position=new Vector3(Mathf.Round (transform.position.x),Mathf.Round(transform.position.y),transform.position.z);
							center.x=Mathf.Round (center.x);
							center.y=Mathf.Round (center.y);
						}
				}
						if (newDirection == 1) {
								if (worldDirection != 0) {
										center = new Vector3 (curX + Mathf.Cos (angle), curY + Mathf.Sin (angle), transform.position.z);
										angle += Mathf.PI;
										worldDirection = 0;
								} else {
										transform.position = new Vector3 (center.x + Mathf.Cos (angle), center.y + Mathf.Sin (angle), transform.position.z);
										angle += Mathf.PI / 2 * speed;
								}
								if (counter > 0.99) {
										transform.position = new Vector3 (Mathf.Round (transform.position.x), Mathf.Round (transform.position.y), transform.position.z);
										center.x = Mathf.Round (center.x);
										center.y = Mathf.Round (center.y);
								}		
						}
						if (newDirection == 2) {
								if (worldDirection == 0) {
										center = new Vector3 (curX + Mathf.Cos (angle), curY + Mathf.Sin (angle), transform.position.z);
										angle += Mathf.PI;
										transform.position = new Vector3 (center.x + Mathf.Cos (angle), center.y + Mathf.Sin (angle), transform.position.z);
										angle -= Mathf.PI / 2 * speed;
										if (counter == 0) {
												worldDirection = 1;
										}
								} else {	
										transform.position = new Vector3 (center.x + Mathf.Cos (angle), center.y + Mathf.Sin (angle), transform.position.z);
										angle -= Mathf.PI / 2 * speed;
								}
								if (counter >= 1) {
										transform.position = new Vector3 (Mathf.Round (transform.position.x), Mathf.Round (transform.position.y), transform.position.z);
										center.x = Mathf.Round (center.x);
										center.y = Mathf.Round (center.y);
								}
						}
				
		if (angle > 2 * Mathf.PI) {
						angle -= 2 * Mathf.PI;
				}
				if (angle < -2 * Mathf.PI) {
						angle += 2 * Mathf.PI;
				}
		}
/*		if (prevDirection > 3) {
			prevDirection-=4;		
		}
		if (prevDirection < 0) {
			prevDirection+=4;		
		}
	}

	int Direction(int prevDirection){

		if ( Input.GetKey("up")) {
			return 0;
		}
		if (Input.GetKey("left")) {
			return 1;
		}
		if (Input.GetKey("right")) {
			return 2;
		}
		return 4;
	}
*/
	Vector3 rightPos(float angle,Vector3 center,float speed){
				center = new Vector3 (center.x + Mathf.Sin (angle)*speed, center.y - Mathf.Cos (angle)*speed, transform.position.z);
		return center;
	}
	Vector3 leftPos(float angle,Vector3 center,float speed){
				center = new Vector3 (center.x - Mathf.Sin (angle)*speed, center.y + Mathf.Cos (angle)*speed, transform.position.z);
		return center;
	}

}
