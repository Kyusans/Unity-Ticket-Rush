using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerHandler : MonoBehaviour
{
    [SerializeField] Text timerText;
    public int timeLeft;

    void Start()
    {
        timeLeft = PlayerPrefs.GetInt("time", 600);
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        while (timeLeft > 0)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
            timerText.text = minuteConverter(timeLeft);
        }
        PlayerPrefs.SetInt("PlayerWon", 0);
        goBackToMenu();
    }

    void goBackToMenu()
    {
        PlayerPrefs.SetInt("PlayerWon", 0);
        SceneManager.LoadScene("MainMenu");
    }

    string minuteConverter(int time)
    {
        int minutes = time / 60;
        int seconds = time % 60;
        return minutes + ":" + (seconds < 10 ? "0" : "") + seconds;
    }
}
