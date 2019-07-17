using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using Rooms;
using TMPro;

public class DomesticAbuseRoom : BaseRoom
{
    public override void Start()
    {
        base.Start();

        if (_gameManager != null)
        {
            roomFacts = _gameManager.languageSO.GetDAFacts;
            factsText.font = _gameManager.languageSO.GetFont;
        }

        UpdateFacts();
    }

    public override void AftQuiz()
    {
        base.AftQuiz();

        if (_gameManager != null)
            _gameManager.SetKitchen = true;
    }
}
