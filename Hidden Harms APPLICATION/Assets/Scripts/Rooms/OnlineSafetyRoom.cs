using UnityEngine.UI;

using Rooms;

public class OnlineSafetyRoom : BaseRoom
{
    public Image PEGI;
    public int PEGI_Fact;

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

    public override void Update()
    {
        base.Update();

        if (factIterator == PEGI_Fact)
            PEGI.enabled = true;
        else
            PEGI.enabled = false;
    }

    public override void AftQuiz()
    {
        base.AftQuiz();

        if (_gameManager != null)
            _gameManager.SetFrontroom = true;
    }
}
