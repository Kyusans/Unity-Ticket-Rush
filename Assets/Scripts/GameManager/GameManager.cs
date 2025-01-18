using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

	[SerializeField] Text player1PointsText;
	[SerializeField] Text player2PointsText;

	[SerializeField] Text player1ChatBox;
	[SerializeField] Text player2ChatBox;

	float player1Points = 0;
	float player2Points = 0;


	void Start()
	{
		player1Points = PlayerPrefs.GetInt("Player1Points");
		player2Points = PlayerPrefs.GetInt("Player2Points");
		player1PointsText.text = player1Points.ToString();
		player2PointsText.text = player2Points.ToString();

		int randomNumber = Random.Range(0, 4);
		string[] messages = new string[] { "ggez", "mao rato?", "boring", "uninstall", "banga" };

		if(PlayerPrefs.GetInt("PlayerWon") == 1)
		{
			player1ChatBox.text = messages[randomNumber];
		}
		else if(PlayerPrefs.GetInt("PlayerWon") == 2)
		{
			player2ChatBox.text = messages[randomNumber];
		}
		// PlayerPrefs.DeleteAll();
	}


	// Update is called once per frame
	void Update()
	{

	}
}
