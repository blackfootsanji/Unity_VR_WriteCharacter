using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
public class energy_line : MonoBehaviour {
	private bool improve_trend = false;
	private bool high_ache = false;
	private bool between_ache = false;
	private bool low_ache = false;
	private bool ready = false;
	private float max_fill_amount = 0f;
	private Renderer[] child_render;
	[SerializeField] private AudioClip high_warn_clip;
	[SerializeField] private AudioClip between_warn_clip;
	[SerializeField] private AudioClip low_warn_clip;

	private string last_name = null;//direction
	private string current_name;//direction
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if ((transform.GetComponent<Image> ().fillAmount >= 0)&&transform.parent.parent.GetComponent<write> ().order_list [transform.parent.parent.GetComponent<write> ().order_num].finish == 2) {
			if (Input.GetButton ("Fire1")) {
				transform.GetComponent<Image> ().fillAmount += 0.02f;
				improve_trend = true;
			} else {
				transform.GetComponent<Image> ().fillAmount -= 0.05f;
				improve_trend = false;
			}
		} else {
			transform.GetComponent<Image> ().fillAmount = 0f;
		}

		if (transform.parent.parent.GetComponent<write> ().hit.collider.transform.parent.name.Equals("fill")) {//bihua
			//current_name = transform.parent.parent.GetComponent<write> ().hit.transform.parent.parent.name;//direction


			//if (!current_name.Equals (last_name)) {
				if (improve_trend) {
					max_fill_amount = transform.GetComponent<Image> ().fillAmount;
				}
				else {
					if((max_fill_amount <= 0.3f)&&(max_fill_amount > 0f)){
						low_ache = true;
					}
					if((max_fill_amount <= 0.8f)&&(max_fill_amount > 0.3f)){
						between_ache = true;
					}
					if((max_fill_amount <= 1f)&&(max_fill_amount > 0.8f)){
						high_ache = true;
					}
				}
			//}


			if (high_ache) {
				
				child_render = transform.parent.parent.GetComponent<write> ().order_list [transform.parent.parent.GetComponent<write> ().order_num].transform.GetComponentsInChildren<Renderer> ();
				for(int i=0;i<child_render.Length;i++){
					child_render [i].material.color = Color.gray;
				}
				transform.parent.parent.GetComponent<write> ().order_list[transform.parent.parent.GetComponent<write> ().order_num].transform.GetComponent<bihua> ().finish = true;
				if (!transform.parent.parent.GetComponent<write> ().temp) {
					transform.parent.parent.GetComponent<write> ().order_num++;
					transform.parent.parent.GetComponent<write> ().order_list [transform.parent.parent.GetComponent<write> ().order_num].enabled = true;
				}//can not write a little
				if(transform.parent.parent.GetComponent<write> ().temp){
					
				}//can write a little	

				transform.GetComponent<AudioSource> ().PlayOneShot (high_warn_clip);
				high_ache = false;
				//last_name = current_name;
				max_fill_amount = 0f;
			}
			if (between_ache) {
				transform.GetComponent<AudioSource> ().PlayOneShot (between_warn_clip);
				between_ache = false;
				//last_name = current_name;
				max_fill_amount = 0f;
			}
			if (low_ache) {
				transform.GetComponent<AudioSource> ().PlayOneShot (low_warn_clip);
				low_ache = false;
				//last_name = current_name;
				max_fill_amount = 0f;
			}

		
		}

	}
}
