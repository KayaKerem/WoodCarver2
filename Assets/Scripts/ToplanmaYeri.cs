using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToplanmaYeri : MonoBehaviour
{
    [SerializeField] WoodScript spawnwood;
    [SerializeField] GameObject portal;
    [SerializeField] Transform spawnWoodT;

    private GameManager manager;
    private PlayerSettings settings;
    private WoodStack woodStack;
    private bool activePortal;
    private int InstantieModelIndex;
    private Models modeller;
    public GameObject[] ayaklar;

    void Start()
    {
        activePortal = false;
        woodStack = FindObjectOfType<WoodStack>();
        manager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!activePortal)
        {
            InstantieModelIndex = manager.InstantieWood();
            PortalActive(true);
        }
        if(other.gameObject.layer == LayerMask.NameToLayer(Layers.collectWood))
        {
            WoodScript wood = other.GetComponent<WoodScript>();
            EventManager.Event_OnLastScore(wood.WoodPuan);
            woodStack.DropWood(wood);

            return;
        }
        woodStack.EnableIsPlay(false);
        InstantieteModel();

    }

    public void InstantieteModel()
    {
        modeller = FindObjectOfType<Models>();

        if(InstantieModelIndex >= modeller.Modeller.Length)
        {
            InstantieModelIndex = modeller.Modeller.Length - 1;
        }
        print(InstantieModelIndex);
        GameObject _wood = Instantiate(spawnwood.gameObject,spawnWoodT.position,Quaternion.identity);
        _wood.SetActive(false);
        WoodScript wood = _wood.GetComponent<WoodScript>();
        wood.SpawnModel(InstantieModelIndex);
        PortalActive(false);
        _wood.SetActive(true);

        ChangeAyaklar(_wood);
    }

    private void ChangeAyaklar(GameObject model)
    {
        for (int i = 0; i < 2; i++)
        {
            Vector3 pos =  ayaklar[i].transform.position;
            Destroy(ayaklar[i].gameObject);
            ayaklar[i] = Instantiate(model, pos , Quaternion.identity);
        }
    }

    private void PortalActive(bool value)
    {
        portal.SetActive(value);
        activePortal = value;
    }
}
