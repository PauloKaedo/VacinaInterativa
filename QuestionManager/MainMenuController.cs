using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject anwserPanel, codePanel, checkPanel, sucessPanel, answerListPanel, deletePanel, deleteSucessPanel, viewPanel, editPanel, envLevel, mainMenu;

    private QuestionFormController formController;

    private void Start()
    {
        formController = FindObjectOfType<QuestionFormController>();
    }

    public void openEnvLevel()
    {
        envLevel.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void closeEnvLevel()
    {
        mainMenu.SetActive(true);
        envLevel.SetActive(false);
    }

    public void openCodePanel()
    {
        codePanel.SetActive(true);
        anwserPanel.SetActive(false);
        checkPanel.SetActive(false);
        sucessPanel.SetActive(false);
    }

    public void openAnswerList()
    {
        codePanel.SetActive(false);
        anwserPanel.SetActive(false);
        checkPanel.SetActive(false);
        sucessPanel.SetActive(false);
        answerListPanel.SetActive(true);
        sucessPanel.SetActive(false);
        deleteSucessPanel.SetActive(false);
        deletePanel.SetActive(false);
        viewPanel.SetActive(false);
        editPanel.SetActive(false);
        formController.loadQuestions();
    }

     public void openEditPanel()
    {
        codePanel.SetActive(false);
        anwserPanel.SetActive(false);
        checkPanel.SetActive(false);
        sucessPanel.SetActive(false);
        answerListPanel.SetActive(false);
        sucessPanel.SetActive(false);
        deleteSucessPanel.SetActive(false);
        deletePanel.SetActive(false);
        viewPanel.SetActive(false);
        editPanel.SetActive(true);
    }

    public void openViewList()
    {
        codePanel.SetActive(false);
        anwserPanel.SetActive(false);
        checkPanel.SetActive(false);
        sucessPanel.SetActive(false);
        answerListPanel.SetActive(false);
        sucessPanel.SetActive(false);
        deleteSucessPanel.SetActive(false);
        deletePanel.SetActive(false);
        viewPanel.SetActive(true);
        formController.loadQuestions();
    }

    public void openAnwserPanel()
    {
        codePanel.SetActive(false);
        anwserPanel.SetActive(true);
        checkPanel.SetActive(false);
        sucessPanel.SetActive(false);
        answerListPanel.SetActive(false);
    }

    public void openCheckAnwserPanel()
    {
        codePanel.SetActive(false);
        anwserPanel.SetActive(true);
        checkPanel.SetActive(true);
        sucessPanel.SetActive(false);
    }

    public void openDeleteAnwserPanel()
    {
        codePanel.SetActive(false);
        anwserPanel.SetActive(false);
        checkPanel.SetActive(false);
        deletePanel.SetActive(true);
        sucessPanel.SetActive(false);
    }

    public void closeCheckAnwserPanel()
    {
        codePanel.SetActive(false);
        anwserPanel.SetActive(true);
        checkPanel.SetActive(false);
        sucessPanel.SetActive(false);
    }

    public void closeDeleteAnwserPanel()
    {
        codePanel.SetActive(false);
        anwserPanel.SetActive(false);
        checkPanel.SetActive(false);
        deletePanel.SetActive(false);
        sucessPanel.SetActive(false);
        answerListPanel.SetActive(true);
    }

    public void openSucessPanel()
    {
        codePanel.SetActive(false);
        anwserPanel.SetActive(false);
        checkPanel.SetActive(false);
        sucessPanel.SetActive(true);
    }
    public void openDeletedSucessPanel()
    {
        codePanel.SetActive(false);
        anwserPanel.SetActive(false);
        checkPanel.SetActive(false);
        deleteSucessPanel.SetActive(true);
    }

    public void closeDeletedSucessPanel()
    {
        codePanel.SetActive(false);
        anwserPanel.SetActive(false);
        checkPanel.SetActive(false);
        deleteSucessPanel.SetActive(false);
    }

    public void closeAll()
    {
        codePanel.SetActive(false);
        anwserPanel.SetActive(false);
        checkPanel.SetActive(false);
        answerListPanel.SetActive(false);
        sucessPanel.SetActive(false);
    }
}
