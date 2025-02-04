using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinnerManager : MonoBehaviour
{
    [SerializeField] GameObject player1, player2;
    [SerializeField] Animator blackScreenAnimator;
    [SerializeField] Text youWinText;

    private void Awake()
    {
        player1.SetActive(false);
        player2.SetActive(false);
    }

    void Start()
    {
        if(PlayerPrefs.GetInt("PlayerWon") == 0){
            youWinText.text = "TIME'S UP";
            youWinText.color = Color.red;
        }
        else if (PlayerPrefs.GetInt("PlayerWon") == 1)
        {
            youWinText.text = "Player 1 Wins!";
            player1.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("PlayerWon") == 2)
        {
            youWinText.text = "Player 2 Wins!";
            player2.SetActive(true);
        }
        StartCoroutine(LoadMainMenu());
    }

    IEnumerator LoadMainMenu()
    {
        yield return new WaitForSeconds(5);
        blackScreenAnimator.SetBool("closeBackground", true);
    }

  
}
