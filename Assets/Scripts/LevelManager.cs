using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{

    public GameObject[] Levels;
    public GameObject SpawnPont_Level;
    public GameObject Loading;

    public GameObject LevelManager_Obj;
    public GameObject NextBtn;
    public GameObject CloseBtn;
    public GameObject Joystick_Canvas;

    public Text[] MenuTexts;

    public Move_Cleaner MCleaner;
    public TrashGenerator TGenerate;

    private int _level;

#if UNITY_EDITOR
    public MeshRenderer[] Borders;
    public Color[] colors;
#endif


    private void Start()
    {
        _level = PlayerPrefs.GetInt("LEVEL");

        if (_level > Levels.Length) { Debug.LogError("MaxLevel Seted"); }
        if (_level == 0) { _level++; }

        Load_Level();
    }

    private void Awake()
    {
        Loading.SetActive(true);
    }

    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape)) { ActiveMenu(0); }

#if UNITY_EDITOR


        if (Input.GetKeyDown(KeyCode.S))
        {
            SetColors();
        }

#endif

    }
#if UNITY_EDITOR

    public void SetColors() { for (int i = 0; i < Borders.Length; i++) { Borders[i].sharedMaterial.color = colors[i]; } }

#endif
    public void Load_Level()
    {

        foreach (Transform child in SpawnPont_Level.transform) Destroy(child.gameObject); // Очищаем Levels
        Instantiate(Levels[_level-1]);
        TGenerate.Start_Generate();
    }



    public void ActiveMenu(int idActive)
    {
        PauseMenu(true);
        LevelManager_Obj.SetActive(true);
        if (idActive == 0)
        {
            MenuTexts[0].text = "MainMenu";
            MenuTexts[1].text = "The game is paused";
            NextBtn.SetActive(false);
            CloseBtn.SetActive(true);
        }
        else
        {
            if (_level == Levels.Length)
            {

                MenuTexts[0].text = "Completed";
                MenuTexts[1].text = "The last level is passed";
                CloseBtn.SetActive(false);
                NextBtn.SetActive(false);

            }
            else
            {

                MenuTexts[0].text = "Win";
                MenuTexts[1].text = "Level completed";
                CloseBtn.SetActive(false);
                NextBtn.SetActive(true);

            }
        }
    }

    public void NextLevel()
    {
        if (_level < Levels.Length)
        {
            _level++;
            PlayerPrefs.SetInt("LEVEL", _level);
            SceneManager.LoadScene(1);
        }
        else { Debug.LogError("Level not found"); }

    }

    public void RestartLevel()
    {

        SceneManager.LoadScene(1);

    }
    public void PauseMenu(bool status)
    {
        if(status)
        {
            Joystick_Canvas.SetActive(false);
            MCleaner.Speed = 0;
        }
        else
        {
            Joystick_Canvas.SetActive(true);
            MCleaner.Speed = 14;
        }

    }
    public void Go_Home()
    {
        SceneManager.LoadScene(0);
    }
    public void Close_Panel()
    {
        PauseMenu(false);
        LevelManager_Obj.SetActive(false);
    }
}
