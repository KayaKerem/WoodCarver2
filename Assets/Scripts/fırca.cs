using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class fırca : MonoBehaviour
{
    [SerializeField] Transform Firca;

    [SerializeField] Vector3 rotateDegeri;

    private void Start()
    {
        Firca.DOLocalRotate(rotateDegeri, 1f).SetLoops(-1, LoopType.Yoyo);
    }

}
