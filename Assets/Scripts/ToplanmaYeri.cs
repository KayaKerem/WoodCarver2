using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;
using Cinemachine;

public class ToplanmaYeri : MonoBehaviour
{
    OyunSonu oyunSonu;
    Transform woodM1, woodM2, woodM3, woodM4, woodM5, scoreTransform;
    [SerializeField] List<Transform> stackTransform = new List<Transform>(); // Kanka buraya parçalarýn stackleneceði tranformlarý atacaz sýralamasý önemli olur düzgün gözükmesi için
    public Transform positionToGo;
    bool start = false;

    List<GameObject> woodsM1 = new List<GameObject>();
    List<GameObject> woodsM2 = new List<GameObject>();
    List<GameObject> woodsM3 = new List<GameObject>();
    List<GameObject> woodsM4 = new List<GameObject>();
    List<GameObject> woodsM5 = new List<GameObject>();
    bool objectFinished;


    private GameManager manager;
    [SerializeField] private PlayerSettings settings;
    private WoodStack woodStack;
    private bool allowCorutine = false;
    int hit;

    void Start()
    {
        woodStack = FindObjectOfType<WoodStack>();
        manager = FindObjectOfType<GameManager>();
        oyunSonu = GetComponent<OyunSonu>();
        hit = 0;


        //KANKA aþaðýdaki yorum satýrýnda normalde bitirdiðimiz objeleri aktif ediyordum buna yeni bir çözüm bulmamýz gerekli çümkü yaptýðýmýz objeleri desenlerini felan atayacaðýz



        //if (settings.howManyObjectsOpend < objectsToBuild.Count)
        //{
        //    switch (settings.howManyObjectsOpend)
        //    {
        //        case 1:
        //            objectsToBuild[0].SetActive(false);
        //            objectsToBuildsToGo[0].gameObject.SetActive(true);
        //            objectsToBuildsToGo[0].transform.localScale = objectsToBuild[0].transform.localScale;
        //            objectsToBuildsToGo[0].GetComponent<BoxCollider>().enabled = false;
        //            break;
        //        case 2:
        //            objectsToBuild[1].SetActive(false);
        //            objectsToBuild[0].SetActive(false);
        //            objectsToBuildsToGo[0].gameObject.SetActive(true);
        //            objectsToBuildsToGo[0].transform.localScale = objectsToBuild[0].transform.localScale;
        //            objectsToBuildsToGo[0].GetComponent<BoxCollider>().enabled = false;
        //            objectsToBuildsToGo[1].gameObject.SetActive(true);
        //            objectsToBuildsToGo[1].transform.localScale = objectsToBuild[1].transform.localScale;
        //            objectsToBuildsToGo[1].GetComponent<BoxCollider>().enabled = false;
        //            break;
                
        //    }
        //}

        positionToGo = oyunSonu.ObjectToBuild().transform.GetChild(1).transform;
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
                    break;

                case 1:
                    EventManager.Event_OnLastScore(x.WoodPuan);
                    x.transporter.woods.Remove(x);
                    other.gameObject.transform.parent = null;

                    if (woodM1 == null)
                    {
                        woodM1 = stackTransform[0];
                        stackTransform.Remove(woodM1);
                    }

                    if (woodM1 != null)
                    {
                        other.gameObject.transform.DOLocalMove(new Vector3(woodM1.position.x, woodM1.position.y + woodsM1.Count / 2f, woodM1.position.z), 0.5f);
                        other.gameObject.transform.DORotate(new Vector3(0, 0, -90), 0.5f);
                        woodsM1.Add(other.gameObject);
                        return;
                    }
                   
                    
                    break;

                case 2:
                    EventManager.Event_OnLastScore(x.WoodPuan);
                    x.transporter.woods.Remove(x);
                    other.gameObject.transform.parent = null;
                    if (woodM2 == null)
                    {
                        woodM2 = stackTransform[0];
                        stackTransform.Remove(woodM2);

                    }
                    if (woodM2 != null)
                    {
                        other.gameObject.transform.DOMove(new Vector3(woodM2.position.x, woodM2.position.y + woodsM2.Count / 3.33f, woodM2.position.z), 0.5f);
                        other.gameObject.transform.DORotate(new Vector3(0, 0, -90), 0.5f);
                        woodsM2.Add(other.gameObject);
                    }
                    break;

                case 3:
                    EventManager.Event_OnLastScore(x.WoodPuan);
                    x.transporter.woods.Remove(x);
                    other.gameObject.transform.parent = null;

                    if (woodM3 == null)
                    {
                        woodM3 = stackTransform[0];
                        stackTransform.Remove(woodM3);
                    }

                    if (woodM3 != null)
                    {
                        other.gameObject.transform.DOMove(new Vector3(woodM3.position.x, woodM3.position.y + woodsM4.Count / 3.33f, woodM3.position.z), 0.5f);
                        other.gameObject.transform.DORotate(new Vector3(0, 0, -90), 0.5f);
                        woodsM3.Add(other.gameObject);
                    }
                    break;
                
                case 4:
                    EventManager.Event_OnLastScore(x.WoodPuan);
                    x.transporter.woods.Remove(x);
                    other.gameObject.transform.parent = null;
                    if (woodM4 == null)
                    {
                        woodM4 = stackTransform[0];
                        stackTransform.Remove(woodM4);
                    }
                    if (woodM4 != null)
                    {
                        other.gameObject.transform.DOMove(new Vector3(woodM4.position.x, woodM4.position.y + woodsM4.Count / 3.33f, woodM4.position.z), 0.5f);
                        other.gameObject.transform.DORotate(new Vector3(0, 0, -90), 0.5f);
                        woodsM4.Add(other.gameObject);
                    }
                    break; 
                
                case 5:
                    EventManager.Event_OnLastScore(x.WoodPuan);
                    x.transporter.woods.Remove(x);
                    other.gameObject.transform.parent = null;
                    if (woodM5 == null)
                    {
                        woodM5 = stackTransform[0];
                        stackTransform.Remove(woodM5);
                    }
                    if (woodM5 != null)
                    {
                        other.gameObject.transform.DOMove(new Vector3(woodM5.position.x, woodM5.position.y + woodsM5.Count / 3.33f, woodM5.position.z), 0.5f);
                        other.gameObject.transform.DORotate(new Vector3(0, 0, -90), 0.5f);
                        woodsM5.Add(other.gameObject);
                    }
                    break;
            }  // kanka burda burda deðen objenin indeksine göre sýrayla listedeki transformlarý atýyorum

            
        }

        if (other.gameObject.CompareTag("Player"))
        {
            woodStack.EnableIsPlay(false);
            allowCorutine = true;
            EventManager.Event_OnCharacterAnimControl(false,AnimName.CharacterRunnig);  //Karakter Aniamsyon kapanmasý
        }
    }

    IEnumerator ObjectCreate()
    {
        allowCorutine = false;
        yield return new WaitForSeconds(1);
        oyunSonu.ObjectToBuild().transform.GetChild(1).GetChild(settings.howManyObjectsOpend).gameObject.SetActive(true);
        while (woodsM1.Count != 0 || woodsM2.Count != 0 || woodsM3.Count != 0 || woodsM4.Count != 0 || woodsM5.Count != 0)
        {

            if (woodsM1.Count != 0)
            {
                woodsM1.Last().transform.DOMove(positionToGo.position, 0.2f);
                woodsM1.Last().transform.DORotate(new Vector3(0, 0, 90), 0.5f);
                woodsM1.Remove(woodsM1.Last().gameObject);
            }

            if (woodsM2.Count != 0)
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
        } // buradada ayný stacklediðimiz malzemelerin yapýlacak objeye gtmesini saðlýyoruz
        oyunSonu.startMove = true;
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
            oyunSonu.ObjectToBuild().transform.GetChild(0).GetChild(settings.howManyObjectsOpend).gameObject.SetActive(false);
            positionToGo = GameObject.FindGameObjectWithTag("x").transform;
            settings.howManyObjectsOpend++;
            if (settings.howManyObjectsOpend == 3)
            {
                objectFinished = true;
                StartCoroutine(FinishMove());
            }
        } // kanka 5 tane obje yapýalcak sandalyaye gidince odunlar  canvastaki scora doðru gidiyor  ve sandalyenini geri dönme iþlemini baþlatýyoruz
    }

    IEnumerator FinishMove()
    {
        yield return new WaitForSeconds(2);
        oyunSonu.startMove = false;
    }

}
