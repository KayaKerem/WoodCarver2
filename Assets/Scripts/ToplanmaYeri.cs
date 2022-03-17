using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;
using Cinemachine;

public class ToplanmaYeri : MonoBehaviour
{
    CinemachineVirtualCamera vcam;
    [SerializeField] WoodScript spawnwood;
    [SerializeField] GameObject portal;
    [SerializeField] Transform spawnWoodT;
    [SerializeField] Transform woodM1, woodM2, woodM3, woodM4, woodM5, scoreTransform;
    public Transform positionToGo;
    bool start = false;

    List<GameObject> woodsM1 = new List<GameObject>();
    List<GameObject> woodsM2 = new List<GameObject>();
    List<GameObject> woodsM3 = new List<GameObject>();
    List<GameObject> woodsM4 = new List<GameObject>();
    List<GameObject> woodsM5 = new List<GameObject>();
    public List<GameObject> objectsToBuild = new List<GameObject>();
    public List<GameObject> objectsToBuildsToGo = new List<GameObject>();

    [SerializeField] Transform finishedObjectTransformTogo;
    [SerializeField] GameObject finishedObject;
    [SerializeField] GameObject Confetti;
    bool objectFinished;
    [SerializeField] GameObject tranparent;


    private GameManager manager;
    [SerializeField] private PlayerSettings settings;
    private WoodStack woodStack;
    private bool allowCorutine = false;
    public GameObject[] ayaklar;
    private GameObject currentObject;
    int hit;
    public int toplamAcilanObje;


    //private int InstantieModelIndex;
    //private Models modeller;

    void Start()
    {
        woodStack = FindObjectOfType<WoodStack>();
        manager = FindObjectOfType<GameManager>();
        hit = 0;

        //ObjectControl();

        if (settings.howManyObjectsOpend < objectsToBuild.Count)
        {
            switch (settings.howManyObjectsOpend)
            {
                case 1:
                    objectsToBuild[0].SetActive(false);
                    objectsToBuildsToGo[0].gameObject.SetActive(true);
                    objectsToBuildsToGo[0].transform.localScale = objectsToBuild[0].transform.localScale;
                    objectsToBuildsToGo[0].GetComponent<BoxCollider>().enabled = false;
                    break;
                case 2:
                    objectsToBuild[1].SetActive(false);
                    objectsToBuild[0].SetActive(false);
                    objectsToBuildsToGo[0].gameObject.SetActive(true);
                    objectsToBuildsToGo[0].transform.localScale = objectsToBuild[0].transform.localScale;
                    objectsToBuildsToGo[0].GetComponent<BoxCollider>().enabled = false;
                    objectsToBuildsToGo[1].gameObject.SetActive(true);
                    objectsToBuildsToGo[1].transform.localScale = objectsToBuild[1].transform.localScale;
                    objectsToBuildsToGo[1].GetComponent<BoxCollider>().enabled = false;
                    break;
                
            }
        }

        currentObject = objectsToBuildsToGo[toplamAcilanObje];

        toplamAcilanObje = settings.howManyObjectsOpend;
        positionToGo = objectsToBuildsToGo[toplamAcilanObje].transform;

        //else if (settings.howManyObjectsOpend >= objectsToBuild.Count)
        //{
        //    settings.howManyObjectsOpend = 0;
        //}
    }

