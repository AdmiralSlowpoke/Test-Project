using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    public Level level;
    private Text _buttonText;

    private void Start()
    {
        _buttonText = gameObject.GetComponentInChildren<Text>();
        SetLevelText(level.levelText);
        if(Int32.Parse(level.levelText)> PlayerPrefs.GetInt("CompletedLevels"))
            SetButtonStatus(Level.State.Locked);
        if (Int32.Parse(level.levelText) == PlayerPrefs.GetInt("CompletedLevels")+1)
            SetButtonStatus(Level.State.Open);
        if(Int32.Parse(level.levelText) <= PlayerPrefs.GetInt("CompletedLevels"))
            SetButtonStatus(Level.State.Complete);

    }
    public void SetLevelText(string level)
    {
        _buttonText.text = level; //Сеттер номера уровня
    }
    public void SetButtonStatus(Level.State status)//Установка статуса кнопки
    {
        switch (status)
        {
            case Level.State.Complete:
                Button b = gameObject.GetComponent<Button>();
                ColorBlock cb = b.colors;
                cb.normalColor = Color.yellow;
                b.colors = cb;
                break;
            case Level.State.Open:
                gameObject.GetComponent<Button>().interactable = true;
                break;
            case Level.State.Locked:
                gameObject.GetComponent<Button>().interactable = false;
                break;

        }
    }
    public void clickOnButton()
    {
        PlayerPrefs.SetInt("Level", Int32.Parse(level.levelText));
        SceneManager.LoadScene("Game");
    }
}
