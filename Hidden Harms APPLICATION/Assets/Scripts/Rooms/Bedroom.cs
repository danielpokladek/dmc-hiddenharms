﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using Rooms;
using TMPro;

public class Bedroom : BaseRoom
{
    public override void Start()
    {
        base.Start();

        if (_gameManager != null)
        {
            if (_gameManager.languageSO.UsesRTL)
            {
                factsText.isRightToLeftText = true;
                factsText.alignment = TMPro.TextAlignmentOptions.Right;
            }
            
            roomFacts = _gameManager.languageSO.GetDAFacts;
            factsText.font = _gameManager.languageSO.GetFont;
        }

        UpdateFacts();
    }

    public override void AftQuiz()
    {
        base.AftQuiz();

        if (_gameManager != null)
            _gameManager.SetBedroom = true;
    }
}
