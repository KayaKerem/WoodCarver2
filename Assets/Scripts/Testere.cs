using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Testere : MonoBehaviour
{
    [SerializeField] Vector3 dön;
    [SerializeField] Vector3 first;
    [SerializeField] Vector3 back;
    bool allow = true;

    void Update()
    {
        transform.Rotate(dön, Space.World);

        if (allow)
        {
            allow = false;
            transform.DOLocalMove(first, 2f).OnComplete(Back); 
        }
    }

    void Back()
    {
        transform.DOLocalMove(back, 0.5f).OnComplete(Again);
    }

    void Again()
    {
        allow = true;
    }
}
