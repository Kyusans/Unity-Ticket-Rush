using UnityEngine;

public class CrusherTrap : MonoBehaviour
{
    float trapX, trapY;
    float trapSpeed = 1000f;
    Rigidbody2D rb;

    bool fall = false;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        trapX = transform.position.x;
        trapY = transform.position.y;
    }

    void trapFall()
    {
        rb.velocity = new Vector2(0, -10f * trapSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player1" || other.gameObject.tag == "Player2")
        {
            fall = true;
        }
    }

    void Update()
    {
        if (fall)
        {
            trapFall();
        }

        if (transform.position.y < -40)
        {
            transform.position = new Vector2(trapX, trapY);
        }
    }
}
