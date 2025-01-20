using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleTiles : MonoBehaviour
{
	[SerializeField] private GameObject invisibleTile;

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Player1") || other.gameObject.CompareTag("Player2"))
		{
			invisibleTile.SetActive(true);
		}
	}

}
