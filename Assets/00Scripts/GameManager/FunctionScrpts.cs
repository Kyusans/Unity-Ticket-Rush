using UnityEngine;
using UnityEngine.SceneManagement;

public class FunctionScrpts : MonoBehaviour
{

	public void goToLoadingScreen()
	{

		if (SceneManager.GetActiveScene().name == "MainMenu")
		{
			SceneManager.LoadScene("Cutscene");
		}
		else if (SceneManager.GetActiveScene().name == "WinScene")
		{
			PlayerPrefs.DeleteAll();
			SceneManager.LoadScene("MainMenu");
		}
		else if (SceneManager.GetActiveScene().name != "01LoadingScreen")
		{
			SceneManager.LoadScene("01LoadingScreen");
		}

	}

	public void winner()
	{
		SceneManager.LoadScene("WinScene");
	}

	public void goToRoofDeck()
	{
		SceneManager.LoadScene("RoofDeck");
	}

	// public void QuitGame()
	// {
	// 	Application.Quit();
	// }	
}
