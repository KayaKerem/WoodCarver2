using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    [SerializeField] GameObject Testere;
    private Collider myCollider;

    void Start()
    {
        myCollider = transform.GetComponent<Collider>();
    }


    private void OnTriggerEnter(Collider other)
    {
        TestereKapat();
    }

    private void TestereKapat()
    {
        myCollider.enabled = false;
        Testere.GetComponent<Animation>().Stop("CarkAnim");
        while (Testere.transform.localPosition.y > -2f)
        {
            Testere.transform.localPosition += new Vector3(0f, -0.5f * Time.deltaTime, 0f);
        }
        
    }

}
