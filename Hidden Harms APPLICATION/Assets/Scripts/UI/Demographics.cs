using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Rooms;

public class Demographics : MonoBehaviour
{
    [Header("UI Objects")]
    public GameObject UI_selectLang;
    public GameObject UI_selectNat;
    public GameObject UI_selectGend;
    public GameObject UI_selectAge;
    public GameObject UI_demographics;

    [Header("Scripts")]
    public MenuRoom menuRoom;

    private GameManager _gameManager;

    void Start()
    {
        // Disable all UI elements before showing the demo UI.
        UI_selectLang.SetActive(false);
        UI_selectNat.SetActive(false);
        UI_selectGend.SetActive(false);
        UI_selectAge.SetActive(false);


        if (GameManager.manager != null)
            _gameManager = GameManager.manager;
        else
            Debug.LogError("No manager found. Check that the game manager is attached to a gameobject.");

        if (_gameManager.DemographicsSet)
            SkipDemographics();
        else
            DemographicsMenu();
    }

    public void DemographicsMenu()
    {
        UI_demographics.SetActive(true);
        UI_selectLang.SetActive(true);
    }

    private void SkipDemographics()
    {
        // The demographics have previously been recorded.
        // Skip the demographics questionnaire.
        UI_demographics.SetActive(false);
        menuRoom.EnableDollhouse();
    }

    // Update is called once per frame
    void Update()
    {

    }

    #region Button Functions
    public void BTN_SetLanguage(string value)
    {
        menuRoom.AddToForm(value);

        UI_selectLang.SetActive(false);
        UI_selectNat.SetActive(true);

        Debug.Log("Set Language");
    }

    public void BTN_SetNationality(string value)
    {
        menuRoom.AddToForm(value);

        UI_selectNat.SetActive(false);
        UI_selectGend.SetActive(true);

        Debug.Log("Set Nationality");
    }

    public void BTN_SetGender(string value)
    {
        menuRoom.AddToForm(value);

        UI_selectGend.SetActive(false);
        UI_selectAge.SetActive(true);

        Debug.Log("Set Gender");
    }

    public void BTN_SetAge(string value)
    {
        menuRoom.AddToForm(value);

        UI_selectAge.SetActive(false);
        UI_demographics.SetActive(false);
        _gameManager.DemographicsSet = true;

        menuRoom.EnableDollhouse();
    }
    #endregion
}
