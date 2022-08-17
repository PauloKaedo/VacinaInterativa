using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int environmentLevel;

    void Start()
    {
        DontDestroyOnLoad(this);
    }
}
