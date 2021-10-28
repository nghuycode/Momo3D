using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatDetector : MonoBehaviour
{
    public static BeatDetector Instance;
    private void Awake() 
    {
        Instance = this;
        Init();
    }
    public float BPM;
    [SerializeField]
    private float _beatTime, _beat;
    public bool IsBeat; 
    public AudioSource MusicSource;
    public List<MusicData> MusicDataList = new List<MusicData>();
    private void Init() 
    {
        MusicData musicData = MusicDataList[Random.Range(0, MusicDataList.Count)];
        MusicSource.clip = musicData.Music;
        BPM = musicData.BPM;
        MusicSource.Play();
    }

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
            PlatformSpawner.Instance.SpawnPlatform();
            Debug.Log("beat");
        }
    }
}
