using UnityEngine;

public class Gravity : MonoBehaviour
{
	private float increasedGravity;
	void Start()
	{
		increasedGravity = -Physics2D.gravity.y;
	}

  
	void Update()
	{
		increasedGravity += .05f * Time.deltaTime;
		Physics2D.gravity = new Vector3(0, -increasedGravity, 0);
	}
}
