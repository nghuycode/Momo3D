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

    public float OffsetLeft, OffsetRight;
    private void Awake() 
    {
        Instance = this;
        Init();
    }
    public void Init()
    {
        PlatformObjectPool = new Queue<Platform>();
        PlatformList = new List<Platform>();
        for (int i = 0; i < MAX_PLATFORM_POOL; ++i)
        {
            GameObject newPlatform = Instantiate(PlatformPrefab, this.transform);
            newPlatform.transform.position = SpawnPosition.position;
            newPlatform.SetActive(false);
            PlatformObjectPool.Enqueue(newPlatform.GetComponent<Platform>());
        }
        SpawnPlatform();
    }
    public void SpawnPlatform() 
    {
        Platform newPlatform = PlatformObjectPool.Dequeue();
        newPlatform.transform.position = SpawnPosition.position + new Vector3(Random.Range(OffsetLeft, OffsetRight), 0, 0);
        // newPlatform.transform.position = SpawnPosition.position;
        newPlatform.Respawn();
        PlatformList.Add(newPlatform);
        PlatformObjectPool.Enqueue(newPlatform);
    }
}
