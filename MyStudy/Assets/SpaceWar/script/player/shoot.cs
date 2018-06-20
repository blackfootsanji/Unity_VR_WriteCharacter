using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
public class shoot : MonoBehaviour {

	public GameObject zidan;
	// Use this for initialization
	public GameObject text;
	public AudioClip shootclip;
	public AudioClip shootclip1;
	public GameObject gunl;
	public GameObject gunr;
	public GameObject expolsion;
	private Vector3 vec;

	void Start () {

	}
	int ci = 0;
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown ("Fire1")) {

			vec.x = gunl.transform.position.x;
			vec.y = gunl.transform.position.y;
			vec.z = gunl.transform.position.z + 0.12f;
			Instantiate (expolsion,vec,gunl.transform.rotation);

			vec.x = gunr.transform.position.x;
			vec.y = gunr.transform.position.y;
			vec.z = gunr.transform.position.z + 0.12f;
			Instantiate (expolsion,vec,gunr.transform.rotation);

			GameObject fire = Instantiate (zidan, transform.position,transform.rotation);
			fire.GetComponent<Rigidbody> ().AddForce (transform.forward*2000);
			Destroy (fire, 5f);
			transform.GetComponent<AudioSource> ().PlayOneShot (shootclip);
			transform.GetComponent<AudioSource> ().PlayOneShot (shootclip1);
			ci++;
		}
		text.GetComponent<TextMesh> ().text = "此次作战中,敌方派出战机10架,击退他们,士兵" + "\n当前击落数：" + targetfire.shootnum + "\n当前被击数：" + targetfire.beshootnum + "\n当前耗弹数" + ci;


	}




}
