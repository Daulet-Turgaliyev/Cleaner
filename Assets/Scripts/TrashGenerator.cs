using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TrashGenerator : MonoBehaviour
{
    private GameObject WinObject;
    GameObject[] TrashAll;

    private int _trash_counter;

    public Slider Score_Slider;
    public GameObject Loading;



    [SerializeField] private Vector3 _startVector;

    private int _count;

    private void Awake()
    {
        WinObject = GameObject.FindGameObjectWithTag("LevelManager");
    }

    public void Start_Generate()
    {
        TrashAll = GameObject.FindGameObjectsWithTag("Trash");
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(1);
        Score_Slider.maxValue = TrashAll.Length - Score_Slider.value;
        Score_Slider.value = 0;
        Loading.SetActive(false);
    }


    public void AddScore()
    {

        if(Score_Slider.value >= Score_Slider.maxValue-1){ WinObject.GetComponent<LevelManager>().ActiveMenu(1); }
        else {
            Score_Slider.value++;
        }
        
    }

}
