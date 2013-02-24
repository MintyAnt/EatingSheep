using UnityEngine;
using System.Collections;

public class Sheep2 : MonoBehaviour{
	public int SheepCharacterHealth = 100;
	SphereCollider mSphereCollider = null;
	
	
	// Used for when PlayerHealth reaches 0
	public void SheepHealth(){
		if(SheepCharacterHealth == 0){
			GameObject.Destroy (gameObject);
		}
	}
	
	public void SheepHealth(int AttackDamage){
		SheepCharacterHealth = SheepCharacterHealth - AttackDamage;
		Debug.Log("Sheep Health: " + SheepCharacterHealth);
		
		if(SheepCharacterHealth == 0){
			GameObject.Destroy (gameObject);
		}
	}
	
	// Returns true if another character is whithin the collider radius
	public bool characterDistanceIsClose(){
		bool returnValue, check = false;
		
		GameObject playerObject = GameObject.Find("Character");
		GameObject sheepObject = GameObject.Find("Sheep");
		
		if (sheepObject != null){
			Vector3 playerPosition = playerObject.transform.position;
			Vector3 sheepPosition = sheepObject.transform.position;
		
			float distance = Vector3.Distance (playerPosition, sheepPosition);
			float characterColliderRadius = mSphereCollider.radius;
			
			check = (distance < characterColliderRadius);
		}
		
		Debug.Log ("check: " + check);
		if (check)
			returnValue = true;
		else
			returnValue = false;
				
		return returnValue;
	}	
	
	// Amount of damage the player can deal
	public int Damage(Collider collider){
		int AttackDamage = 5;
		
		if (characterDistanceIsClose())
			collider.SendMessage("Health", AttackDamage, SendMessageOptions.DontRequireReceiver);
		
		return AttackDamage;
	}
	
	// Use this for initialization
	public void Start(){
		GameObject playerTriggerObject = GameObject.Find ("PlayerTrigger");
		mSphereCollider = (SphereCollider)playerTriggerObject.gameObject.collider;
	}
	
	// Update is called once per frame
	public void Update(){
		SheepHealth();
	}
}
