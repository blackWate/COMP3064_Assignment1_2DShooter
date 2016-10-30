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


		//check bounds of screen
		checkBounds ();
		_transform.position = _currentPosition;

		if (Input.GetKeyDown("space")) {
			// Create a new fireball at “transform.position”
			// Which is the current position of the crazy_bullet
			//  add the fireball with no rotation
			Instantiate(fireball, transform.position, Quaternion.identity);
		}

	}
	//check the bounds for Crazy_bullet
	private void checkBounds(){
		//get the height and width of the crazy_bullet
		var renderer = gameObject.GetComponent<Renderer>();
		float heigtCrazyBullet = renderer.bounds.size.y;
		float widthCrazyBullet = renderer.bounds.size.x;

		//if position is bigger than camera view-half of the height of CB(otherwise the half of CB will be out of screen)
		//for the top boundry
		if (_currentPosition.y > Camera.main.orthographicSize-heigtCrazyBullet/2) {
			_currentPosition.y = Camera.main.orthographicSize-heigtCrazyBullet/2;
		}

		//for the bottom boundry
		if (_currentPosition.y < -Camera.main.orthographicSize+heigtCrazyBullet/2) {
			_currentPosition.y = -Camera.main.orthographicSize+heigtCrazyBullet/2;
		}

		//for the right  boundry
		if (_currentPosition.x > Camera.main.orthographicSize*2-widthCrazyBullet/2) {
			_currentPosition.x = Camera.main.orthographicSize*2-widthCrazyBullet/2;
		}

		//for the left boundry
		if (_currentPosition.x < -Camera.main.orthographicSize*2+widthCrazyBullet/2) {
			_currentPosition.x = -Camera.main.orthographicSize*2+widthCrazyBullet/2;
		}

	}
}
