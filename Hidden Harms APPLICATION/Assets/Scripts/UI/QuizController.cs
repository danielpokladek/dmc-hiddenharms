using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuizController : MonoBehaviour
{
    public GameObject wrongAnswer;
    public GameObject[] quizQuestions;
    private int questionIterator = 0;
    

    private void Start()
    {
        wrongAnswer.SetActive(false);
        // Disable all the questions at the start.
        foreach (GameObject _obj in quizQuestions)
        {
            _obj.SetActive(false);
        }
    }

    private void Update()
    {
        
    }

    public void ShowQuiz()
    {
        quizQuestions[questionIterator].gameObject.SetActive(true);
    }

    private void NextQuestion()
    {
        quizQuestions[questionIterator].gameObject.SetActive(false);

        if (questionIterator +1 == quizQuestions.Length)
        {
            // Quiz done.
            Debug.Log("Quiz complete!");
            SceneManager.LoadScene(0);
        }
        else
        {
            questionIterator++;
            quizQuestions[questionIterator].gameObject.SetActive(true);
        }
    }

    public void BTN_CloseWA()
    {
        quizQuestions[questionIterator].SetActive(true);
        wrongAnswer.SetActive(false);
        NextQuestion();
    }

    public void BTN_QuestionAnswer(bool isCorrect)
    {
        if (isCorrect)
        {
            // Selected answer is correct.
            Debug.Log("Correct Answer!");

            NextQuestion();
        }

        if (!isCorrect)
        {
            // Incorrect answer.
            // Show the animation, and go to next question.
            Debug.Log("Incorrect answer!");
            quizQuestions[questionIterator].SetActive(false);
            wrongAnswer.SetActive(true);

            //NextQuestion();
        }
    }
}
