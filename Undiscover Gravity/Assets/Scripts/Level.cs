using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
	[SerializeField] private float delayInSeconds = 1f;

	public void LoadStartMenu()
	{
		SceneManager.LoadScene("Start Menu");
	}
	public void LoadGameScene()
	{
		//FindObjectOfType<GameSession>().ResetScore();
		SceneManager.LoadScene("Game Scene");
	}
	public void LoadGameOver()
	{
		StartCoroutine(WaitAndLoad());
	}
	
	public void LoadMainMenu()
	{
		SceneManager.LoadScene("Start Menu");
	}
	
	public void RetryGameScene()
	{
		FindObjectOfType<GameSession>().ResetScore();
		SceneManager.LoadScene("Game Scene");
	}

	public void QuitGame()
	{
		Application.Quit();
	}
	
	private IEnumerator WaitAndLoad()
	{
		yield return new WaitForSeconds(delayInSeconds);
		SceneManager.LoadScene("Game Over");
	}
}

