using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTile : MonoBehaviour
{
    AudioSource audioSources;
    void Start()
    {
        audioSources = GetComponent<AudioSource>();
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (CompareTag("TrapTile"))
        {
            AudioManager audioManager = FindObjectOfType<AudioManager>();
            audioManager.PlayTrapAudioPHRoom();
            if (other.gameObject.CompareTag("Player1") || other.gameObject.CompareTag("Player2"))
            {
                Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();
                rb.gravityScale += 100;
                GameObject tileObject = transform.parent.gameObject;
                RandomSafeTileHandler randomSafeTileHandler = FindObjectOfType<RandomSafeTileHandler>();
                randomSafeTileHandler.disableTileObject(tileObject);
            }
        }
        else
        {
            audioSources.Play();
        }
    }
}