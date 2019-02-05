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

    float timer;
    public float currTimer;

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
                nextFact = true;
            }

            foreach (TMPro.TMP_Text txt in facts)
            {
                txt.enabled = true;

                if (nextFact)
                {
                    txt.enabled = false;
                    nextFact = false;
                }
                else
                {
                    return;
                }
            }
        }
    }

    public void _SetQuizBef(string value)
    {
        formManager.AddField("test", value);
        _ShowFacts();
    }

    public void _ShowFacts()
    {
        BeforeQuiz.SetActive(false);
        showFacts = true;
    }

    public void _ShowQuizAft()
    {

    }

    IEnumerator Facts()
    {


        yield break;
    }
}
