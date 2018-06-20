using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
public class bihua : MonoBehaviour {

	/*// Use this for initialization 
	public GameObject obj1;
	public GameObject obj2;
	public GameObject obj3;
	public GameObject obj4;
	public GameObject obj5;
	public GameObject obj6;
	public GameObject obj7;
	public GameObject obj8;
	public GameObject obj9;
	public GameObject obj10;
	public GameObject obj11;
	public GameObject obj12;
	public GameObject obj13;
	public GameObject obj14;
	public GameObject obj15;
	public GameObject obj16;
	public GameObject obj17;
	public GameObject obj18;
	public GameObject obj19;
	public GameObject obj20;
	public GameObject obj21;
	public GameObject obj22;
	public GameObject obj23;
	public GameObject obj24;
	public GameObject obj25;
	public GameObject obj26;
	public GameObject obj27;
	public GameObject obj28;
	public GameObject obj29;
	public GameObject obj30;*/


	private int point_num = 0; 
	private int write_num = 0; 
	private point[] child_point; 

	public GameObject screen;
	public bool finish = false;
	public string name = "";

	//List<GameObject> obj = new List<GameObject>();
	/*private GameObject[] obj = new GameObject[30]{obj1,obj2,obj3,obj4,obj5,obj6,obj7,obj8,obj9,obj10,
		obj11,obj12,obj13,obj14,obj15,obj16,obj17,obj18,obj19,obj20,
		obj21,obj22,obj23,obj24,obj25,obj26,obj27,obj28,obj29,obj30};  */

	void Start () {
		child_point = transform.GetComponentsInChildren <point>();
		/*obj.AddRange ( new GameObject[30]{obj1,obj2,obj3,obj4,obj5,obj6,obj7,obj8,obj9,obj10,
			obj11,obj12,obj13,obj14,obj15,obj16,obj17,obj18,obj19,obj20,
			obj21,obj22,obj23,obj24,obj25,obj26,obj27,obj28,obj29,obj30});
		while(obj[point_num]!=null){
			point_num++;
			if(point_num == 30){
				break;
			}
		}*/

	}
	
	// Update is called once per frame
	void Update () {

		for(int i = 0 ; i<child_point.Length ; i++){
			if (child_point [i].get) {				
				write_num++;
				if ((write_num == child_point.Length)) {
					finish = true;
					write_num = 0;
					break;
				}
			}
			else {
				write_num = 0;
				break;
			}

		}
		/*for(int i = 0;i<point_num;i++){

			if(obj[i].GetComponent<Renderer>().material.color.Equals(Color.black)){
				write_point_num++;
				if(write_point_num == point_num){
					finish = true;
					screen.GetComponent<TextMesh> ().text = "单位数：\n" + point_num +"\n"+ name +"   已完成";
					break;
				}
			}

			if (obj [i].GetComponent<Renderer> ().material.color.Equals (Color.red)) {
				write_point_num = 0;
				break;
			}

		}*/
	


	}

}
