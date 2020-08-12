using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public MeteorContainer meteor;
    public GameObject explosion;
    public AudioClip explosionSound;
    private GameObject _sprite;
    private AudioManagerScript sound;
    private void Start()
    {
        _sprite = transform.GetChild(0).gameObject;
        sound = GameObject.Find("AudioManager").GetComponent<AudioManagerScript>();
    }
    private void FixedUpdate()
    {
        transform.position += new Vector3(0, -meteor.speed, 0)*Time.fixedDeltaTime;
        _sprite.transform.rotation = Quaternion.Euler(0, 0, _sprite.transform.rotation.eulerAngles.z + meteor.rotationSpeed);
        if (transform.position.y <= -ScreenSizeInfo.ScreenHeight)
            Destroy(this.gameObject);
    }
    public void ExplodeMeteor()
    {
        GameObject temp = Instantiate(explosion);
        temp.transform.position = transform.position;
        sound.PlaySound(explosionSound);
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<LaserShot>() != null)
        {
            ExplodeMeteor();
            Destroy(collision.gameObject);
            
        }
    }
}
