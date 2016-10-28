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
