using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageQuestionsLoader : MonoBehaviour
{
    public static List<QuestionObject> allQuestions;
    public static List<string> allClues;

    private int environmentLevel;

    void Awake()
    {
        GameManager gM = FindObjectOfType<GameManager>();
        
        if(gM != null)
        {
            environmentLevel = GameManager.environmentLevel;
            Destroy(gM.gameObject);
        } else
        {
            environmentLevel = 1;
        }

        DontDestroyOnLoad(this);
        allQuestions = new List<QuestionObject>();
        List<QuestionObject> questions = new List<QuestionObject>();

        if (JsonFileHandler.checkFile())
            questions = JsonFileHandler.loadFile<QuestionObject>();

        foreach(QuestionObject question in questions)
        {
            if (question.environmentLevel == environmentLevel)
                allQuestions.Add(question);
        }
        allClues = new List<string>();
        configureClues();
    }

    private void configureClues()
    {
        foreach(QuestionObject question in allQuestions)
        {
            allClues.Add(question.clue);
        }
    }
}
