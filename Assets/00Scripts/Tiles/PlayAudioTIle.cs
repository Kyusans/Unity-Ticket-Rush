using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioTIle : MonoBehaviour
{

    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void disableTileObject()
    {
        // tileObject.SetActive(false);
        spriteRenderer.enabled = false;


        StartCoroutine(enableTileObject(gameObject));
    }

    IEnumerator enableTileObject(GameObject tileObject)
    {
        yield return new WaitForSeconds(2.5f);
        spriteRenderer.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        AudioManager audioManager = FindObjectOfType<AudioManager>();
        audioManager.playTileAudioFinance();
        disableTileObject();
    }
}
