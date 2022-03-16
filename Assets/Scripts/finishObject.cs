using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class finishObject : MonoBehaviour
{
    [SerializeField] ToplanmaYeri toplanmaYeri;

    int hit;
    private void Update()
    {
        if (hit >= 5)
        {
            //GetComponent<BoxCollider>().enabled = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer(Layers.collectWood))
        {
            toplanmaYeri.ObjectControl();
            hit++;
            Destroy(other.gameObject);

            if (transform.localScale.x < 2.5f)
            {
                transform.DOScale(new Vector3(transform.localScale.x + toplanmaYeri.objectsToBuild[0].transform.localScale.x/5, transform.localScale.y , transform.localScale.z), 0.1f);
            }

            else if (transform.localScale.y <2.5f)
            {
                transform.DOScale(new Vector3(transform.localScale.x , transform.localScale.y + toplanmaYeri.objectsToBuild[0].transform.localScale.y / 5, transform.localScale.z), 0.1f);
            }

            else if (transform.localScale.z < 2.5f)
            {
                transform.DOScale(new Vector3(transform.localScale.x , transform.localScale.y, transform.localScale.z + toplanmaYeri.objectsToBuild[0].transform.localScale.z / 5), 0.1f);
            }

        }
    }
}
