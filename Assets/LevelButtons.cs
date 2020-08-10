using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelButtons : MonoBehaviour
{
    private void Start()
    {
        Initialize();
    }
    public void Initialize()//Метод который задаст номер уровня кнопкам
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if(transform.GetChild(i).GetComponent<LevelButton>()!=null)//Защита если мы случайно засунем в объект не кнопку уровня
            transform.GetChild(i).GetComponent<LevelButton>().SetLevelText(i + 1);
            transform.GetChild(i).GetComponent<LevelButton>().SetButtonStatus(LevelButton.State.Complete);
        }
    }
}
