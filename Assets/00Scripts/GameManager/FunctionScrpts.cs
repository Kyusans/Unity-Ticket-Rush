using UnityEngine;
using UnityEngine.SceneManagement;

public class FunctionScrpts : MonoBehaviour
{

	public void goToLoadingScreen()
	{

		if (SceneManager.GetActiveScene().name == "MainMenu")
		{
			SceneManager.LoadScene("RoofDeck");
		}
		else if (SceneManager.GetActiveScene().name != "01LoadingScreen")
		{
			SceneManager.LoadScene("01LoadingScreen");
		}
	}

	public void winner()
	{
		SceneManager.LoadScene("MainMenu");
	}

	// public void QuitGame()
	// {
	// 	Application.Quit();
	// }	
}
