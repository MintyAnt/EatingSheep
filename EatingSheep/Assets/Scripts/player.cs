using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
	
	public GameObject Body;
	public GameObject Trigger;
	Vector3 hight;
	// Use this for initialization
	void Start () {
		transform.tag = "Player";
		
		Physics.IgnoreCollision(transform.root.collider,transform.FindChild("CamTarget").transform.collider);
		Physics.IgnoreCollision(transform.root.collider,transform.FindChild("mouth").transform.collider);
		Physics.IgnoreCollision(transform.root.collider,Body.collider);
		Physics.IgnoreCollision(transform.root.collider,Trigger.collider);
		
	}
	
	// Update is called once per frame
	void Update () {
		//hight = transform.position;
		//hight.y = 1.0f;
		//transform.position = hight;
	}
}
