using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPunchScript : MonoBehaviour
{
    [SerializeField] float pushForce = 500f;
    [SerializeField] Transform player; 

    public void InactiveGameObject()
    {
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1") || collision.CompareTag("Player2"))
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                float direction = player.localScale.x > 0 ? 1 : -1; 
                rb.AddForce(new Vector2(pushForce * direction, 0), ForceMode2D.Impulse);
            }
        }
    }
}
