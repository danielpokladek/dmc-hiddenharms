﻿using System.Collections;
using System.Collections.Generic;
using Rooms;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bedroom : BaseRoom
{
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
