using System;
using UnityEngine;

public class Comics : MonoBehaviour
{
    [SerializeField] private AudioClip pageFlipSfx;
    [SerializeField] private int gainHealth = 1;
    private Newton newtonAttributes;

    private void Start()
    {
        newtonAttributes = FindObjectOfType<Newton>();
    }

    private void Update()
    {
        if(newtonAttributes.GetHealth()==3)
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), newtonAttributes.GetComponent<Collider2D>());
        else
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), newtonAttributes.GetComponent<Collider2D>(), false);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (newtonAttributes.GetHealth() == 3) return;
            OpenComics();
    }

    private void OpenComics()
    {
        if (newtonAttributes.GetHealth() < 3)
            GetComponent<SpriteRenderer>().enabled = false;
        AudioSource.PlayClipAtPoint(pageFlipSfx, Camera.main.transform.position);
        newtonAttributes.ProcessHit(-gainHealth);
        newtonAttributes.transform.GetChild(1).gameObject.SetActive(false); //toggling emotion
        StartCoroutine(newtonAttributes.ChangeFace(true)); 
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject, 7f);
    }
}