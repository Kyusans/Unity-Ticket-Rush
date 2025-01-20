using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CountdownScript : MonoBehaviour
{

	[SerializeField] Text countDownText, readyInText;
	int stage = 0;

	private void Awake()
	{
		stage = PlayerPrefs.GetInt("stage", 0);
		PlayerPrefs.DeleteAll();
	}
	public void StartCountdown()
	{
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
		yield return new WaitForSeconds(1f);
		NextScene();
	}

	public void NextScene()
	{
		switch (stage)
		{
			case 0:
				SceneManager.LoadScene("Library");
				break;
			case 1:
				SceneManager.LoadScene("Bridge");
				break;
			case 2:
				SceneManager.LoadScene("PHRooms");
				break;
			case 3:
				SceneManager.LoadScene("Finance");
				break;
			default:
				break;
		}
		stage++;
		PlayerPrefs.SetInt("stage", stage);
	}
}
