using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class finishObject : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer(Layers.collectWood))
        {
            Destroy(other.gameObject);
            transform.DOScale(transform.localScale * 1.08f,0.1f);
        }
    }
}
