using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class enterSW : MonoBehaviour {

	private RaycastHit hit;
	public GameObject introduce;
	public GameObject loadingimage;
	public GameObject cursor;
	// Use this for initialization
	private Vector3 originpos = Vector3.zero;
	private string name;
	private GameObject obj = null;
	private AsyncOperation async;
	private float loadingnum = 0f;



	void Start () {
		loadingimage.GetComponent<Image> ().enabled = false;
		cursor.GetComponent<RawImage> ().enabled = true;
	}
	
	// Update is called once per frame
	void Update () {


		if (Physics.Raycast (transform.position, transform.forward, out hit)) {
			name = hit.collider.transform.name;
			obj = hit.collider.transform.gameObject;
			Vector3 vec = Vector3.zero;

			if (originpos.Equals (Vector3.zero)) {
				originpos = hit.collider.transform.position;
				vec.x = originpos.x;
				vec.y = originpos.y;
				vec.z = originpos.z + 3f;
				hit.collider.transform.position = Vector3.SmoothDamp(originpos, vec,ref vec, 2f);
			}

			if (name.Equals ("mirror")) {
				introduce.GetComponent<Text> ().text = "欢迎来到镜像王国,在这里\n模型头部镜像反射头部运动";	
				if (Input.GetButtonDown ("Fire1")) {
					StartCoroutine(loading(1));
				}
			}

			if (name.Equals ("war")) {
				introduce.GetComponent<Text> ().text = "星球大战:原力与你同在\n拍击触摸板发射炮弹";	
				if (Input.GetButtonDown ("Fire1")) {
					StartCoroutine(loading(2));
				}
			}

			if (name.Equals ("tracker")) {
				introduce.GetComponent<Text> ().text = "快用光标追逐红色小球,别让它跑了";	
				if (Input.GetButtonDown ("Fire1")) {
					StartCoroutine(loading(3));
				}
			}
			if (Input.GetButtonDown ("Cancel")) {
				StartCoroutine(loading(0));
			}

		
		} 

		else {
			if (obj != null) {
				obj.transform.position = originpos;
			}
			obj = null;
			name = "";
			originpos = Vector3.zero;
			introduce.GetComponent<Text> ().text = "";
		}

	}

	IEnumerator loading(int i){
		async = SceneManager.LoadSceneAsync(i);
		cursor.GetComponent<RawImage> ().enabled = false;
		loadingimage.GetComponent<Image> ().enabled = true;
		while(!async.isDone){
			loadingimage.GetComponent<Image> ().fillAmount = loadingnum;
			loadingnum += 0.007f;
			yield return new WaitForEndOfFrame();
		}
	}




}
