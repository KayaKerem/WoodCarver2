using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestRoyObje : MonoBehaviour
{

    void Start()
    {
        Invoke("GeriDondur", 1f);
    }

    void GeriDondur()
    {
        ObjectifPool.singleton.ReturnModel("Agac", this.gameObject);
    }

}
