using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {
	float targetHight;
	Vector3 a_bundle_of_sticks;
	GameObject Pray;
	// Use this for initialization
	public GameObject Player;
	GameObject terrain;
	void Start () {
		Player = GameObject.FindGameObjectWithTag("Player");
		terrain = GameObject.FindGameObjectWithTag("Terrain");
		Physics.IgnoreCollision(Player.collider,transform.root.collider);
		Physics.IgnoreCollision(terrain.collider, transform.root.collider);
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Player.transform.position;
		if(Pray!=null)
		{
			targetHight = Pray.transform.position.y;
		}
		else
		{
			targetHight = 1;
		}
		a_bundle_of_sticks = new Vector3(Player.transform.position.x, targetHight, Player.transform.position.z);
		Player.transform.position = Vector3.Lerp(Player.transform.position, a_bundle_of_sticks,Time.deltaTime*3.0f);
	}
	void OnTriggerEnter(Collider other) 
	{
		Pray = other.gameObject;
		other.renderer.material.color = Color.cyan;
        Player.renderer.material.color = Color.red;
		Debug.Log("I am coliding with "+other);
    }
	void OnTriggerExit(Collider other)
	{
		Pray = null;
		other.renderer.material.color = Color.white;
		Player.renderer.material.color = Color.blue;
	}
	void OnTriggerStay(Collider other)
	{
		Pray = other.gameObject;
	}
	
}
