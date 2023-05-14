using UnityEngine;

public class Apple : MonoBehaviour
{
	[SerializeField] private AudioClip hitSfx;
	[SerializeField] private float gravityFix = 3f;
	[SerializeField] private int damage = 1;
	private Newton newtonAttributes;
	[SerializeField] private int scoreValue = 1;
	private Rigidbody2D appleRigidBody;

	private void Start()
    {
	    appleRigidBody = GetComponent<Rigidbody2D>();
	    newtonAttributes = FindObjectOfType<Newton>();
    }
	
    private void OnCollisionEnter2D(Collision2D other)
    {
	    AppleBounce();
    }

    private void AppleBounce()
    {
	    AudioSource.PlayClipAtPoint(hitSfx, Camera.main.transform.position);
	    gameObject.layer = LayerMask.NameToLayer("Fallen Apple");
	    appleRigidBody.gravityScale = gravityFix;
	    transform.Rotate(Vector3.up * Time.deltaTime * 7f);
	    newtonAttributes.ProcessHit(damage);
	    StartCoroutine(newtonAttributes.ChangeFace(false));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
	    FindObjectOfType<GameSession>().AddToScore(scoreValue);
	    Destroy(gameObject);
    }
}
