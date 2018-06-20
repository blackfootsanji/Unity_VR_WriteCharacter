using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gaze : MonoBehaviour {
	private RaycastHit hit;
	private Vector3 pos = Vector3.zero;
	private int gazetime = 0;
	private bool isgaze = false;
	public int time = 60;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Physics.Raycast(transform.position,transform.forward,out hit)){
			
			if (pos == hit.collider.transform.position) {
				gazetime++;
			} else {
				gazetime=0;
				pos = hit.collider.transform.position;
			}
			if(gazetime==time){
				isgaze=!isgaze;
				gazetime=0;
			}
			//用isgaze来作判断开始与否依据，


		}
	}

}
