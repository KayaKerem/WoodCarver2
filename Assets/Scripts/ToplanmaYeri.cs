using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;

public class ToplanmaYeri : MonoBehaviour
{
    [SerializeField] WoodScript spawnwood;
    [SerializeField] GameObject portal;
    [SerializeField] Transform spawnWoodT;
    [SerializeField] Transform woodM1;
    [SerializeField] Transform woodM2;
    [SerializeField] Transform woodM3;


    List<GameObject> woodsM1 = new List<GameObject>();
    List<GameObject> woodsM2 = new List<GameObject>();
    List<GameObject> woodsM3 = new List<GameObject>();
    [SerializeField] List<GameObject> objectsToBuild = new List<GameObject>();
    [SerializeField] List<GameObject> objectsToBuildsToGo = new List<GameObject>();


    private GameManager manager;
    [SerializeField] private PlayerSettings settings;
    private WoodStack woodStack;
    private bool allowCorutine = false;
    public GameObject[] ayaklar;

    //private int InstantieModelIndex;
    //private Models modeller;
    void Start()
    {
        woodStack = FindObjectOfType<WoodStack>();
        manager = FindObjectOfType<GameManager>();
    }
    private void Update()
    {
        if (!settings.isPlaying && allowCorutine)
        {
            objectsToBuild[0].SetActive(true);
            StartCoroutine(ObjectCreate());
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //if (!activePortal)
        //{
        //    InstantieModelIndex = manager.InstantieWood();
        //    PortalActive(true);
        //}

        if (other.gameObject.layer == LayerMask.NameToLayer(Layers.collectWood))
        {

            WoodScript x = other.gameObject.GetComponent<WoodScript>();
            EventManager.Event_OnLastScore(x.WoodPuan);
            switch (x.modelindex)
            {
                case 0:
                    x.transporter.woods.Remove(x);
                    x.transporter = null;
                    other.gameObject.transform.parent = null;
                    other.gameObject.transform.DOLocalMove(new Vector3(woodM1.position.x, woodM1.position.y + woodsM1.Count / 2f, woodM1.position.z), 0.5f);
                    other.gameObject.transform.DORotate(new Vector3(0, 0, -90), 0.5f);
                    woodsM1.Add(other.gameObject);
                    break;
                case 1:
                    x.transporter.woods.Remove(x);
                    x.transporter = null;
                    other.gameObject.transform.parent = null;
                    other.gameObject.transform.DOLocalMove(new Vector3(woodM2.position.x, woodM2.position.y + woodsM2.Count / 2f, woodM2.position.z), 0.5f);
                    other.gameObject.transform.DORotate(new Vector3(0, 0, -90), 0.5f);
                    woodsM2.Add(other.gameObject);
                    break;
                case 2:
                    x.transporter.woods.Remove(x);
                    x.transporter = null;
                    other.gameObject.transform.parent = null;
                    other.gameObject.transform.DOMove(new Vector3(woodM3.position.x, woodM3.position.y + woodsM3.Count / 3.33f, woodM3.position.z), 0.5f);
                    other.gameObject.transform.DORotate(new Vector3(0, 0, -90), 0.5f);
                    woodsM3.Add(other.gameObject);
                    break;
            }
            
            //woodStack.DropWood(wood);

            //return;
        }

        if (other.gameObject.CompareTag("Player"))
        {
            woodStack.EnableIsPlay(false);
            allowCorutine = true;
            EventManager.Event_OnLevelFinish();
            EventManager.Event_OnCharacterAnimControl(false);  //Karakter Aniamsyon kapanmasý
        }

        //woodStack.EnableIsPlay(false);

        //InstantieteModel();


    }
    private void ChangeAyaklar(GameObject model)
    {
        for (int i = 0; i < 2; i++)
        {
            Vector3 pos = ayaklar[i].transform.position;
            Destroy(ayaklar[i].gameObject);
            ayaklar[i] = Instantiate(model, pos, Quaternion.identity);
        }
    }

    //public void InstantieteModel()
    //{
    //    modeller = FindObjectOfType<Models>();

    //    if (InstantieModelIndex >= modeller.Modeller.Length)
    //    {
    //        InstantieModelIndex = modeller.Modeller.Length - 1;
    //    }
    //    print(InstantieModelIndex);
    //    GameObject _wood = Instantiate(spawnwood.gameObject, spawnWoodT.position, Quaternion.identity);
    //    _wood.SetActive(false);
    //    WoodScript wood = _wood.GetComponent<WoodScript>();
    //    wood.SpawnModel(InstantieModelIndex);
    //    _wood.SetActive(true);

    //    ChangeAyaklar(_wood);
    //}



    IEnumerator ObjectCreate()
    {
        allowCorutine = false;
        yield return new WaitForSeconds(1);
        while (woodsM1.Count != 0 || woodsM2.Count != 0 || woodsM3.Count != 0)
        {
            if (woodsM1.Count != 0)
            {
                woodsM1.Last().transform.DOMove(objectsToBuild[0].transform.position, 0.5f);
                woodsM1.Last().transform.DORotate(new Vector3(0,0,90), 0.5f);
                woodsM1.Remove(woodsM1.Last().gameObject);
            }

            if (woodsM2.Count != 0)
            {
                woodsM2.Last().transform.DOMove(objectsToBuild[0].transform.position, 0.5f);
                woodsM2.Last().transform.DORotate(new Vector3(0, 0, 90), 0.5f);
                woodsM2.Remove(woodsM2.Last().gameObject);
            }

            if (woodsM3.Count != 0)
            {
                woodsM3.Last().transform.DOMove(objectsToBuild[0].transform.position, 0.5f);
                woodsM3.Last().transform.DORotate(new Vector3(0, 0, 90), 0.5f);
                woodsM3.Remove(woodsM3.Last().gameObject);
            }
            yield return new WaitForSeconds(0.2f);

        }
        allowCorutine = true;   
    }
   
}
