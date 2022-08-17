using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageController : MonoBehaviour
{
    public void goToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void play(int environmentLevel)
    {
        GameManager.environmentLevel = environmentLevel;
        SceneManager.LoadScene("StageBasic");
    }
}
