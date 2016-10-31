//*Source            :FireballController.cs
//*Author            :Umit M.Karasu - 100938361
//*Last Modified by  :Umit M.Karasu
//*Date last Modified:10/30/2016
//*Description       : fireball will be used for shooting the enemies
//* the fireballs which missed the target will be destroyed when they go out of teh screen.
//*Revision History  :https://github.com/blackWate/COMP3064_Assignment1_2DShooter/commits/master/Assets/Scripts/FireballController.cs


using UnityEngine;
using System.Collections;

public class FireballController : MonoBehaviour {

	//speed variable of the fireball
	[SerializeField]
	private float speed;

	private Rigidbody2D rigidbodyComponent;
	// method called once when the fireball is created
	void  Start (){

		// Get the rigidbody component
		if (rigidbodyComponent == null) rigidbodyComponent = GetComponent<Rigidbody2D>();


	}
	void FixedUpdate(){

		// Make the bullet move right
		rigidbodyComponent.velocity = new Vector2(speed,0);

	}
	// method called when the fireball goes out of the screen
	void  OnBecameInvisible (){
		// Destroy the bullet
		Destroy(gameObject);
	}

}
