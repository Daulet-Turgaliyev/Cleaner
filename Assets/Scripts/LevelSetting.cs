using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSetting : MonoBehaviour
{
    private GameObject SpawnPoint;
    private RectTransform RT;

    private void Start()
    {
        SpawnPoint = GameObject.FindGameObjectWithTag("Levels");
        RT = gameObject.GetComponent<RectTransform>();
        if (SpawnPoint != null)
        {
            gameObject.transform.SetParent(SpawnPoint.transform);
            gameObject.transform.SetParent(SpawnPoint.transform, false);
            gameObject.transform.localScale = new Vector3(1, 1, 1);

            RT.offsetMax = new Vector3(0, 0);
            RT.offsetMin = new Vector2(0, 0);
            RT.localPosition = new Vector3(0, 0, 0);
        }
        else { Debug.LogError("Object not found"); }
    }
}
