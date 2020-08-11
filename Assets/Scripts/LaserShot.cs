using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShot : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private void FixedUpdate()
    {
        transform.position += new Vector3(0, speed, 0) * Time.fixedDeltaTime;
        if (transform.position.y >= ScreenSizeInfo.ScreenHeight)
            Destroy(this.gameObject);
    }
}
