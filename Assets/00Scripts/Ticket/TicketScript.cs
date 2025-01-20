using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TicketScript : MonoBehaviour
{

	private int player1Points = 0;
	private int player2Points = 0;

	void Start()
	{
		player1Points = PlayerPrefs.GetInt("Player1Points", 0);
		player2Points = PlayerPrefs.GetInt("Player2Points", 0);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player1")
		{
			player1Points += 1;
			PlayerPrefs.SetInt("Player1Points", player1Points);
			PlayerPrefs.SetInt("PlayerWon", 1);
			PlayerPrefs.Save();
			goToLoadingScene();
			Destroy(gameObject);
		}
		else if (other.gameObject.tag == "Player2")
		{
			player2Points += 1;
			PlayerPrefs.SetInt("Player2Points", player2Points);
			PlayerPrefs.SetInt("PlayerWon", 2);
			PlayerPrefs.Save();
			goToLoadingScene();
			Destroy(gameObject);
		}
	}

	public void DeletePlayerPrefs()
	{
		PlayerPrefs.DeleteKey("Player1Points");
		PlayerPrefs.DeleteKey("Player2Points");
		PlayerPrefs.Save();
	}

	void goToLoadingScene()
	{
		SceneManager.LoadScene("01LoadingScreen");
	}

}

