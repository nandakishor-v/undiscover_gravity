using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class BookShelf : MonoBehaviour
{
    [SerializeField] private GameObject comics;
    private BoxCollider2D shelfCollider;
    private Bounds bounds;
    [SerializeField]  float comicRespawnTime = 10f;
    private float x, y, z;

    private void Start()
    {
        shelfCollider = GetComponent<BoxCollider2D>();
        bounds = shelfCollider.bounds;
    }

    private void Update()
    {
        z += Time.deltaTime;
        if (z >= comicRespawnTime)
        {
            SpawnComics();
            z = 0;
        }
            
    }

    private void SpawnComics()
    {
        x = Random.Range(bounds.min.x, bounds.max.x);
        y = Random.Range(bounds.min.y, bounds.max.y);
        Instantiate(comics, new Vector3(x, y, 0), quaternion.identity);
    }
}