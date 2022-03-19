using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OyunSonu : MonoBehaviour
{
    Models models;
    [SerializeField] PlayerSettings settings;
    List<GameObject> ghosts = new List<GameObject>();
    [SerializeField] List<List<ModelParts>> oyunSonu = new List<List<ModelParts>>();
    Vector3 firstPoint;
    [SerializeField] Transform pointToGo;
    [SerializeField] GameObject puff;
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
        models = GameObject.Find("Modeller").GetComponent<Models>();
        ObjectToBuild();
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
        settings.index++;
        settings.howManyObjectsOpend = 0;
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
}
