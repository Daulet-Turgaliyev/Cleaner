using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DanielLochner.Assets.SimpleScrollSnap;
public class MainMenu : MonoBehaviour
{

    public GameObject Loading;
    public GameObject SkinsObjectPanel;
    public GameObject[] SettingObjects;

    public SimpleScrollSnap ScrollSnap;

    public Text[] MenuTexts;

    private int _level;

   

    public void Awake()
    {
        _level = PlayerPrefs.GetInt("LEVEL");
    }


    public void SelectLevel_Update()
    {
        int select_level = ScrollSnap.TargetPanel + 1;
    }

    public void SelectLevel()
    {
        PlayerPrefs.SetInt("LEVEL", ScrollSnap.TargetPanel + 1);
        PlayerPrefs.Save();
        SceneManager.LoadScene(1);
    }



    public void SkinsPanel()
    {
        SkinsObjectPanel.SetActive(true);
    }

    public void SettingActive(int num)
    {
        if(SettingObjects[num].activeInHierarchy)
        {
            SettingObjects[num].SetActive(false);
        }
        else
        {
            SettingObjects[num].SetActive(true);
        }
    }
}

