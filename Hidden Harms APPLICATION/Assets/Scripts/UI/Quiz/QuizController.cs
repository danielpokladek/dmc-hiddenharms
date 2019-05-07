using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuizController : MonoBehaviour
{
    public GameObject wrongAnswer;
    public AudioClip policeSiren;
    public GameObject[] quizQuestionsUI     = new GameObject[5];
    public QuizQuestion[] _quizQuestions    = new QuizQuestion[5];

    protected GameManager _gameManager;
    protected int questionIterator = 0;

    private void Start()
    {
        _gameManager = GameManager.manager;

        wrongAnswer.SetActive(false);
        // Disable all the questions at the start.
        foreach (GameObject _obj in quizQuestionsUI)
        {
            _obj.SetActive(false);
        }
    }

    public virtual void ShowQuiz()
    {
        // Override this function, and add the first question header and answers before using base.
        // ---

        quizQuestionsUI[questionIterator].gameObject.SetActive(true);
    }

    public virtual void NextQuestion()
    {
        quizQuestionsUI[questionIterator].gameObject.SetActive(false);

        // ---
        // Override this function, and add the answers for the room.
    }

    public void BTN_CloseWA()
    {
        quizQuestionsUI[questionIterator].SetActive(true);
        wrongAnswer.SetActive(false);
        //NextQuestion();
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
            quizQuestionsUI[questionIterator].SetActive(false);
            wrongAnswer.SetActive(true);
            Camera.main.GetComponent<AudioSource>().clip = policeSiren;
            Camera.main.GetComponent<AudioSource>().Play(0);
            
            //NextQuestion();
        }
    }
}
