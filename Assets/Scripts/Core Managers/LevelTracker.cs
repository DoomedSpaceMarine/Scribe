using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelTracker : MonoBehaviour
{
    [SerializeField] private List<Transcribe> transcribes = new List<Transcribe>();
    [SerializeField] private int currentLevelIndex;
}
