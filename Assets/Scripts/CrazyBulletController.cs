//*Source            :CrazyBulletController.cs
//*Author            :Umit M.Karasu - 100938361
//*Last Modified by  :Umit M.Karasu
//*Date last Modified:Oct 30, 2016
//*Description       :CrazyBulletController controls the main chacarter of the game, which is crazy_bullet, it moves
//* character up and down, left and right, it keeps the character in the bounds of the screen, it gets the speed variable
//*to move to the desired direction,and fireball gameobject to shoot the enemies
//*Revision History  :https://github.com/blackWate/COMP3064_Assignment1_2DShooter/commits/master/Assets/Scripts/CrazyBulletController.cs

using UnityEngine;
using System.Collections;

public class CrazyBulletController : MonoBehaviour {

	//speed variable for crazy_bullet
	[SerializeField]
	private float speed;

	//a fireball gameobject to connect to the crazy_bullet
	public GameObject fireball;

	private Transform _transform;
	private Vector2 _currentPosition;

	// Use this for initialization
	void Start () {
		_transform = gameObject.GetComponent<Transform> ();
		_currentPosition = _transform.position;
	}

	// Update is called once per frame
	void Update () {
		_currentPosition = _transform.position;

		//move up
		if (Input.GetKey ("up"))
			_currentPosition += new Vector2 (0,speed);

		//move down
		if (Input.GetKey ("down"))
			_currentPosition -= new Vector2 (0,speed);

		//move left
		if (Input.GetKey ("left"))
			_currentPosition -= new Vector2 (speed,0);

		//move right
		if (Input.GetKey ("right"))
			_currentPosition += new Vector2 (speed,0);


		//check bounds of screen
		checkBounds ();
		_transform.position = _currentPosition;

		if (Input.GetKeyDown("space")) {
			// Create a new fireball at “transform.position”
			// Which is the current position of the crazy_bullet
			Instantiate(fireball, transform.position, Quaternion.identity);
		}

	}
	//check the bounds for Crazy_bullet
	private void checkBounds(){
		//get the height of the crazy_bullet
		var renderer = gameObject.GetComponent<SpriteRenderer>();
		float heightCrazyBullet = renderer.bounds.size.y;



		//if position is bigger than camera view-half of the height of CB(otherwise the half of CB will be out of screen)
		//for the top boundry
		if (_currentPosition.y > Camera.main.orthographicSize-heightCrazyBullet/2.0f) {
			_currentPosition.y = Camera.main.orthographicSize-heightCrazyBullet/2.0f;
		}

		//for the bottom boundry (grass height added -->1.4f)
		if (_currentPosition.y < -Camera.main.orthographicSize+heightCrazyBullet/2.0f+1.4f) {
			_currentPosition.y = -Camera.main.orthographicSize+heightCrazyBullet/2.0f+1.4f;
		}

		//for the right  boundry
		if (_currentPosition.x > 12.9f) {
			_currentPosition.x = 12.9f;
		}

		//for the left boundry
		if (_currentPosition.x < -12.9f) {
			_currentPosition.x = -12.9f;
		}

	}
}