    private void Update()
    {
        if (!settings.isPlaying && allowCorutine)
        {
            //objectsToBuild[0].SetActive(true);
            StartCoroutine(ObjectCreate());

        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer(Layers.collectWood))
        {
            WoodScript x = other.gameObject.GetComponent<WoodScript>();
            switch (x.tagIndex)
            {
                case 0:
                    x.transporter.woods.Remove(x);
                    other.gameObject.transform.parent = null;
                    other.gameObject.transform.DOLocalMove(new Vector3(transform.position.x + 10, transform.position.y, transform.position.z), 0.5f);
                    Destroy(other.gameObject, 2);
                    //other.gameObject.transform.DORotate(new Vector3(0, 0, -90), 0.5f);
                    //woodsM1.Add(other.gameObject);
                    break;
                case 1:
                    EventManager.Event_OnLastScore(x.WoodPuan);
                    x.transporter.woods.Remove(x);
                    other.gameObject.transform.parent = null;
                    other.gameObject.transform.DOLocalMove(new Vector3(woodM1.position.x, woodM1.position.y + woodsM1.Count / 2f, woodM1.position.z), 0.5f);
                    other.gameObject.transform.DORotate(new Vector3(0, 0, -90), 0.5f);
                    woodsM1.Add(other.gameObject);
                    break;
                case 2:
                    EventManager.Event_OnLastScore(x.WoodPuan);
                    x.transporter.woods.Remove(x);
                    other.gameObject.transform.parent = null;
                    other.gameObject.transform.DOMove(new Vector3(woodM2.position.x, woodM2.position.y + woodsM2.Count / 3.33f, woodM2.position.z), 0.5f);
                    other.gameObject.transform.DORotate(new Vector3(0, 0, -90), 0.5f);
                    woodsM2.Add(other.gameObject);
                    break;

                case 3:
                    EventManager.Event_OnLastScore(x.WoodPuan);
                    x.transporter.woods.Remove(x);
                    other.gameObject.transform.parent = null;
                    other.gameObject.transform.DOMove(new Vector3(woodM3.position.x, woodM3.position.y + woodsM4.Count / 3.33f, woodM3.position.z), 0.5f);
                    other.gameObject.transform.DORotate(new Vector3(0, 0, -90), 0.5f);
                    woodsM3.Add(other.gameObject);
                    break;
                
                
                case 4:
                    EventManager.Event_OnLastScore(x.WoodPuan);
                    x.transporter.woods.Remove(x);
                    other.gameObject.transform.parent = null;
                    other.gameObject.transform.DOMove(new Vector3(woodM4.position.x, woodM4.position.y + woodsM4.Count / 3.33f, woodM4.position.z), 0.5f);
                    other.gameObject.transform.DORotate(new Vector3(0, 0, -90), 0.5f);
                    woodsM4.Add(other.gameObject);
                    break; 
                
                case 5:
                    EventManager.Event_OnLastScore(x.WoodPuan);
                    x.transporter.woods.Remove(x);
                    other.gameObject.transform.parent = null;
                    other.gameObject.transform.DOMove(new Vector3(woodM5.position.x, woodM5.position.y + woodsM5.Count / 3.33f, woodM5.position.z), 0.5f);
                    other.gameObject.transform.DORotate(new Vector3(0, 0, -90), 0.5f);
                    woodsM5.Add(other.gameObject);
                    break;
            }

            //woodStack.DropWood(wood);

            //return;
        }

        if (other.gameObject.CompareTag("Player"))
        {
            woodStack.EnableIsPlay(false);
            allowCorutine = true;
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

    bool tamamlanmadi = false;

    IEnumerator ObjectCreate()
    {
        allowCorutine = false;
        yield return new WaitForSeconds(1);
        objectsToBuildsToGo[toplamAcilanObje].SetActive(true);
        while (woodsM1.Count != 0 || woodsM2.Count != 0 || woodsM3.Count != 0 || woodsM4.Count != 0)
        {

            if (woodsM1.Count != 0)
            {
                woodsM1.Last().transform.DOMove(positionToGo.position, 0.2f);
                woodsM1.Last().transform.DORotate(new Vector3(0, 0, 90), 0.5f);
                woodsM1.Remove(woodsM1.Last().gameObject);
            }

            if (woodsM2.Count != 0)
            {
                woodsM1.Last().transform.DOMove(positionToGo.position, 0.2f);
                woodsM1.Last().transform.DORotate(new Vector3(0, 0, 90), 0.5f);
                woodsM1.Last().transform.DOScale(woodsM1.Last().transform.localScale / 2, 0.5f);
                woodsM1.Remove(woodsM2.Last().gameObject);

            } if (woodsM2.Count != 0)
            {
                woodsM2.Last().transform.DOMove(positionToGo.position, 0.2f);
                woodsM2.Last().transform.DORotate(new Vector3(0, 0, 90), 0.5f);
                woodsM2.Last().transform.DOScale(woodsM4.Last().transform.localScale / 2, 0.5f);
                woodsM2.Remove(woodsM2.Last().gameObject);
            }

            if (woodsM3.Count != 0)
            {
                woodsM3.Last().transform.DOMove(positionToGo.position, 0.2f);
                woodsM3.Last().transform.DORotate(new Vector3(0, 0, 90), 0.5f);
                woodsM3.Last().transform.DOScale(woodsM4.Last().transform.localScale / 2, 0.5f);
                woodsM3.Remove(woodsM3.Last().gameObject);
            }

            if (woodsM4.Count != 0)
            {
                woodsM4.Last().transform.DOMove(positionToGo.position, 0.2f);
                woodsM4.Last().transform.DORotate(new Vector3(0, 0, 90), 0.5f);
                woodsM4.Last().transform.DOScale(woodsM4.Last().transform.localScale / 2, 0.5f);
                woodsM4.Remove(woodsM4.Last().gameObject);
            }
            
            if (woodsM5.Count != 0)
            {
                woodsM5.Last().transform.DOMove(positionToGo.position, 0.2f);
                woodsM5.Last().transform.DORotate(new Vector3(0, 0, 90), 0.5f);
                woodsM5.Last().transform.DOScale(woodsM5.Last().transform.localScale / 2, 0.5f);
                woodsM5.Remove(woodsM4.Last().gameObject);
            }




            yield return new WaitForSeconds(0.2f);
        }
        if (!objectFinished)
        {
            EventManager.Event_OnLevelFinish();
        }
        allowCorutine = true;
    }

    public void ObjectControl()
    {
        hit += 1;
        if (hit == 5)
        {
            start = true;
            objectsToBuild[toplamAcilanObje].SetActive(false);
            positionToGo = GameObject.FindGameObjectWithTag("x").transform;
            //positionToGo.transform.GetComponent<BoxCollider>().enabled = false;
            settings.howManyObjectsOpend++;
            if (settings.howManyObjectsOpend == 3)
            {
                objectFinished = true;
                StartCoroutine(FinishMove());

            }
        }
        //else if (hit < 5)
        //{
        //}
    }

    IEnumerator FinishMove()
    {
        yield return new WaitForSeconds(2);
        finishedObject.transform.DOMove(finishedObjectTransformTogo.position, 1f).OnComplete(onComplite);
        finishedObject.transform.DOScale(finishedObject.transform.localScale / 2.5f, 1f);
    }

    private void onComplite()
    {
        finishedObject.transform.DOPunchScale(finishedObject.transform.localScale * 1.2f, 0.5f, 1);
        Instantiate(Confetti, new Vector3(finishedObjectTransformTogo.position.x, finishedObjectTransformTogo.position.y, finishedObjectTransformTogo.position.z - 3), Quaternion.identity);
        Destroy(tranparent);
        Invoke("finishLevel", 1.5f);
        settings.howManyObjectsOpend = 0;
        //settings.index++;
    }

    void finishLevel()
    {
        EventManager.Event_OnLevelFinish();

    }

}
