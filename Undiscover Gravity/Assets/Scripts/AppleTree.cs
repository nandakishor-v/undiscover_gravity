using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class AppleTree : MonoBehaviour
{
    [SerializeField] private GameObject apple;
    [SerializeField] private float appleRespawnTime = 1f;
    private BoxCollider2D treeCollider;
	private Bounds bounds;
    private float x, y, z;

    private void Start()
    {
        treeCollider = GetComponent<BoxCollider2D>();
        bounds = treeCollider.bounds;
    }

    private void Update()
    {
        z += Time.deltaTime;
        if (z >= appleRespawnTime)
        {
            SpawnApple();
            z = 0;
        }
    }

    private void SpawnApple()
    {
        x = Random.Range(bounds.min.x, bounds.max.x);
        y = Random.Range(bounds.min.y, bounds.max.y);
        Instantiate(apple, new Vector3(x, y, 0), quaternion.identity);
    }
}
