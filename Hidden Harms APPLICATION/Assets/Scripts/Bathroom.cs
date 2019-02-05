using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bathroom : MonoBehaviour
{
    WebForm formManager;

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

    private void Start()
    {
        currTimer = factLength;
        nextFact = false;

        foreach (TMPro.TMP_Text txt in facts)
            txt.enabled = false;

        formManager = WebForm.WebManager;
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
            _ShowQuizAft();
            showFacts = false;
        }
        else
        {
            facts[factNo].enabled = true;
        }
    }

    public void _SetQuizBef(string value)
    {
        formManager.AddField("test", value);
        _ShowFacts();
    }

    public void _ShowFacts()
    {
        facts[factNo].enabled = true;
        
        showFacts = true;
        BeforeQuiz.SetActive(false);
    }

    public void _ShowQuizAft()
    {
        AfterQuiz.SetActive(true);
    }

    IEnumerator Facts()
    {


        yield break;
    }
}
