using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    [SerializeField] LayerMask layers; 
    [SerializeField] LayerMask layers2; 
    private void OnTriggerEnter(Collider other)
    {
        EventManager.Event_OnLevelFinish();
    }
}
