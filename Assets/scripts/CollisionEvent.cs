using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class CollisionEvent : MonoBehaviour {
	
	void OnCollisionEnter (Collision col)
	{
		print (col.gameObject.name);
	}
}
