using UnityEngine;
using System.Collections;

public class EnemyFireController : MonoBehaviour {

	//a fireball gameobject to connect to the crazy_bullet
	[SerializeField]
	private GameObject bullet;
	//min time in secs between bullets
	[SerializeField]
	public float fireRateMin;
	//max time in secs between bullets
	[SerializeField]
	public float fireRateMax;
	//base fire time in secs
	[SerializeField]
	private float baseFireTime;

	private Transform _transform;
	private Vector2 _currentPosition;

	// Use this for initialization
	void Start () {
		_transform = gameObject.GetComponent<Transform> ();
		_currentPosition = _transform.position;
	}

	// Update is called once per tick
	void FixedUpdate () {
		_currentPosition = _transform.position;

		//creates random time and add to the base fire time if actual time is greater than  the base fire time
		if (Time.time > baseFireTime) {
			baseFireTime = Time.time + Random.Range (fireRateMin, fireRateMax);
			//creates a bullet at the ppsition of the enemy
			Instantiate(bullet, transform.position, Quaternion.identity);
		}

	}




}
