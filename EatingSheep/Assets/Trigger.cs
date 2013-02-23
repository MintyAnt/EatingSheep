using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {

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
	}
	void OnTriggerEnter(Collider other) 
	{
        	 Player.renderer.material.color = Color.red;
			Debug.Log("I am coliding with "+other);
    }
	void OnTriggerExit(Collider other)
	{
		Player.renderer.material.color = Color.blue;
	}
}
