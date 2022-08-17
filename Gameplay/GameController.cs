using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private Animator correctTextAnim;
    [SerializeField] private Animator wrongTextAnim;
    [SerializeField] private GameObject questionarie;

    PlayerController playerController;

    [SerializeField] private List<GameObject> npcs;

    [SerializeField] private GameObject clueTextWindow;
    [SerializeField] private TMP_Text clueText;


    [SerializeField] private GameObject coletedCluesTextWindow;
    [SerializeField] private TMP_Text coletedCluesText;

    private List<string> cluesColleted;

    [SerializeField] private int peopleToHelp;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        cluesColleted = new List<string>();
    }

    public void correctAnswer(int npcIndex)
    {
        StartCoroutine(correctCoroutine(npcIndex));
    }

    private IEnumerator correctCoroutine(int npcIndex)
    {
        correctTextAnim.SetTrigger("answered");
        yield return new WaitForSeconds(2);
        letPlayerPass(npcIndex);
        peopleToHelp--;
        closeQuestionarie();
    }

    public void wrongAnswer()
    {
        wrongTextAnim.SetTrigger("answered");
        playerController.loseLife();
    }

    private void letPlayerPass(int npcIndex)
    {
        npcs[npcIndex].SetActive(false);
    }

    public void openQuestionarie()
    {
        questionarie.SetActive(true);
    }

    public void closeQuestionarie()
    {
        questionarie.SetActive(false);
    }

    public void gameOverScene()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void wonStage()
    {
        if(peopleToHelp == 0)
        {
            SceneManager.LoadScene("WinGame");
        } else
        {
            clueText.text = "Você ainda não respondeu todas perguntas! Esqueceu alguém?";
            clueTextWindow.SetActive(true);
        }
    }

    private void addClueToList(string clue)
    {
        cluesColleted.Add(clue);
    }

    public void collectClue(string clue)
    {
        addClueToList(clue);
        openClueText(clue);
    }

    public void openClueText(string clue)
    {
        clueText.text = clue;
        clueTextWindow.SetActive(true);
    }

    public void closeClueText()
    {
        clueTextWindow.SetActive(false);
    }

    public void openColetedClueText()
    {
        string clues = "";
        int i = 0;
        foreach(string clueText in cluesColleted)
        {
            i++;
            clues = clues + i + " - " + clueText + ". \n";
        }
        coletedCluesText.text = clues;
        coletedCluesTextWindow.SetActive(true);
    }

    public void closeColetedClueText()
    {
        coletedCluesTextWindow.SetActive(false);
    }
}
