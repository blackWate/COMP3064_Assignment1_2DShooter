//*Source            :RandomEnemyController.cs
//*Author            :Umit M.Karasu - 100938361
//*Last Modified by  :Umit M.Karasu
//*Date last Modified:Oct 30, 2016
//*Description       : it randomly creates enemies or obstacles from list, it is connected  a gameobject which is at the right
//* outside of the screen, we have three gameobjects, one of them for enemies,one of them obstacles and the other one for coins
//* all these gameobjects create the clones of the connected prefabs.
//*Revision History  :https://github.com/blackWate/COMP3064_Assignment1_2DShooter/commits/master/Assets/Scripts/RandomEnemyController.cs
using UnityEngine;
using System.Collections;

public class RandomEnemyController : MonoBehaviour {
	// array Variable to store the enemies or obstacles
	public GameObject[] enemy;
	private Transform _transform;
	private Vector2 spawnPoint;
	private SpriteRenderer rend;
	// Variable to know how fast we should create new enemies or obstc
	public float spawnTime ;

	void  Start (){
		// Call the 'addEnemy' function in 0 second
		// Then every 'spawnTime' seconds
		InvokeRepeating("addEnemy", 0, spawnTime);
	}

	// method to spawn an enemy
	void  addEnemy (){
		// Get the renderer component of the spawn object
		if(rend==null)
			rend =gameObject.GetComponent<SpriteRenderer>();

		// Position of the left edge of the spawn object
		// position of the center-half the width
		float y1= transform.position.y - rend.bounds.size.y/2;

		// Same for the right edge
		float y2= transform.position.y + rend.bounds.size.y/2;

		// Randomly pick a point within the spawn object
		spawnPoint= new Vector2(transform.position.x,Random.Range(y1, y2));

		//select random enemy from enemy  or obstacle list
		int index = Random.Range (0, enemy.Length);

		// Create an enemy at the 'spawnPoint' position
		Instantiate(enemy[index], spawnPoint, Quaternion.identity);
	}
}

