using UnityEngine;
using System.Collections;

public class sheep : MonoBehaviour {

	// Use this for initialization
	void Start () {
	transform.tag = "sheep";
	animation.Play("eating");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
