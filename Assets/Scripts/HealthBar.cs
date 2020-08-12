using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    private List<GameObject> _healthObject=new List<GameObject>();
    private int _health;
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
            _healthObject.Add(transform.GetChild(i).gameObject);
        _health = _healthObject.Count;
    }
    public int GetHealth()
    {
        return _health;
    }
    public void DoDamage()
    {
        _healthObject[_healthObject.Count - 1].SetActive(false);
        _healthObject.RemoveAt(_healthObject.Count - 1);
        --_health;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            DoDamage();
        }
    }
}
