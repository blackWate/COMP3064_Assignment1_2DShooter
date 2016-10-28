using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour {

	//variable to store speed of the background
	[SerializeField]
	private float speed;

	//create transform and currentpostion variables for movement and position
	//of the background sprites
	private Transform _transform;
	private Vector2 _currentPosition;



	//variable to get size of the background sprites
	SpriteRenderer render;


	//tets
	void Start () {

		_transform = gameObject.GetComponent<Transform> ();
		_currentPosition = _transform.position;
		// Get the render component for size of the gameobject
		render = gameObject.GetComponent<SpriteRenderer>();
		//get camera height length(the width of the camera is height*2)
		float camera = Camera.main.orthographicSize;

	}


	void Update () {

		_currentPosition = _transform.position;
		_currentPosition -= new Vector2 (speed,0);
		_transform.position = _currentPosition;

	}

	//when background became invisible
	void OnBecameInvisible()
	{
		//get the background x coordinate
		float width = render.bounds.size.x;
		//calculate current position
		var backgrndPosition = gameObject.transform.position;
		//calculate new position;
		float X = backgrndPosition.x + width*2;

		//move the background to new position when invisible
		gameObject.transform.position =new Vector2(X,0);
	}
}
