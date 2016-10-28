using UnityEngine;
using System.Collections;

public class CrazyBulletController : MonoBehaviour {

	//speed variable for crazy_bullet
	[SerializeField]
	private float speed;

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


	}
}
