using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour{
	public int PlayerHealth = 100;
	SphereCollider mSphereCollider = null;
	
	
	// Used for when PlayerHealth reaches 0
	public void Health(){
		if(PlayerHealth == 0){
			GameObject.Destroy (gameObject);
			Debug.Log("Game Over: You Lose. >:)");
		}
	}
	
	public void Health(int AttackDamage){
		PlayerHealth = PlayerHealth - AttackDamage;
		Debug.Log("Player Health: " + PlayerHealth);
		
		if(PlayerHealth == 0){
			GameObject.Destroy (gameObject);
			Debug.Log("Game Over: You Lose. >:)");
		}
	}
	
	// Returns true if another character is whithin the collider radius
	public bool characterDistanceIsClose(){
		bool returnValue, check = false;
		
		GameObject playerObject = GameObject.Find("Character");
		GameObject sheepObject = GameObject.Find("Sheep");
		GameObject dogObject = GameObject.Find("Dog");
		
		if (sheepObject != null){
			Vector3 playerPosition = playerObject.transform.position;
			Vector3 sheepPosition = sheepObject.transform.position;
		
			float distance = Vector3.Distance (playerPosition, sheepPosition);
			float characterColliderRadius = mSphereCollider.radius;
			
			check = (distance < characterColliderRadius);
		}
		
		if (dogObject != null){
			Vector3 playerPosition = playerObject.transform.position;
			Vector3 dogPosition = dogObject.transform.position;
		
			float distance = Vector3.Distance (playerPosition, dogPosition);
			float characterColliderRadius = mSphereCollider.radius;
			
			check = (distance < characterColliderRadius);
		}
		
		if (check)
			returnValue = true;
		else
			returnValue = false;
				
		return returnValue;
	}	
	
	// Amount of damage the player can deal
	public int Damage(Collider collider){
		int AttackDamage = 10;
		
		if (characterDistanceIsClose()){
       		if (Input.GetKeyDown("e")){
				if (collider.name == "Dog")
					collider.SendMessage("DogHealth", AttackDamage, SendMessageOptions.DontRequireReceiver);
				else
					collider.SendMessage("SheepHealth", AttackDamage, SendMessageOptions.DontRequireReceiver);
			}
		}
		
		return AttackDamage;
	}
	
	// Use this for initialization
	public void Start(){
		mSphereCollider = (SphereCollider)transform.FindChild("PlayerTrigger").gameObject.collider;
	}
	
	// Update is called once per frame
	public void Update(){
		Health();
	}
}
