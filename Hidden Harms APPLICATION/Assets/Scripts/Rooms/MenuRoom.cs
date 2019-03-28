using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rooms
{
    public class MenuRoom : BaseRoom
    {
        [Header("Demographics UI")]
        public GameObject SelectLangScreen;
        public GameObject NationalityScreen;
        public GameObject GenderScreen;
        public GameObject AgeScreen;

        public GameObject DemographicsUI;

        public GameObject dollHouse;
        public GameObject UI;

        private GameManager _gameManager;
        
        [HideInInspector]
        public override void Start()
        {
            _gameManager = GameManager.manager;
            
            NationalityScreen.SetActive(false);
            GenderScreen.SetActive(false);
            AgeScreen.SetActive(false);

            if (_gameManager.DemographicsSet == false)
            {
                dollHouse.SetActive(false);
                UI.SetActive(true);
            }
            else
            {
                dollHouse.SetActive(true);
                UI.SetActive(false);
                
            }
        }

        #region Button Functions
        public void _SETLANGUAGE(Language_SO language)
        {
            if (GameManager.manager != null)
                GameManager.manager.languageSO = language;
        }

        public void BTN_SelectLanguage(string value)
        {
            AddToForm(value);

            SelectLangScreen.SetActive(false);
            NationalityScreen.SetActive(true);
        }

        public void BTN_SetNationality(string value)
        {
            AddToForm(value);

            NationalityScreen.SetActive(false);
            GenderScreen.SetActive(true);
        }

        public void BTN_SetGender(string value)
        {
            AddToForm(value);

            GenderScreen.SetActive(false);
            AgeScreen.SetActive(true);
        }

        public void BTN_SetAge(string value)
        {
            AddToForm(value);

            _gameManager.DemographicsSet = true;
            DemographicsUI.SetActive(false);
            dollHouse.SetActive(true);
        }
        #endregion
    }
}