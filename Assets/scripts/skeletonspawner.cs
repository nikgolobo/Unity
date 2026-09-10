using UnityEngine;

public class SkeletonSpawner : MonoBehaviour
{
    [Header("Skeleton Spawning")]
    [SerializeField] private GameObject skeletonPrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float spawnCooldown = 3f;
    [SerializeField] private int maxSkeletonsAlive = 3;

    private int aliveSkeletons = 0;
    private float nextSpawnTime = 0f;

    void Update()
    {
        if (aliveSkeletons < maxSkeletonsAlive && Time.time >= nextSpawnTime)
        {
            SpawnSkeleton();
            nextSpawnTime = Time.time + spawnCooldown;
        }
    }

    private void SpawnSkeleton()
    {
        if (skeletonPrefab == null || spawnPoints.Length == 0) return;

        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];

        Instantiate(skeletonPrefab, spawnPoint.position, Quaternion.identity);

        aliveSkeletons++;
    }

    public void SkeletonDefeated()
    {
        aliveSkeletons--;

        if (aliveSkeletons < 0)
        {
            aliveSkeletons = 0;
        }
    }
}