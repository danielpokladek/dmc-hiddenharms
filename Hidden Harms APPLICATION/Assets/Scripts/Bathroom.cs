using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Rooms;

public class Bathroom : BaseRoom
{    
    public override void Start()
    {
        base.Start();
    }

    #region Quiz Buttons
    public void BTN_KnowledgeBefore(string value)
    {
        AddToForm(value);
        showFacts = true;
        beforeFactsQuiz.SetActive(false);
        factsUI.enabled = true;
    }

    public void BTN_KnowledgeAfter(string value)
    {
        AddToForm(value);
    }
    #endregion
}
