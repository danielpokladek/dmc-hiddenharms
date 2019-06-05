using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using TMPro;

namespace Rooms
{
    [RequireComponent(typeof(QuizController))]
    public class BaseRoom : MonoBehaviour
    {
        // References to managers & controllers.
        // They have to be public in order to be used by other scritps,
        //  but they are assigned automatically by script so they are hidden.
        [HideInInspector] public QuizController _quizController;
        [HideInInspector] public GameManager _gameManager;
        [HideInInspector] public WebForm _webManager;

        // Properties
        [Header("Room Settings")]
        public bool sendData = false;
        public bool hasFacts = false;
        public RTLTMPro.RTLTextMeshPro factsText;
        public GameObject factsUI;
        public string[] roomFacts;
        public float factDelay = .5f;
        public float factLength = 3f;
        public Button nextFactButton;

        [HideInInspector] public bool showFacts  = false;
        private int factIterator    = 0;
        private float timer         = 0;

        public void BTN_NextFact()
        {
            _quizController = GetComponent<QuizController>();

            NextFact();
        }

        public virtual void Start() {
            _webManager = WebForm.WebManager;
            _gameManager = GameManager.manager;

            if (_gameManager.languageSO.UsesRTL)
            {
                Debug.Log("Uses RTL");

                factsText.isRightToLeftText = true;
                factsText.alignment = TextAlignmentOptions.Right;
            }

            nextFactButton.interactable = false;
            factsText.text = roomFacts[factIterator];
            factsText.enabled = true;
            showFacts = true;
        }

        public void SendFormData(string formAddress) {

        }

        public void UpdateFacts()
        {
            factsText.text = roomFacts[factIterator];
        }

        private void Update()
        {
            if (hasFacts) {
                if (showFacts) {
                    timer += Time.deltaTime;

                    if ((timer > factDelay && Input.GetMouseButtonDown(0)) ||
                        (timer > factLength))
                        nextFactButton.interactable = true;
                }
            }
        }

        private void NextFact() {
            timer = 0;
            factsText.text = "";
            factIterator++;

            if (factIterator > roomFacts.Length - 1) {
                AftQuiz();
            }
            else {
                factsText.text = roomFacts[factIterator];
                nextFactButton.interactable = false;
            }
        }

        public virtual void AftQuiz()
        {
            factsUI.SetActive(false);
            _quizController.ShowQuiz();

            //factsUI.enabled = false;
            //showFacts       = false;
            //afterFactsQuiz.SetActive(true);
            //SceneManager.LoadScene(0);
        }

        #region Button Functions
        /// <summary>
        /// Add a field to the current form.
        /// </summary>
        /// <param name="field">Name of the field, and the value. (use comma ',' to split the field name and the value).
        ///                         The field name should always come first, and value after; for example "entry.000,value".</param>
        public void AddToForm(string field)
        {
            _webManager = WebForm.WebManager;

            string[] splitParams = field.Split(',');

            // Disabled when testing the rooms. ENABLE AFTER DONE TESTING.
            if (sendData)
                _webManager.AddField(splitParams[0], splitParams[1]);
            else
                return;
        }
        #endregion 
    }
}
