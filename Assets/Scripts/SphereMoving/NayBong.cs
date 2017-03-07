using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NayBong : MonoBehaviour {
	public Rigidbody rb;
	float jumpHeight = 10f;
	bool isFalling;

	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isFalling == false) {
			isFalling = true;
			Vector3 v = rb.velocity;
			v.y = jumpHeight;
			rb.velocity = v;
		}
	}

	void OnCollisionEnter(Collision other){
		print ("Collision: " + other.gameObject.name);
		if (other.gameObject.name == "WaterBasicDaytime") {
			Debug.Log ("AAAAAAAAAAAAAAAAAAAAAAAAAAAAa");
			isFalling = false;
		}
	}
    
}
