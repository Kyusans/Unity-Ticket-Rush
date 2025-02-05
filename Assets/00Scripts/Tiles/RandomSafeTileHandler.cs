using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSafeTileHandler : MonoBehaviour
{
    [SerializeField] private GameObject[] tiles;
    [SerializeField] private GameObject tileObject;


    private void Start()
    {
        int randomTileIndex = Random.Range(0, tiles.Length);
        tiles[randomTileIndex].tag = "TrapTile";
    }

    public void disableTileObject()
    {
        tileObject.SetActive(false);
        StartCoroutine(enableTileObject());
    }

    IEnumerator enableTileObject()
    {
        yield return new WaitForSeconds(1.2f);
        tileObject.SetActive(true);
    }
}
