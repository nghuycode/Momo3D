using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "NGH/Music Data")]
public class MusicData : ScriptableObject
{
    public AudioClip Music;
    public float BPM;
}
