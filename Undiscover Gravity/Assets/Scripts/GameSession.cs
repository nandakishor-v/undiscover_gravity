using UnityEngine;

public class GameSession : MonoBehaviour
{
	[SerializeField] private int score = 0;

	private void Awake()
	{
		SetUpSingleton();
	}

	private void SetUpSingleton()
	{
		var numberGameSessions = FindObjectsOfType<GameSession>().Length;
		if (numberGameSessions > 1)
		{
			Destroy(gameObject);
		}
		else
		{
			DontDestroyOnLoad(gameObject);
		}
	}

	public void AddToScore(int scoreValue)
	{
		score += scoreValue;
	}

	public int GetScore()
	{
		return score;
	}

	public void ResetScore()
	{
		score = 0; 
	}
    
    
}
