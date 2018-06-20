using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
public class bichua_new: MonoBehaviour {
	[SerializeField] private GameObject text;
	[SerializeField] private Renderer[] child_mat; 
	[SerializeField] private int child_count;
	// Use this for initialization
	void Start () {
		child_mat = transform.GetComponentsInChildren<Renderer>();//只有有zu件才算个数
		child_count = transform.childCount;//只算第一子点个数
	}

	// Update is called once per frame
	void Update () {
		int child_count = transform.childCount;
		if (child_mat [0].material.color.Equals (Color.red)) {
			child_mat [0].material.color = Color.black;
		}
	}



}
