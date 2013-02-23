using UnityEngine;
using System.Collections;

public class mouth : MonoBehaviour {
	

	Vector3 scale;
	float asdf = 0.99f;

	// Use this for initialization
	GameObject Player;
	void Start () {
		
		transform.renderer.material.color = Color.gray;
		Player = GameObject.FindGameObjectWithTag("Player");
		Physics.IgnoreCollision(Player.transform.collider, transform.root.collider);
		scale = new Vector3(0.3f,0.3f,0.3f);
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
	}
	
	void OnTriggerEnter(Collider other) 
	{	
		if(other.gameObject.tag == "sheep")
		{
			transform.renderer.material.color = Color.red;
		}
    }
	void OnTriggerExit(Collider other)
	{
		transform.renderer.material.color = Color.gray;
	}
	void OnTriggerStay(Collider other)
	{
		if(other.gameObject.tag == "sheep")
		{
			transform.renderer.material.color = Color.red;
			other.gameObject.transform.localScale *= asdf;
			if(other.transform.localScale.x<scale.x)
				Destroy(other.gameObject);
		}
	}
	
}
