using System.Collections.Generic;
using UnityEngine;

public class Models : MonoBehaviour
{
	[SerializeField] PlayerSettings settings;

    public List<ModelParts> modelParts = new List<ModelParts>();

    public GameObject[] Modeller;

    private void Start()
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
        

        //switch (settings.index)
        //{
        //    case 0:

        //        switch (settings.howManyObjectsOpend)
        //        {
        //            case 0:
        //                Modeller[2] = Modeller1[0];
        //                break;
        //            case 1:
        //                Modeller[2] = Modeller1[1];
        //                break;
        //            case 2:
        //                Modeller[2] = Modeller1[2];
        //                break;
        //        }
        //        break;

        //    case 1:
        //        switch (settings.howManyObjectsOpend)
        //        {
        //            case 0:
        //                Modeller[2] = Modeller2[0];
        //                break;
        //            case 1:
        //                Modeller[2] = Modeller2[1];
        //                break;
        //            case 2:
        //                Modeller[2] = Modeller2[2];
        //                break;
        //        }
        //        break;

        //    case 2:
        //        switch (settings.howManyObjectsOpend)
        //        {
        //            case 0:
        //                Modeller[2] = Modeller3[0];
        //                break;
        //            case 1:
        //                Modeller[2] = Modeller3[1];
        //                break;
        //            case 2:
        //                Modeller[2] = Modeller3[2];
        //                break;
        //        }
        //        break;

        //    case 3:
        //        switch (settings.howManyObjectsOpend)
        //        {
        //            case 0:
        //                Modeller[2] = Modeller3[0];
        //                break;
        //            case 1:
        //                Modeller[2] = Modeller3[1];
        //                break;
        //            case 2:
        //                Modeller[2] = Modeller3[2];
        //                break;
        //        }
        //        break;
        //}
    }


}

[System.Serializable]
public class ModelParts
{
    public GameObject TransParantHali;
    public List<GameObject> models = new List<GameObject>();
}

