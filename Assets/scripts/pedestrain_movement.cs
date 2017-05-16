using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pedestrain_movement : MonoBehaviour {

	public float speed;
	private Vector3 destPos;

	// Use this for initialization
	void Start () {
		destPos = new Vector3 (23,transform.position.y,transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.MoveTowards (transform.position, destPos, speed * Time.deltaTime);
	}
}
