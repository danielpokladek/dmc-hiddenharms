using System.Collections;
using System.Collections.Generic;
using Rooms;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Kitchen : BaseRoom
{
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
