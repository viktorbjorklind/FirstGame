using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject blockPrefab;
    public float spawnRate = 1f;
    public float spawnWidth = 8f;

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnRate)
        {
            SpawnBlock();
            timer = 0f;
        }
    }

    void SpawnBlock()
    {
        float x = Random.Range(-spawnWidth, spawnWidth);
        Vector3 pos = new Vector3(x, 6f, 0f);
        Instantiate(blockPrefab, pos, Quaternion.identity);
    }
}