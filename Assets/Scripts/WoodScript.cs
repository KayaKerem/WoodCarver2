using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using System.Linq;

public class WoodScript : MonoBehaviour
{
    //[SerializeField] ObjectifPool objectPool;
    [SerializeField] Transform ModelContainerT;
    [SerializeField] GameObject destroyableTree;
    //[SerializeField] GameObject Cila;
    [SerializeField] Animator Animator;

    public ParticleSystem explosionEffect;
    public int modelindex;
    public int WoodPuan;
    [SerializeField] GameObject particul;
    public WoodStack transporter { set {
            _transporter = value;
            if(value == null)
            {
                ModelContainerT.localScale = new Vector3(1f, 1f, 1f);
                AnimPlay(false); 
            }
        } 
        get { return _transporter; } }

    private WoodStack _transporter;

    private List<string> DoorsName;
    private Collider MyCollider;
    private Models modeller;
    private GameObject Model;

    private void Start()
    {
        modeller = FindObjectOfType<Models>();
        MyCollider = GetComponent<Collider>();
        DoorsName = new List<string>();

        WoodPuan = modelindex + 1;

        //SpawnModel(modelindex);
        AnimPlay(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer(Layers.wood))
        {
            EventManager.Event_OnWoodAdded(other.GetComponent<WoodScript>());
        }
        if((other.gameObject.layer == LayerMask.NameToLayer(Layers.obstacle)) && transporter != null)
        {
            transporter.DropWood(this);
        }
    }

    public void SpawnModel(int indexModel = 0)
    {
        if (modeller == null) modeller = FindObjectOfType<Models>();
        modelindex = indexModel;
        gameObject.tag = Tags.taglar[indexModel];
        WoodPuan = modelindex + 1;
        Model = modeller.Modeller[modelindex];
        if (!GameManager.levelFinish)
        {
            if (ModelContainerT.childCount != 0) Destroy(ModelContainerT.GetChild(0)?.gameObject);
        }
        if (ModelContainerT.childCount == 0)
        {
            GameObject model = Instantiate(Model, ModelContainerT);
            model.transform.localPosition = Vector3.zero;

        }
    }

    public void AnimPlay(bool value)
    {
        Animator.SetBool("IdleAnim", value);
        if (!value)
        {
            ModelContainerT.localRotation = Quaternion.Euler(Vector3.zero);
            ModelContainerT.localPosition = Vector3.zero;
        }
    }
    public void DestRoyWood()
    {
        Instantiate(explosionEffect,transform.position,Quaternion.identity);
        Destroy(this.gameObject);
    }

    public void DropStackList()
    {
        MyCollider.enabled = false;
        Invoke("EnableCollider",1f);
        Vector3 paunch = new Vector3(transform.position.x + Random.Range(2f, -2f), transform.position.y, transform.position.z + Random.Range(1f, 3f));
        transform.DOJump(paunch, 2f, 1, 1f);
    }

    private void EnableCollider()
    {
        MyCollider.enabled = true;
    }

    public void UpGrade(string name)
    {
        if (modeller == null) modeller = FindObjectOfType<Models>();

        if (!DoorsName.Contains(name))
        {
            DoorsName.Add(name);// arda arda etkileþimi engellemek için
            if (modelindex < modeller.Modeller.Length)
            {
                if (modelindex == 0)
                {
                    GameObject parcalananAgac =  ObjectifPool.singleton.getModel("Agac");
                    parcalananAgac.transform.position = transform.position + Vector3.down;
                    parcalananAgac.SetActive(true);
                }
                else if (modelindex == 1)
                {
                    Instantiate(particul, transform.position, Quaternion.identity);
                    gameObject.tag = Tags.taglar[modelindex];
                }
                modelindex++;
                WoodPuan = modelindex;
                Model = modeller.Modeller[modelindex];
                gameObject.tag = Tags.taglar[modelindex];

                if (transform.childCount != 0)
                    {
                        Destroy(transform.GetChild(1).GetChild(0).gameObject);
                        transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
                    Debug.Log(transform.GetChild(1).GetChild(0).gameObject.name);
                    }

                    GameObject model = Instantiate(Model, ModelContainerT);
                model.transform.localPosition = Vector3.zero;
                Animator.enabled = false;
                Animator.enabled = true;
                AnimationScaleWood();
                EventManager.Event_OnIncreaseScore(WoodPuan);
            }
        }
    }


    public void ShakeProcessStart(float waitTime)
    {
        StartCoroutine(AnimTrigger(waitTime));
    }

    IEnumerator AnimTrigger(float time)
    {
        yield return new WaitForSeconds(time);
        AnimationScaleWood();
    }

    public void AnimationScaleWood()
    {
        Animator.Play("ScaleWood");
    }


    public void ChangeMaterial(Material _material)
    {
        WoodPuan += 5;
        gameObject.tag = Tags.taglar[3];
        if (modelindex != 0)
        {
            Material[] mats = ModelContainerT.GetChild(0).GetChild(0).GetComponent<Renderer>().sharedMaterials;
            for (int i = 0; i < mats.Length; i++)
            {
                mats[i] = _material;
            }
            ModelContainerT.GetChild(0).GetChild(0).GetComponent<Renderer>().sharedMaterials = mats;
        }
        AnimationScaleWood();
        EventManager.Event_OnIncreaseScore(WoodPuan);
    }

    public void Polish(Material toPolish)
    {
        WoodPuan += 5;
        gameObject.tag = Tags.taglar[4];
        Material _material =  ModelContainerT.GetChild(0).GetChild(0).GetComponent<Renderer>().material;
        toPolish.color = _material.color;
        Destroy(ModelContainerT.GetChild(0).GetChild(0).GetComponent<Renderer>().material);
        ModelContainerT.GetChild(0).GetChild(0).GetComponent<Renderer>().sharedMaterial = new Material(toPolish);
        transform.GetChild(0).gameObject.SetActive(true);
        AnimationScaleWood();
        EventManager.Event_OnIncreaseScore(WoodPuan);
    }

    public void Pattern(Material _material)
    {

        WoodPuan += 5;
        Renderer rend = ModelContainerT.GetChild(0).GetChild(0).GetComponent<Renderer>();
        _material.color = rend.sharedMaterial.color;
        ModelContainerT.GetChild(0).GetChild(0).GetComponent<Renderer>().sharedMaterial = _material;
        AnimationScaleWood();
        EventManager.Event_OnIncreaseScore(WoodPuan);
    }
}
