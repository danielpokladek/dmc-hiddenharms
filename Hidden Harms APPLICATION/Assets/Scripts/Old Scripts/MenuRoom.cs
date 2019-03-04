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

        [HideInInspector]
        public override void Start()
        {
            //base.Start();

            NationalityScreen.SetActive(false);
            GenderScreen.SetActive(false);
            AgeScreen.SetActive(false);

            dollHouse.SetActive(false);
            UI.SetActive(true);
        }

        #region Button Functions
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

            DemographicsUI.SetActive(false);
            dollHouse.SetActive(true);
        }
        #endregion
    }
}