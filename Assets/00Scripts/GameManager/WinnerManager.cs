using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinnerManager : MonoBehaviour
{
    [SerializeField] GameObject player1, player2;
    [SerializeField] Text youWinText;

    private void Awake()
    {
        player1.SetActive(false);
        player2.SetActive(false);
    }

    void Start()
    {
        if (PlayerPrefs.GetInt("PlayerWon") == 1)
        {
            youWinText.text = "Player 1 Wins!";
            player1.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("PlayerWon") == 2)
        {
            youWinText.text = "Player 2 Wins!";
            player2.SetActive(true);
        }
    }
}
