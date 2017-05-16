using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rider_movement : MonoBehaviour {

	public float speed;
	public GameObject destinationObj;
	private Vector3 startPos, endPos;
	private Time startTime;
	private bool collisionFlag;

	// Use this for initialization
	void Start () {
		endPos = destinationObj.transform.position;
		collisionFlag = false;
	}
	
	// Update is called once per frame
	void Update () {
//		float currentDuration = Time.time - startTime;
//		float jurneyFruction = currentDuration / distance;
		if (!collisionFlag) {
//			this.transform.position = Vector3.Lerp (startPos, endPos, jurneyFruction * speed);
			this.transform.position = Vector3.MoveTowards (this.transform.position, endPos, speed * Time.deltaTime);
		} else {
			
			collisionFlag = false;
		}
		if (this.transform.position == endPos) {
			print ("arrive");
			speed = 0;
		}
	}

	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.tag == "Infrastructure") {
			var pos = this.transform.position;
			pos.x += 10;
			Vector3 endPos_temp = pos;
			this.transform.position = Vector3.MoveTowards (this.transform.position, endPos_temp, col.gameObject.GetComponent<Collider>().bounds.size.x);
		} 
		else if (col.gameObject.tag == "lineStartPoint") {
//			GameObject.Destroy(GameObject.Find("rider1"));
		}
		collisionFlag = true;
	}
}
