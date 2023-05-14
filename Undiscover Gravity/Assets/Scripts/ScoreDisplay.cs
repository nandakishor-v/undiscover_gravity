using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
	private TextMeshProUGUI scoreText;
	// Start is called before the first frame update
	void Start()
	{
		scoreText = GetComponent<TextMeshProUGUI>();
	}

	// Update is called once per frame
	void Update()
	{
		UpdateScore();
	}

	public void UpdateScore()
	{
		var scoreValue = FindObjectOfType<GameSession>().GetScore();
		scoreText.text = scoreValue.ToString();
	}
}
