using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rider_movement_v2 : MonoBehaviour {

	public GameObject line_start;
	private Vector3 destPos;
	public float speed;

	// Use this for initialization
	void Start () {
		destPos = line_start.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit = new RaycastHit();
		Vector3 currentPos = transform.position;
		Vector3 direction = destPos - currentPos;
		Debug.DrawRay(transform.position, direction, Color.green);
		transform.position = Vector3.MoveTowards (transform.position, destPos, speed * Time.deltaTime);
		// update destination when collision
		if (Physics.Raycast (currentPos, direction, out hit)) {
//			print (hit.distance + " " + hit.collider.tag + " " + hit.transform.position);
//			print (hit.transform.position + " " + hit.collider.transform.position.x);
			if (hit.collider.tag == "Infrastructure") {
				// collision with infrastructure, update destPos
				if (hit.transform.position.x < line_start.transform.position.x) {
					destPos = hit.collider.transform.position;
					destPos.x += hit.collider.bounds.size.x;
				} else {
					destPos = hit.collider.transform.position;
					destPos.x -= hit.collider.bounds.size.x;
				}
				print ("collision " + transform.name);
			} else if (hit.collider.tag == "pedestrian") {
				// collision with infrastructure, update destPos
				if (hit.transform.position.x < line_start.transform.position.x) {
					destPos = hit.collider.transform.position;
					destPos.x += hit.collider.bounds.size.x;
				} else {
					destPos = hit.collider.transform.position;
					destPos.x -= hit.collider.bounds.size.x;
				}
				print ("collision " + transform.name);
			}
		} 
//		print (position_close(transform.position, destPos) + " " + transform.name);
		if (position_close (transform.position, destPos)) {
			destPos = line_start.transform.position;
		}

	}

	bool position_close(Vector3 currentPos, Vector3 destPos){
		float distance = Vector3.Distance (currentPos, destPos);
		if (distance < 0.25f) {
			return true;
		}
		return false;
	}
}
