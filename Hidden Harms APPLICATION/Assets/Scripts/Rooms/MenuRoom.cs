using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        public GameObject FinalQuestUI;

        public Demographics _demoScript;
        public Camera _animCamera;

        public GameObject dollHouse;
        public GameObject UI;
        
        [HideInInspector]
        public override void Start()
        {
            _gameManager = GameManager.manager;

            DemographicsUI.SetActive(false);
            FinalQuestUI.SetActive(false);

            NationalityScreen.SetActive(false);
            GenderScreen.SetActive(false);
            AgeScreen.SetActive(false);

            if (_gameManager.DemographicsSet)
            {
                _demoScript.SkipDemographics();
                _animCamera.gameObject.SetActive(false);
            }

            if (_gameManager.CheckStatus())
            {
                ShowFinalQuest();
            }
        }

        public void ShowInterrior()
        {
            dollHouse.SetActive(true);
        }

        private void ShowFinalQuest()
        {
            FinalQuestUI.SetActive(true);
        }

        public void BTN_FinalQuest(string value)
        {
            AddToForm(value);
            WebForm.WebManager._SendForm();
            SceneManager.LoadScene(5);
        }
    }
}