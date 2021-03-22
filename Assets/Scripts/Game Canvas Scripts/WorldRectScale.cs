using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 

[ExecuteInEditMode]
public class WorldRectScale : MonoBehaviour
{
    private RectTransform _parent;



    [SerializeField] private bool _OsX, _OsY;

    private void Awake()
    {
        _parent = (RectTransform)transform.parent;
    }

    private void Start()
    {
        Update_View();
    }

    private void Update_View()
    {
        if(_parent == null) { Awake(); }

        Vector3 scale = Vector3.one;

        if(_OsX) {

            scale.x = _parent.rect.width+150;

        }

        if (_OsY)
        {

            scale.y = _parent.rect.height+150;

        }

        transform.localScale = scale;
    }


#if UNITY_EDITOR
    private void Update()
    {
        Update_View();
    }
#endif



}
