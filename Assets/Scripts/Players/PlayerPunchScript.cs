using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPunchScript : MonoBehaviour
{
	[SerializeField] float pushForce = 500f;
	public void inactiveGameObject()
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
				rb.AddForce(new Vector2(pushForce, 0), ForceMode2D.Impulse);
			}
		}
		Debug.Log("punched");
	}

}
