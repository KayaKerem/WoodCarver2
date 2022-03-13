using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class fırca : MonoBehaviour
{
    [SerializeField] Vector3 first;
    [SerializeField] Vector3 last;
    bool allow = true;


    void Update()
    {
        if (allow)
        {
            transform.DOLocalRotate(first, 1).OnComplete(Back);
            allow = false;
        }
    }

    void Back()
    {
        transform.DOLocalRotate(last,1).OnComplete(StartAgain);
    }

    void StartAgain()
    {
        allow = true;
    }
}
