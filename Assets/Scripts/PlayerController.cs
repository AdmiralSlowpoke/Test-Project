using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed=15f;
    public float shotCooldown = 0.3f;
    public DynamicJoystick joystick;
    public GameObject laserShot;
    public GameObject emitPosition;
    private bool _canShoot=true;

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 gamepadInput = new Vector3(joystick.Horizontal,joystick.Vertical,0);
        transform.position += (gamepadInput + new Vector3(x, y, 0))*speed*Time.deltaTime;
    }
    private void FixedUpdate()
    {
        if (_canShoot)
        {
            GameObject temp = Instantiate(laserShot);
            temp.transform.position = emitPosition.transform.position;
            StartCoroutine(shotFired(shotCooldown));
        }
    }
    IEnumerator shotFired(float cooldown)
    {
        _canShoot = false;
        yield return new WaitForSeconds(cooldown);
        _canShoot = true;
    }
}
