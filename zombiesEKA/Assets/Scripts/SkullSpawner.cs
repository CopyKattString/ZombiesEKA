using UnityEngine;

public class SkullSpawner : MonoBehaviour
{
    public GameObject skullPrefab;
    public Transform[] spawnPoints;

    public void SpawnSkull()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(skullPrefab, spawnPoints[randomIndex].position, Quaternion.identity);
    }
    
    void Start()
    {
        InvokeRepeating(nameof(SpawnSkull), 1f, 2f);
    }
}