using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beshootonce : MonoBehaviour {
	public static bool beshoot = false;
	// Use this for initialization
	public GameObject expolsion;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.position.z <= -10.0f) {
			beshoot = true;
			targetfire.beshootnum++;
			transform.GetComponent<BoxCollider> ().enabled = false;
			Instantiate(expolsion,transform.position,transform.rotation);
			Destroy (transform.gameObject);
		}
	}



}
