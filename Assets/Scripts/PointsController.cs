//*Source            :PointsController.cs
//*Author            :Umit M.Karasu - 100938361
//*Last Modified by  :Umit M.Karasu
//*Date last Modified:Oct 30, 2016
//*Description       :PointsController is connected to a empty game object and this object is gives it is
//* value to the text gameobject  to keep the point score update
//*Revision History  :https://github.com/blackWate/COMP3064_Assignment1_2DShooter/commits/master/Assets/Scripts/PointsController.cs

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PointsController : MonoBehaviour {
	//connects to the text objects
	[SerializeField]
	Text points = null;


	// Use this for initialization
	void Start () {
		//create a player instance with pointscontroller which is a member of player class for this
		Player.Instance.poc = this;
	}


	//method to update the point values on the scene
	public void UpdatePoints(){

		points.text =  Player.Instance.Points.ToString();

	}

}
