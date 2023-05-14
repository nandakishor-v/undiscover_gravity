using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Newton : MonoBehaviour
{
	[SerializeField] private float moveSpeed = 5f;
	[SerializeField] private int maxHealth = 3;
	[SerializeField] private int scoreValue = -5;
	[SerializeField] private int health;
	[SerializeField] private Sprite[] faces;
	private Emotion emotion;
	private HealthBar healthBar;
	private int index;
	private SpriteRenderer faceRenderer;
	private Rigidbody2D newtonRigidBody;
	private Vector2 moveInput;

	private void Start()
	{
		newtonRigidBody = GetComponent<Rigidbody2D>();
		faceRenderer = GetComponent<SpriteRenderer>();
		healthBar = transform.GetComponentInChildren<HealthBar>();
		emotion = transform.GetComponentInChildren<Emotion>(true);
		transform.GetChild(1).gameObject.SetActive(false); //disabling emotion child
		health = maxHealth;
	}

	void Update()
    {
		Move();
		FlipNewton();
		moveSpeed += .01f * Time.deltaTime;
    }
	
	private void OnMove(InputValue value)
	{
		moveInput = value.Get<Vector2>();
	}

	private void Move()
	{
		var newtonVelocity = new Vector2(moveInput.x * moveSpeed, 0);
		newtonRigidBody.velocity = newtonVelocity;
	}
	
	private void FlipNewton()
	{
		var newtonHasVelocity = Mathf.Abs(newtonRigidBody.velocity.x) > Mathf.Epsilon;
		if (newtonHasVelocity)
		{
			transform.GetChild(0).localScale =
				transform.GetChild(1).localScale = 
					transform.localScale = new Vector2(Mathf.Sign(newtonRigidBody.velocity.x), 1f);
		}
	}
	public int GetHealth()
	{
		return health;
	}

	public int GetMaxHealth()
	{
		return maxHealth;
	}
	
	public void ProcessHit(int damage)
	{
		FindObjectOfType<GameSession>().AddToScore(scoreValue);
		health = Mathf.Clamp(health - damage, 0, maxHealth);
		Debug.Log(health);
		if (health > 0)
		{
			if(health == 3)
				transform.GetChild(1).gameObject.SetActive(false);
			else
				transform.GetChild(1).gameObject.SetActive(true);
			healthBar.SetHealthBar(health - 1);
			if(health<3)
				emotion.SetEmotion(health-1);
		}
			
		if (health <= 0)
		{
			Die();
		}
	}

	public IEnumerator ChangeFace(bool isReading)
	{
		if (isReading)
		{
			faceRenderer.sprite = faces[3];
			yield return new WaitForSeconds(4f);
		}
		//Debug.Log("before");
		//Debug.Log("hey");
		index = Mathf.Clamp(health - 1, 0, maxHealth - 1 );
		faceRenderer.sprite = faces[index];
	}

	private void Die()
	{
		FindObjectOfType<Level>().LoadGameOver();
		//AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolume);
	}
	


}

