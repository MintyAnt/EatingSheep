using UnityEngine;
using System.Collections;

public class CharacterCollider : MonoBehaviour{
	
	void OnTriggerStay(Collider collider){
		GameObject sheepObject = GameObject.Find ("Sheep");
		gameObject.SendMessageUpwards("Damage", collider);
		sheepObject.SendMessage ("SheepDamage", collider, SendMessageOptions.DontRequireReceiver);
	}
	
	// Use this for initialization
	void Start (){
		GameObject playerObject = GameObject.Find("Character");
		Physics.IgnoreCollision(playerObject.collider, collider);
	}
	
	// Update is called once per frame
	void Update (){
	}
}
