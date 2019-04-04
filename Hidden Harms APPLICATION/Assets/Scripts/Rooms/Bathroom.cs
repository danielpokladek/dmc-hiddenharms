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

        if (GameManager.manager != null)
        {
            roomFacts = GameManager.manager.languageSO.GetFGMFacts;
            factsText.font = GameManager.manager.languageSO.GetFont;
        }

        UpdateFacts();
    }

    public override void AftQuiz()
    {
        base.AftQuiz();

        if (GameManager.manager != null)
            GameManager.manager.SetBathroom = true;
    }
}
