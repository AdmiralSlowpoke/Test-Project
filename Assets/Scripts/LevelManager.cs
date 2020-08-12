using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject meteorPrefab;
    public Text distanceText;
    public GameObject winScreen, loseScreen;
    public AudioClip winSound, loseSound;
    private bool _meteorIsReady=true;
    private float _distance=1000;
    private AudioManagerScript sound;


    void Start()
    {
        transform.position = new Vector3(0, ScreenSizeInfo.ScreenHeight, 0);
        _distance *= PlayerPrefs.GetInt("Level");
        sound = GameObject.Find("AudioManager").GetComponent<AudioManagerScript>();
    }

    private void FixedUpdate()
    {
        _distance -= Time.fixedDeltaTime*100;
        distanceText.text = ((int)_distance).ToString();
        if (_distance <= 0)
            Win();
        if (_meteorIsReady)
        {
            GameObject a = Instantiate(meteorPrefab);
            Vector3 spawnPointPos;
            if (Random.Range(0, 100) >= 50)
            {
                spawnPointPos = new Vector3(Random.Range(0, ScreenSizeInfo.ScreenWidth), transform.position.y, 0);
            }
            else
                spawnPointPos = new Vector3(-Random.Range(0, ScreenSizeInfo.ScreenWidth), transform.position.y, 0);
            a.transform.position = spawnPointPos;
            StartCoroutine(meteorRespawnCooldown(1f));
        }
    }
    public void Win()
    {
        sound.PlaySound(winSound);
        PlayerPrefs.SetInt("CompletedLevels", PlayerPrefs.GetInt("Level"));
        PlayerPrefs.Save();
        Time.timeScale = 0f;
        winScreen.SetActive(true);
    }
    public void Lose()
    {
        sound.PlaySound(loseSound);
        Time.timeScale = 0f;
        loseScreen.SetActive(true);
    }
    IEnumerator meteorRespawnCooldown(float cooldown)
    {
        _meteorIsReady = false;
        yield return new WaitForSeconds(cooldown);
        _meteorIsReady = true;
    }
}
