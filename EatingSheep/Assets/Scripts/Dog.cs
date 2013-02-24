using UnityEngine;
using System.Collections;

public class Dog : MonoBehaviour {
	public int DogCharacterHealth = 250;
	
	public void DogHealth(int AttackDamage){
		DogCharacterHealth = DogCharacterHealth - AttackDamage;
		Debug.Log("Dog Health: " + DogCharacterHealth);
		
		if(DogCharacterHealth == 0){
			GameObject.Destroy(gameObject);
			Debug.Log("Game Over: You Win! :D");
		}
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
