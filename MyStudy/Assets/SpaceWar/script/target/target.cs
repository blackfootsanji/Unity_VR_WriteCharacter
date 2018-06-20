using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	public GameObject gameobj;
	public bool go = true;
	// Update is called once per frame
	private float speed = 0f; 
	void Update () {
		if(go)
		{
			if (targetfire.level == 1) {
				speed = 150f;
			}
			if (targetfire.level == 2) {
				speed = 200f;
			}
			if (targetfire.level == 3) {
				speed = 250f;
			}
			if (targetfire.level == 4) {
				speed = 300f;
			}
			if (targetfire.level == 5) {
				speed = 350f;
			}
			GameObject target = Instantiate (gameobj, transform.position, transform.rotation);
			target.GetComponent<Rigidbody> ().AddForce (-transform.forward * speed);
			Destroy (target, 20f);
			go = false;
		}
	}



}
