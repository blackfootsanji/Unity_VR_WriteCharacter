﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestChild : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.GetChild (0).GetComponent<Renderer> ().material.color = Color.red;
	}
}
