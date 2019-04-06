using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Rooms;

public class FrontRoom : BaseRoom
{
    public override void Start()
    {
        base.Start();

        if (_gameManager != null)
        {
            roomFacts = _gameManager.languageSO.GetONSFacts;
            factsText.font = _gameManager.languageSO.GetFont;
        }

        UpdateFacts();
    }

    public override void AftQuiz()
    {
        base.AftQuiz();

        if (_gameManager != null)
            _gameManager.SetFrontroom = true;
    }
}
