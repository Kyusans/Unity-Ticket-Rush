using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFunctions : MonoBehaviour
{
    [SerializeField] Animator blackScreenAnim;

    private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void PlayGame()
    {
		PlayerPrefs.DeleteAll();
        blackScreenAnim.SetBool("closeBackground", true);
    }

    public void About()
    {
        Debug.Log("About");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
