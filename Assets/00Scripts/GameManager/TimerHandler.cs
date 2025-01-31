using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerHandler : MonoBehaviour
{
    [SerializeField] Text timerText;
    [SerializeField] Animator blackBackgroundAnim;
    public int timeLeft;

    void Start()
    {
        timeLeft = PlayerPrefs.GetInt("time", 480);
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
        goBackToMenu();

    }

    void goBackToMenu()
    {
        PlayerPrefs.SetInt("PlayerWon", 0);
        blackBackgroundAnim.SetBool("win", true);
    }

    string minuteConverter(int time)
    {
        int minutes = time / 60;
        int seconds = time % 60;
        return (minutes < 1 ? "0" : "") + minutes + ":" + (seconds < 10 ? "0" : "") + seconds;
    }
}
