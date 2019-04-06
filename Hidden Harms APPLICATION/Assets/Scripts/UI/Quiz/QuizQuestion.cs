using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class QuizQuestion : MonoBehaviour
{
    public TMP_Text _questionHeader;
    public TMP_Text[] _questionAnswers = new TMP_Text[4];

    public void SetHeader(string value)
    {
        if (value != "")
            _questionHeader.text = value;
    }

    public void SetAnswers(string[] questionAnswers)
    {
        for (int i = 0; i < questionAnswers.Length; i++)
        {
            _questionAnswers[i].text = questionAnswers[i];
        }
    }
}
