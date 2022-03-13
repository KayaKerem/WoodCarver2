using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Doors : MonoBehaviour
{
    //public UnityEvent<string> UpgradeModel;
    //public UnityEvent<int> IncreaseScore;
    [SerializeField] int doorNumber;
    [SerializeField] Material material;
    [SerializeField] GameObject cutParticul;
    Coroutine falseParticul;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer(Layers.collectWood))
        {
            WoodScript wood = other.GetComponent<WoodScript>();

            if((wood.gameObject.tag == Tags.taglar[0]) && doorNumber == 1)
            {
                wood.UpGrade(transform.gameObject.name);
                cutParticul.SetActive(true);
                if (falseParticul == null)
                {
                    falseParticul = StartCoroutine(FalseParticul());
                }

                else if (falseParticul != null)
                {
                    StopCoroutine(FalseParticul());
                    falseParticul = null;
                }
            }

            else if ((wood.gameObject.tag == Tags.taglar[1]) && doorNumber == 2)
            {
                wood.ChangeMaterial(material);
                other.gameObject.tag = Tags.taglar[2];
            }

            else if((wood.gameObject.tag == Tags.taglar[2]) && doorNumber == 3)
            {
                wood.Polish(material);
            }
        }
    }

    IEnumerator FalseParticul()
    {
        yield return new WaitForSeconds(2f);
        cutParticul.SetActive(false);
    }
}
