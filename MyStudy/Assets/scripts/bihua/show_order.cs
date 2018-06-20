using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class show_order : MonoBehaviour {
	public int finish = 0;
	// Use this for initialization
	private Renderer[] render_array;
	[SerializeField]private float delay_time = 0.2f;

	void Start () {
		StartCoroutine (show());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator show(){
		if (finish == 0) {

			for (int i = 0; i < transform.childCount; i++) {
				for (int j = 0; j < transform.GetChild (i).childCount; j++) {
					render_array = transform.GetChild (i).GetChild (j).GetComponentsInChildren<Renderer> ();
					for (int n = 0; n < render_array.Length; n++) {
						render_array [n].material.color = Color.blue;
					}
					yield return new WaitForSeconds (delay_time);
				}

				if (i == transform.childCount - 1) {
					finish = 1;
				}
			}

		} 

		if (finish == 1) {
			render_array = transform.GetComponentsInChildren<Renderer> ();
			for (int n = 0; n < render_array.Length; n++) {
				render_array [n].material.color = Color.red;
			}
			finish = 2;
	
		}
	}

}
