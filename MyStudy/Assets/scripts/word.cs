using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class word : MonoBehaviour {

	private int child_num = 0;
	// Use this for initialization
	private List<bihua> check;//2
	public bool finish_all = false;
	public float finish_time = 0f;
	public GameObject player;
	public GameObject remind;
	public string thisword;
	public GameObject finish_canvas;
	//List<bihua> check = new List<bihua>();//1
	public GameObject warning;
	public GameObject[] destroy;

	void Start () {
		child_num = transform.childCount;
		check = new List<bihua>(transform.GetComponentsInChildren<bihua> ());//2
		//check.AddRange (transform.GetComponentsInChildren<bihua> ());//1
	}

	// Update is called once per frame
	void Update () {
		
		for (int i = 0; i < child_num; i++) {
			if (!check [i].finish) {
				finish_all = false;
				break;
			}
			if (i == child_num - 1) {
				finish_all = true;
			}
		}

		if (finish_all) {
			finish_time = player.GetComponent<write> ().usetime;
			player.GetComponent<write> ().enabled = false;
			remind.GetComponent<TextMesh> ().text = "完成字：\n" + thisword + "\n" + "当前用时：\n" + finish_time + " s";
			finish_canvas.GetComponent<finish> ().enabled = true;
			warning.transform.GetComponent<TextMesh> ().text = "";
			for(int i = 0 ; i < destroy.Length ; i++){
				Destroy (destroy[i].gameObject);
			}
		}

	}
}
