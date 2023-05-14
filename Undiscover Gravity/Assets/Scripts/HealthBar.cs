using UnityEngine;

public class HealthBar : MonoBehaviour
{
	[SerializeField] private Sprite[] healthBars;
	private SpriteRenderer spriteRenderer;
	private Newton newtonAttributes;

	private void Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		newtonAttributes = GetComponentInParent<Newton>();
	}

	public void SetHealthBar(int index)
    {
	    spriteRenderer.sprite = healthBars[index];
    }
}
