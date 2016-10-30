using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	//speed for connected enemies,obstacles or coin,
	[SerializeField]
	private float speed;

	//create rigid body component for enemies  done
	private Rigidbody2D rigidbodyComponent;

	//audioclip which plays when objects collieded
	public AudioClip hitsound;

	//source for audioclip            1
	AudioSource audioEnemy;


	// Use this for initialization
	void Start () {
		// Get the rigidbody component  done
		if (rigidbodyComponent == null) rigidbodyComponent = GetComponent<Rigidbody2D>();

		// Add a horizantol speed to the enemy
		rigidbodyComponent.velocity = new Vector2(-speed,0);


	}

	// method called when the enemies,obstacles or coins(with crazy_bullet) collides with the fireball and the crazy_bullet
	void  OnTriggerEnter2D (Collider2D obj){
		// Get the name of the object that collided with the enemy
		//get the name of the fireball or crazy_bullet
		string name= obj.gameObject.name;
		//get the name/s of enemies,obstacles or coin
		string enemyName = gameObject.name;

		//get audio source component of the connected objects(enemy,obstacle or coin)
		audioEnemy = gameObject.GetComponent<AudioSource> ();

		// If the enemy collided with the fireball
		if (name == "fireball(Clone)") {

			//play hit sound which is connected to the bird  1
			audioEnemy.PlayOneShot (hitsound);
			//delay object destroy for a while to complete of the playing sound 1
			//Destroy fireball done
			Object.Destroy (obj.gameObject,0.15f);
			//destroy enemy(birds) done
			Object.Destroy (gameObject,0.15f);

			}

		// If the enemy,obstcale or coin collided with the carzy_bullet
		if (name == "crazy_bullet") {

			//if crazy_bullet collides with birds
			//play hit sound for birds
			audioEnemy.PlayOneShot (hitsound);
			//delay object destroy for a while to complete of the playing sound
			Object.Destroy (gameObject,0.15f);

		}


	}
}
