using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

	[SerializeField] Text player1PointsText;
	[SerializeField] Text player2PointsText;

	float player1Points = 0;
	float player2Points = 0;

	// Use this for initialization
	void Start()
	{
		player1Points = PlayerPrefs.GetInt("Player1Points");
		player2Points = PlayerPrefs.GetInt("Player2Points");
		player1PointsText.text = player1Points.ToString();
		player2PointsText.text = player2Points.ToString();
		// PlayerPrefs.DeleteAll();
	}


	// Update is called once per frame
	void Update()
	{

	}
}
