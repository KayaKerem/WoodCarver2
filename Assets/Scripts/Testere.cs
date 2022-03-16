using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Testere : MonoBehaviour
{
    [SerializeField] Transform _modelTestere;
    [SerializeField] Transform move;


    private void Start()
    {
        _modelTestere.DOLocalMove(move.localPosition, 0.5f).SetLoops(-1, LoopType.Yoyo);
    }

    
}
