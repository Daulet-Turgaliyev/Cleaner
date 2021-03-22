using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinChanger : MonoBehaviour
{
    public Text Descript_Text;

    public void Change(int skin_id)
    {

        switch (skin_id)
        {

            case 0:
                Descript_Text.text = "Skin One";
            break;
            case 1:
                Descript_Text.text = "Skin Two";
                break;
            case 2:
                Descript_Text.text = "Skin Three";
                break;
            case 3:
                Descript_Text.text = "Skin Four";
                break;
            case 4:
                Descript_Text.text = "Skin Five";
                break;
            default:
                Descript_Text.text = "Skin Default";
                skin_id = 0;
                break;
        }
        PlayerPrefs.SetInt("SKIN", skin_id);
        PlayerPrefs.Save();
    }

    public void PanelClose() { gameObject.SetActive(false); }

}
