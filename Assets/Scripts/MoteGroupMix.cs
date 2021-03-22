using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoteGroupMix : MonoBehaviour
{
    void Start()
    {
        Transform[] children = GetComponentsInChildren<Transform>();
        for (int i = 1 /*0*/; i < children.Length; i++)
        {
            children[i].localPosition = new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), Random.Range(-2f, 2f));
            children[i].localScale = new Vector3(Random.Range(.5f, 2f), Random.Range(.5f, 2f), Random.Range(.5f, 2f));
        }
    }

}