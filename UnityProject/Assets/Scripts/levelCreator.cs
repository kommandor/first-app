using UnityEngine;
using System.Collections;

public class levelCreator : MonoBehaviour {

	public GameObject[] trainCell;  
	public GameObject fieldCell;//Array of train prefabs
	public int wagonsNumber;              //Number of wagons in the train
	private GameObject Creation;			  //Array of created train elements
	public Vector3 trainStartPosition;
//	private int number; 
	// Use this for initialization
	void Start () {
		StartCoroutine (fieldSpawn());
		StartCoroutine (roadSpawn(Creation));
		StartCoroutine (trainSpawn(0,Creation));   // Calling the trainSpawn function
//		number =Random.Range (10,20);
	}
	IEnumerator fieldSpawn(){
		yield break;
	}
	IEnumerator roadSpawn(GameObject fieldCell){
		yield break;
//		Vector3 fieldStartPosition = trainStartPosition;
//		Creation = Instantiate (fieldCell,fieldStartPosition,transform.rotation) as GameObject;
	}
	IEnumerator trainSpawn(int number,GameObject prevTrain){
		//Getting the position of the head of the train
		trainStartPosition = new Vector3 (trainStartPosition.x,trainStartPosition.y, 0);
		//First wagon is locomotion, others - wagons
		int cellIndex = number == 0 ? 0 : 1;
		//Making an object
		Creation= Instantiate(trainCell[cellIndex],trainStartPosition,transform.rotation) as GameObject;
		trainStartPosition.x -= 1;
		if (cellIndex != 0) {
			//Chain of the train objects
			Creation.transform.parent=prevTrain.transform;
		}																			
//		print (trainCreation.name);
		if (number != wagonsNumber) {
			// Do this coroutine until all objects done
			StartCoroutine (trainSpawn (number + 1,Creation));
		} 
		else {
			//return ready train info
				yield break;
		}
	}
}
