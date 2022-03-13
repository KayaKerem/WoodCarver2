using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestRoyObje : MonoBehaviour
{

    void Start()
    {
        Destroy(transform.gameObject, 1f);
    }

}
