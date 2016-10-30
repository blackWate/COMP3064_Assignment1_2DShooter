using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	//speed for connected enemies,obstacles or coin,
	[SerializeField]
	private float speed;

	//create rigid body component for enemies
	private Rigidbody2D rigidbodyComponent;

	//audioclip which plays when objects collieded
	public AudioClip hitsound;

	//source for audioclip
	AudioSource audioEnemy;

	//Gameobjects for "live" objects on the scene
	private GameObject[] lives;

	//points for connected enemies,obstacles or coin,
	[SerializeField]
	private int  point;


	// Use this for initialization
	void Start () {
		// Get the rigidbody component
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

			// Destroy itself (the enemy) and the fireball but obstacles and coins
			if (enemyName == "coin(Clone)" || enemyName == "spike(Clone)" || enemyName == "spike_monster_A(Clone)" || enemyName == "spike_monster_B(Clone)") {
				//do nothing

			} else //in case of collison with the birds
			{

				//play hit sound which is connected to the bird
				audioEnemy.PlayOneShot (hitsound);
				//delay object destroy for a while to complete of the playing sound
				//Destroy fireball
				Object.Destroy (obj.gameObject,0.15f);
				//destroy enemy(birds)
				Object.Destroy (gameObject,0.15f);
				//add points which is given to the bird
				Player.Instance.Points+=point;

			}

			}

		// If the enemy,obstcale or coin collided with the carzy_bullet
		if (name == "crazy_bullet") {
			// If the crazy_bullet collided with the obstacles
			if (enemyName == "spike(Clone)"||enemyName == "spike_monster_A(Clone)"||enemyName == "spike_monster_B(Clone)") {
				//play hit sound for spikes
				audioEnemy.PlayOneShot (hitsound);
				//go to method lifeCounter  to check the number of lives that carzy_bullet has
				lifeCounter (obj.gameObject);


			}
			else
			{
				//if carzy_bullet hits coin
				if (enemyName == "coin(Clone)") {
					//play related hit sound
					audioEnemy.PlayOneShot (hitsound);
					Object.Destroy (gameObject,0.2f);
					//add the points given to the coins
					Player.Instance.Points+=point;
				}
				else {
					//if crazy_bullet collides with birds
					//play hit sound for birds
					audioEnemy.PlayOneShot (hitsound);
					//delay object destroy for a while to complete of the playing sound
					Object.Destroy (gameObject,0.15f);
					//go to method lifeCounter  to check the number of lives that carzy_bullet has
					lifeCounter (obj.gameObject);


				}

			}

		}


	}
	// method called when the object goes out of the screen
	void  OnBecameInvisible (){
		// Destroy the enemy
		Destroy(gameObject);
	}
	//count the number of lives, if it zero destroy the gameobject,reset the points, got to the Game end scene
	private void lifeCounter(GameObject obj){
		//check the scene to get the array of gameobjects with "life" tag name
		lives=GameObject.FindGameObjectsWithTag("life");
		//get the array length
		var numLives = lives.Length;
		//if the number of gameobjects is greater than zero destroy the last object in the array
		if (numLives > 0) {
			Destroy (lives[numLives-1]);
		}
		//if array length is one then destroy crazy_bullet
		if (lives.Length == 1) {
			Destroy (obj.gameObject);
			//reset points to zero
			Player.Instance.Points = 0;

			//goto Game_end scene
			SceneController scene=new SceneController();
			scene.loadScene ("Game_End");

		}
	}

}
