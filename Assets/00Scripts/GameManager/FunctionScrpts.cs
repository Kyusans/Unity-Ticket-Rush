using UnityEngine;
using UnityEngine.SceneManagement;

public class FunctionScrpts : MonoBehaviour
{

	public void goToLoadingScreen()
	{
		if (SceneManager.GetActiveScene().name != "01LoadingScreen")
		{
			SceneManager.LoadScene("01LoadingScreen");
		}
	}

	// public void QuitGame()
	// {
	// 	Application.Quit();
	// }	
}
