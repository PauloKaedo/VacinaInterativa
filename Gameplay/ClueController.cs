using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueController : MonoBehaviour
{
    [SerializeField] private int clueIndex;

    private string clue;
    void Start()
    {
        clue = StageQuestionsLoader.allClues[clueIndex];
    }

    public void collectClue()
    {
        FindObjectOfType<GameController>().collectClue(clue);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collectClue();
        }
    }
}
