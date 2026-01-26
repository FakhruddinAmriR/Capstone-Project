using System.Collections;
using UnityEngine;
public class Spawner : MonoBehaviour
{
    [Header("Spawn area X range (world units)")]
    public float minX = -7f;
    public float maxX = 7f;
    public float spawnY = 10f; // jauh di atas player



    [Header("Prefabs to spawn (assign prefabs with FallingObject component)")]
    public GameObject[] spawnPrefabs;
    public Sprite[] spawnSprites;

    [Header("Spawn timing")]
    public float minSpawnInterval = 0.4f;
    public float maxSpawnInterval = 1.2f;


    private Coroutine spawnRoutine;


    void OnEnable()
    {
        StartSpawning();
    }


    //public void StartSpawning()
    //{
    //    if (spawnRoutine != null) StopCoroutine(spawnRoutine);
    //    spawnRoutine = StartCoroutine(SpawnLoop());
    //}


    public void StopSpawning()
    {
        if (spawnRoutine != null) StopCoroutine(spawnRoutine);
        spawnRoutine = null;
    }

    public void StartSpawning()
    {
        if (spawnRoutine != null) StopCoroutine(spawnRoutine);
        spawnRoutine = StartCoroutine(StartWithDelay());
    }

    IEnumerator StartWithDelay()
    {
        yield return new WaitForSeconds(0.5f);
        yield return StartCoroutine(SpawnLoop());
    }



    IEnumerator SpawnLoop()
    {
        while (GameManagerFallingObject.Instance != null && GameManagerFallingObject.Instance.IsSpawning)
        {
            SpawnOne();
            float wait = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(wait);
        }
    }


    void SpawnOne()
    {
        if (spawnPrefabs == null || spawnPrefabs.Length == 0) return;
        int idx = Random.Range(0, spawnPrefabs.Length);
        Vector3 pos = new Vector3(Random.Range(minX, maxX), spawnY, 0f);
        if (idx == 0)
            spawnPrefabs[idx].GetComponent<SpriteRenderer>().sprite = spawnSprites[ Random.Range(0, spawnSprites.Length)];
        Instantiate(spawnPrefabs[idx], pos, Quaternion.identity);
    }
}