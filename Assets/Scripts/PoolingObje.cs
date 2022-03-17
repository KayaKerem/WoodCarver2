using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingObje : MonoBehaviour
{
    [SerializeField] string name;

    void Start()
    {
        Destroy(this.gameObject,1f);
        //Invoke("GeriDondur", 1f);
    }

    void GeriDondur()
    {
        ObjectifPool.singleton.ReturnModel(name, this.gameObject);
    }

}
