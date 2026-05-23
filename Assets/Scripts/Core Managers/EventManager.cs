using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
   //Setup Level UI
   public event Action<Transcribe> onSetupLevelUI;
   public void SetupLevelUI(Transcribe level) => onSetupLevelUI?.Invoke(level);

}
