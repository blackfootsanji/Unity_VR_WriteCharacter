using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooter : MonoBehaviour {
	/*
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	*/
	public static bool col = false;
	public GameObject expolsion;
	void OnCollisionEnter(Collision info){
		string str = info.gameObject.name;
		Debug.Log (str);
		if (str.Equals ("target(Clone)")) {
			Instantiate (expolsion,transform.position,transform.rotation);
			targetfire.shootnum++;
			info.gameObject.transform.GetComponent<BoxCollider> ().enabled = false;
			Destroy (info.transform.gameObject);
			col = true;
		}
		Destroy (this.gameObject);
	}

}
