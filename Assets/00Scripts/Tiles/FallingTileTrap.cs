using UnityEngine;

public class FallingTileTrap : MonoBehaviour
{
  private float tileX, tileY;
  Rigidbody2D rb;


  void Start()
  {
    rb = GetComponent<Rigidbody2D>();
    tileX = transform.position.x;
    tileY = transform.position.y;
  }

  void Update()
  {
    if (transform.position.y < -40)
    {
      transform.position = new Vector2(tileX, tileY);
      rb.bodyType = RigidbodyType2D.Static;
    }
  }

  void OnCollisionEnter2D(Collision2D other)
  {
    if (other.gameObject.CompareTag("Player1") || other.gameObject.CompareTag("Player2"))
    {
      rb.bodyType = RigidbodyType2D.Dynamic;
    }
  }
}
