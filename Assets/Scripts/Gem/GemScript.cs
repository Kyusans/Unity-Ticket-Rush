﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GemScript : MonoBehaviour
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
			Debug.Log("Player 1 got the gem");
			player1Points += 1;
			PlayerPrefs.SetInt("Player1Points", player1Points);
			PlayerPrefs.Save();
			goToLoadingScene();
			Destroy(gameObject);
		}
		else if (other.gameObject.tag == "Player2")
		{
			player2Points += 1;
			PlayerPrefs.SetInt("Player2Points", player2Points);
			PlayerPrefs.Save();
			goToLoadingScene();
			Destroy(gameObject);
		}
	}

	void goToLoadingScene()
	{
		SceneManager.LoadScene("LoadingScene");
	}

}

