using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

	[SerializeField] Text player1PointsText, player2PointsText, player1ChatBox, player2ChatBox;
	float player1Points, player2Points = 0;
	int stage = 0;

	private void Awake()
	{
		stage = PlayerPrefs.GetInt("stage", 0);
		PlayerPrefs.DeleteAll();
	}

	void Start()
	{
		player1Points = PlayerPrefs.GetInt("Player1Points");
		player2Points = PlayerPrefs.GetInt("Player2Points");
		player1PointsText.text = player1Points.ToString();
		player2PointsText.text = player2Points.ToString();

		int randomNumber = Random.Range(0, 5);
		string[] messages = new string[] { "ggez", "mao rato?", "boring", "uninstall", "banga", "HAHAHAHA" };

		if (PlayerPrefs.GetInt("PlayerWon") == 1)
		{
			player2ChatBox.text = "";
			player1ChatBox.text = messages[randomNumber];
		}
		else if (PlayerPrefs.GetInt("PlayerWon") == 2)
		{
			player1ChatBox.text = "";
			player2ChatBox.text = messages[randomNumber];
		}
		// PlayerPrefs.DeleteAll();
	}

	public void NextScene()
	{
		switch (stage)
		{
			case 0:
				SceneManager.LoadScene("Library");
				break;
			case 1:
				SceneManager.LoadScene("Bridge");
				break;
			case 2:
				SceneManager.LoadScene("PHRooms");
				break;
			case 3:
				SceneManager.LoadScene("Finance");
				break;
			default:
				break;
		}
		stage++;
		PlayerPrefs.SetInt("stage", stage);
	}
}
