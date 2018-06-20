using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class directionTracker : MonoBehaviour {

	public GameObject goalText;
	public GameObject N,S,W,E,NW,NE,SW,SE,C;
	public bool Nget,Sget,Wget,Eget,NWget,NEget,SWget,SEget,Cget;
	private GameObject[] myObj;
	private bool[] myBool;
	private RaycastHit hit;
	private Vector3 fwd;
	private int num = 0;
	private int goal = 0;
	// Use this for initialization
	private AsyncOperation async;
	public bool ready;

	void Start () {
		init ();

	}

	// Update is called once per frame
	void Update () {
		fwd = transform.TransformDirection (Vector3.forward);

		if (Input.GetButtonDown ("Cancel")) {
			StartCoroutine (loading());
			init();
		}

		if(ready){
			num = (int)Random.Range (0f,9f);
			change (myObj[num]);
			ready = false;
		}
		if(Physics.Raycast(transform.position,fwd,out hit)){
			string name = hit.collider.name;
			Debug.Log (name);
			if (name.Equals (myObj [num].name)) {
				init ();
				goal++;
				myBool [num] = true;
				goalText.GetComponent<Text>().text = "当前得分："+goal;
				ready = true;
			}
		}
	}

	void init(){
		ready = true;
		Nget = false;
		Sget = false;
		Wget = false;
		Eget = false;
		Cget = false;
		NWget = false;
		NEget = false;
		SWget = false;
		SEget = false;
		recover (N);
		recover (S);
		recover (W);
		recover (E);
		recover (C);
		recover (NW);
		recover (NE);
		recover (SW);
		recover (SE);
		myBool = new bool[9]{Nget,Sget,Wget,Eget,NWget,NEget,SWget,SEget,Cget};
		myObj = new GameObject[9]{N,S,W,E,NW,NE,SW,SE,C};
	}

/*	void choose(GameObject obj,bool temp){
		if (temp) {
			init ();
			change (obj);
		}
	}
*/
	void change(GameObject obj){
		obj.GetComponent<Renderer> ().material.color = Color.red;
	}

	void recover(GameObject obj){
		obj.GetComponent<Renderer> ().material.color = Color.white;
	}
		
	IEnumerator loading(){
		async = SceneManager.LoadSceneAsync (0);
		yield return async;
	}

}
