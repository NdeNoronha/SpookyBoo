using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;


    private void Start()
    {
        text.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
    }
    public void ChangeSceneGame()
    {
        SceneManager.LoadScene(1);
    }

    public static void ChangeSceneMenu()
    {
        SceneManager.LoadScene(0);
    }
}
