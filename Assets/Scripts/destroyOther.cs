using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyOther : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        EventManager.Event_OnIncreaseScore(10);
    }
}
