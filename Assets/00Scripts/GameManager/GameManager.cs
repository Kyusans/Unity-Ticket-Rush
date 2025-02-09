using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	[SerializeField] GameObject player1Win, player2Win, player1Lose, player2Lose;
	[SerializeField] Text player1PointsText, player2PointsText, player1ChatBox, player2ChatBox;
	float player1Points, player2Points = 0;

	void Start()
	{
		player1Points = PlayerPrefs.GetInt("Player1Points", 0);
		player2Points = PlayerPrefs.GetInt("Player2Points", 0);
		player1PointsText.text = player1Points.ToString();
		player2PointsText.text = player2Points.ToString();

		int randomNumber = Random.Range(0, 7);
		string[] messages = new string[] { "ez", "forfeit na", "kaya pa?", "tarunga pud", "haha banga", "hehe", "tagaan takag chance?" };

		if (PlayerPrefs.GetInt("PlayerWon") == 1)
		{

			player2ChatBox.text = "";
			player1ChatBox.text = messages[randomNumber];
			player1Win.SetActive(true);
			player2Lose.SetActive(true);
		}
		else if (PlayerPrefs.GetInt("PlayerWon") == 2)
		{
			player1ChatBox.text = "";
			player2ChatBox.text = messages[randomNumber];
			player2Win.SetActive(true);
			player1Lose.SetActive(true);
		}
		// PlayerPrefs.DeleteAll();
	}
}
