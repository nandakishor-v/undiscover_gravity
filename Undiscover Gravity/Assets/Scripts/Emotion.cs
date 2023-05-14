using UnityEngine;

public class Emotion : MonoBehaviour
{
    [SerializeField] private Sprite[] emotions;
    private SpriteRenderer spriteRenderer;
    private Newton newtonAttributes;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        newtonAttributes = GetComponentInParent<Newton>();
    }

    public void SetEmotion(int index)
    {
        spriteRenderer.sprite = emotions[index];
    }
}