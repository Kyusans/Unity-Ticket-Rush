using System.Collections;
using UnityEngine;

public class RedLightGreenLight : MonoBehaviour
{
    [SerializeField] float greenLightDuration = 5f;
    [SerializeField] float redLightDuration = 2f;

    [SerializeField] GameObject greenLightObject;
    [SerializeField] GameObject redLightObject;

    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;

    [SerializeField] float firstTimeWaitTime = 0.5f;
    private bool isGreenLight, firstTime = true;
    private bool hasGunshotPlayedForP1, hasGunshotPlayedForP2 = false;
    private AudioSource[] audioSources;


    private Vector2 player1PreviousPosition, player2PreviousPosition;
    private float player1X, player1Y, player2X, player2Y;

    void Start()
    {
        audioSources = GetComponents<AudioSource>();
        StartCoroutine(LightCycle());
        player1X = player1.transform.position.x;
        player1Y = player1.transform.position.y;
        player2X = player2.transform.position.x;
        player2Y = player2.transform.position.y;

        if (player1 != null)
        {
            player1PreviousPosition = new Vector2(player1.transform.position.x, player1.transform.position.y);
        }
        if (player2 != null)
        {
            player2PreviousPosition = new Vector2(player2.transform.position.x, player2.transform.position.y);
        }
    }

    void Update()
    {
        if (isGreenLight)
        {
            hasGunshotPlayedForP1 = false;
            hasGunshotPlayedForP2 = false;

            if (player1 != null)
            {
                player1PreviousPosition = new Vector2(player1.transform.position.x, player1.transform.position.y);
            }
            if (player2 != null)
            {
                player2PreviousPosition = new Vector2(player2.transform.position.x, player2.transform.position.y);
            }
        }

        if (!isGreenLight)
        {
            if (player1 != null && HasPlayerMoved(player1, player1PreviousPosition))
            {
                player1.transform.position = new Vector2(player1X, player1Y);
                if (!hasGunshotPlayedForP1)
                {
                    audioSources[2].Play();
                }
                hasGunshotPlayedForP1 = true;
            }

            if (player2 != null && HasPlayerMoved(player2, player2PreviousPosition))
            {
                player2.transform.position = new Vector2(player2X, player2Y);
                if (!hasGunshotPlayedForP2)
                {
                    audioSources[2].Play();
                }
                hasGunshotPlayedForP2 = true;
            }
        }
    }

    IEnumerator LightCycle()
    {

        while (true)
        {
            isGreenLight = true;
            hasGunshotPlayedForP1 = false;
            hasGunshotPlayedForP2 = false;
            Debug.Log("Green Light - Move!");
            greenLightObject.SetActive(true);
            redLightObject.SetActive(false);
            if (firstTime)
            {
                yield return new WaitForSeconds(firstTimeWaitTime);
                audioSources[0].Play();
                firstTime = false;
            }else{
                audioSources[0].Play();
            }
            yield return new WaitForSeconds(greenLightDuration);

            isGreenLight = false;
            Debug.Log("Red Light - Stop!");
            greenLightObject.SetActive(false);
            redLightObject.SetActive(true);
            audioSources[0].Stop();
            yield return new WaitForSeconds(0.5f);
            audioSources[1].Play();
            yield return new WaitForSeconds(redLightDuration);
            audioSources[1].Stop();
        }
    }

    private bool HasPlayerMoved(GameObject player, Vector2 previousPosition)
    {
        if (player == null) return false;

        Vector2 currentPosition = new Vector2(player.transform.position.x, player.transform.position.y);
        return Vector2.Distance(currentPosition, previousPosition) > 0.01f;
    }
}
