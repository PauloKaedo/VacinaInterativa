using System.Collections.Generic;
using UnityEngine;

public class QuestionController : MonoBehaviour
{
    public static List<QuestionObject> questions;
    public static List<QuestionObject> ownQuestions;
    public static List<QuestionObject> othersQuestions;
    public static int questionIndex;
    void Start()
    {
        startPlayerPrefs();

        DontDestroyOnLoad(this);

        if (JsonFileHandler.checkFile())
            questions = JsonFileHandler.loadFile<QuestionObject>();
        else
            questions = new List<QuestionObject>();
    }

    public static void separeRegistredQuestions(string partnerCode)
    {
        ownQuestions = new List<QuestionObject>();
        othersQuestions = new List<QuestionObject>();

        foreach (QuestionObject question in questions)
        {
            if (question.partnerKey.Equals(partnerCode))
                ownQuestions.Add(question);   
            else
                othersQuestions.Add(question);
        }
    }

    private void startPlayerPrefs()
    {
        if (PlayerPrefs.HasKey("questionIndex"))
        {
            questionIndex = PlayerPrefs.GetInt("questionIndex");
        }
        else
        {
            questionIndex = 0;
            PlayerPrefs.SetInt("questionIndex", questionIndex);
        }
    }

    public static int sumIndex()
    {
        questionIndex++;
        PlayerPrefs.SetInt("questionIndex", questionIndex);
        return questionIndex;
    } 

    public static void removeQuestion(int index){
        QuestionController.questions.RemoveAt(index);
        JsonFileHandler.saveFile<QuestionObject>(QuestionController.questions);
    }

    public static void editQuestion(int index, QuestionObject edited){
        QuestionController.questions[index] = edited;
        JsonFileHandler.saveFile<QuestionObject>(QuestionController.questions);
    }
}
