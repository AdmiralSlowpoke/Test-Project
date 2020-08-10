using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed=15f;
    public DynamicJoystick joystick;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 gamepadInput = new Vector3(joystick.Horizontal,joystick.Vertical,0);
        transform.position += (gamepadInput + new Vector3(x, y, 0))*speed*Time.deltaTime;
    }
}
