using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TicketScript : MonoBehaviour
{
    [SerializeField] Animator blackBackgroundAnim;
    private int player1Points = 0;
    private int player2Points = 0;

    AudioSource audioSource;
    BoxCollider2D boxCollider;
    SpriteRenderer spriteRenderer;

    private bool hasBeenCollected = false; 

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        player1Points = PlayerPrefs.GetInt("Player1Points", 0);
        player2Points = PlayerPrefs.GetInt("Player2Points", 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (hasBeenCollected) return; 

        if (other.gameObject.CompareTag("Player1"))
        {
            CollectTicket(1);
        }
        else if (other.gameObject.CompareTag("Player2"))
        {
            CollectTicket(2);
        }
    }

    void CollectTicket(int playerNumber)
    {
        hasBeenCollected = true;
        boxCollider.enabled = false;
        audioSource.Play();

        if (playerNumber == 1)
        {
            player1Points++;
            PlayerPrefs.SetInt("Player1Points", player1Points);
            PlayerPrefs.SetInt("PlayerWon", 2);
        }
        else if (playerNumber == 2)
        {
            player2Points++;
            PlayerPrefs.SetInt("Player2Points", player2Points);
            PlayerPrefs.SetInt("PlayerWon", 2);
        }
        TimerHandler timerHandler = FindObjectOfType<TimerHandler>();
        PlayerPrefs.SetInt("time", timerHandler.timeLeft);

        PlayerPrefs.Save();

        if ((playerNumber == 1 && player1Points >= 3) || (playerNumber == 2 && player2Points >= 3))
        {
            blackBackgroundAnim.SetBool("win", true);
        }
        else
        {
            CloseBackground();
        }

        DisableComponents();
    }

    void DisableComponents()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = false;
        }
    }

    public void CloseBackground()
    {
        blackBackgroundAnim.SetBool("closeBackground", true);
    }
}
