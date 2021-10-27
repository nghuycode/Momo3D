using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int PlatformID;
    public Vector3 NextPlatformPosition;
    public float DistanceToNextPlatform;

    private void Start() 
    {
        PlatformID = 0;
        DistanceToNextPlatform = Vector3.Distance(this.transform.position, PlatformSpawner.Instance.PlatformList[PlatformID].transform.position);
    }
    private void Init()
    {

    }
}
