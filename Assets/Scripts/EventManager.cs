using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
public static class EventManager
{

    public static event Action<int> OnIncreaseScore;
    public static void Event_OnIncreaseScore(int value) { OnIncreaseScore?.Invoke(value); }

    public static event Action<Vector3> OnScoreChangeTransform;
    public static void Event_OnScoreChangeTransform(Vector3 position) { OnScoreChangeTransform?.Invoke(position); }

    public static event Action<WoodScript> OnWoodAdded;
    public static void Event_OnWoodAdded(WoodScript wood) { OnWoodAdded?.Invoke(wood); }

    public static event Action OnLevelFinish;
    public static void Event_OnLevelFinish() { OnLevelFinish?.Invoke(); }

    public static event Action FinishFirstTouch;
    public static void Event_FinishFirstTouch() { FinishFirstTouch?.Invoke(); }

    public static event Action<int> OnLastScore;
    public static void Event_OnLastScore(int puan) { OnLastScore?.Invoke(puan); }

    public static event Action<int> OnRestScore;
    public static void Event_OnRestScore(int puan) { OnRestScore?.Invoke(puan); }

    public static event Action<bool> OnCharacterAnimControl;
    public static void Event_OnCharacterAnimControl(bool value) { OnCharacterAnimControl?.Invoke(value); }
}
