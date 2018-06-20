using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class shake : MonoBehaviour {
	private float count;
	// Use this for initialization
	public float shake_range = 0 ;
	public float limit_time = 0;
	private Vector3 originpos;
	private AsyncOperation async;
	void Start () {
		originpos = transform.position;
		if (shake_range == 0) {
			shake_range = 0.3f;
		}
		if (limit_time == 0) {
			limit_time = 0.6f;
		}

	}
	void startshake(){

		StartCoroutine (yao());
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Cancel")) {
			StartCoroutine (loading());
			initstatic ();
		}
	}

	IEnumerator loading(){
		async = SceneManager.LoadSceneAsync (0);
		yield return async;
	}

	IEnumerator yao(){
		count = 0;
		Vector3 vec = Vector3.zero;
		while(count<limit_time){
			count += Time.smoothDeltaTime;
			vec.x = originpos.x + Random.Range (-shake_range, shake_range);
			vec.y = originpos.y +  Random.Range (-shake_range, shake_range);
			vec.z = originpos.z;
			transform.position = vec;
			yield return 0;
		}
		transform.position = originpos;
		StopCoroutine (yao());
	}
	void initstatic(){
		targetfire.shootnum = 0;
		targetfire.beshootnum = 0;
		shooter.col = false;
		beshootonce.beshoot = false;
		targetfire.level = 1;
	}
}
