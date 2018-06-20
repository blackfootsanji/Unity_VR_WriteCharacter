using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class write : MonoBehaviour {

	private Vector3 fwd; 
	public RaycastHit hit ;
	// Use this for initialization
	private bool isgaze = false;
	private bool jia = false;
	private int child_num = 0;
	//private string[] word = new string[5] {"白","日","依","山","尽"};
	public string current_bihua;
	private int wordnum = 0;
	private int gazetime = 0;
	private Vector3 pos1 = Vector3.zero;
	//private float[] usetime = new float[5];
	private float starttime = 0f;
	public float usetime = 0f;
	private float usetime1 = 0f;
	public GameObject remind;
	public int LimitTime = 60;
	public GameObject screen;
	public GameObject warning;
	public show_order[] order_list;
	public int order_num = 0;

	private GameObject obj;
	public bool temp;//stand for the current bihua is whether right or not
	void Start () {
		obj = GameObject.Find ("bihua");
		order_list = obj.transform.GetComponentsInChildren<show_order> ();

	}
	
	// Update is called once per frame
	void Update () {
		fwd = transform.forward;

		if (Physics.Raycast (transform.position, fwd, out hit)) {

			if (hit.collider.transform.parent.parent.parent.Equals (obj.transform.GetChild (order_num))) {
				temp = true;
			} else {
				temp = false;
			}
			//finish？
			if (hit.collider.transform.parent.name.Equals ("fill")&&(order_list[order_num].finish==2)) {
				current_bihua = "";
				current_bihua = hit.collider.transform.parent.parent.parent.transform.GetComponent<bihua> ().name;
				if (hit.collider.transform.parent.parent.parent.transform.GetComponent<bihua> ().finish) {
					screen.GetComponent<TextMesh> ().text = "当前笔画： \n" + current_bihua + "\n已完成"; 
					if (temp&&(order_num<obj.transform.childCount - 1)) {
						order_num++;
						order_list [order_num].enabled = true;
						temp = false;
					}
				} 
				else {	
					screen.GetComponent<TextMesh> ().text = "当前笔画： \n" + current_bihua;
				}
				//warning.transform.GetComponent<TextMesh> ().text = "按照蓝色提示书写,请不要四处张望";
			}
			if(!hit.collider.transform.parent.name.Equals ("fill")||!temp){
				current_bihua = "";
				warning.transform.GetComponent<TextMesh> ().text = "按照红色轨迹书写,请不要四处张望";
				screen.GetComponent<TextMesh> ().text = "当前笔画： \n";
			}


			if (pos1 == hit.collider.transform.position) {
				gazetime++;
			} else {
				gazetime = 0;
				pos1 = hit.collider.transform.position;
			}

			if (gazetime == LimitTime) {
				isgaze = !isgaze;
				gazetime = 0;
			}

			/*if (isgaze) {
				hit.collider.transform.GetComponent<Renderer> ().material.color = Color.black;
				current = hit.collider.transform.parent.parent.name;
				wordnum = current [0] - '0';
				usetime [wordnum] = Time.fixedTime - starttime;
				remind.GetComponent<TextMesh> ().text = word [wordnum] + "\n   用时:" + usetime [wordnum] + "s";
			}*/
			if (!isgaze) {
				starttime = Time.fixedTime;
				usetime1 = usetime;
			}
			//write
			if (isgaze) {
				Renderer[] child_render;
				//hit.collider.transform.GetComponent<Renderer> ().material.color = Color.black;
				if (hit.collider.transform.parent.name.Equals ("fill")&&(hit.collider.transform.parent.parent.parent.GetComponent<show_order>().finish==2)&&temp) {
					hit.collider.transform.parent.GetComponent<point> ().get = true;
					child_render = hit.collider.transform.parent.GetComponentsInChildren<Renderer> ();
					for (int i = 0; i < child_render.Length; i++) {
						child_render [i].material.color = Color.black;
					}
					warning.transform.GetComponent<TextMesh> ().text = "";
				}

			}

			usetime = Time.fixedTime - starttime + usetime1;
			remind.GetComponent<TextMesh> ().text = "已用时间:\n" + (int)usetime + "s";

		} else {
			warning.transform.GetComponent<TextMesh> ().text = "按照红色轨迹书写,请不要四处张望";
		}



	} 

}
			/*if (Physics.Raycast( transform.position, fwd, out hit)) {
				if (!gazeStart&&gazeEnd) {
					string a = hit.collider.transform.name;
					StartCoroutine (Wait(2f));
					string b = hit.collider.transform.name;
					if(a.Equals(b)){
						gazeStart = true;
						gazeEnd = false;
					}
				}

				if (gazeStart&&!gazeEnd) {
					string a = hit.collider.transform.name;
					StartCoroutine (Wait(2f));
					string b = hit.collider.transform.name;
					if(a.Equals(b)){
						gazeEnd = true;
						gazeStart = false;
					}
				}*/
			


	

