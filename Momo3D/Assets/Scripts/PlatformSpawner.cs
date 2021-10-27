using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public static PlatformSpawner Instance; 
    public GameObject PlatformPrefab;
    public Transform SpawnPosition;
    public const int MAX_PLATFORM_POOL = 20;
    public Queue<Platform> PlatformObjectPool;
    public List<Platform> PlatformList;
    private void Awake() 
    {
        Instance = this;
        SpawnPlatform();
    }
    public void Init()
    {
        PlatformObjectPool = new Queue<Platform>();
        PlatformList = new List<Platform>();
        for (int i = 0; i < MAX_PLATFORM_POOL; ++i)
        {
            SpawnPlatform();
        }
    }
    public void SpawnPlatform() 
    {
        GameObject newPlatform = Instantiate(PlatformPrefab, this.transform);
        // newPlatform.transform.position = SpawnPosition.position + new Vector3(Random.Range(-3, 3), 0, 0);
        newPlatform.transform.position = SpawnPosition.position;
        newPlatform.SetActive(false);
        PlatformObjectPool.Enqueue(newPlatform.GetComponent<Platform>());
    }
}
