using UnityEngine;
using System.Collections;

public class mouth : MonoBehaviour {
	
	float mouth_size = 0.99f;
	GameObject pray;
	Vector3 scale;

	// Use this for initialization
	GameObject Player;
	void Start () {
		transform.renderer.material.color = Color.gray;
		Player = GameObject.FindGameObjectWithTag("Player");
		Physics.IgnoreCollision(Player.transform.collider, transform.root.collider);
		
	}
	
	// Update is called once per frame
	void Update () {
		scale =new Vector3(0.3f,0.3f,0.3f);
	}
	
	void OnTriggerEnter(Collider other) 
	{	
		if(other.gameObject.tag == "sheep")
		{
			pray = other.gameObject;
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
			Debug.Log("Drinking "+other +"'s Blood");
			transform.renderer.material.color = Color.red;
			other.gameObject.transform.localScale *= mouth_size;
			if(other.transform.localScale.x<scale.x)
				Destroy(other.gameObject);
		}
	}
	
}
