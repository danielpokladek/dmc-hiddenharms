using UnityEngine;
using UnityEngine.SceneManagement;

public class MSQuiz : QuizController
{
    public override void ShowQuiz()
    {
        _quizQuestions[questionIterator].SetHeader(_gameManager.languageSO.MS_Questions[questionIterator]);
        _quizQuestions[questionIterator].SetAnswers(_gameManager.languageSO.MS_qOneAnswers);

        base.ShowQuiz();
    }

    public override void NextQuestion()
    {
        base.NextQuestion();

        if (questionIterator + 1 == quizQuestionsUI.Length)
        {
            // Quiz done.
            Debug.Log("Quiz complete!");
            SceneManager.LoadScene(0);
        }
        else
        {
            questionIterator++;

            _quizQuestions[questionIterator].SetHeader(_gameManager.languageSO.MS_Questions[questionIterator]);

            switch (questionIterator)
            {
                case 1:
                    _quizQuestions[questionIterator].SetAnswers(_gameManager.languageSO.MS_qTwoAnswers);
                    break;

                case 2:
                    _quizQuestions[questionIterator].SetAnswers(_gameManager.languageSO.MS_qThreeAnswers);
                    break;

                case 3:
                    _quizQuestions[questionIterator].SetAnswers(_gameManager.languageSO.MS_qFourAnswers);
                    break;

                case 4:
                    _quizQuestions[questionIterator].SetAnswers(_gameManager.languageSO.MS_qFiveAnswers);
                    break;
            }

            quizQuestionsUI[questionIterator].gameObject.SetActive(true);
        }
    }
}
