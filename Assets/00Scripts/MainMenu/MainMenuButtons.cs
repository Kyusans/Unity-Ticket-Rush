using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFunctions : MonoBehaviour
{
    [SerializeField] Animator blackScreenAnim;
    public void PlayGame()
    {
        blackScreenAnim.SetBool("closeBackground", true);
    }

    public void About()
    {
        Debug.Log("About");
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
    }
}
