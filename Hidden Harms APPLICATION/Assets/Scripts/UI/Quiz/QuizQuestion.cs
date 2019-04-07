using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class QuizQuestion : MonoBehaviour
{
    public TMP_Text _questionHeader;
    public TMP_Text[] _questionAnswers = new TMP_Text[4];

    private string[] tempArray;

    public void SetHeader(string value)
    {
        if (value != "")
        {
            _questionHeader.text = value;

            if (GameManager.manager.languageSO.UsesRTL)
            {
                _questionHeader.isRightToLeftText       = true;
                _questionHeader.alignment               = TextAlignmentOptions.Right;

                _questionHeader.font                    = GameManager.manager.languageSO.GetFont;
            }
        }
    }

    public void SetAnswers(string[] questionAnswers)
    {
        tempArray = questionAnswers;

        for (int i = 0; i < tempArray.Length; i++)
        {
            _questionAnswers[i].text = tempArray[i];

            if (GameManager.manager.languageSO.UsesRTL)
            {
                _questionAnswers[i].isRightToLeftText   = true;
                _questionAnswers[i].alignment           = TextAlignmentOptions.Right;

                _questionAnswers[i].font                = GameManager.manager.languageSO.GetFont;
            }
        }
    }
}
