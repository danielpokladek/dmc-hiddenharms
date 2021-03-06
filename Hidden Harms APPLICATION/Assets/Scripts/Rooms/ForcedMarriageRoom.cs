﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Rooms;

public class ForcedMarriageRoom : BaseRoom
{
    public override void Start()
    {
        base.Start();

        if (GameManager.manager != null)
        {
            roomFacts = GameManager.manager.languageSO.GetFMFacts;
            factsText.font = GameManager.manager.languageSO.GetFont;
        }

        UpdateFacts();
    }

    public override void AftQuiz()
    {
        base.AftQuiz();

        if (GameManager.manager != null)
            GameManager.manager.SetBedroom = true;
    }

}
