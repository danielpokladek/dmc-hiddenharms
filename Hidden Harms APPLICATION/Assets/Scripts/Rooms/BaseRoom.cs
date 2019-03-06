﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace Rooms
{
    public class BaseRoom : MonoBehaviour
    {
        [Header("Room Settings")]
        public bool sendData = false;
        public bool hasFacts = false;
        public TMP_Text factsUI;
        public string[] roomFacts;
        public float factDelay = .5f;
        public float factLength = 3f;
        public GameObject beforeFactsQuiz;
        public GameObject afterFactsQuiz;

        [HideInInspector] public bool showFacts  = false;
        private int factNo      = 0;
        private float timer     = 0;
        private WebForm webManager;

        public virtual void Start() {
            webManager = WebForm.WebManager;
            
            beforeFactsQuiz.SetActive(true);
            afterFactsQuiz.SetActive(false);
            factsUI.text = roomFacts[factNo];
            factsUI.enabled = false;
        }

        public void SendFormData(string formAddress) {

        }

        private void Update()
        {
            if (hasFacts) {
                if (showFacts) {
                    timer += Time.deltaTime;

                    if ((timer > factDelay && Input.GetMouseButtonDown(0)) ||
                        (timer > factLength))
                        NextFact();
                }
            }
        }

        private void NextFact() {
            timer = 0;
            factsUI.text = "";
            factNo++;

            if (factNo > roomFacts.Length - 1) {
                AftQuiz();
            }
            else {
                factsUI.text = roomFacts[factNo];
            }
        }

        private void AftQuiz()
        {
            factsUI.enabled = false;
            showFacts       = false;
            afterFactsQuiz.SetActive(true);
        }

        #region Button Functions
        /// <summary>
        /// Add a field to the current form.
        /// </summary>
        /// <param name="field">Name of the field, and the value. (use comma ',' to split the field name and the value).
        ///                         The field name should always come first, and value after; for example "entry.000,value".</param>
        protected void AddToForm(string field)
        {
            string[] splitParams = field.Split(',');

            // Disabled when testing the rooms. ENABLE AFTER DONE TESTING.
            if (sendData)
                webManager.AddField(splitParams[0], splitParams[1]);
            else
                return;
        }
        #endregion 
    }
}