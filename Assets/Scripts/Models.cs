using System.Collections.Generic;
using UnityEngine;

public class Models : MonoBehaviour
{
	[SerializeField] PlayerSettings settings;
    List<ModelParts> modelParts = new List<ModelParts>();

    public GameObject[] Modeller;
    public GameObject[] Modeller1;
    public GameObject[] Modeller2;
    public GameObject[] Modeller3;
    public GameObject[] Modeller4;
    public GameObject[] Modeller5;


    private void Start()
    {
        switch (settings.index)
        {
            case 0:

                switch (settings.howManyObjectsOpend)
                {
                    case 0:
                        Modeller[2] = Modeller1[0];
                        break;
                    case 1:
                        Modeller[2] = Modeller1[1];
                        break;
                    case 2:
                        Modeller[2] = Modeller1[2];
                        break;
                }
                break;

            case 1:
                switch (settings.howManyObjectsOpend)
                {
                    case 0:
                        Modeller[2] = Modeller2[0];
                        break;
                    case 1:
                        Modeller[2] = Modeller2[1];
                        break;
                    case 2:
                        Modeller[2] = Modeller2[2];
                        break;
                }
                break;

            case 2:
                switch (settings.howManyObjectsOpend)
                {
                    case 0:
                        Modeller[2] = Modeller3[0];
                        break;
                    case 1:
                        Modeller[2] = Modeller3[1];
                        break;
                    case 2:
                        Modeller[2] = Modeller3[2];
                        break;
                }
                break;

            case 3:
                switch (settings.howManyObjectsOpend)
                {
                    case 0:
                        Modeller[2] = Modeller3[0];
                        break;
                    case 1:
                        Modeller[2] = Modeller3[1];
                        break;
                    case 2:
                        Modeller[2] = Modeller3[2];
                        break;
                }
                break;
        }
    }


}
public class ModelParts
{
    public GameObject gameObject;
    public int sayisi;
}

