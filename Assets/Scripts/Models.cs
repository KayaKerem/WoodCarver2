using System.Collections.Generic;
using UnityEngine;

public class Models : MonoBehaviour
{
	[SerializeField] PlayerSettings settings;

    public List<ModelParts> modelParts = new List<ModelParts>();

    public GameObject[] Modeller;


    private void Awake()
    {
        switch (settings.howManyObjectsOpend)
        {
            case 0:
                Modeller[2] = modelParts[settings.index].models[0]; //bacaðý  1 masanýn mcaðaý
                break;
            case 1:
                Modeller[2] = modelParts[settings.index].models[1]; //oturaj
                break;
            case 2:
                Modeller[2] = modelParts[settings.index].models[2]; //arkasý
                break;
        }
    }


}

[System.Serializable]
public class ModelParts
{
    public GameObject buildObje;
    public List<GameObject> models = new List<GameObject>();

}

