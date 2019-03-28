using System.Collections;
using System.Collections.Generic;
using Rooms;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Kitchen : BaseRoom
{
    public override void Start()
    {
        base.Start();

        if (GameManager.manager != null)
            roomFacts = GameManager.manager.languageSO.GetFGMFacts;

        UpdateFacts();
    }

    public void BTN_KnowledgeBefore(string value)
    {
        AddToForm(value);
        
        showFacts = true;
        factsText.enabled = true;
    }

    public void BTN_KnowledgeAfter(string value)
    {
        AddToForm(value);
        SceneManager.LoadScene(0);
    }
}
