using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class finish : MonoBehaviour {
	private float num = 0f;
	// Use this for initialization
	private Color color;
	void Start () {
		over ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void over(){
		//color = transform.GetChild (0).GetComponent<Image> ().color;
		//color.a = 0;
		StartCoroutine (writing());
	}

	IEnumerator writing(){
		/*if (color.a < 1f) {
			color.a += 0.2f * Time.deltaTime;
			transform.GetChild (0).GetComponent<Image> ().color = color;
		}
		yield return 0;*/
		while (num != 1) {
			transform.GetChild (0).GetComponent<Image> ().fillAmount = num;
			num += 0.005f;

		}
		yield return 0;
	}

}
