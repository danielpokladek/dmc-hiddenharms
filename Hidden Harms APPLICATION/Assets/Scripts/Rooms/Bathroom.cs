using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Rooms;
using UnityEngine.SceneManagement;

public class Bathroom : BaseRoom
{    
    public override void Start()
    {
        base.Start();
    }

    public void BTN_KnowledgeBefore(string value)
    {
        AddToForm(value);
        beforeFactsQuiz.SetActive(false);
        
        showFacts = true;
        factsUI.enabled = true;
    }

    public void BTN_KnowledgeAfter(string value)
    {
        AddToForm(value);
        afterFactsQuiz.SetActive(false);
        SceneManager.LoadScene(0);
    }
}
