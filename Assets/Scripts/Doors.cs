using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Doors : MonoBehaviour
{
    //public UnityEvent<string> UpgradeModel;
    //public UnityEvent<int> IncreaseScore;
    [SerializeField] int doorNumber;
    [SerializeField] PlayerSettings settings;
    [SerializeField] Material material;
    [SerializeField] GameObject cutParticul;
    [SerializeField] Texture patterm;
    [SerializeField] Texture patternMetal;

    Coroutine falseParticul;
    Models modeller;


    private void Start()
    {
        modeller = GameObject.FindObjectOfType<Models>();

    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer(Layers.collectWood))
        {
            WoodScript wood = other.GetComponent<WoodScript>();
            if(modeller == null) material = modeller.modelParts[settings.index].material;

            if ((wood.gameObject.tag == Tags.taglar[0] && doorNumber == 0))
            {
                wood.UpGrade(transform.gameObject.name);

            }else if(wood.gameObject.tag == Tags.taglar[1] && doorNumber == 1)
            {
                wood.UpGrade(transform.gameObject.name);
                ParticleEffect();
            }
            else if ((wood.gameObject.tag == Tags.taglar[2]) && doorNumber == 2)
            {
                wood.UpGrade(transform.gameObject.name, material);
            }
            //else if((wood.gameObject.tag == Tags.taglar[3]) && doorNumber == 3)
            //{
            //    wood.UpGrade(transform.gameObject.name, material);
            //}
            //else if ((wood.gameObject.tag == Tags.taglar[4]) && doorNumber == 4)
            //{
            //    wood.UpGrade(transform.gameObject.name,null,patterm,patternMetal);
            //}
        }
    }

    private void ParticleEffect()
    {
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

    IEnumerator FalseParticul()
    {
        yield return new WaitForSeconds(2f);
        cutParticul.SetActive(false);
    }
}
