using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class ParcalamaEngel : MonoBehaviour
{

    [SerializeField] Animation Animation;
    [SerializeField] ParticleSystem Effect;

    void Start()
    {
        Animation.Play();
    }

    void Update()
    {
        
    }

    public void ParticleEffect()
    {
        Effect.Play();
    }
}
