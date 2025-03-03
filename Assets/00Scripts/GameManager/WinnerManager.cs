using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinnerManager : MonoBehaviour
{
    [SerializeField] GameObject player1, player2, fish;
    [SerializeField] Animator blackScreenAnimator;
    [SerializeField] Text youWinText;
    AudioSource[] audioSource;

    private void Awake()
    {
        player1.SetActive(false);
        player2.SetActive(false);
    }

    void Start()
    {
        audioSource = GetComponents<AudioSource>();
        if (PlayerPrefs.GetInt("PlayerWon") == 0)
        {
            audioSource[1].Play();
            fish.SetActive(false);
            youWinText.text = "TIME'S UP";
            youWinText.color = Color.red;
        }
        else if (PlayerPrefs.GetInt("PlayerWon") == 1)
        {
            audioSource[0].Play();
            youWinText.text = "Player 1 Wins!";
            player1.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("PlayerWon") == 2)
        {
            audioSource[0].Play();
            youWinText.text = "Player 2 Wins!";
            player2.SetActive(true);
        }
        StartCoroutine(LoadMainMenu());
    }

    IEnumerator LoadMainMenu()
    {
        yield return new WaitForSeconds(10);
        blackScreenAnimator.SetBool("closeBackground", true);
    }


}
