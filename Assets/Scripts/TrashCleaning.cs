using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrashCleaning : MonoBehaviour
{
    private TrashGenerator TG;

    public void Awake()
    {
        TG = GameObject.FindGameObjectWithTag("TrashGenerator").GetComponent<TrashGenerator>();
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Trash"))
        {
            TG.AddScore();
            Destroy(other.gameObject);
        }
    }
}
