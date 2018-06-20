using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetfire : MonoBehaviour {

	public GameObject fire0;
	public GameObject fire1;
	public GameObject fire2;
	public GameObject fire3;
	public GameObject fire4;
	public GameObject palyer;
	public GameObject shaker;
	public AudioClip winclip;
	public AudioClip beshootclip;
	public AudioClip getclip;
	public static int shootnum = 0;
	public static int beshootnum = 0;
	public GameObject text;
	public GameObject leveltext;
	public static int level = 1;



	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		
		if ((shooter.col || beshootonce.beshoot)&& targetfire.shootnum < 11) {
			if(shooter.col){
				transform.GetComponent<AudioSource> ().PlayOneShot (getclip);
			}
			if (beshootonce.beshoot) {
				shaker.SendMessage("startshake");
				transform.GetComponent<AudioSource> ().PlayOneShot (beshootclip);
			}

			init();
			int num = (int)Random.Range (0f, 5f);
			GameObject obj = transform.Find("targetfire_" + num).gameObject;//here
			obj.GetComponent<target> ().go = true;
			beshootonce.beshoot = false;
			shooter.col = false;
		}

		if(targetfire.shootnum >= 10){
			targetfire.shootnum = 0;
			shooter.col = false;
			beshootonce.beshoot = false;
			init ();
			fire0.GetComponent<target> ().go = true;
			level++;
		}

		if (level > 5) {
			init ();
			transform.Translate (0, 0, 5 * Time.deltaTime);
			Destroy (this.gameObject, 8f);
			transform.GetComponent<AudioSource> ().PlayOneShot (winclip);
			palyer.GetComponent<shoot> ().enabled = false;
			leveltext.GetComponent<TextMesh> ().text = "";
			text.GetComponent<TextMesh> ().text = "";
			text.GetComponent<TextMesh> ().text = "成功击退所有敌人,守住了战船! \n士兵,干的漂亮!";
		} else {
			leveltext.GetComponent<TextMesh> ().text = "第" + level + "波敌人\n每波均为10架";
		}




	}

	void init(){
		fire0.GetComponent<target> ().go = false;
		fire1.GetComponent<target> ().go = false;
		fire2.GetComponent<target> ().go = false;
		fire3.GetComponent<target> ().go = false;
		fire4.GetComponent<target> ().go = false;
	}



}
