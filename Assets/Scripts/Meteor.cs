using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public float meteorSpeed = 5f;
    public float rotationSpeed = 3f;
    private GameObject _sprite;
    private void Start()
    {
        _sprite = transform.GetChild(0).gameObject;
    }
    private void FixedUpdate()
    {
        transform.position += new Vector3(0, -meteorSpeed, 0)*Time.fixedDeltaTime;
        _sprite.transform.rotation = Quaternion.Euler(0, 0, _sprite.transform.rotation.eulerAngles.z + rotationSpeed);
        if (transform.position.y <= -ScreenSizeInfo.ScreenHeight)
            Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<LaserShot>() != null)
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
