using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private GameObject asteroidPrefab;
    [SerializeField] private Transform[] spawnPoints; 

    private void Start()
    {
        StartCoroutine(AsteroidSpawn());
    }

    private IEnumerator AsteroidSpawn()
    {
        Instantiate(asteroidPrefab,
            spawnPoints[Random.Range(0, spawnPoints.Length - 1)].position, 
            Quaternion.Euler(0f, 0f, Random.Range(0f, 360f)));
        yield return new WaitForSeconds(3f);
        StartCoroutine(AsteroidSpawn());
    }
}