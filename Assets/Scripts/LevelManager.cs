using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject meteorPrefab;
    private bool _meteorIsReady=true;
        
    void Start()
    {
        transform.position = new Vector3(0, ScreenSizeInfo.ScreenHeight, 0);
    }

    private void FixedUpdate()
    {
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
    IEnumerator meteorRespawnCooldown(float cooldown)
    {
        _meteorIsReady = false;
        yield return new WaitForSeconds(cooldown);
        _meteorIsReady = true;
    }
}
