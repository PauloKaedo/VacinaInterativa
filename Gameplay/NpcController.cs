using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NpcController : MonoBehaviour
{
    [SerializeField] private int orderInStage;
    private QuestionObject npcQuestion;
    [SerializeField] private TMP_Text questionText;
    [SerializeField] private TMP_Text firstAnswer;
    [SerializeField] private TMP_Text secondAnswer;
    [SerializeField] private TMP_Text thirdAnswer;
    [SerializeField] private TMP_Text fouthAnswer;

    private int correctAnswerIndex;
    private GameController gameController;

    [SerializeField] private List<Button> buttons;

    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        npcQuestion = StageQuestionsLoader.allQuestions[orderInStage].Clone();
        randomAnswers();
    }

    public void openQuestion()
    {
        questionText.text = npcQuestion.question;
        firstAnswer.text = npcQuestion.answer1;
        secondAnswer.text = npcQuestion.answer2;
        thirdAnswer.text = npcQuestion.answer3;
        fouthAnswer.text = npcQuestion.answer4;
        configureButtons();
        gameController.openQuestionarie();
    }

    private void configureButtons()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].onClick.RemoveAllListeners();
        }

        for (int i = 0; i < buttons.Count; i++)
        {
            if(i == correctAnswerIndex)
                buttons[i].onClick.AddListener(delegate { gameController.correctAnswer(orderInStage); });
            else
                buttons[i].onClick.AddListener(delegate { gameController.wrongAnswer(); });
        }
    }

    public void letPlayerPass()
    {
        gameObject.SetActive(false);
    }

    private void randomAnswers()
    {
        List<string> answersArray = new List<string>();
        answersArray.Add(npcQuestion.answer1);
        answersArray.Add(npcQuestion.answer2);
        answersArray.Add(npcQuestion.answer3);
        answersArray.Add(npcQuestion.answer4);

        List<int> numbers = new List<int>();
        numbers.Add(4);

        for (int i = 0; i <= 3; i++)
        {
            while (true) 
            { 
                int randomNum = Random.Range(0, 4);
                if (!numbers.Contains(randomNum))
                {
                    if(randomNum == 0)
                    {
                        correctAnswerIndex = i;
                    }
                    switch (i)
                    {
                        case 0:
                            npcQuestion.answer1 = answersArray[randomNum];
                            break;
                        case 1:
                            npcQuestion.answer2 = answersArray[randomNum];
                            break;
                        case 2:
                            npcQuestion.answer3 = answersArray[randomNum];
                            break;
                        case 3:
                            npcQuestion.answer4 = answersArray[randomNum];
                            break;
                    }
                    numbers.Add(randomNum);
                    break;
                }
            }
        }
    }
}
