using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject meteorPrefab;
    public float spawnInterval = 2f;

    void Start()
    {
        InvokeRepeating("SpawnMeteor", 0f, spawnInterval);
    }

    void SpawnMeteor()
    {
        Vector3 spawnPosition = new Vector3(
            Random.Range(transform.position.x - transform.localScale.x / 2, transform.position.x + transform.localScale.x / 2),
            transform.position.y,
            transform.position.z
        );

        Instantiate(meteorPrefab, spawnPosition, Quaternion.identity);
    }
}