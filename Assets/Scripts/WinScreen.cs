using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public void ClickOnHome()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
    public void ClickOnNext()
    {
        Time.timeScale = 1f;
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
        SceneManager.LoadScene("Game");
    }
}
