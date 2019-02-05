using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    WebForm formManager;

    [Header("Demographics UI")]
    public GameObject SelectLangScreen;
    public GameObject NationalityScreen;
    public GameObject GenderScreen;
    public GameObject AgeScreen;

    public GameObject dollHouse;
    public GameObject UI;


    private void Start()
    {
        formManager = WebForm.WebManager;

        NationalityScreen.SetActive(false);
        GenderScreen.SetActive(false);
        AgeScreen.SetActive(false);

        dollHouse.SetActive(false);
        UI.SetActive(true);
    }

    void ShowNationalityScreen()
    {
        SelectLangScreen.SetActive(false);
        HideDemoScreens();
        NationalityScreen.SetActive(true);
    }

    void ShowGenderScreen()
    {
        HideDemoScreens();
        GenderScreen.SetActive(true);
    }

    void ShowAgeScreen()
    {
        HideDemoScreens();
        AgeScreen.SetActive(true);
    }

    void HideDemoScreens()
    {
        NationalityScreen.SetActive(false);
        GenderScreen.SetActive(false);
        AgeScreen.SetActive(false);
    }

    #region Button Functions
    public void _SelectLanguage(string value)
    {
        PlayerPrefs.SetString("Language", value);
        ShowNationalityScreen();
    }

    public void _SetNationality(string value)
    {
        formManager.AddField("entry.679332033", value);
        ShowGenderScreen();
    }

    public void _SetGender(string value)
    {
        formManager.AddField("entry.200936802", value);
        ShowAgeScreen();
    }

    public void _SetAge(string value)
    {
        formManager.AddField("entry.416226614", value);
        ShowHouse();
    }

    public void _BathKnowledgeBef(string value)
    {
        formManager.AddField("entry.738434021", value);
    }

    public void _BathKnowledgAft(string value)
    {
        formManager.AddField("entry.711406450", value);
    }
    #endregion

    private void ShowHouse()
    {
        dollHouse.SetActive(true);
        UI.SetActive(false);
    }
}
