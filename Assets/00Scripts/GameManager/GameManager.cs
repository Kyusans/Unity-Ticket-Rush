using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

	[SerializeField] Text player1PointsText, player2PointsText, player1ChatBox, player2ChatBox;
	float player1Points, player2Points = 0;

	void Start()
	{
		player1Points = PlayerPrefs.GetInt("Player1Points", 0);
		player2Points = PlayerPrefs.GetInt("Player2Points", 0);
		player1PointsText.text = player1Points.ToString();
		player2PointsText.text = player2Points.ToString();

		int randomNumber = Random.Range(0, 7);
		string[] messages = new string[] { "ez", "mao rato?", "boring", "tarunga pud", "haha banga", "HAHAHAHAHA", "?" };

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
}
