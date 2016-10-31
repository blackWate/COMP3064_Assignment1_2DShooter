//*Source            :SceneController.cs
//*Author            :Umit M.Karasu - 100938361
//*Last Modified by  :Umit M.Karasu
//*Date last Modified:Oct 30, 2016
//*Description       :Scene Manager, it manages the scene navigation and , app quit
//*Revision History  :https://github.com/blackWate/COMP3064_Assignment1_2DShooter/commits/master/Assets/Scripts/SceneController.cs


using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneController: MonoBehaviour {

	//load the  desired scene
	public void loadScene(string scene){

		SceneManager.LoadScene (scene);
	}
	//quit application does not work  at in development mode, but works after "build and run"
	public void quit(){
		Application.Quit ();
	}
}
