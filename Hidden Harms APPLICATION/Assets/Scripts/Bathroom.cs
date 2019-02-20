using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Rooms;

public class Bathroom : BaseRoom
{
    public TMPro.TMP_Text[] facts;

    public GameObject BeforeQuiz;
    public GameObject AfterQuiz;
    public float factLength = 2;

    public bool nextFact;
    public bool showFacts;

    private GameObject currentFact;
    [SerializeField] private int factNo = 0;
    private float timer;
    private float currTimer;

    [HideInInspector]
    public override void Start()
    {
        base.Start();

        currTimer = factLength;
        nextFact = false;

        AfterQuiz.SetActive(false);

        foreach (TMPro.TMP_Text txt in facts)
            txt.enabled = false;
    }

    private void Update()
    {
        if (showFacts)
        {
            if (currTimer > 0)
            {
                currTimer -= Time.deltaTime;
            }
            else if (currTimer <= 0)
            {
                currTimer = factLength;
                NextFact();
            }
        }
    }

    private void NextFact()
    {   
        facts[factNo].enabled = false;
        factNo++;

        if (factNo > facts.Length - 1)
        {
            AfterQuiz.SetActive(true);
            showFacts = false;
        }
        else
        {
            facts[factNo].enabled = true;
        }
    }

    #region Quiz Buttons
    public void BTN_KnowledgeBefore(string value)
    {
        AddToForm(value);
        ShowFacts();
    }

    public void BTN_KnowledgeAfter(string value)
    {
        AddToForm(value);
        AfterQuiz.SetActive(false);
    }
    #endregion

    public void ShowFacts()
    {
        facts[factNo].enabled = true;
        
        showFacts = true;
        BeforeQuiz.SetActive(false);
    }
}
