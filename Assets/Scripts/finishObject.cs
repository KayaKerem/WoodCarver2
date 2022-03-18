using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class finishObject : MonoBehaviour
{
    [SerializeField] ToplanmaYeri toplanmaYeri;
    [SerializeField] PlayerSettings settings;
    Transform ghost;
    Transform buildObejct;

    private void Start()
    {
        ghost = transform.GetChild(0).GetChild(settings.howManyObjectsOpend).transform;
        buildObejct = transform.GetChild(1).GetChild(settings.howManyObjectsOpend).transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer(Layers.collectWood))
        {
            toplanmaYeri.ObjectControl();
            Destroy(other.gameObject);
            if (ghost.localScale.x > buildObejct.localScale.x)
            {
                buildObejct.DOScaleX(buildObejct.localScale.x + ghost.localScale.x / 5f, 0.1f);
            }

            else if (ghost.localScale.y > buildObejct.localScale.y)
            {
                buildObejct.DOScaleY(buildObejct.localScale.y + ghost.localScale.y / 5f, 0.1f);

            }

            else if (ghost.localScale.z > buildObejct.localScale.z)
            {
                buildObejct.DOScaleZ(buildObejct.localScale.z + ghost.localScale.z / 5f, 0.1f);

            }
        }
    }
}
