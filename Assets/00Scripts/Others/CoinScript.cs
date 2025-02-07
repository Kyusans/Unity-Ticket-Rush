using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private bool isCollected = false;
    private MerryGoRoundHandler merryGoRoundHandler;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        merryGoRoundHandler = FindObjectOfType<MerryGoRoundHandler>(); 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isCollected) return; 

        if (other.CompareTag("Player1") || other.CompareTag("Player2"))
        {
            isCollected = true;

            if (merryGoRoundHandler != null)
            {
                merryGoRoundHandler.AddCoinCollected(other.gameObject.tag);
            }
            audioSource.Play();
            GetComponent<Collider2D>().enabled = false; 
            Destroy(gameObject, 0.1f); 
        }
    }
}
