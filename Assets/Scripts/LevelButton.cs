using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    private Text _buttonText;
    public enum State {Complete,Open,Locked};//Статус кнопки
    private void Start()
    {
        _buttonText = gameObject.GetComponentInChildren<Text>();
    }
    public void SetLevelText(int level)
    {
        _buttonText.text = level.ToString(); //Сеттер номера уровня
    }
    public void SetButtonStatus(State status)//Установка статуса кнопки
    {
        switch (status)
        {
            case State.Complete:
                Button b = gameObject.GetComponent<Button>();
                ColorBlock cb = b.colors;
                cb.normalColor = Color.yellow;
                b.colors = cb;
                break;
            case State.Open:
                gameObject.GetComponent<Button>().interactable = true;
                break;
            case State.Locked:
                gameObject.GetComponent<Button>().interactable = false;
                break;

        }
    }
    public void clickOnButton()
    {
        SceneManager.LoadScene("Game");
    }
}
