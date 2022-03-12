using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Doors : MonoBehaviour
{
    //public UnityEvent<string> UpgradeModel;
    //public UnityEvent<int> IncreaseScore;

     [SerializeField] Material Color;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer(Layers.collectWood)  && gameObject.name != "4")
        {
            WoodScript wood = other.GetComponent<WoodScript>();

            wood.UpGrade(transform.gameObject.name);
        }
    }
}
