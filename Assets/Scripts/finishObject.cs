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
            transform.DOScale(new Vector3(transform.localScale.x,transform.localScale.y+0.1f, transform.localScale.z) , 0.1f);
        }
    }
}
