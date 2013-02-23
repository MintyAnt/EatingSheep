using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {
	GameObject CamTarget;
	
	float speed = 6;
	
	// Use this for initialization
	void Start () {
		CamTarget = GameObject.FindGameObjectWithTag("CamTarget");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	transform.position = Vector3.Lerp(transform.position, CamTarget.transform.position, Time.deltaTime * speed);
	}
}
