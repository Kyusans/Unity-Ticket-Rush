using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSafeTileHandler : MonoBehaviour
{
    [SerializeField] private GameObject[] tiles;

    private void Start()
    {
        int randomTileIndex = Random.Range(0, tiles.Length);
        tiles[randomTileIndex].tag = "TrapTile";
    }

    public void disableTileObject(GameObject tileObject)
    {
        tileObject.SetActive(false);
        StartCoroutine(enableTileObject(tileObject));
    }

    IEnumerator enableTileObject(GameObject tileObject)
    {
        yield return new WaitForSeconds(1.2f);
        tileObject.SetActive(true);
        Debug.Log("Enabled TileObject: " + tileObject.name);
    }
}