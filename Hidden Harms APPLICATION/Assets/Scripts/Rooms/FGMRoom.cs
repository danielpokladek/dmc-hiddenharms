using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Rooms;
using UnityEngine.SceneManagement;

public class FGMRoom : BaseRoom
{
    public override void Start()
    {
        base.Start();

        if (_gameManager != null)
        {
            roomFacts = _gameManager.languageSO.GetFGMFacts;
            factsText.font = _gameManager.languageSO.GetFont;
        }

        UpdateFacts();
    }

    public override void AftQuiz()
    {
        base.AftQuiz();

        if (_gameManager != null)
            _gameManager.SetBathroom = true;
    }
}
