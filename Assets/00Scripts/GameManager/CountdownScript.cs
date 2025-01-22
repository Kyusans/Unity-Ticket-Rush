using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownScript : MonoBehaviour
{
	[SerializeField] Text countDownText, readyInText;
	[SerializeField] Animator blackScreenAnim;

	private int stage = 0;
	private bool isCountdownRunning = false;

	private void Start()
	{
		// PlayerPrefs.DeleteAll();
		stage = PlayerPrefs.GetInt("stage", 0);
	}

	public void StartCountdown()
	{
		if (isCountdownRunning) return;
		isCountdownRunning = true;
		StartCoroutine(CountdownCoroutine());
	}

	private IEnumerator CountdownCoroutine()
	{
		int countdown = 5;

		while (countdown > 0)
		{
			countDownText.text = countdown.ToString();
			yield return new WaitForSeconds(1);
			countdown--;
		}

		readyInText.text = "Ready!";
		countDownText.text = "";
		blackScreenAnim.SetBool("closeBackground", true);
		yield return new WaitForSeconds(2f);
		NextScene();
		isCountdownRunning = false;
	}

	public void NextScene()
	{
		switch (stage)
		{
			case 1:
				SceneManager.LoadScene("Library");
				break;
			case 2:
				SceneManager.LoadScene("Bridge");
				break;
			case 3:
				SceneManager.LoadScene("PHRooms");
				break;
			case 4:
				SceneManager.LoadScene("Finance");
				break;
			default:
				SceneManager.LoadScene("RoofDeck");
				PlayerPrefs.SetInt("stage", 0);
				break;
		}

		// Increment and save the stage.
		stage += 1;
		PlayerPrefs.SetInt("stage", stage);
		Debug.Log("Stage: " + stage);
	}
}
