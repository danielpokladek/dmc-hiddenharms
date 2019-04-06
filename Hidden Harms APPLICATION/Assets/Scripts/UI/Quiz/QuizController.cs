using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuizController : MonoBehaviour
{
    private GameManager _gameManager;
    [SerializeField] private QuizQuestion[] _quizQuestions = new QuizQuestion[5];

    public GameObject wrongAnswer;
    public GameObject[] quizQuestionsUI;
    private int questionIterator = 0;

    public string[] answersTemp = new string[4];

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

    public void InitializeQuiz()
    {

    }

    public void ShowQuiz()
    {
        _quizQuestions[questionIterator].SetHeader(_gameManager.languageSO.questions[questionIterator]);
        _quizQuestions[questionIterator].SetAnswers(_gameManager.languageSO.qOneAnswers);
        

        quizQuestionsUI[questionIterator].gameObject.SetActive(true);
    }

    private void NextQuestion()
    {
        quizQuestionsUI[questionIterator].gameObject.SetActive(false);


        if (questionIterator +1 == quizQuestionsUI.Length)
        {
            // Quiz done.
            Debug.Log("Quiz complete!");
            SceneManager.LoadScene(0);
        }
        else
        {
            questionIterator++;

            _quizQuestions[questionIterator].SetHeader(_gameManager.languageSO.questions[questionIterator]);

            quizQuestionsUI[questionIterator].gameObject.SetActive(true);
        }
    }

    public void BTN_CloseWA()
    {
        quizQuestionsUI[questionIterator].SetActive(true);
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
            quizQuestionsUI[questionIterator].SetActive(false);
            wrongAnswer.SetActive(true);

            //NextQuestion();
        }
    }
}
