using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEditor;

public class OyunSonu : MonoBehaviour
{
    Models models;
    [SerializeField] PlayerSettings settings;
    List<GameObject> ghosts = new List<GameObject>();
    [SerializeField] List<List<ModelParts>> oyunSonu = new List<List<ModelParts>>();
    Vector3 firstPoint;
    [SerializeField] Transform pointToGo;
    [SerializeField] GameObject puff;

    public string matName;
    public bool startMove
    {
        set
        {
            _startMove = value;
            if (value)
            {
                MoveToPoint();
            }
            else GetBack();
        }
        get { return _startMove; }
    }
    bool _startMove;
   
    void Start()
    {
        //Invoke("StartSetup", 0.5f);
        models = GameObject.Find("Modeller").GetComponent<Models>();
        ObjectToBuild();
        StartSetup();
        if (settings.index == 0 && settings.howManyObjectsOpend != 0)
        {
            models.modelParts[0].buildObje.transform.GetChild(1).GetChild(settings.howManyObjectsOpend - 1).gameObject.SetActive(true);
            models.modelParts[0].buildObje.transform.GetChild(0).GetChild(settings.howManyObjectsOpend - 1).gameObject.SetActive(false);
        }
        
    }


    public GameObject ObjectToBuild()
    {
        GameObject obje = models.modelParts[settings.index].buildObje;
        return obje;
    }

    void MoveToPoint()
    {
        firstPoint = ObjectToBuild().transform.position;
        ObjectToBuild().transform.DOMove(pointToGo.position, 0.5f);
    }

    void GetBack()
    {
        ObjectToBuild().transform.DOMove(firstPoint, 0.5f).OnComplete(ComplateObject);
    }

    void ComplateObject()
    {
        if (settings.howManyObjectsOpend == 3)
        {
            ObjectToBuild().transform.DOPunchScale(ObjectToBuild().transform.localScale * 1.5f, 0.5f, 1).OnComplete(OnComplite);
            Instantiate(puff, ObjectToBuild().transform.position, Quaternion.identity);
        }
        else InvokeFinish();
    }

    void OnComplite()
    {
        
        InvokeFinish();
    }

    void InvokeFinish()
    {
        Invoke("FinishScren", 1.5f);

    }
    void FinishScren()
    {
        EventManager.Event_OnLevelFinish();
    }

    void StartSetup()
    {
        
            for (int i = 0; i <= settings.index; i++)
            {
                GameObject obje = models.modelParts[i].buildObje;
                if (settings.index != i)
                {
                    for (int j = 0; j < obje.transform.GetChild(0).childCount; j++)
                    {
                        string name = i.ToString() + "." + j.ToString() + ".mat";
                        obje.transform.GetChild(1).GetChild(j).localScale = obje.transform.GetChild(0).GetChild(j).localScale;
                        obje.transform.GetChild(1).GetChild(j).gameObject.SetActive(true);
                        obje.transform.GetChild(1).GetChild(j).GetComponent<Renderer>().material = (Material)AssetDatabase.LoadAssetAtPath("Assets/InGameMaterial/" + name, typeof(Material));
                    }
                    obje.transform.GetChild(0).gameObject.SetActive(false);
                }
                else
                {
                    for (int j = 0; j < settings.howManyObjectsOpend; j++)
                    {
                        string name = 0.ToString() + "." + j.ToString() + ".mat";
                        obje.transform.GetChild(1).GetChild(j).localScale = obje.transform.GetChild(0).GetChild(j).localScale;
                        obje.transform.GetChild(1).GetChild(j).gameObject.SetActive(true);
                        obje.transform.GetChild(0).GetChild(j).gameObject.SetActive(false);
                        obje.transform.GetChild(1).GetChild(j).GetComponent<Renderer>().material = (Material)AssetDatabase.LoadAssetAtPath("Assets/InGameMaterial/" + name, typeof(Material));
                    }
                }
                
            }
        
        //else
        //{
        //    if (settings.howManyObjectsOpend != 0)
        //    {
        //        GameObject obje = models.modelParts[0].buildObje;
        //        for (int j = 0; j < settings.howManyObjectsOpend; j++)
        //        {
        //            string name = 0.ToString() + "." + j.ToString() + ".mat";
        //            obje.transform.GetChild(1).GetChild(j).localScale = obje.transform.GetChild(0).GetChild(j).localScale;
        //            obje.transform.GetChild(1).GetChild(j).gameObject.SetActive(false);
        //            obje.transform.GetChild(1).GetChild(j).GetComponent<Renderer>().material = (Material)AssetDatabase.LoadAssetAtPath("Assets/InGameMaterial/" + name, typeof(Material));
        //        }
        //    }
        //}
    }
}
