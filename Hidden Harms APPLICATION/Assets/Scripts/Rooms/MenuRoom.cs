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

            //if (_gameManager.DemographicsSet == false)
            //{
            //    dollHouse.SetActive(false);
            //    UI.SetActive(true);
            //}
            //else
            //{
            //    dollHouse.SetActive(true);
            //    UI.SetActive(false);
                
            //}
        }

        public void EnableDollhouse()
        {
            dollHouse.SetActive(true);
        }
    }
}