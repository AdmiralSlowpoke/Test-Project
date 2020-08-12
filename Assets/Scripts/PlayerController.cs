using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public SpaceShipContainer spaceShip;
    public DynamicJoystick joystick;
    public GameObject laserShot;
    public GameObject emitPosition;
    public AudioClip[] shootSounds;
    private bool _canShoot=true;
    private AudioManagerScript sound;
    private HealthBar _spaceShipHealth;

    // Update is called once per frame
    private void Start()
    {
        sound = GameObject.Find("AudioManager").GetComponent<AudioManagerScript>();
        _spaceShipHealth = GameObject.Find("HealthBar").GetComponent<HealthBar>();
    }
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 gamepadInput = new Vector3(joystick.Horizontal,joystick.Vertical,0);
        transform.position += (gamepadInput + new Vector3(x, y, 0))*spaceShip.speed*Time.deltaTime;
    }
    private void FixedUpdate()
    {
        if (_canShoot)
        {
            sound.PlaySound(shootSounds[Random.Range(0,shootSounds.Length)]);
            GameObject temp = Instantiate(laserShot);
            temp.transform.position = emitPosition.transform.position;
            StartCoroutine(ShotFired(spaceShip.shotCooldown));
        }
    }
    IEnumerator ShotFired(float cooldown)
    {
        _canShoot = false;
        yield return new WaitForSeconds(cooldown);
        _canShoot = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Meteor>() != null)
        {
            _spaceShipHealth.DoDamage();
            collision.GetComponent<Meteor>().ExplodeMeteor();
            if (_spaceShipHealth.GetHealth() == 0)
            {
                GameObject.Find("LevelManager").GetComponent<LevelManager>().Lose();
            }
        }
    }
}
