using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatDetector : MonoBehaviour
{
    public static BeatDetector Instance;
    private void Awake() 
    {
        Instance = this;
    }
    public float BPM;
    [SerializeField]
    private float _beatTime, _beat;
    public bool IsBeat; 

    private void Update() 
    {
        Detect();
    }
    private void Detect() 
    {
        IsBeat = false;
        _beat = 60f / BPM;
        _beatTime += Time.deltaTime;
        if (_beatTime >= _beat)
        {
            _beatTime -= _beat;
            IsBeat = true;
            //PlatformSpawner.Instance.SpawnPlatform();
            Debug.Log("beat");
        }
    }
}
