using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MerryGoRoundHandler : MonoBehaviour
{
    AudioSource[] audioSource;
    [SerializeField] GameObject coins, player1, player2;
    [SerializeField] Text p1CoinCollectedText, p2CoinCollectedText, p1TimerText, p2TimerText;
    
    int p1CoinCollected, p2CoinCollected = 0;
    float minimumTime = 7f;
    float maximumTime = 9f;
    float coinsNeeded;

    float player1x, player1y, player2x, player2y;
    int timeLeft = 10;
    private Coroutine countdownCoroutine;
    private GameObject spawnedCoins;

    private void Start()
    {
        player1x = player1.transform.position.x;
        player1y = player1.transform.position.y;
        player2x = player2.transform.position.x;
        player2y = player2.transform.position.y;
        audioSource = GetComponents<AudioSource>();
        StartCoroutine(StartMerryGoRound());
    }

    public void AddCoinCollected(string playerTag)
    {
        if (playerTag == "Player1")
        {
            p1CoinCollected++;
            p1CoinCollectedText.text = p1CoinCollected + "/" + coinsNeeded + " Coins";
        }
        else if (playerTag == "Player2")
        {
            p2CoinCollected++;
            p2CoinCollectedText.text = p2CoinCollected + "/" + coinsNeeded + " Coins";
        }
    }

    IEnumerator StartMerryGoRound()
    {
        while (true)
        {
            p1CoinCollectedText.gameObject.SetActive(false);
            p2CoinCollectedText.gameObject.SetActive(false);
            p1TimerText.gameObject.SetActive(false);
            p2TimerText.gameObject.SetActive(false);
            
            p1CoinCollected = 0;
            p2CoinCollected = 0;
            
            audioSource[1].Stop();
            audioSource[0].Play();

            float randomTime = Random.Range(minimumTime, maximumTime);
            yield return new WaitForSeconds(randomTime);

            timeLeft = 10;
            StartCountdown();

            coinsNeeded = Random.Range(3, 5);
            p1CoinCollectedText.text = p1CoinCollected + "/" + coinsNeeded + " Coins";
            p2CoinCollectedText.text = p2CoinCollected + "/" + coinsNeeded + " Coins";

            if (spawnedCoins != null)
            {
                Destroy(spawnedCoins);
                spawnedCoins = null;
            }
            
            spawnedCoins = Instantiate(coins, transform.position, Quaternion.identity);

            p1CoinCollectedText.gameObject.SetActive(true);
            p2CoinCollectedText.gameObject.SetActive(true);
            p1TimerText.gameObject.SetActive(true);
            p2TimerText.gameObject.SetActive(true);

            audioSource[0].Stop();
            audioSource[1].Play();

            yield return new WaitForSeconds(timeLeft);

            StopCountdown();

            if (spawnedCoins != null)
            {
                Destroy(spawnedCoins);
                spawnedCoins = null;
            }
            if(p1CoinCollected < coinsNeeded)
            {
                player1.transform.position = new Vector2(player1x, player1y);
                audioSource[2].Play();
            }else if(p2CoinCollected < coinsNeeded)
            {
                player2.transform.position = new Vector2(player2x, player2y);
                audioSource[2].Play();
            }
        }
    }

    IEnumerator Countdown()
    {
        while (timeLeft > 0)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
            p1TimerText.text = timeLeft + " seconds left";
            p2TimerText.text = timeLeft + " seconds left";
        }
    }

    public void StartCountdown()
    {
        StopCountdown();
        countdownCoroutine = StartCoroutine(Countdown());
    }

    public void StopCountdown()
    {
        if (countdownCoroutine != null)
        {
            StopCoroutine(countdownCoroutine);
            countdownCoroutine = null;
        }
    }
}
