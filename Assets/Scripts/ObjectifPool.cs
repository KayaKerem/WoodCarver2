using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectifPool : MonoBehaviour
{
    static public ObjectifPool singleton;

    public List<Model> poolModel;
    Dictionary<string, List<GameObject>> poolModelDictionary = new Dictionary<string, List<GameObject>>();


    /// <summary>
    /// Model Parentler Oyun için
    /// </summary>

    [SerializeField] Transform treeModelParent;
  
    void Start()
    {
        singleton = this;

        for (int i = 0; i < poolModel.Count; i++)
        {
            if (!poolModelDictionary.ContainsKey(poolModel[i].isim)){

                poolModelDictionary.Add(poolModel[i].isim,new List<GameObject>());
            }
            for (int y = 0; y < poolModel[i].sayisi; y++)
            {
                GameObject model = Instantiate(poolModel[i].gameObject, treeModelParent);
                model.SetActive(false);
                poolModelDictionary[poolModel[i].isim].Add(model);
            }
        }

    }

    public GameObject getModel(string modelName)
    {

        if(poolModelDictionary.ContainsKey(modelName))
        {

            if(poolModelDictionary[modelName].Count > 0)
            {
                GameObject model = poolModelDictionary[modelName].Last();
                poolModelDictionary[modelName].RemoveAt(poolModelDictionary[modelName].Count - 1);

                return model;

            }else{
                Model model = poolModel.Find(x => x.isim == modelName);
                
                GameObject newModel = Instantiate(model.gameObject, treeModelParent);

                return newModel;
            }

        }

        Debug.LogWarning(modelName + " model ismi listede bulunamadý knk");
        return null;
    }

    public void ReturnModel(string modelName,GameObject gameObject)
    {
        gameObject.SetActive(false);
        poolModelDictionary[modelName].Add(gameObject);

    }

}

[System.Serializable]
public class Model
{
    public string isim;
    public GameObject gameObject;
    public int sayisi;
}